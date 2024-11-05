// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.GuideLineSettingsData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;
using UnityEngine;

#nullable disable
namespace Game.Prefabs
{
  public struct GuideLineSettingsData : IComponentData, IQueryTypeParameter
  {
    public Color m_VeryLowPriorityColor;
    public Color m_LowPriorityColor;
    public Color m_MediumPriorityColor;
    public Color m_HighPriorityColor;
  }
}
