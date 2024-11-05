// Decompiled with JetBrains decompiler
// Type: Game.Tutorials.ObjectSelectionActivationData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;

#nullable disable
namespace Game.Tutorials
{
  public struct ObjectSelectionActivationData : IBufferElementData
  {
    public Entity m_Prefab;
    public bool m_AllowTool;

    public ObjectSelectionActivationData(Entity prefab, bool allowTool)
    {
      this.m_Prefab = prefab;
      this.m_AllowTool = allowTool;
    }
  }
}
