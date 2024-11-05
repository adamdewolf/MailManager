// Decompiled with JetBrains decompiler
// Type: Game.UI.InGame.UIResource
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.UI.Binding;
using Game.Economy;
using System;

#nullable disable
namespace Game.UI.InGame
{
  public readonly struct UIResource : IJsonWritable, IComparable<UIResource>
  {
    public Resource key { get; }

    public int amount { get; }

    public UIResource(Game.Economy.Resources resource)
    {
      this.key = resource.m_Resource;
      this.amount = resource.m_Amount;
    }

    public UIResource(Resource resource, int amount)
    {
      this.key = resource;
      this.amount = amount;
    }

    public void Write(IJsonWriter writer)
    {
      writer.TypeBegin(this.GetType().FullName);
      writer.PropertyName("key");
      writer.Write(Enum.GetName(typeof (Resource), (object) this.key));
      writer.PropertyName("amount");
      writer.Write(this.amount);
      writer.TypeEnd();
    }

    public int CompareTo(UIResource other) => other.amount.CompareTo(this.amount);
  }
}
