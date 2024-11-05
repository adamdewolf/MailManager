// Decompiled with JetBrains decompiler
// Type: Game.Pathfind.PathTargetMoved
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;
using Unity.Mathematics;

#nullable disable
namespace Game.Pathfind
{
  public struct PathTargetMoved : IComponentData, IQueryTypeParameter
  {
    public Entity m_Target;
    public float3 m_OldLocation;
    public float3 m_NewLocation;

    public PathTargetMoved(Entity target, float3 oldLocation, float3 newLocation)
    {
      this.m_Target = target;
      this.m_OldLocation = oldLocation;
      this.m_NewLocation = newLocation;
    }
  }
}
