﻿// Decompiled with JetBrains decompiler
// Type: Game.Simulation.MailTransferRequestFlags
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Simulation
{
  [Flags]
  public enum MailTransferRequestFlags : ushort
  {
    Deliver = 1,
    Receive = 2,
    RequireTransport = 4,
    UnsortedMail = 16, // 0x0010
    LocalMail = 32, // 0x0020
    OutgoingMail = 64, // 0x0040
    ReturnUnsortedMail = 256, // 0x0100
    ReturnLocalMail = 512, // 0x0200
    ReturnOutgoingMail = 1024, // 0x0400
  }
}