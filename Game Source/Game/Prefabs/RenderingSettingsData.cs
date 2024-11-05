// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.RenderingSettingsData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;
using UnityEngine;

#nullable disable
namespace Game.Prefabs
{
  public struct RenderingSettingsData : IComponentData, IQueryTypeParameter
  {
    public Color m_HoveredColor;
    public Color m_OverrideColor;
    public Color m_WarningColor;
    public Color m_ErrorColor;
    public Color m_OwnerColor;
  }
}
