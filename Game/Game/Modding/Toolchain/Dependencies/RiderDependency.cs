﻿// Decompiled with JetBrains decompiler
// Type: Game.Modding.Toolchain.Dependencies.RiderDependency
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace Game.Modding.Toolchain.Dependencies
{
  public class RiderDependency : BaseIDEDependency
  {
    public override string name => "Rider";

    public override string icon => "Media/Toolchain/Rider.svg";

    public override bool canBeInstalled => false;

    public override bool canBeUninstalled => false;

    public override string minVersion => "2021.3.3";

    protected override Task<string> GetIDEVersion(CancellationToken token)
    {
      RiderPathLocator.RiderInfo[] array = ((IEnumerable<RiderPathLocator.RiderInfo>) RiderPathLocator.GetAllRiderPaths()).OrderByDescending<RiderPathLocator.RiderInfo, System.Version>((Func<RiderPathLocator.RiderInfo, System.Version>) (a => a.BuildNumber)).ToArray<RiderPathLocator.RiderInfo>();
      return array.Length != 0 ? Task.FromResult<string>(((IEnumerable<RiderPathLocator.RiderInfo>) array).First<RiderPathLocator.RiderInfo>().ProductInfo.version) : Task.FromResult<string>(string.Empty);
    }
  }
}