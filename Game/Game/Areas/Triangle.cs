﻿// Decompiled with JetBrains decompiler
// Type: Game.Areas.Triangle
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Mathematics;
using Colossal.Serialization.Entities;
using Unity.Entities;
using Unity.Mathematics;

#nullable disable
namespace Game.Areas
{
  [InternalBufferCapacity(2)]
  public struct Triangle : IBufferElementData, IEmptySerializable
  {
    public int3 m_Indices;
    public Bounds1 m_HeightRange;
    public int m_MinLod;

    public Triangle(int a, int b, int c)
    {
      this.m_Indices = new int3(a, b, c);
      this.m_HeightRange = new Bounds1();
      this.m_MinLod = 0;
    }
  }
}