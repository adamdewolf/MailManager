// Decompiled with JetBrains decompiler
// Type: Game.Input.CompositeInstance
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System.Collections.Generic;
using UnityEngine.InputSystem.Utilities;

#nullable disable
namespace Game.Input
{
  public class CompositeInstance : ICustomComposite
  {
    private Usages m_Usages = ICustomComposite.defaultUsages;

    public string typeName { get; internal set; }

    public bool isRebindable { get; set; } = true;

    public bool allowModifiers { get; set; } = true;

    public bool canBeEmpty { get; set; } = true;

    public bool developerOnly { get; set; }

    public bool builtIn { get; set; } = true;

    public bool isDummy { get; set; }

    public bool isHidden { get; set; }

    public Mode mode { get; set; }

    public OptionGroupOverride optionGroupOverride { get; set; }

    public List<NameAndParameters> processors { get; } = new List<NameAndParameters>();

    public List<NameAndParameters> interactions { get; } = new List<NameAndParameters>();

    public Usages usages
    {
      get => this.m_Usages.Copy();
      set => this.m_Usages.SetFrom(value);
    }

    public InputManager.CompositeData compositeData
    {
      get
      {
        InputManager.CompositeData data;
        return !InputManager.TryGetCompositeData(this.typeName, out data) ? new InputManager.CompositeData() : data;
      }
    }

    public NameAndParameters parameters
    {
      get
      {
        return new NameAndParameters()
        {
          name = this.typeName,
          parameters = new ReadOnlyArray<NamedValue>(new NamedValue[9]
          {
            NamedValue.From<bool>("m_IsRebindable", this.isRebindable),
            NamedValue.From<bool>("m_AllowModifiers", this.allowModifiers),
            NamedValue.From<bool>("m_CanBeEmpty", this.canBeEmpty),
            NamedValue.From<bool>("m_DeveloperOnly", this.developerOnly),
            NamedValue.From<bool>("m_BuiltIn", this.builtIn),
            NamedValue.From<Mode>("m_Mode", this.mode),
            NamedValue.From<bool>("m_IsDummy", this.isDummy),
            NamedValue.From<bool>("m_IsHidden", this.isHidden),
            NamedValue.From<OptionGroupOverride>("m_OptionGroupOverride", this.optionGroupOverride)
          })
        };
      }
      set
      {
        foreach (NamedValue parameter in value.parameters)
        {
          switch (parameter.name)
          {
            case "m_AllowModifiers":
              this.allowModifiers = parameter.value.ToBoolean();
              continue;
            case "m_BuiltIn":
              this.builtIn = parameter.value.ToBoolean();
              continue;
            case "m_CanBeEmpty":
              this.canBeEmpty = parameter.value.ToBoolean();
              continue;
            case "m_DeveloperOnly":
              this.developerOnly = parameter.value.ToBoolean();
              continue;
            case "m_IsDummy":
              this.isDummy = parameter.value.ToBoolean();
              continue;
            case "m_IsHidden":
              this.isHidden = parameter.value.ToBoolean();
              continue;
            case "m_IsRebindable":
              this.isRebindable = parameter.value.ToBoolean();
              continue;
            case "m_Mode":
              this.mode = (Mode) parameter.value.ToInt32();
              continue;
            case "m_OptionGroupOverride":
              this.optionGroupOverride = (OptionGroupOverride) parameter.value.ToInt32();
              continue;
            case "m_Usages":
              this.m_Usages = new Usages((BuiltInUsages) parameter.value.ToInt32());
              continue;
            default:
              continue;
          }
        }
      }
    }

    public CompositeInstance(string typeName) => this.typeName = typeName;

    public CompositeInstance(NameAndParameters parameters)
      : this(parameters.name)
    {
      this.m_Usages = ICustomComposite.defaultUsages;
      this.parameters = parameters;
      this.m_Usages.MakeReadOnly();
    }

    public CompositeInstance(NameAndParameters parameters, NameAndParameters usages)
      : this(parameters.name)
    {
      this.m_Usages = new Usages(0, false);
      this.parameters = parameters;
      this.m_Usages.parameters = usages;
      this.m_Usages.MakeReadOnly();
    }
  }
}
