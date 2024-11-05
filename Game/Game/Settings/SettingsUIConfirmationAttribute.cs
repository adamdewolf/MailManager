// Decompiled with JetBrains decompiler
// Type: Game.Settings.SettingsUIConfirmationAttribute
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Settings
{
  public class SettingsUIConfirmationAttribute : Attribute
  {
    public readonly string confirmMessageValue;
    public readonly string confirmMessageId;

    public SettingsUIConfirmationAttribute(
      string overrideConfirmMessageId = null,
      string overrideConfirmMessageValue = null)
    {
      this.confirmMessageValue = overrideConfirmMessageValue;
      this.confirmMessageId = overrideConfirmMessageId;
    }
  }
}
