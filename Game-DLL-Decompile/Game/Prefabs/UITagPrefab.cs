﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.UITagPrefab
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.OdinSerializer.Utilities;
using System;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("UI/", new Type[] {})]
  public class UITagPrefab : UITagPrefabBase
  {
    public override string uiTag
    {
      get => !this.m_Override.IsNullOrWhitespace() ? this.m_Override : base.uiTag;
    }
  }
}