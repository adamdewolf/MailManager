// Decompiled with JetBrains decompiler
// Type: Game.Tutorials.ControlSchemeActivationData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Input;
using Unity.Entities;

#nullable disable
namespace Game.Tutorials
{
  public struct ControlSchemeActivationData : IComponentData, IQueryTypeParameter
  {
    public InputManager.ControlScheme m_ControlScheme;

    public ControlSchemeActivationData(InputManager.ControlScheme controlScheme)
    {
      this.m_ControlScheme = controlScheme;
    }
  }
}
