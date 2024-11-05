// Decompiled with JetBrains decompiler
// Type: Game.Areas.DistrictModifier
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;
using Unity.Mathematics;

#nullable disable
namespace Game.Areas
{
  [InternalBufferCapacity(0)]
  public struct DistrictModifier : IBufferElementData, ISerializable
  {
    public float2 m_Delta;

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_Delta);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      if (reader.context.version >= Version.modifierRefactoring)
        reader.Read(out this.m_Delta);
      else
        reader.Read(out this.m_Delta.y);
    }
  }
}
