// Decompiled with JetBrains decompiler
// Type: Game.Common.PseudoRandomSeed
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;
using Unity.Mathematics;

#nullable disable
namespace Game.Common
{
  public struct PseudoRandomSeed : IComponentData, IQueryTypeParameter, ISerializable
  {
    public static readonly ushort kEffectCondition = 24997;
    public static readonly ushort kSubObject = 30691;
    public static readonly ushort kSecondaryObject = 6624;
    public static readonly ushort kSplitEdge = 22175;
    public static readonly ushort kEdgeNodes = 43059;
    public static readonly ushort kColorVariation = 47969;
    public static readonly ushort kBuildingState = 61698;
    public static readonly ushort kSubLane = 38092;
    public static readonly ushort kDummyPassengers = 16686;
    public static readonly ushort kLightState = 2545;
    public static readonly ushort kBrightnessLimit = 13328;
    public static readonly ushort kDrivingStyle = 45236;
    public static readonly ushort kFlowOffset = 8934;
    public static readonly ushort kMeshGroup = 60951;
    public static readonly ushort kCollapse = 12473;
    public static readonly ushort kDummyName = 29193;
    public static readonly ushort kTemperatureLimit = 4505;
    public static readonly ushort kAreaBorder = 35490;
    public ushort m_Seed;

    public PseudoRandomSeed(ushort seed) => this.m_Seed = seed;

    public PseudoRandomSeed(ref Random random) => this.m_Seed = (ushort) random.NextUInt(65536U);

    public Random GetRandom(uint reason)
    {
      Random random = new Random(math.max(1U, (uint) this.m_Seed ^ reason));
      int num1 = (int) random.NextUInt();
      int num2 = (int) random.NextUInt();
      return random;
    }

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_Seed);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read(out this.m_Seed);
    }
  }
}
