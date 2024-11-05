// Decompiled with JetBrains decompiler
// Type: Game.Input.ICustomComposite
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using UnityEngine.InputSystem.Utilities;

#nullable disable
namespace Game.Input
{
  public interface ICustomComposite
  {
    const bool defaultIsRebindable = true;
    const bool defaultAllowModifiers = true;
    const bool defaultCanBeEmpty = true;
    const bool defaultDeveloperOnly = false;
    const bool defaultBuiltIn = true;
    const bool defaultIsDummy = false;
    const bool defaultIsHidden = false;
    const Mode defaultMode = Mode.DigitalNormalized;
    const OptionGroupOverride defaultOptionGroupOverride = OptionGroupOverride.None;

    bool isRebindable { get; }

    bool allowModifiers { get; }

    bool canBeEmpty { get; }

    bool developerOnly { get; }

    bool builtIn { get; }

    bool isDummy { get; }

    bool isHidden { get; }

    Usages usages { get; }

    NameAndParameters parameters { get; }

    string typeName { get; }

    OptionGroupOverride optionGroupOverride { get; }

    static Usages defaultUsages => Usages.defaultUsages.Copy(false);
  }
}
