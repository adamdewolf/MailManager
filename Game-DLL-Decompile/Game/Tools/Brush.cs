// Decompiled with JetBrains decompiler
// Type: Game.Tools.Brush
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;
using Unity.Mathematics;

#nullable disable
namespace Game.Tools
{
  public struct Brush : IComponentData, IQueryTypeParameter
  {
    public Entity m_Tool;
    public float3 m_Position;
    public float3 m_Target;
    public float3 m_Start;
    public float m_Angle;
    public float m_Size;
    public float m_Strength;
    public float m_Opacity;
  }
}
