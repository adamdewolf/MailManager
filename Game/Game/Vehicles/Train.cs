// Decompiled with JetBrains decompiler
// Type: Game.Vehicles.Train
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;

#nullable disable
namespace Game.Vehicles
{
  public struct Train : IComponentData, IQueryTypeParameter, ISerializable
  {
    public TrainFlags m_Flags;

    public Train(TrainFlags flags) => this.m_Flags = flags;

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write((uint) this.m_Flags);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      uint num;
      reader.Read(out num);
      this.m_Flags = (TrainFlags) num;
      if (!(reader.context.version < Version.trainPrefabFlags))
        return;
      this.m_Flags |= TrainFlags.Pantograph;
    }
  }
}
