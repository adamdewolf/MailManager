// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.UITrendThresholds
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;
using UnityEngine;

#nullable disable
namespace Game.Prefabs
{
  [Serializable]
  public class UITrendThresholds
  {
    [Tooltip("Proportion of the actual value over which the medium trend arrows will be shown.")]
    public float m_Medium;
    [Tooltip("Proportion of the actual value over which the high trend arrows will be shown.")]
    public float m_High;
  }
}
