﻿// Decompiled with JetBrains decompiler
// Type: Game.Modding.Toolchain.Dependencies.ProjectTemplateDependency
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using CliWrap;
using Colossal;
using Colossal.Core;
using Colossal.IO;
using Colossal.PSI.Environment;
using Game.UI.Localization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace Game.Modding.Toolchain.Dependencies
{
  public class ProjectTemplateDependency : BaseDependency
  {
    private const string kProjectName = "C# Mod project template";
    private const string kPropsFile = "Mod.props";
    private const string kTargetsFile = "Mod.targets";
    private const string kTemplatePackageId = "ColossalOrder.ModTemplate";
    private const string kTemplateId = "csiimod";
    private static string templatePackageFile = "ColossalOrder.ModTemplate.1.0.0.nupkg";

    private static string propsFileSource => EnvPath.kGameToolingPath + "/Mod.props";

    private static string targetsFileSource => EnvPath.kGameToolingPath + "/Mod.targets";

    private static string propsFileDeploy => EnvPath.kUserToolingPath + "/Mod.props";

    private static string targetsFileDeploy => EnvPath.kUserToolingPath + "/Mod.targets";

    private static string templatePackageSource
    {
      get => Path.Combine(EnvPath.kGameToolingPath, ProjectTemplateDependency.templatePackageFile);
    }

    private static string templatePackageInstallation
    {
      get
      {
        return Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile), ".templateengine", "packages", ProjectTemplateDependency.templatePackageFile);
      }
    }

    public override string name => "C# template";

    public override string icon => "Media/Menu/ColossalLogo.svg";

    public override LocalizedString installDescr
    {
      get => LocalizedString.Id("Options.WARN_TOOLCHAIN_INSTALL_PROJECT_TEMPLATE");
    }

    public override Type[] dependsOnInstallation
    {
      get => new Type[1]{ typeof (DotNetDependency) };
    }

    public override Type[] dependsOnUninstallation
    {
      get => new Type[1]{ typeof (DotNetDependency) };
    }

    public override IEnumerable<string> envVariables
    {
      get
      {
        yield return "CSII_PATHSET";
        yield return "CSII_INSTALLATIONPATH";
        yield return "CSII_USERDATAPATH";
        yield return "CSII_TOOLPATH";
        yield return "CSII_LOCALMODSPATH";
        yield return "CSII_UNITYMODPROJECTPATH";
        yield return "CSII_UNITYVERSION";
        yield return "CSII_ENTITIESVERSION";
        yield return "CSII_MODPOSTPROCESSORPATH";
        yield return "CSII_MODPUBLISHERPATH";
        yield return "CSII_MANAGEDPATH";
        yield return "CSII_PDXCACHEPATH";
        yield return "CSII_PDXMODSPATH";
        yield return "CSII_ASSEMBLYSEARCHPATH";
      }
    }

    public override async Task<bool> IsInstalled(CancellationToken token)
    {
      try
      {
        if (!LongFile.Exists(ProjectTemplateDependency.propsFileDeploy) || !LongFile.Exists(ProjectTemplateDependency.targetsFileDeploy))
          return false;
        System.Version version = await DotNetDependency.GetDotnetVersion(token).ConfigureAwait(false);
        if (version.Major < 6)
          return false;
        List<string> errorText = new List<string>();
        CommandResult commandResult = await Cli.Wrap("dotnet").WithArguments(version.Major == 6 ? "new --list csiimod" : "new list csiimod --verbosity q").WithStandardErrorPipe(PipeTarget.ToDelegate((Action<string>) (l => errorText.Add(l)))).WithValidation(CommandResultValidation.None).ExecuteAsync(token).ConfigureAwait(false);
        if (errorText.Count > 0)
          IToolchainDependency.log.Warn((object) string.Join<string>('\n', (IEnumerable<string>) errorText));
        return commandResult.ExitCode == 0;
      }
      catch (Exception ex)
      {
        IToolchainDependency.log.Error(ex, (object) "Error during mod template check");
        return false;
      }
    }

    public override Task<bool> IsUpToDate(CancellationToken token)
    {
      try
      {
        if ((long) CalculateCache(ProjectTemplateDependency.propsFileSource) != (long) CalculateCache(ProjectTemplateDependency.propsFileDeploy))
          return Task.FromResult<bool>(false);
        if ((long) CalculateCache(ProjectTemplateDependency.targetsFileSource) != (long) CalculateCache(ProjectTemplateDependency.targetsFileDeploy))
          return Task.FromResult<bool>(false);
        return (long) CalculateCache(ProjectTemplateDependency.templatePackageSource) != (long) CalculateCache(ProjectTemplateDependency.templatePackageInstallation) ? Task.FromResult<bool>(false) : Task.FromResult<bool>(true);
      }
      catch (Exception ex)
      {
        IToolchainDependency.log.Error(ex, (object) "Error during mod template check");
        return Task.FromResult<bool>(false);
      }

      static ulong CalculateCache(string file)
      {
        return !LongFile.Exists(file) ? 0UL : new Crc(new CrcParameters(64, 4823603603198064275UL, 0UL, 0UL, false, false)).CalculateAsNumeric(LongFile.ReadAllBytes(file));
      }
    }

    public override Task<bool> NeedDownload(CancellationToken token)
    {
      return Task.FromResult<bool>(false);
    }

    public override Task Download(CancellationToken token) => Task.CompletedTask;

    public override async Task Install(CancellationToken token)
    {
      ProjectTemplateDependency source = this;
      token.ThrowIfCancellationRequested();
      try
      {
        IToolchainDependency.log.DebugFormat("Installing {0}", (object) "C# Mod project template");
        // ISSUE: explicit non-virtual call
        __nonvirtual (source.state) = new IToolchainDependency.State(DependencyState.Installing, "InstallingModTemplate");
        IToolchainDependency.log.DebugFormat("Copy mod template properties file '{0}' to '{1}'", (object) ProjectTemplateDependency.propsFileSource, (object) ProjectTemplateDependency.propsFileDeploy);
        IOUtils.EnsureDirectory(Path.GetDirectoryName(ProjectTemplateDependency.propsFileDeploy));
        await AsyncUtils.CopyFileAsync(ProjectTemplateDependency.propsFileSource, ProjectTemplateDependency.propsFileDeploy, true, token).ConfigureAwait(false);
        IToolchainDependency.log.DebugFormat("Copy mod template targets file '{0}' to '{1}'", (object) ProjectTemplateDependency.targetsFileSource, (object) ProjectTemplateDependency.targetsFileDeploy);
        IOUtils.EnsureDirectory(Path.GetDirectoryName(ProjectTemplateDependency.targetsFileDeploy));
        await AsyncUtils.CopyFileAsync(ProjectTemplateDependency.targetsFileSource, ProjectTemplateDependency.targetsFileDeploy, true, token).ConfigureAwait(false);
        IToolchainDependency.log.DebugFormat("Install mod template package '{0}'", (object) ProjectTemplateDependency.templatePackageSource);
        System.Version dotnetVersion = await DotNetDependency.GetDotnetVersion(token).ConfigureAwait(false);
        if (dotnetVersion.Major < 6)
          throw new ToolchainException(ToolchainError.Install, (IToolchainDependency) source, ".net6.0 is required");
        List<string> errorText = new List<string>();
        CommandResult commandResult1 = await Cli.Wrap("dotnet").WithArguments(dotnetVersion.Major == 6 ? "new --uninstall ColossalOrder.ModTemplate" : "new uninstall ColossalOrder.ModTemplate --verbosity q").WithStandardErrorPipe(PipeTarget.ToDelegate((Action<string>) (l => errorText.Add(l)))).WithValidation(CommandResultValidation.None).ExecuteAsync(token).ConfigureAwait(false);
        if (errorText.Count > 0)
          IToolchainDependency.log.Warn((object) string.Join<string>('\n', (IEnumerable<string>) errorText));
        errorText.Clear();
        CommandResult commandResult2 = await Cli.Wrap("dotnet").WithArguments(dotnetVersion.Major == 6 ? "new --install \"" + ProjectTemplateDependency.templatePackageSource + "\" --force" : "new install \"" + ProjectTemplateDependency.templatePackageSource + "\" --force --verbosity q").WithStandardErrorPipe(PipeTarget.ToDelegate((Action<string>) (l => errorText.Add(l)))).WithValidation(CommandResultValidation.None).ExecuteAsync(token).ConfigureAwait(false);
        if (errorText.Count > 0)
          IToolchainDependency.log.Warn((object) string.Join<string>('\n', (IEnumerable<string>) errorText));
        if (commandResult2.ExitCode != 0)
          throw new ToolchainException(ToolchainError.Install, (IToolchainDependency) source, "Mod template package not installed: code {result.ExitCode}");
        dotnetVersion = (System.Version) null;
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
      ProjectTemplateDependency source = this;
      token.ThrowIfCancellationRequested();
      try
      {
        // ISSUE: explicit non-virtual call
        __nonvirtual (source.state) = new IToolchainDependency.State(DependencyState.Removing, "RemovingProjectTemplate");
        IToolchainDependency.log.DebugFormat("Removing {0}", (object) "C# Mod project template");
        await AsyncUtils.DeleteFileAsync(ProjectTemplateDependency.propsFileDeploy, token).ConfigureAwait(false);
        await AsyncUtils.DeleteFileAsync(ProjectTemplateDependency.targetsFileDeploy, token).ConfigureAwait(false);
        System.Version version = await DotNetDependency.GetDotnetVersion(token).ConfigureAwait(false);
        if (version.Major < 6)
          throw new ToolchainException(ToolchainError.Uninstall, (IToolchainDependency) source, ".net6.0 is required");
        List<string> errorText = new List<string>();
        CommandResult commandResult = await Cli.Wrap("dotnet").WithArguments(version.Major == 6 ? "new --uninstall ColossalOrder.ModTemplate" : "new uninstall ColossalOrder.ModTemplate").WithStandardErrorPipe(PipeTarget.ToDelegate((Action<string>) (l => errorText.Add(l)))).WithValidation(CommandResultValidation.None).ExecuteAsync(token).ConfigureAwait(false);
        if (errorText.Count > 0)
          IToolchainDependency.log.Warn((object) string.Join<string>('\n', (IEnumerable<string>) errorText));
        if (commandResult.ExitCode != 0)
          throw new ToolchainException(ToolchainError.Uninstall, (IToolchainDependency) source, "Mod template package not removed: code {result.ExitCode}");
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
          m_Path = ProjectTemplateDependency.propsFileDeploy,
          m_Size = new FileInfo(ProjectTemplateDependency.propsFileSource).Length
        },
        new IToolchainDependency.DiskSpaceRequirements()
        {
          m_Path = ProjectTemplateDependency.targetsFileDeploy,
          m_Size = new FileInfo(ProjectTemplateDependency.targetsFileSource).Length
        },
        new IToolchainDependency.DiskSpaceRequirements()
        {
          m_Path = ProjectTemplateDependency.templatePackageInstallation,
          m_Size = new FileInfo(ProjectTemplateDependency.templatePackageSource).Length
        }
      });
    }
  }
}