// Decompiled with JetBrains decompiler
// Type: Game.Tools.CreationDefinition
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;

#nullable disable
namespace Game.Tools
{
  public struct CreationDefinition : IComponentData, IQueryTypeParameter
  {
    public Entity m_Prefab;
    public Entity m_SubPrefab;
    public Entity m_Original;
    public Entity m_Owner;
    public Entity m_Attached;
    public CreationFlags m_Flags;
    public int m_RandomSeed;
  }
}
