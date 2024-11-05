// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.Effects.CitizenSelectedSoundInfo
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Citizens;
using System;
using UnityEngine;

#nullable disable
namespace Game.Prefabs.Effects
{
  [Serializable]
  public class CitizenSelectedSoundInfo
  {
    public CitizenAge m_Age;
    [Tooltip("when 'Is Sick Or Injured' was checked, the happiness value will be ignored")]
    public bool m_IsSickOrInjured;
    [Tooltip("this value will be ignored when 'Is Sick Or Injured' was checked")]
    public CitizenHappiness m_Happiness;
    public EffectPrefab m_SelectedSound;
  }
}
