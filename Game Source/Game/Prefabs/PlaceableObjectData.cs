// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.PlaceableObjectData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Game.Objects;
using Unity.Entities;
using Unity.Mathematics;

#nullable disable
namespace Game.Prefabs
{
  public struct PlaceableObjectData : IComponentData, IQueryTypeParameter, ISerializable
  {
    public float3 m_PlacementOffset;
    public uint m_ConstructionCost;
    public int m_XPReward;
    public byte m_DefaultProbability;
    public RotationSymmetry m_RotationSymmetry;
    public PlacementFlags m_Flags;

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read(out this.m_PlacementOffset);
      reader.Read(out this.m_ConstructionCost);
      reader.Read(out this.m_XPReward);
      uint num;
      reader.Read(out num);
      this.m_Flags = (PlacementFlags) ((int) num & -32769);
    }

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_PlacementOffset);
      writer.Write(this.m_ConstructionCost);
      writer.Write(this.m_XPReward);
      writer.Write((uint) this.m_Flags);
    }
  }
}
