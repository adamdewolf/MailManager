// Decompiled with JetBrains decompiler
// Type: Game.Rendering.IGameCameraController
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Cinemachine;
using UnityEngine;

#nullable disable
namespace Game.Rendering
{
  public interface IGameCameraController
  {
    float zoom { get; set; }

    Vector3 pivot { get; set; }

    Vector3 position { get; set; }

    Vector3 rotation { get; set; }

    bool controllerEnabled { get; set; }

    bool inputEnabled { get; set; }

    void TryMatchPosition(IGameCameraController other);

    void UpdateCamera();

    ICinemachineCamera virtualCamera { get; }

    ref LensSettings lens { get; }
  }
}
