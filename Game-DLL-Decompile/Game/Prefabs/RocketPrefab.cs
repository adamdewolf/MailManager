// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.RocketPrefab
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Vehicles;
using System;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("Vehicles/", new Type[] {})]
  public class RocketPrefab : HelicopterPrefab
  {
    protected override HelicopterType GetHelicopterType() => HelicopterType.Rocket;
  }
}
