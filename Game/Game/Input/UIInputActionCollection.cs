// Decompiled with JetBrains decompiler
// Type: Game.Input.UIInputActionCollection
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

#nullable disable
namespace Game.Input
{
  [CreateAssetMenu(menuName = "Colossal/UI/UIInputActionCollection")]
  public class UIInputActionCollection : ScriptableObject
  {
    public UIInputAction[] m_InputActions;

    public UIInputAction.State GetActionState(string actionName, string source)
    {
      UIInputAction uiInputAction = ((IEnumerable<UIInputAction>) this.m_InputActions).FirstOrDefault<UIInputAction>((Func<UIInputAction, bool>) (a => a.m_AliasName == actionName));
      return !((UnityEngine.Object) uiInputAction != (UnityEngine.Object) null) ? (UIInputAction.State) null : uiInputAction.GetState(source);
    }
  }
}
