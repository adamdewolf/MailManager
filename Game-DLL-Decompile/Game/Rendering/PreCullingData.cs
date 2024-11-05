// Decompiled with JetBrains decompiler
// Type: Game.Rendering.PreCullingData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;

#nullable disable
namespace Game.Rendering
{
  public struct PreCullingData
  {
    public Entity m_Entity;
    public PreCullingFlags m_Flags;
    public sbyte m_UpdateFrame;
    public byte m_Timer;
  }
}
