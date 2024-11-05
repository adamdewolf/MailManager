// Decompiled with JetBrains decompiler
// Type: Game.UI.Tooltip.GuideLineTooltipSystem
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Rendering;
using Game.UI.Widgets;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Scripting;

#nullable disable
namespace Game.UI.Tooltip
{
  public class GuideLineTooltipSystem : TooltipSystemBase
  {
    private GuideLinesSystem m_GuideLinesSystem;
    private List<TooltipGroup> m_Groups;

    [Preserve]
    protected override void OnCreate()
    {
      base.OnCreate();
      this.m_GuideLinesSystem = this.World.GetOrCreateSystemManaged<GuideLinesSystem>();
      this.m_Groups = new List<TooltipGroup>();
    }

    [Preserve]
    protected override void OnUpdate()
    {
      JobHandle dependencies;
      // ISSUE: reference to a compiler-generated method
      NativeList<GuideLinesSystem.TooltipInfo> tooltips = this.m_GuideLinesSystem.GetTooltips(out dependencies);
      dependencies.Complete();
      for (int index = 0; index < tooltips.Length; ++index)
      {
        // ISSUE: variable of a compiler-generated type
        GuideLinesSystem.TooltipInfo tooltipInfo = tooltips[index];
        if (this.m_Groups.Count <= index)
        {
          List<TooltipGroup> groups = this.m_Groups;
          TooltipGroup tooltipGroup = new TooltipGroup();
          tooltipGroup.path = (PathSegment) string.Format("guideLineTooltip{0}", (object) index);
          tooltipGroup.horizontalAlignment = TooltipGroup.Alignment.Center;
          tooltipGroup.verticalAlignment = TooltipGroup.Alignment.Center;
          tooltipGroup.category = TooltipGroup.Category.Network;
          tooltipGroup.children.Add((IWidget) new IntTooltip());
          groups.Add(tooltipGroup);
        }
        TooltipGroup group = this.m_Groups[index];
        // ISSUE: reference to a compiler-generated field
        float2 tooltipPos = TooltipSystemBase.WorldToTooltipPos((Vector3) tooltipInfo.m_Position, out bool _);
        if (!group.position.Equals(tooltipPos))
        {
          group.position = tooltipPos;
          group.SetChildrenChanged();
        }
        IntTooltip child = group.children[0] as IntTooltip;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: variable of a compiler-generated type
        GuideLinesSystem.TooltipType type = tooltipInfo.m_Type;
        switch (type)
        {
          case GuideLinesSystem.TooltipType.Angle:
            child.icon = "Media/Glyphs/Angle.svg";
            // ISSUE: reference to a compiler-generated field
            child.value = tooltipInfo.m_IntValue;
            child.unit = "angle";
            break;
          case GuideLinesSystem.TooltipType.Length:
            child.icon = "Media/Glyphs/Length.svg";
            // ISSUE: reference to a compiler-generated field
            child.value = tooltipInfo.m_IntValue;
            child.unit = "length";
            break;
        }
        this.AddGroup(group);
      }
    }

    [Preserve]
    public GuideLineTooltipSystem()
    {
    }
  }
}
