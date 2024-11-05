// Decompiled with JetBrains decompiler
// Type: Game.Notifications.IconElement
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using System;
using Unity.Entities;

#nullable disable
namespace Game.Notifications
{
  [InternalBufferCapacity(4)]
  public struct IconElement : IBufferElementData, IEquatable<IconElement>, IEmptySerializable
  {
    public Entity m_Icon;

    public IconElement(Entity icon) => this.m_Icon = icon;

    public bool Equals(IconElement other) => this.m_Icon.Equals(other.m_Icon);

    public override int GetHashCode() => this.m_Icon.GetHashCode();
  }
}
