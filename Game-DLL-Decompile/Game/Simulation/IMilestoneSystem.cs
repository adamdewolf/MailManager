// Decompiled with JetBrains decompiler
// Type: Game.Simulation.IMilestoneSystem
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

#nullable disable
namespace Game.Simulation
{
  public interface IMilestoneSystem
  {
    int currentXP { get; }

    int requiredXP { get; }

    int lastRequiredXP { get; }

    int nextRequiredXP { get; }

    float progress { get; }

    int nextMilestone { get; }
  }
}
