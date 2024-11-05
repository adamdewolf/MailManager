// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.TrafficSignData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  public struct TrafficSignData : IComponentData, IQueryTypeParameter
  {
    public uint m_TypeMask;
    public int m_SpeedLimit;

    public static uint GetTypeMask(TrafficSignType type)
    {
      return type == TrafficSignType.None ? 0U : 1U << (int) (16 - type & (TrafficSignType.RoundaboutCounterclockwise | TrafficSignType.RoundaboutClockwise));
    }
  }
}
