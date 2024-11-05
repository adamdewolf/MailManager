// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.MeshGroupFlags
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Prefabs
{
  [Flags]
  public enum MeshGroupFlags : uint
  {
    RequireCold = 1,
    RequireWarm = 2,
    RequireHome = 4,
    RequireHomeless = 8,
    RequireMotorcycle = 16, // 0x00000010
    ForbidMotorcycle = 32, // 0x00000020
  }
}
