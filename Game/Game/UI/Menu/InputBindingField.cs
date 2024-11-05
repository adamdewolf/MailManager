// Decompiled with JetBrains decompiler
// Type: Game.UI.Menu.InputBindingField
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.UI.Binding;
using Game.Input;
using Game.UI.Widgets;
using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Entities;

#nullable disable
namespace Game.UI.Menu
{
  public class InputBindingField : Field<ProxyBinding>
  {
    public InputBindingField()
    {
      this.valueWriter = (IWriter<ProxyBinding>) new ValueWriter<ProxyBinding>();
    }

    protected override bool ValueEquals(ProxyBinding newValue, ProxyBinding oldValue)
    {
      return ProxyBinding.pathAndModifiersComparer.Equals(newValue, oldValue);
    }

    protected override void WriteProperties(IJsonWriter writer)
    {
      base.WriteProperties(writer);
      writer.PropertyName("conflicts");
      writer.Write<ProxyBinding>((IList<ProxyBinding>) this.m_Value.conflicts.ToArray<ProxyBinding>());
    }

    public class Bindings : IWidgetBindingFactory
    {
      public IEnumerable<IBinding> CreateBindings(
        string group,
        IReader<IWidget> pathResolver,
        ValueChangedCallback onValueChanged)
      {
        yield return (IBinding) new TriggerBinding<IWidget>(group, "rebindInput", (Action<IWidget>) (widget =>
        {
          InputBindingField bindingField = widget as InputBindingField;
          if (bindingField == null)
            return;
          World.DefaultGameObjectInjectionWorld.GetOrCreateSystemManaged<InputRebindingUISystem>().Start(bindingField.m_Value, (Action<ProxyBinding>) (value => bindingField.SetValue(value)));
        }), pathResolver);
        yield return (IBinding) new TriggerBinding<IWidget>(group, "unsetInputBinding", (Action<IWidget>) (widget =>
        {
          if (!(widget is InputBindingField inputBindingField2))
            return;
          ProxyBinding proxyBinding = inputBindingField2.m_Value with
          {
            path = string.Empty,
            modifiers = (IReadOnlyList<ProxyModifier>) Array.Empty<ProxyModifier>()
          };
          inputBindingField2.SetValue(proxyBinding);
          onValueChanged(widget);
        }), pathResolver);
        yield return (IBinding) new TriggerBinding<IWidget>(group, "resetInputBinding", (Action<IWidget>) (widget =>
        {
          InputBindingField bindingField = widget as InputBindingField;
          if (bindingField == null)
            return;
          World.DefaultGameObjectInjectionWorld.GetOrCreateSystemManaged<InputRebindingUISystem>().Start(bindingField.m_Value, bindingField.m_Value.original, (Action<ProxyBinding>) (value => bindingField.SetValue(value)));
        }), pathResolver);
      }
    }
  }
}
