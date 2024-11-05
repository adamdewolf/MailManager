// Decompiled with JetBrains decompiler
// Type: Game.Input.CameraZoomProcessor
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
  public class CameraZoomProcessor : InputProcessor<float>
  {
    public Platform m_Platform = Platform.All;
    public DeviceType m_DeviceType;
    public float m_Scale = 1f;

    public override float Process(float value, InputControl control)
    {
      if (!this.m_Platform.IsPlatformSet(Application.platform))
        return value;
      Game.Settings.InputSettings input = SharedSettings.instance.input;
      value *= this.m_Scale;
      float num1 = value;
      float num2;
      switch (this.m_DeviceType)
      {
        case DeviceType.Keyboard:
          num2 = input.keyboardZoomSensitivity;
          break;
        case DeviceType.Mouse:
          num2 = input.mouseZoomSensitivity;
          break;
        case DeviceType.Gamepad:
          num2 = input.gamepadZoomSensitivity;
          break;
        default:
          num2 = 1f;
          break;
      }
      value = num1 * num2;
      return value;
    }

    static CameraZoomProcessor() => CameraZoomProcessor.Initialize();

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Initialize() => UnityEngine.InputSystem.InputSystem.RegisterProcessor<CameraZoomProcessor>();
  }
}
