// Decompiled with JetBrains decompiler
// Type: Game.UI.BudgetItem`1
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;
using UnityEngine;

#nullable disable
namespace Game.UI
{
  [Serializable]
  public class BudgetItem<T> where T : struct, Enum
  {
    public string m_ID;
    public Color m_Color = Color.gray;
    public string m_Icon;
    public T[] m_Sources;
  }
}
