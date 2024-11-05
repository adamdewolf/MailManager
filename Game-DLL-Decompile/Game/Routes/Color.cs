// Decompiled with JetBrains decompiler
// Type: Game.Routes.Color
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;
using UnityEngine;

#nullable disable
namespace Game.Routes
{
  public struct Color : IComponentData, IQueryTypeParameter, ISerializable
  {
    public Color32 m_Color;

    public Color(Color32 color) => this.m_Color = color;

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_Color);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read(out this.m_Color);
    }
  }
}
