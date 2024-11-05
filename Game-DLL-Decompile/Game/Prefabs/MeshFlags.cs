// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.MeshFlags
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Prefabs
{
  [Flags]
  public enum MeshFlags : uint
  {
    Decal = 1,
    StackX = 2,
    StackY = 4,
    StackZ = 8,
    Impostor = 16, // 0x00000010
    Tiling = 32, // 0x00000020
    Invert = 64, // 0x00000040
    Base = 128, // 0x00000080
    MinBounds = 256, // 0x00000100
    Default = 512, // 0x00000200
    Animated = 4096, // 0x00001000
    Skeleton = 8192, // 0x00002000
    Character = 16384, // 0x00004000
  }
}
