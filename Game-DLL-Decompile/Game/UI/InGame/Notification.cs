// Decompiled with JetBrains decompiler
// Type: Game.UI.InGame.Notification
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Notifications;
using Unity.Entities;

#nullable disable
namespace Game.UI.InGame
{
  public readonly struct Notification
  {
    public Entity entity { get; }

    public Entity target { get; }

    public IconPriority priority { get; }

    public Notification(Entity entity, Entity target, IconPriority priority)
    {
      this.entity = entity;
      this.target = target;
      this.priority = priority;
    }
  }
}
