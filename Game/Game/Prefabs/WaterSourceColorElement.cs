// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.WaterSourceColorElement
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;
using UnityEngine;

#nullable disable
namespace Game.Prefabs
{
  [InternalBufferCapacity(4)]
  public struct WaterSourceColorElement : IBufferElementData
  {
    public Color m_Outline;
    public Color m_Fill;
    public Color m_ProjectedOutline;
    public Color m_ProjectedFill;
  }
}
