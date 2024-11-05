// Decompiled with JetBrains decompiler
// Type: Game.Modding.Toolchain.ToolchainException
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Modding.Toolchain
{
  public class ToolchainException : Exception
  {
    public IToolchainDependency source { get; }

    public ToolchainError error { get; }

    public ToolchainException(
      ToolchainError error,
      IToolchainDependency source,
      string message = null,
      Exception innerException = null)
      : base(message, innerException)
    {
      this.source = source;
      this.error = error;
    }

    public ToolchainException(
      ToolchainError status,
      IToolchainDependency source,
      Exception innerException)
      : this(status, source, string.Empty, innerException)
    {
    }
  }
}
