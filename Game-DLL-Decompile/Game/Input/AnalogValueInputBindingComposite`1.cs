// Decompiled with JetBrains decompiler
// Type: Game.Input.AnalogValueInputBindingComposite`1
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;

#nullable disable
namespace Game.Input
{
  public abstract class AnalogValueInputBindingComposite<T> : ValueInputBindingComposite<T> where T : struct
  {
    public Mode m_Mode;

    protected override IEnumerable<NamedValue> GetParameters()
    {
      return base.GetParameters().Append<NamedValue>(NamedValue.From<Mode>("m_Mode", this.m_Mode));
    }

    protected class Vector2Comparer : IComparer<Vector2>
    {
      public static AnalogValueInputBindingComposite<T>.Vector2Comparer instance = new AnalogValueInputBindingComposite<T>.Vector2Comparer();

      public int Compare(Vector2 x, Vector2 y) => x.magnitude.CompareTo(y.magnitude);
    }
  }
}
