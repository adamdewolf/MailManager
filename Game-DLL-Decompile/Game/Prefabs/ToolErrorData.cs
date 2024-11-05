// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.ToolErrorData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Tools;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  public struct ToolErrorData : IComponentData, IQueryTypeParameter
  {
    public ErrorType m_Error;
    public ToolErrorFlags m_Flags;
  }
}
