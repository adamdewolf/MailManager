// Decompiled with JetBrains decompiler
// Type: Game.Input.DisplayNameOverride
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Input
{
  public class DisplayNameOverride : IDisposable
  {
    public const int kDisabledPriority = -1;
    private readonly ProxyAction m_Action;
    private readonly string m_Source;
    private bool m_Disposed;
    private int m_Priority;
    private UIInputAction.Transform m_Transform;
    private string m_DisplayName;
    private bool m_Active;

    public string source => this.m_Source;

    public bool isDisposed => this.m_Disposed;

    public bool active => this.m_Active && this.m_Priority != -1;

    public bool shouldBeActive
    {
      internal get => this.m_Active;
      set
      {
        if (value == this.m_Active)
          return;
        this.m_Active = value;
        this.m_Action.UpdateDisplay();
      }
    }

    public string displayName
    {
      get => this.m_DisplayName;
      set
      {
        if (!(value != this.m_DisplayName))
          return;
        this.m_DisplayName = value;
        if (!this.m_Active)
          return;
        this.m_Action.UpdateDisplay();
      }
    }

    public int priority
    {
      get => this.m_Priority;
      set
      {
        if (value == this.m_Priority)
          return;
        this.m_Priority = value;
        if (!this.m_Active)
          return;
        this.m_Action.UpdateDisplay();
      }
    }

    public UIInputAction.Transform transform
    {
      get => this.m_Transform;
      set
      {
        if (value == this.m_Transform)
          return;
        this.m_Transform = value;
        if (!this.m_Active)
          return;
        this.m_Action.UpdateDisplay();
      }
    }

    public DisplayNameOverride(
      string overrideSource,
      ProxyAction action,
      string displayName = null,
      int priority = -1,
      UIInputAction.Transform transform = UIInputAction.Transform.None)
    {
      this.m_Action = action;
      this.m_Source = overrideSource;
      this.m_DisplayName = displayName;
      this.m_Priority = priority;
      this.m_Transform = transform;
      this.m_Action.m_DisplayOverrides.Add(this);
    }

    public bool Equals(DisplayNameOverride other)
    {
      return this.m_Priority == other.m_Priority && !(this.m_DisplayName != other.m_DisplayName);
    }

    public void Dispose()
    {
      if (this.m_Disposed)
        return;
      this.m_Disposed = true;
      this.m_Action.m_DisplayOverrides.Remove(this);
    }
  }
}
