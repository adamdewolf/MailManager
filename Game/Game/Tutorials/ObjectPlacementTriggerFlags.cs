// Decompiled with JetBrains decompiler
// Type: Game.Tutorials.ObjectPlacementTriggerFlags
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Tutorials
{
  [Flags]
  [Serializable]
  public enum ObjectPlacementTriggerFlags
  {
    AllowSubObject = 1,
    RequireElevation = 2,
    RequireRoadConnection = 4,
    RequireTransformerConnection = 8,
    RequireSewageOutletConnection = 16, // 0x00000010
    RequireElectricityProducerConnection = 32, // 0x00000020
    RequireOutsideConnection = 64, // 0x00000040
  }
}
