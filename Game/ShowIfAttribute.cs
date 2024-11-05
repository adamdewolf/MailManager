// Decompiled with JetBrains decompiler
// Type: ShowIfAttribute
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using UnityEngine;

#nullable disable
public class ShowIfAttribute : PropertyAttribute
{
  public string ConditionName { get; private set; }

  public int EnumValue { get; private set; }

  public bool Inverse { get; private set; }

  public ShowIfAttribute(string conditionName, int enumValue, bool inverse = false)
  {
    this.ConditionName = conditionName;
    this.EnumValue = enumValue;
    this.Inverse = inverse;
  }
}
