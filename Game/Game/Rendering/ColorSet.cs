﻿// Decompiled with JetBrains decompiler
// Type: Game.Rendering.ColorSet
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using UnityEngine;

#nullable disable
namespace Game.Rendering
{
  public struct ColorSet
  {
    public Color m_Channel0;
    public Color m_Channel1;
    public Color m_Channel2;

    public ColorSet(Color color)
    {
      this.m_Channel0 = color;
      this.m_Channel1 = color;
      this.m_Channel2 = color;
    }

    public Color this[int index]
    {
      get
      {
        switch (index)
        {
          case 0:
            return this.m_Channel0;
          case 1:
            return this.m_Channel1;
          case 2:
            return this.m_Channel2;
          default:
            return new Color();
        }
      }
      set
      {
        switch (index)
        {
          case 0:
            this.m_Channel0 = value;
            break;
          case 1:
            this.m_Channel1 = value;
            break;
          case 2:
            this.m_Channel2 = value;
            break;
        }
      }
    }
  }
}