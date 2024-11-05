// Decompiled with JetBrains decompiler
// Type: Game.Tools.IconDefinition
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Notifications;
using Unity.Entities;
using Unity.Mathematics;

#nullable disable
namespace Game.Tools
{
  public struct IconDefinition : IComponentData, IQueryTypeParameter
  {
    public float3 m_Location;
    public IconPriority m_Priority;
    public IconClusterLayer m_ClusterLayer;
    public IconFlags m_Flags;

    public IconDefinition(Icon icon)
    {
      this.m_Location = icon.m_Location;
      this.m_Priority = icon.m_Priority;
      this.m_ClusterLayer = icon.m_ClusterLayer;
      this.m_Flags = icon.m_Flags;
    }
  }
}
