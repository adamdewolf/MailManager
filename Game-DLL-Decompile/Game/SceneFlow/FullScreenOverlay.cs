﻿// Decompiled with JetBrains decompiler
// Type: Game.SceneFlow.FullScreenOverlay
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Input;
using System;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace Game.SceneFlow
{
  public abstract class FullScreenOverlay : IScreenState
  {
    protected const string kEngagementAnyKeyAction = "AnyKey";
    protected const string kEngagementContinueAction = "Continue";
    protected const string kEngagementCancelAction = "Cancel";
    protected Action m_CompletedEvent;
    protected bool m_Done;

    protected abstract OverlayScreen overlayScreen { get; }

    protected virtual string actionA => "Continue";

    protected virtual string actionB => "Cancel";

    protected virtual string continueDisplayProperty => (string) null;

    protected virtual string cancelDisplayProperty => (string) null;

    protected virtual int continueDisplayPriority => 20;

    protected virtual int cancelDisplayPriority => 20;

    protected virtual bool HandleScreenChange(OverlayScreen screen)
    {
      if (screen == this.overlayScreen)
        InputManager.instance.AssociateActionsWithUser(false);
      else if (screen == OverlayScreen.None || screen == OverlayScreen.Loading)
        InputManager.instance.AssociateActionsWithUser(true);
      return screen == this.overlayScreen;
    }

    public abstract Task Execute(GameManager manager, CancellationToken token);
  }
}