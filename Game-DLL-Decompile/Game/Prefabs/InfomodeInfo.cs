// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.InfomodeInfo
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Prefabs
{
  [Serializable]
  public class InfomodeInfo : IComparable<InfomodeInfo>
  {
    public InfomodePrefab m_Mode;
    public int m_Priority;
    public bool m_Supplemental;
    public bool m_Optional;

    public int CompareTo(InfomodeInfo other) => this.m_Priority - other.m_Priority;
  }
}
