// Decompiled with JetBrains decompiler
// Type: Game.Tools.SnapLine
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Mathematics;

#nullable disable
namespace Game.Tools
{
  public struct SnapLine
  {
    public ControlPoint m_ControlPoint;
    public Bezier4x3 m_Curve;
    public SnapLineFlags m_Flags;

    public SnapLine(ControlPoint position, Bezier4x3 curve, SnapLineFlags flags)
    {
      this.m_ControlPoint = position;
      this.m_Curve = curve;
      this.m_Flags = flags;
    }
  }
}
