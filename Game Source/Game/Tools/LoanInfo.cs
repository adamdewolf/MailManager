﻿// Decompiled with JetBrains decompiler
// Type: Game.Tools.LoanInfo
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Tools
{
  public struct LoanInfo : IEquatable<LoanInfo>
  {
    public int m_Amount;
    public float m_DailyInterestRate;
    public int m_DailyPayment;

    public bool Equals(LoanInfo other)
    {
      return this.m_Amount == other.m_Amount && this.m_DailyInterestRate.Equals(other.m_DailyInterestRate) && this.m_DailyPayment == other.m_DailyPayment;
    }
  }
}