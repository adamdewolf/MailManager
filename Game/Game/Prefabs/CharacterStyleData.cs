// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.CharacterStyleData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  public struct CharacterStyleData : IComponentData, IQueryTypeParameter
  {
    public ActivityMask m_ActivityMask;
    public AnimationLayerMask m_AnimationLayerMask;
    public int m_BoneCount;
    public int m_ShapeCount;
    public int m_RestPoseClipIndex;
  }
}
