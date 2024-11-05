// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.DefaultNetLane
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;
using Unity.Mathematics;

#nullable disable
namespace Game.Prefabs
{
  [InternalBufferCapacity(0)]
  public struct DefaultNetLane : IBufferElementData
  {
    public Entity m_Lane;
    public float3 m_Position;
    public LaneFlags m_Flags;
    public byte m_Carriageway;
    public byte m_Group;
    public byte m_Index;

    public DefaultNetLane(NetCompositionLane source)
    {
      this.m_Lane = source.m_Lane;
      this.m_Position = source.m_Position;
      this.m_Flags = source.m_Flags;
      this.m_Carriageway = source.m_Carriageway;
      this.m_Group = source.m_Group;
      this.m_Index = source.m_Index;
    }
  }
}
