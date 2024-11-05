// Decompiled with JetBrains decompiler
// Type: Game.CameraInput
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Input;
using UnityEngine;

#nullable disable
namespace Game
{
  public class CameraInput : MonoBehaviour
  {
    public float m_MoveSmoothing = 1E-06f;
    public float m_RotateSmoothing = 1E-06f;
    public float m_ZoomSmoothing = 1E-06f;
    private Vector2 m_LastMoveInput;
    private Vector2 m_LastRotateInput;
    private Vector2 m_LastMouseRotateInput;
    private float m_LastZoomInput;
    private float m_LastMouseZoomInput;
    private ProxyAction m_MoveAction;
    private ProxyAction m_RotateAction;
    private ProxyAction m_MouseRotateAction;
    private ProxyAction m_ZoomAction;
    private ProxyAction m_MouseZoomAction;

    public Vector2 move { get; private set; }

    public Vector2 rotate { get; private set; }

    public float zoom { get; private set; }

    public void Initialize()
    {
      this.m_MoveAction = InputManager.instance.FindAction("Camera", "Move");
      this.m_RotateAction = InputManager.instance.FindAction("Camera", "Rotate");
      this.m_MouseRotateAction = InputManager.instance.FindAction("Camera", "Rotate Mouse");
      this.m_ZoomAction = InputManager.instance.FindAction("Camera", "Zoom");
      this.m_MouseZoomAction = InputManager.instance.FindAction("Camera", "Zoom Mouse");
    }

    public void Reset()
    {
      this.m_LastMoveInput = Vector2.zero;
      this.m_LastRotateInput = Vector2.zero;
      this.m_LastMouseRotateInput = Vector2.zero;
      this.m_LastZoomInput = 0.0f;
      this.m_LastMouseZoomInput = 0.0f;
    }

    public bool isMoving => this.m_MoveAction.IsPressed();

    public bool any
    {
      get
      {
        return this.m_MoveAction.IsPressed() || this.m_RotateAction.IsPressed() || this.m_MouseRotateAction.IsPressed() || this.m_ZoomAction.IsPressed() || this.m_MouseZoomAction.IsPressed();
      }
    }

    public void Refresh()
    {
      this.move = CameraController.SmoothTime(this.m_MoveAction.ReadValue<Vector2>(), ref this.m_LastMoveInput, this.m_MoveSmoothing);
      Vector2 vector2_1 = CameraController.SmoothTime(this.m_RotateAction.ReadValue<Vector2>(), ref this.m_LastRotateInput, this.m_RotateSmoothing);
      Vector2 vector2_2 = CameraController.Smooth(this.m_MouseRotateAction.ReadValue<Vector2>(), ref this.m_LastMouseRotateInput, this.m_RotateSmoothing);
      this.rotate = (double) vector2_2.sqrMagnitude > (double) vector2_1.sqrMagnitude ? vector2_2 : vector2_1;
      float f1 = CameraController.SmoothTime(this.m_ZoomAction.ReadValue<float>(), ref this.m_LastZoomInput, this.m_ZoomSmoothing);
      float f2 = CameraController.Smooth(this.m_MouseZoomAction.ReadValue<float>(), ref this.m_LastMouseZoomInput, this.m_ZoomSmoothing);
      this.zoom = (double) Mathf.Abs(f2) > (double) Mathf.Abs(f1) ? f2 : f1;
    }
  }
}
