﻿// Decompiled with JetBrains decompiler
// Type: Game.UI.Localization.LocalizationUtils
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Common;

#nullable disable
namespace Game.UI.Localization
{
  public static class LocalizationUtils
  {
    public static string AppendIndex(
      string localeId,
      RandomLocalizationIndex randomLocalizationIndex)
    {
      return randomLocalizationIndex.m_Index == -1 ? localeId : string.Format("{0}:{1}", (object) localeId, (object) randomLocalizationIndex.m_Index);
    }
  }
}