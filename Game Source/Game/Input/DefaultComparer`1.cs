// Decompiled with JetBrains decompiler
// Type: Game.Input.DefaultComparer`1
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace Game.Input
{
  public class DefaultComparer<T> : IComparer<T> where T : struct, IComparable<T>
  {
    public static DefaultComparer<T> instance = new DefaultComparer<T>();

    public int Compare(T x, T y) => x.CompareTo(y);
  }
}
