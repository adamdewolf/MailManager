// Decompiled with JetBrains decompiler
// Type: Game.Input.ValueInputBindingComposite`1
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System.Collections.Generic;
using System.Linq;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

#nullable disable
namespace Game.Input
{
  public abstract class ValueInputBindingComposite<T> : InputBindingComposite<T>, ICustomComposite where T : struct
  {
    public bool m_IsRebindable = true;
    public bool m_AllowModifiers = true;
    public bool m_CanBeEmpty = true;
    public bool m_DeveloperOnly;
    public bool m_BuiltIn = true;
    public bool m_IsDummy;
    public bool m_IsHidden;
    public OptionGroupOverride m_OptionGroupOverride;
    public BuiltInUsages m_Usages = BuiltInUsages.Default | BuiltInUsages.Overlay | BuiltInUsages.Tool | BuiltInUsages.CancelableTool;

    public bool isRebindable => this.m_IsRebindable;

    public bool allowModifiers => this.m_AllowModifiers;

    public bool canBeEmpty => this.m_CanBeEmpty;

    public bool developerOnly => this.m_DeveloperOnly;

    public bool builtIn => this.m_BuiltIn;

    public bool isDummy => this.m_IsDummy;

    public bool isHidden => this.m_IsHidden;

    public OptionGroupOverride optionGroupOverride => this.m_OptionGroupOverride;

    public abstract string typeName { get; }

    protected virtual IEnumerable<NamedValue> GetParameters()
    {
      yield return NamedValue.From<bool>("m_IsRebindable", this.m_IsRebindable);
      yield return NamedValue.From<bool>("m_AllowModifiers", this.m_AllowModifiers);
      yield return NamedValue.From<bool>("m_CanBeEmpty", this.m_CanBeEmpty);
      yield return NamedValue.From<bool>("m_DeveloperOnly", this.m_DeveloperOnly);
      yield return NamedValue.From<bool>("m_BuiltIn", this.m_BuiltIn);
      yield return NamedValue.From<bool>("m_IsDummy", this.m_IsDummy);
      yield return NamedValue.From<bool>("m_IsHidden", this.m_IsHidden);
      yield return NamedValue.From<OptionGroupOverride>("m_OptionGroupOverride", this.m_OptionGroupOverride);
    }

    public virtual NameAndParameters parameters
    {
      get
      {
        return new NameAndParameters()
        {
          name = this.typeName,
          parameters = new ReadOnlyArray<NamedValue>(this.GetParameters().ToArray<NamedValue>())
        };
      }
    }

    public Usages usages => new Usages(this.m_Usages);
  }
}
