// Decompiled with JetBrains decompiler
// Type: Game.Pathfind.EdgeID
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Pathfind
{
  public struct EdgeID : IEquatable<EdgeID>
  {
    public int m_Index;

    public bool Equals(EdgeID other) => this.m_Index == other.m_Index;

    public override int GetHashCode() => this.m_Index;
  }
}
