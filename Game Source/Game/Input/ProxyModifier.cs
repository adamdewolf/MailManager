﻿// Decompiled with JetBrains decompiler
// Type: Game.Input.ProxyModifier
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Json;
using System;
using System.Collections.Generic;

#nullable disable
namespace Game.Input
{
  public struct ProxyModifier : IEquatable<ProxyModifier>
  {
    public static readonly ProxyModifier.Comparer pathComparer = new ProxyModifier.Comparer(ProxyModifier.Comparer.Options.Path);
    [Exclude]
    public ActionComponent m_Component;
    public string m_Name;
    public string m_Path;

    public static ProxyModifier.Comparer defaultComparer => ProxyModifier.Comparer.defaultComparer;

    public override string ToString() => this.m_Name + " - " + this.m_Path;

    public bool Equals(ProxyModifier other)
    {
      return ProxyModifier.Comparer.defaultComparer.Equals(this, other);
    }

    public override int GetHashCode() => ProxyModifier.Comparer.defaultComparer.GetHashCode(this);

    public override bool Equals(object obj) => obj is ProxyModifier other && this.Equals(other);

    public static bool operator ==(ProxyModifier left, ProxyModifier right) => left.Equals(right);

    public static bool operator !=(ProxyModifier left, ProxyModifier right) => !left.Equals(right);

    public class Comparer : IEqualityComparer<ProxyModifier>, IComparer<ProxyModifier>
    {
      private static Dictionary<string, int> order = new Dictionary<string, int>()
      {
        {
          "<Keyboard>/shift",
          0
        },
        {
          "<Keyboard>/ctrl",
          1
        },
        {
          "<Keyboard>/alt",
          2
        },
        {
          "<Gamepad>/leftStickPress",
          3
        },
        {
          "<Gamepad>/rightStickPress",
          4
        }
      };
      public static readonly ProxyModifier.Comparer defaultComparer = new ProxyModifier.Comparer();
      public readonly ProxyModifier.Comparer.Options options;

      public Comparer(ProxyModifier.Comparer.Options options = ProxyModifier.Comparer.Options.Path | ProxyModifier.Comparer.Options.Component)
      {
        this.options = options;
      }

      public bool Equals(ProxyModifier x, ProxyModifier y)
      {
        return ((this.options & ProxyModifier.Comparer.Options.Name) == (ProxyModifier.Comparer.Options) 0 || !(x.m_Name != y.m_Name)) && ((this.options & ProxyModifier.Comparer.Options.Path) == (ProxyModifier.Comparer.Options) 0 || !(x.m_Path != y.m_Path)) && ((this.options & ProxyModifier.Comparer.Options.Component) == (ProxyModifier.Comparer.Options) 0 || x.m_Component == y.m_Component);
      }

      public int GetHashCode(ProxyModifier modifier)
      {
        HashCode hashCode = new HashCode();
        if ((this.options & ProxyModifier.Comparer.Options.Name) != (ProxyModifier.Comparer.Options) 0)
          hashCode.Add<string>(modifier.m_Name);
        if ((this.options & ProxyModifier.Comparer.Options.Path) != (ProxyModifier.Comparer.Options) 0)
          hashCode.Add<string>(modifier.m_Path);
        if ((this.options & ProxyModifier.Comparer.Options.Component) != (ProxyModifier.Comparer.Options) 0)
          hashCode.Add<ActionComponent>(modifier.m_Component);
        return hashCode.ToHashCode();
      }

      public int Compare(ProxyModifier x, ProxyModifier y)
      {
        int num = 0;
        if ((this.options & ProxyModifier.Comparer.Options.Name) != (ProxyModifier.Comparer.Options) 0 && (num = string.Compare(x.m_Name, y.m_Name, StringComparison.Ordinal)) != 0)
          return num;
        if ((this.options & ProxyModifier.Comparer.Options.Path) != (ProxyModifier.Comparer.Options) 0)
        {
          int maxValue1;
          if (!ProxyModifier.Comparer.order.TryGetValue(x.m_Path, out maxValue1))
            maxValue1 = int.MaxValue;
          int maxValue2;
          if (!ProxyModifier.Comparer.order.TryGetValue(y.m_Path, out maxValue2))
            maxValue2 = int.MaxValue;
          num = maxValue1 != int.MaxValue || maxValue2 != int.MaxValue ? maxValue1 - maxValue2 : string.Compare(x.m_Path, y.m_Path, StringComparison.Ordinal);
          if (num != 0)
            return num;
        }
        return (this.options & ProxyModifier.Comparer.Options.Component) != (ProxyModifier.Comparer.Options) 0 ? x.m_Component - y.m_Component : num;
      }

      [Flags]
      public enum Options
      {
        Name = 1,
        Path = 2,
        Component = 4,
      }
    }
  }
}