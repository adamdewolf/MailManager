// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.EffectCondition
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Prefabs
{
  [Serializable]
  public struct EffectCondition
  {
    public EffectConditionFlags m_RequiredFlags;
    public EffectConditionFlags m_ForbiddenFlags;
    public EffectConditionFlags m_IntensityFlags;
  }
}
