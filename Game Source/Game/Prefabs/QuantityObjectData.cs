// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.QuantityObjectData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Areas;
using Game.Economy;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  public struct QuantityObjectData : IComponentData, IQueryTypeParameter
  {
    public Resource m_Resources;
    public MapFeature m_MapFeature;
    public uint m_StepMask;
  }
}
