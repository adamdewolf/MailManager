// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.TrainEngineData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;
using Unity.Mathematics;

#nullable disable
namespace Game.Prefabs
{
  public struct TrainEngineData : IComponentData, IQueryTypeParameter, IEmptySerializable
  {
    public int2 m_Count;

    public TrainEngineData(int minCount, int maxCount)
    {
      this.m_Count = new int2(minCount, maxCount);
    }
  }
}
