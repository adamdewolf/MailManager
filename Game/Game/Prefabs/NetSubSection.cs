// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.NetSubSection
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  [InternalBufferCapacity(0)]
  public struct NetSubSection : IBufferElementData
  {
    public Entity m_SubSection;
    public CompositionFlags m_CompositionAll;
    public CompositionFlags m_CompositionAny;
    public CompositionFlags m_CompositionNone;
    public NetSectionFlags m_SectionAll;
    public NetSectionFlags m_SectionAny;
    public NetSectionFlags m_SectionNone;
  }
}
