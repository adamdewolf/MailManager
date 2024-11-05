// Decompiled with JetBrains decompiler
// Type: Game.Modding.Toolchain.Dependencies.UnityModProjectDependency
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using CliWrap;
using CliWrap.EventStream;
using Colossal;
using Colossal.IO;
using Colossal.Json;
using Colossal.PSI.Environment;
using Colossal.Win32;
using Game.UI.Localization;
using Mono.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace Game.Modding.Toolchain.Dependencies
{
  public class UnityModProjectDependency : BaseDependency
  {
    public const string kProjectName = "UnityModsProject";

    public static string projectUnzipPath => EnvPath.kUserToolingPath + "/UnityModsProject";

    public static string projectZipPath => EnvPath.kGameToolingPath + "/UnityModsProject.zip";

    public static string modProjectsUnityVersionPath
    {
      get => UnityModProjectDependency.projectUnzipPath + "/ProjectSettings/ProjectVersion.txt";
    }

    public static string projectSettingsAsset => "ProjectSettings/ProjectSettings.asset";

    public static string modProjectsVersionPath
    {
      get
      {
        return UnityModProjectDependency.projectUnzipPath + "/" + UnityModProjectDependency.projectSettingsAsset;
      }
    }

    public static string projectPackageManifest => "Packages/manifest.json";

    public static string projectPackageLock => "Packages/packages-lock.json";

    public static string modProjectPackages
    {
      get
      {
        return UnityModProjectDependency.projectUnzipPath + "/" + UnityModProjectDependency.projectPackageLock;
      }
    }

    public static bool isUnityOpened
    {
      get
      {
        return UnityModProjectDependency.IsUnityOpenWithModsProject(UnityModProjectDependency.projectUnzipPath);
      }
    }

    public override string name => "Unity Mod Project";

    public override string icon => "Media/Menu/ColossalLogo.svg";

    public override string version
    {
      get
      {
        if (LongFile.Exists(UnityModProjectDependency.modProjectsVersionPath) && base.version == null)
          this.version = UnityModProjectDependency.ReadYAMLVersion((IEnumerable<string>) LongFile.ReadAllLines(UnityModProjectDependency.modProjectsVersionPath)).shortVersion;
        return base.version;
      }
      protected set => base.version = value;
    }

    public override IEnumerable<string> envVariables
    {
      get
      {
        yield return "CSII_PATHSET";
        yield return "CSII_UNITYMODPROJECTPATH";
        yield return "CSII_UNITYVERSION";
        yield return "CSII_ENTITIESVERSION";
        yield return "CSII_ASSEMBLYSEARCHPATH";
      }
    }

    public override Type[] dependsOnInstallation
    {
      get
      {
        return new Type[2]
        {
          typeof (UnityDependency),
          typeof (UnityLicenseDependency)
        };
      }
    }

    public override LocalizedString installDescr
    {
      get => LocalizedString.Id("Options.WARN_TOOLCHAIN_INSTALL_MOD_PROJECT");
    }

    public override Task<bool> IsInstalled(CancellationToken token)
    {
      return Task.FromResult<bool>(LongDirectory.Exists(UnityModProjectDependency.projectUnzipPath + "/Library") && LongFile.Exists(UnityModProjectDependency.modProjectsUnityVersionPath));
    }

    public override Task<bool> IsUpToDate(CancellationToken token)
    {
      try
      {
        Colossal.Version version1 = UnityModProjectDependency.ReadUnityProjectVersion(UnityModProjectDependency.modProjectsUnityVersionPath);
        Colossal.Version version2 = new Colossal.Version(UnityDependency.sUnityVersion);
        Colossal.Version version3 = UnityModProjectDependency.ReadYAMLVersion((IEnumerable<string>) LongFile.ReadAllLines(UnityModProjectDependency.modProjectsVersionPath));
        Colossal.Version version4 = UnityModProjectDependency.ReadYAMLVersion(ZipUtilities.ExtractAllLines(UnityModProjectDependency.projectZipPath, UnityModProjectDependency.projectSettingsAsset));
        Colossal.Version version5 = version2;
        if (version1 < version5 || version3 < version4)
          return Task.FromResult<bool>(false);
        if (!LongFile.Exists(UnityModProjectDependency.modProjectPackages))
          return Task.FromResult<bool>(false);
        Colossal.Json.Variant variant1 = JSON.Load(LongFile.ReadAllText(UnityModProjectDependency.modProjectPackages));
        Colossal.Json.Variant variant2 = JSON.Load(ZipUtilities.ExtractAllText(UnityModProjectDependency.projectZipPath, UnityModProjectDependency.projectPackageManifest));
        ProxyObject proxyObject1 = variant1.TryGet("dependencies") as ProxyObject;
        ProxyObject proxyObject2 = variant2.TryGet("dependencies") as ProxyObject;
        if (proxyObject1 == null || proxyObject2 == null)
          return Task.FromResult<bool>(false);
        foreach (KeyValuePair<string, Colossal.Json.Variant> keyValuePair in (IEnumerable<KeyValuePair<string, Colossal.Json.Variant>>) proxyObject2)
        {
          Colossal.Json.Variant variant3;
          if (!proxyObject1.TryGetValue(keyValuePair.Key, out variant3))
            return Task.FromResult<bool>(false);
          if (!(variant3 is ProxyObject proxyObject3))
            return Task.FromResult<bool>(false);
          Colossal.Json.Variant variant4;
          if (!proxyObject3.TryGetValue("version", out variant4) || !variant4.Equals(keyValuePair.Value))
            return Task.FromResult<bool>(false);
        }
        return Task.FromResult<bool>(true);
      }
      catch (Exception ex)
      {
        IToolchainDependency.log.Error(ex, (object) "Error during up-to-date check");
        return Task.FromResult<bool>(false);
      }
    }

    public override Task<bool> NeedDownload(CancellationToken token)
    {
      return Task.FromResult<bool>(false);
    }

    public override Task Download(CancellationToken token) => Task.CompletedTask;

    public override async Task Install(CancellationToken token)
    {
      UnityModProjectDependency source = this;
      token.ThrowIfCancellationRequested();
      string zipPath = UnityModProjectDependency.projectZipPath;
      string unzipPath = UnityModProjectDependency.projectUnzipPath;
      try
      {
        if (UnityModProjectDependency.isUnityOpened)
        {
          IToolchainDependency.log.Debug((object) "Waiting for close Unity");
          // ISSUE: explicit non-virtual call
          __nonvirtual (source.state) = new IToolchainDependency.State(DependencyState.Installing, "WaitingUnityClose");
          await AsyncUtils.WaitForAction((Func<bool>) (() => !UnityModProjectDependency.isUnityOpened), token).ConfigureAwait(false);
        }
        token.ThrowIfCancellationRequested();
        IToolchainDependency.log.DebugFormat("Deploy Mods project from '{0}' to '{1}'", (object) zipPath, (object) unzipPath);
        // ISSUE: explicit non-virtual call
        __nonvirtual (source.state) = new IToolchainDependency.State(DependencyState.Installing, "InstallingModProject");
        if (LongDirectory.Exists(unzipPath))
          await AsyncUtils.DeleteDirectoryAsync(unzipPath, true, token).ConfigureAwait(false);
        await Task.Run((Action) (() => ZipUtilities.Unzip(zipPath, unzipPath)), token).ConfigureAwait(false);
        IToolchainDependency.log.DebugFormat("Launching Unity ({0})", (object) UnityDependency.unityExe);
        await foreach (CommandEvent commandEvent in TaskAsyncEnumerableExtensions.ConfigureAwait<CommandEvent>(Cli.Wrap(UnityDependency.unityExe).WithArguments((IEnumerable<string>) new string[5]
        {
          "-projectPath",
          unzipPath,
          "-logFile",
          "-",
          "-quit"
        }).ListenAsync(token), false))
        {
          switch (commandEvent)
          {
            case StandardOutputCommandEvent outputCommandEvent:
              IToolchainDependency.log.Debug((object) outputCommandEvent.Text);
              continue;
            case StandardErrorCommandEvent errorCommandEvent:
              IToolchainDependency.log.Error((object) errorCommandEvent.Text);
              continue;
            default:
              continue;
          }
        }
      }
      catch (OperationCanceledException ex)
      {
        throw;
      }
      catch (ToolchainException ex)
      {
        throw;
      }
      catch (Exception ex)
      {
        throw new ToolchainException(ToolchainError.Install, (IToolchainDependency) source, ex);
      }
    }

    public override async Task Uninstall(CancellationToken token)
    {
      UnityModProjectDependency source = this;
      token.ThrowIfCancellationRequested();
      try
      {
        IToolchainDependency.log.Debug((object) "Deleting Mods project");
        // ISSUE: explicit non-virtual call
        __nonvirtual (source.state) = new IToolchainDependency.State(DependencyState.Installing, "RemovingModProject");
        string projectUnzipPath = UnityModProjectDependency.projectUnzipPath;
        if (!LongDirectory.Exists(projectUnzipPath))
          return;
        await AsyncUtils.DeleteDirectoryAsync(projectUnzipPath, true, token).ConfigureAwait(false);
      }
      catch (OperationCanceledException ex)
      {
        throw;
      }
      catch (ToolchainException ex)
      {
        throw;
      }
      catch (Exception ex)
      {
        throw new ToolchainException(ToolchainError.Uninstall, (IToolchainDependency) source, ex);
      }
    }

    public override Task<List<IToolchainDependency.DiskSpaceRequirements>> GetRequiredDiskSpace(
      CancellationToken token)
    {
      return Task.FromResult<List<IToolchainDependency.DiskSpaceRequirements>>(new List<IToolchainDependency.DiskSpaceRequirements>()
      {
        new IToolchainDependency.DiskSpaceRequirements()
        {
          m_Path = UnityModProjectDependency.projectUnzipPath,
          m_Size = 1073741824L
        }
      });
    }

    private static Colossal.Version ReadUnityProjectVersion(string path)
    {
      return new Colossal.Version(LongFile.ReadAllLines(path)[0].Split(':', StringSplitOptions.None)[1].Trim());
    }

    private static Colossal.Version ReadYAMLVersion(IEnumerable<string> lines)
    {
      foreach (string line in lines)
      {
        if (line.Contains("bundleVersion:"))
          return new Colossal.Version(line.Split(':', StringSplitOptions.None)[1].Trim());
      }
      throw new Exception();
    }

    private static bool IsUnityOpenWithModsProject(string projectPath)
    {
      try
      {
        foreach (Process process in Process.GetProcessesByName("unity"))
        {
          string parameterValue;
          int num = ProcessCommandLine.Retrieve(process, out parameterValue);
          if (num == 0)
          {
            string openProjectPath = string.Empty;
            new OptionSet()
            {
              {
                "projectpath=",
                "",
                (Action<string>) (option => openProjectPath = option)
              }
            }.Parse((IEnumerable<string>) ProcessCommandLine.CommandLineToArgs(parameterValue));
            if (!string.IsNullOrEmpty(openProjectPath) && Path.GetFullPath(openProjectPath) == Path.GetFullPath(projectPath))
              return true;
          }
          else
            IToolchainDependency.log.DebugFormat("Unable to get command line ({0}): {1}", (object) num, (object) ProcessCommandLine.ErrorToString(num));
        }
      }
      catch (Exception ex)
      {
        IToolchainDependency.log.Warn(ex);
      }
      return false;
    }
  }
}
