﻿// Decompiled with JetBrains decompiler
// Type: Game.Objects.Attachment
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;

#nullable disable
namespace Game.Objects
{
  public struct Attachment : IComponentData, IQueryTypeParameter, IEmptySerializable
  {
    public Entity m_Attached;

    public Attachment(Entity attached) => this.m_Attached = attached;
  }
}