// Decompiled with JetBrains decompiler
// Type: Game.Input.CameraRotateProcessor
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
  public class CameraRotateProcessor : InputProcessor<Vector2>
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
      ref float local1 = ref value.x;
      float num1 = local1;
      float num2;
      switch (this.m_DeviceType)
      {
        case DeviceType.Keyboard:
          num2 = input.keyboardRotateSensitivity;
          break;
        case DeviceType.Mouse:
          num2 = input.mouseInvertX ? -input.mouseRotateSensitivity : input.mouseRotateSensitivity;
          break;
        case DeviceType.Gamepad:
          num2 = input.gamepadInvertX ? -input.gamepadRotateSensitivity : input.gamepadRotateSensitivity;
          break;
        default:
          num2 = 1f;
          break;
      }
      local1 = num1 * num2;
      ref float local2 = ref value.y;
      float num3 = local2;
      float num4;
      switch (this.m_DeviceType)
      {
        case DeviceType.Keyboard:
          num4 = input.keyboardRotateSensitivity;
          break;
        case DeviceType.Mouse:
          num4 = input.mouseInvertY ? -input.mouseRotateSensitivity : input.mouseRotateSensitivity;
          break;
        case DeviceType.Gamepad:
          num4 = input.gamepadInvertY ? -1f : 1f;
          break;
        default:
          num4 = 1f;
          break;
      }
      local2 = num3 * num4;
      return value;
    }

    static CameraRotateProcessor() => CameraRotateProcessor.Initialize();

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Initialize() => UnityEngine.InputSystem.InputSystem.RegisterProcessor<CameraRotateProcessor>();
  }
}
