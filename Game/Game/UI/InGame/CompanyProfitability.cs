﻿// Decompiled with JetBrains decompiler
// Type: Game.UI.InGame.CompanyProfitability
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.UI.Binding;
using System;

#nullable disable
namespace Game.UI.InGame
{
  public readonly struct CompanyProfitability : IJsonWritable
  {
    private static readonly string[] kHappinessPaths = new string[5]
    {
      "Media/Game/Icons/CompanyBankrupt.svg",
      "Media/Game/Icons/CompanyLosingMoney.svg",
      "Media/Game/Icons/CompanyBreakingEven.svg",
      "Media/Game/Icons/CompanyGettingBy.svg",
      "Media/Game/Icons/CompanyProfitable.svg"
    };

    private CompanyProfitabilityKey key { get; }

    public CompanyProfitability(int profit)
    {
      this.key = CompanyUIUtils.GetProfitabilityKey(profit);
    }

    public CompanyProfitability(CompanyProfitabilityKey key) => this.key = key;

    public void Write(IJsonWriter writer)
    {
      writer.TypeBegin(typeof (CompanyProfitability).FullName);
      writer.PropertyName("key");
      writer.Write(Enum.GetName(typeof (CompanyProfitabilityKey), (object) this.key));
      writer.PropertyName("iconPath");
      writer.Write(CompanyProfitability.kHappinessPaths[(int) this.key]);
      writer.TypeEnd();
    }
  }
}