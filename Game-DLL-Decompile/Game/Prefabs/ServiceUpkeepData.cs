﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.ServiceUpkeepData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Collections;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  public struct ServiceUpkeepData : IBufferElementData, ICombineBuffer<ServiceUpkeepData>
  {
    public ResourceStack m_Upkeep;
    public bool m_ScaleWithUsage;

    public void Combine(NativeList<ServiceUpkeepData> result)
    {
      for (int index = 0; index < result.Length; ++index)
      {
        ref ServiceUpkeepData local = ref result.ElementAt(index);
        if (local.m_Upkeep.m_Resource == this.m_Upkeep.m_Resource && local.m_ScaleWithUsage == this.m_ScaleWithUsage)
        {
          local.m_Upkeep.m_Amount += this.m_Upkeep.m_Amount;
          return;
        }
      }
      result.Add(in this);
    }

    public ServiceUpkeepData ApplyServiceUsage(float scale)
    {
      return new ServiceUpkeepData()
      {
        m_Upkeep = new ResourceStack()
        {
          m_Amount = (int) ((double) this.m_Upkeep.m_Amount * (double) scale),
          m_Resource = this.m_Upkeep.m_Resource
        },
        m_ScaleWithUsage = this.m_ScaleWithUsage
      };
    }
  }
}