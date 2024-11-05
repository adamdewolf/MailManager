// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.ActivityMask
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

#nullable disable
namespace Game.Prefabs
{
  public struct ActivityMask
  {
    public uint m_Mask;

    public ActivityMask(ActivityType type)
    {
      if (type == ActivityType.None)
        this.m_Mask = 0U;
      else
        this.m_Mask = 1U << (int) (type - 1 & (ActivityType.PushUps | ActivityType.PullUps));
    }
  }
}
