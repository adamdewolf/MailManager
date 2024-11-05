// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.IconAnimationInfo
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;
using UnityEngine;

#nullable disable
namespace Game.Prefabs
{
  [Serializable]
  public class IconAnimationInfo
  {
    public Game.Notifications.AnimationType m_Type;
    public float m_Duration;
    public AnimationCurve m_Scale;
    public AnimationCurve m_Alpha;
    public AnimationCurve m_ScreenY;
  }
}
