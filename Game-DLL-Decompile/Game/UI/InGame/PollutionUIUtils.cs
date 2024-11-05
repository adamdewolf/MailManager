// Decompiled with JetBrains decompiler
// Type: Game.UI.InGame.PollutionUIUtils
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Prefabs;

#nullable disable
namespace Game.UI.InGame
{
  public static class PollutionUIUtils
  {
    public static PollutionThreshold GetPollutionKey(UIPollutionThresholds data, float pollution)
    {
      if ((double) pollution > (double) data.m_High)
        return PollutionThreshold.High;
      if ((double) pollution > (double) data.m_Medium)
        return PollutionThreshold.Medium;
      return (double) pollution <= (double) data.m_Low ? PollutionThreshold.None : PollutionThreshold.Low;
    }
  }
}
