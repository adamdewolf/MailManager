// Decompiled with JetBrains decompiler
// Type: Game.Simulation.GarbageTransferRequestFlags
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Simulation
{
  [Flags]
  public enum GarbageTransferRequestFlags : ushort
  {
    Deliver = 1,
    Receive = 2,
    RequireTransport = 4,
  }
}
