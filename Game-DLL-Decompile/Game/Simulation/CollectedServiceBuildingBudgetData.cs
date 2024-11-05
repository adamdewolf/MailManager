// Decompiled with JetBrains decompiler
// Type: Game.Simulation.CollectedServiceBuildingBudgetData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;

#nullable disable
namespace Game.Simulation
{
  public struct CollectedServiceBuildingBudgetData : 
    IComponentData,
    IQueryTypeParameter,
    ISerializable
  {
    public int m_Count;
    public int m_Workers;
    public int m_Workplaces;

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read(out this.m_Count);
      reader.Read(out this.m_Workers);
      reader.Read(out this.m_Workplaces);
    }

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_Count);
      writer.Write(this.m_Workers);
      writer.Write(this.m_Workplaces);
    }
  }
}
