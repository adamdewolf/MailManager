// Decompiled with JetBrains decompiler
// Type: Game.Tools.LocalCurveCache
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Mathematics;
using Unity.Entities;

#nullable disable
namespace Game.Tools
{
  public struct LocalCurveCache : IComponentData, IQueryTypeParameter
  {
    public Bezier4x3 m_Curve;
  }
}
