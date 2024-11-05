// Decompiled with JetBrains decompiler
// Type: Game.UI.ConfirmationDialogBase
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Annotations;
using Colossal.UI.Binding;
using Game.UI.Localization;

#nullable disable
namespace Game.UI
{
  public abstract class ConfirmationDialogBase : IJsonWritable
  {
    protected const string kDefaultSkin = "Default";
    protected const string kParadoxSkin = "Paradox";
    protected bool dismissable;
    protected bool hasCancelAction = true;
    protected string skin;
    [CanBeNull]
    public LocalizedString title;
    [NotNull]
    public LocalizedString message;
    [NotNull]
    public LocalizedString confirmAction;
    [CanBeNull]
    public LocalizedString cancelAction;
    [CanBeNull]
    public LocalizedString[] otherActions;
    [CanBeNull]
    public LocalizedString? details;
    public bool copyButton;

    protected ConfirmationDialogBase(
      bool dismissable,
      string skin,
      [CanBeNull] LocalizedString title,
      [NotNull] LocalizedString message,
      [CanBeNull] LocalizedString? details,
      bool copyButton,
      [NotNull] LocalizedString confirmAction,
      [CanBeNull] LocalizedString cancelAction,
      [CanBeNull] params LocalizedString[] otherActions)
    {
      this.dismissable = dismissable;
      this.skin = skin;
      this.title = title;
      this.message = message;
      this.confirmAction = confirmAction;
      this.cancelAction = cancelAction;
      this.otherActions = otherActions;
      this.details = details;
      this.copyButton = copyButton;
    }

    public void Write(IJsonWriter writer)
    {
      writer.TypeBegin(this.GetType().FullName);
      writer.PropertyName("dismissable");
      writer.Write(this.dismissable);
      writer.PropertyName("hasCancelAction");
      writer.Write(this.hasCancelAction);
      writer.PropertyName("skin");
      writer.Write(this.skin);
      writer.PropertyName("title");
      writer.Write<LocalizedString>(this.title);
      writer.PropertyName("message");
      writer.Write<LocalizedString>(this.message);
      writer.PropertyName("confirmAction");
      writer.Write<LocalizedString>(this.confirmAction);
      writer.PropertyName("cancelAction");
      writer.Write<LocalizedString>(this.cancelAction);
      writer.PropertyName("otherActions");
      if (this.otherActions != null)
      {
        writer.ArrayBegin(this.otherActions.Length);
        for (int index = 0; index < this.otherActions.Length; ++index)
          writer.Write<LocalizedString>(this.otherActions[index]);
        writer.ArrayEnd();
      }
      else
        writer.WriteEmptyArray();
      writer.PropertyName("details");
      writer.Write<LocalizedString>(this.details);
      writer.PropertyName("copyButton");
      writer.Write(this.copyButton);
      writer.TypeEnd();
    }
  }
}
