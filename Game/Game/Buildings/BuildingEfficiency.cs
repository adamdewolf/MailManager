﻿// Decompiled with JetBrains decompiler
// Type: Game.Buildings.BuildingEfficiency
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using System.Runtime.InteropServices;
using Unity.Entities;

#nullable disable
namespace Game.Buildings
{
  [StructLayout(LayoutKind.Sequential, Size = 1)]
  public struct BuildingEfficiency : IComponentData, IQueryTypeParameter, ISerializable
  {
    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write((byte) 0);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read(out byte _);
    }
  }
}