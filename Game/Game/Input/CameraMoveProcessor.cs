// Decompiled with JetBrains decompiler
// Type: Game.Input.CameraMoveProcessor
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal;
using Game.Settings;
using UnityEngine;
using UnityEngine.InputSystem;

#nullable disable
namespace Game.Input
{
  public class CameraMoveProcessor : InputProcessor<Vector2>
  {
    public Platform m_Platform = Platform.All;
    public DeviceType m_DeviceType;
    public float m_ScaleX = 1f;
    public float m_ScaleY = 1f;

    public override Vector2 Process(Vector2 value, InputControl control)
    {
      if (!this.m_Platform.IsPlatformSet(Application.platform))
        return value;
      Game.Settings.InputSettings input = SharedSettings.instance.input;
      value.x *= this.m_ScaleX;
      value.y *= this.m_ScaleY;
      Vector2 vector2 = value;
      float num;
      switch (this.m_DeviceType)
      {
        case DeviceType.Keyboard:
          num = input.keyboardMoveSensitivity;
          break;
        case DeviceType.Mouse:
          num = input.mouseMoveSensitivity;
          break;
        case DeviceType.Gamepad:
          num = input.gamepadMoveSensitivity;
          break;
        default:
          num = 1f;
          break;
      }
      value = vector2 * num;
      return value;
    }

    static CameraMoveProcessor() => CameraMoveProcessor.Initialize();

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Initialize() => UnityEngine.InputSystem.InputSystem.RegisterProcessor<CameraMoveProcessor>();
  }
}
