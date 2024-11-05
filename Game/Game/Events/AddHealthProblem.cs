// Decompiled with JetBrains decompiler
// Type: Game.Events.AddHealthProblem
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Citizens;
using Unity.Entities;

#nullable disable
namespace Game.Events
{
  public struct AddHealthProblem : IComponentData, IQueryTypeParameter
  {
    public Entity m_Event;
    public Entity m_Target;
    public HealthProblemFlags m_Flags;
  }
}
