// Decompiled with JetBrains decompiler
// Type: Game.Net.Curve
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Mathematics;
using Colossal.Serialization.Entities;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Mathematics;

#nullable disable
namespace Game.Net
{
  public struct Curve : IComponentData, IQueryTypeParameter, IStrideSerializable, ISerializable
  {
    public Bezier4x3 m_Bezier;
    public float m_Length;

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_Bezier);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read(out this.m_Bezier);
      this.m_Length = MathUtils.Length(this.m_Bezier);
    }

    public int GetStride(Context context) => UnsafeUtility.SizeOf<float3>();
  }
}
