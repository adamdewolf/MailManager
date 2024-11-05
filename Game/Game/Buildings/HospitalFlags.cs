// Decompiled with JetBrains decompiler
// Type: Game.Buildings.HospitalFlags
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Buildings
{
  [Flags]
  public enum HospitalFlags : byte
  {
    HasAvailableAmbulances = 1,
    HasAvailableMedicalHelicopters = 2,
    CanCureDisease = 4,
    HasRoomForPatients = 16, // 0x10
    CanProcessCorpses = 32, // 0x20
    CanCureInjury = 64, // 0x40
  }
}
