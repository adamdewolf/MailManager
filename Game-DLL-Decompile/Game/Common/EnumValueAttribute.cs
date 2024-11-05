// Decompiled with JetBrains decompiler
// Type: Game.Common.EnumValueAttribute
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;
using UnityEngine;

#nullable disable
namespace Game.Common
{
  public class EnumValueAttribute : PropertyAttribute
  {
    public string[] names;

    public EnumValueAttribute(System.Type type) => this.names = Enum.GetNames(type);
  }
}
