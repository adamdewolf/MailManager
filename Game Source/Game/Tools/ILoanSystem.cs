// Decompiled with JetBrains decompiler
// Type: Game.Tools.ILoanSystem
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

#nullable disable
namespace Game.Tools
{
  public interface ILoanSystem
  {
    LoanInfo CurrentLoan { get; }

    int Creditworthiness { get; }

    LoanInfo RequestLoanOffer(int amount);

    void ChangeLoan(int amount);
  }
}
