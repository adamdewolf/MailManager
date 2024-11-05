// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.AnimationLayerMask
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

#nullable disable
namespace Game.Prefabs
{
  public struct AnimationLayerMask
  {
    public uint m_Mask;

    public AnimationLayerMask(AnimationLayer layer)
    {
      if (layer == AnimationLayer.None)
        this.m_Mask = 0U;
      else
        this.m_Mask = 1U << (int) (layer - 1 & (AnimationLayer) 31);
    }
  }
}
