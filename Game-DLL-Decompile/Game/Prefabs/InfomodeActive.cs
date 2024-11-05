// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.InfomodeActive
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  public struct InfomodeActive : IComponentData, IQueryTypeParameter
  {
    public int m_Priority;
    public int m_Index;

    public InfomodeActive(int priority, int index)
    {
      this.m_Priority = priority;
      this.m_Index = index;
    }
  }
}
