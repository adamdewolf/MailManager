﻿// Decompiled with JetBrains decompiler
// Type: Game.Modding.Toolchain.Dependencies.VsWhereResult
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Json;

#nullable disable
namespace Game.Modding.Toolchain.Dependencies
{
  internal class VsWhereResult
  {
    public VsWhereEntry[] entries;

    public static VsWhereResult FromJson(string json)
    {
      return JSON.MakeInto<VsWhereResult>(JSON.Load(json));
    }
  }
}