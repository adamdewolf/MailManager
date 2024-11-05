// Decompiled with JetBrains decompiler
// Type: Game.IGPUSystem
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using UnityEngine.Rendering;

#nullable disable
namespace Game
{
  public interface IGPUSystem
  {
    bool Enabled { get; }

    bool IsAsync { get; set; }

    void OnSimulateGPU(CommandBuffer cmd);
  }
}
