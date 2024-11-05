// Decompiled with JetBrains decompiler
// Type: Game.Reflection.EnumArrayAttribute
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Reflection
{
  [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field)]
  public class EnumArrayAttribute : Attribute
  {
    public Type type { get; set; }

    public EnumArrayAttribute(Type type) => this.type = type;
  }
}
