﻿// Decompiled with JetBrains decompiler
// Type: Game.Rendering.ColorGroupID
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

#nullable disable
namespace Game.Rendering
{
  public struct ColorGroupID
  {
    private int m_Index;

    public ColorGroupID(int index) => this.m_Index = index;

    public static bool operator ==(ColorGroupID a, ColorGroupID b) => a.m_Index == b.m_Index;

    public static bool operator !=(ColorGroupID a, ColorGroupID b) => a.m_Index != b.m_Index;

    public override bool Equals(object obj)
    {
      return obj is ColorGroupID colorGroupId && this == colorGroupId;
    }

    public override int GetHashCode() => this.m_Index.GetHashCode();
  }
}