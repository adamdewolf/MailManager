// Decompiled with JetBrains decompiler
// Type: Game.CinemachineGameAxisProvider
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Cinemachine;
using Game.Input;
using UnityEngine;

#nullable disable
namespace Game
{
  public class CinemachineGameAxisProvider : MonoBehaviour, AxisState.IInputAxisProvider
  {
    private ProxyAction m_MouseRotateAction;
    private ProxyAction m_RotateAction;
    private ProxyAction m_MouseZoomAction;
    private ProxyAction m_ZoomAction;

    public float mouseRotateSpeed { get; set; } = 0.1f;

    public float rotateSpeed { get; set; } = 1f;

    private void Awake()
    {
      this.m_RotateAction = InputManager.instance.FindAction("Camera", "Rotate");
      this.m_MouseRotateAction = InputManager.instance.FindAction("Camera", "Rotate Mouse");
      this.m_ZoomAction = InputManager.instance.FindAction("Camera", "Zoom");
      this.m_MouseZoomAction = InputManager.instance.FindAction("Camera", "Zoom Mouse");
    }

    public float GetAxisValue(int axis)
    {
      switch (axis)
      {
        case 0:
          return (float) ((double) this.m_MouseRotateAction.ReadValue<Vector2>().x * (double) this.mouseRotateSpeed + (double) this.m_RotateAction.ReadValue<Vector2>().x * (double) this.rotateSpeed);
        case 1:
          return (float) ((double) this.m_MouseRotateAction.ReadValue<Vector2>().y * (double) this.mouseRotateSpeed + (double) this.m_RotateAction.ReadValue<Vector2>().y * (double) this.rotateSpeed);
        case 2:
          return this.m_ZoomAction.ReadValue<float>() + this.m_MouseZoomAction.ReadValue<float>();
        default:
          return 0.0f;
      }
    }
  }
}
