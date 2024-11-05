// Decompiled with JetBrains decompiler
// Type: Game.Tools.ErrorData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;
using Unity.Mathematics;

#nullable disable
namespace Game.Tools
{
  public struct ErrorData
  {
    public Entity m_TempEntity;
    public Entity m_PermanentEntity;
    public float3 m_Position;
    public ErrorType m_ErrorType;
    public ErrorSeverity m_ErrorSeverity;
  }
}
