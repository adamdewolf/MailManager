﻿// Decompiled with JetBrains decompiler
// Type: Game.UI.ErrorDialog
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Annotations;
using Colossal.UI.Binding;
using Game.UI.Localization;
using System;

#nullable disable
namespace Game.UI
{
  public class ErrorDialog : IJsonWritable
  {
    public ErrorDialog.Severity severity = ErrorDialog.Severity.Error;
    public ErrorDialog.Actions actions = ErrorDialog.Actions.Default;
    public LocalizedString localizedTitle;
    public LocalizedString localizedMessage;
    [CanBeNull]
    public string errorDetails;

    public void Write(IJsonWriter writer)
    {
      writer.TypeBegin(this.GetType().FullName);
      writer.PropertyName("severity");
      writer.Write((int) this.severity);
      writer.PropertyName("actions");
      writer.Write((int) this.actions);
      writer.PropertyName("localizedTitle");
      writer.Write<LocalizedString>(this.localizedTitle);
      writer.PropertyName("localizedMessage");
      writer.Write<LocalizedString>(this.localizedMessage);
      writer.PropertyName("errorDetails");
      writer.Write(this.errorDetails);
      writer.TypeEnd();
    }

    public enum Severity
    {
      Warning,
      Error,
    }

    [Flags]
    public enum Actions
    {
      None = 0,
      Quit = 1,
      SaveAndQuit = 2,
      SaveAndContinue = 4,
      Default = SaveAndQuit | Quit, // 0x00000003
    }
  }
}