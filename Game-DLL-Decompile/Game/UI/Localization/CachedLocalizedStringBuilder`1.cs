﻿// Decompiled with JetBrains decompiler
// Type: Game.UI.Localization.CachedLocalizedStringBuilder`1
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace Game.UI.Localization
{
  public class CachedLocalizedStringBuilder<T>
  {
    private readonly Func<T, LocalizedString> m_Builder;
    private readonly Dictionary<T, LocalizedString> m_Cache;

    public CachedLocalizedStringBuilder(Func<T, LocalizedString> builder)
    {
      this.m_Builder = builder;
      this.m_Cache = new Dictionary<T, LocalizedString>();
    }

    public static CachedLocalizedStringBuilder<T> Value(Func<T, string> builder)
    {
      return new CachedLocalizedStringBuilder<T>((Func<T, LocalizedString>) (key => LocalizedString.Value(builder(key))));
    }

    public static CachedLocalizedStringBuilder<T> Id(Func<T, string> builder)
    {
      return new CachedLocalizedStringBuilder<T>((Func<T, LocalizedString>) (key => LocalizedString.Id(builder(key))));
    }

    public LocalizedString this[T key]
    {
      get
      {
        LocalizedString localizedString;
        return this.m_Cache.TryGetValue(key, out localizedString) ? localizedString : (this.m_Cache[key] = this.m_Builder(key));
      }
    }
  }
}