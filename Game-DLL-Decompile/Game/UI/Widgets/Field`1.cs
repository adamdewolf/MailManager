// Decompiled with JetBrains decompiler
// Type: Game.UI.Widgets.Field`1
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.UI.Binding;

#nullable disable
namespace Game.UI.Widgets
{
  public abstract class Field<T> : ReadonlyField<T>, ISettable, IWidget, IJsonWritable
  {
    private IReader<T> m_ValueReader;

    protected IReader<T> valueReader
    {
      get => this.m_ValueReader ?? (this.m_ValueReader = ValueReaders.Create<T>());
      set => this.m_ValueReader = value;
    }

    public bool shouldTriggerValueChangedEvent => true;

    public void SetValue(IJsonReader reader)
    {
      T obj;
      this.valueReader.Read(reader, out obj);
      this.SetValue(obj);
    }

    public virtual void SetValue(T value) => this.accessor.SetTypedValue(value);
  }
}
