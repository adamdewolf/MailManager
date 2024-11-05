// Decompiled with JetBrains decompiler
// Type: Game.Rendering.AnimatedPropID
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

#nullable disable
namespace Game.Rendering
{
  public struct AnimatedPropID
  {
    private int m_Index;

    public AnimatedPropID(int index) => this.m_Index = index;

    public bool isValid => this.m_Index >= 0;

    public static bool operator ==(AnimatedPropID a, AnimatedPropID b) => a.m_Index == b.m_Index;

    public static bool operator !=(AnimatedPropID a, AnimatedPropID b) => a.m_Index != b.m_Index;

    public override bool Equals(object obj)
    {
      return obj is AnimatedPropID animatedPropId && this == animatedPropId;
    }

    public override int GetHashCode() => this.m_Index.GetHashCode();
  }
}
