﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.EmergencyGeneratorData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Mathematics;
using Colossal.Serialization.Entities;
using Unity.Entities;
using Unity.Mathematics;

#nullable disable
namespace Game.Prefabs
{
  public struct EmergencyGeneratorData : 
    IComponentData,
    IQueryTypeParameter,
    ICombineData<EmergencyGeneratorData>,
    ISerializable
  {
    public int m_ElectricityProduction;
    public Bounds1 m_ActivationThreshold;

    public void Combine(EmergencyGeneratorData otherData)
    {
      this.m_ElectricityProduction += otherData.m_ElectricityProduction;
      this.m_ActivationThreshold = new Bounds1(math.max(otherData.m_ActivationThreshold.min, this.m_ActivationThreshold.min), math.max(otherData.m_ActivationThreshold.max, this.m_ActivationThreshold.max));
    }

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_ElectricityProduction);
      writer.Write(this.m_ActivationThreshold.min);
      writer.Write(this.m_ActivationThreshold.max);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read(out this.m_ElectricityProduction);
      reader.Read(out this.m_ActivationThreshold.min);
      reader.Read(out this.m_ActivationThreshold.max);
    }
  }
}