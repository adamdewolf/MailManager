// Decompiled with JetBrains decompiler
// Type: Game.Pathfind.PathfindCosts
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Mathematics;

#nullable disable
namespace Game.Pathfind
{
  public struct PathfindCosts
  {
    public float4 m_Value;

    public PathfindCosts(float time, float behaviour, float money, float comfort)
    {
      this.m_Value = new float4(time, behaviour, money, comfort);
    }
  }
}
