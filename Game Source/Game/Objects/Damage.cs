// Decompiled with JetBrains decompiler
// Type: Game.Objects.Damage
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;
using Unity.Mathematics;

#nullable disable
namespace Game.Objects
{
  public struct Damage : IComponentData, IQueryTypeParameter
  {
    public Entity m_Object;
    public float3 m_Delta;

    public Damage(Entity _object, float3 delta)
    {
      this.m_Object = _object;
      this.m_Delta = delta;
    }
  }
}
