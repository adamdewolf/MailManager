// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.MeshType
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Prefabs
{
  [Flags]
  public enum MeshType : ushort
  {
    Object = 1,
    Net = 2,
    Lane = 4,
    Zone = 8,
    First = Object, // 0x0001
    Last = Zone, // 0x0008
  }
}
