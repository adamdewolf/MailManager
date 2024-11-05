// Decompiled with JetBrains decompiler
// Type: Game.SceneFlow.AsyncHelpers
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;
using System.Threading.Tasks;

#nullable disable
namespace Game.SceneFlow
{
  public static class AsyncHelpers
  {
    public static async Task<bool> AwaitWithTimeout(this Task task, TimeSpan timeout)
    {
      Task task1 = Task.Delay(timeout);
      return await Task.WhenAny(task, task1) == task;
    }
  }
}
