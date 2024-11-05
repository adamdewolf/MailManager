// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.InfoviewMode
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  [InternalBufferCapacity(0)]
  public struct InfoviewMode : IBufferElementData
  {
    public Entity m_Mode;
    public int m_Priority;
    public bool m_Supplemental;
    public bool m_Optional;

    public InfoviewMode(Entity mode, int priority, bool supplemental, bool optional)
    {
      this.m_Mode = mode;
      this.m_Priority = priority;
      this.m_Supplemental = supplemental;
      this.m_Optional = optional;
    }
  }
}
