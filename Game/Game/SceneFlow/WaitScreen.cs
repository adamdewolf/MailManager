// Decompiled with JetBrains decompiler
// Type: Game.SceneFlow.WaitScreen
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace Game.SceneFlow
{
  public class WaitScreen
  {
    private const OverlayScreen k_OverlayScreen = OverlayScreen.Wait;

    public async Task Execute(GameManager manager, CancellationToken token, Task taskToWaitFor)
    {
      using (manager.inputManager.CreateOverlayBarrier(nameof (WaitScreen)))
      {
        OverlayBindings.ScopedScreen scope = manager.userInterface.overlayBindings.ActivateScreenScoped(OverlayScreen.Wait);
        try
        {
          await taskToWaitFor;
        }
        finally
        {
          scope.Dispose();
        }
        scope = new OverlayBindings.ScopedScreen();
      }
    }
  }
}
