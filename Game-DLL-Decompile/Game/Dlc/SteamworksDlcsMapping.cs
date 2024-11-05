// Decompiled with JetBrains decompiler
// Type: Game.Dlc.SteamworksDlcsMapping
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.PSI.Steamworks;
using UnityEngine.Scripting;

#nullable disable
namespace Game.Dlc
{
  [Preserve]
  public class SteamworksDlcsMapping : SteamworksDlcMapper
  {
    private const uint kProjectWashingtonId = 2427731;
    private const uint kProjectCaliforniaId = 2427730;
    private const uint kExpansionPass = 2472660;
    private const uint kProjectFloridaId = 2427740;
    private const uint kProjectMaineId = 2427741;
    private const uint kProjectOhioId = 2427742;
    private const uint kProjectNewJerseyId = 2427743;
    private const uint kProjectAlaskaId = 2427744;
    private const uint kProjectHawaiiId = 2427745;
    private const uint kProjectIdahoId = 2427746;

    public SteamworksDlcsMapping()
    {
      this.Map(Game.Dlc.Dlc.LandmarkBuildings, 2427731U);
      this.Map(Game.Dlc.Dlc.SanFranciscoSet, 2427730U);
      this.Map(Game.Dlc.Dlc.DeluxeRelaxRadio, 2427744U);
    }
  }
}
