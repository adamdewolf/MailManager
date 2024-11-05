// Decompiled with JetBrains decompiler
// Type: Game.CameraController
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Cinemachine;
using Colossal.Mathematics;
using Game.Audio;
using Game.Input;
using Game.Rendering;
using Game.SceneFlow;
using Game.Settings;
using Game.Simulation;
using Game.UI.InGame;
using System;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

#nullable disable
namespace Game
{
  public class CameraController : MonoBehaviour, IGameCameraController
  {
    [SerializeField]
    private float3 m_Pivot;
    [SerializeField]
    private float2 m_Angle;
    [SerializeField]
    private float m_Zoom;
    [SerializeField]
    private Bounds1 m_ZoomRange = new Bounds1(10f, 10000f);
    [SerializeField]
    private Bounds1 m_MapTileToolZoomRange = new Bounds1(10f, 20000f);
    [SerializeField]
    private bool m_MapTileToolViewEnabled;
    [SerializeField]
    private float m_MapTileToolFOV;
    [SerializeField]
    private float m_MapTileToolFarclip;
    [SerializeField]
    private float3 m_MapTileToolPivot;
    [SerializeField]
    private float2 m_MapTileToolAngle;
    [SerializeField]
    private float m_MapTileToolZoom;
    [SerializeField]
    private float m_MapTileToolTransitionTime;
    [SerializeField]
    private float m_MoveSmoothing = 1E-06f;
    [SerializeField]
    private float m_RotateSmoothing = 1E-06f;
    [SerializeField]
    private float m_ZoomSmoothing = 1E-06f;
    [SerializeField]
    private float m_CollisionSmoothing = 1f / 1000f;
    private ProxyActionMap m_CameraMap;
    private ProxyAction m_MoveAction;
    private ProxyAction m_MoveFastAction;
    private ProxyAction m_RotateAction;
    private ProxyAction m_MouseRotateAction;
    private ProxyAction m_ZoomAction;
    private ProxyAction m_MouseZoomAction;
    private CinemachineVirtualCamera m_VCam;
    private float m_InitialFarClip;
    private float m_InitialFov;
    private float m_LastGameViewZoom;
    private float2 m_LastGameViewAngle;
    private float3 m_LastGameViewPivot;
    private float m_LastMapViewZoom;
    private float2 m_LastMapViewAngle;
    private float3 m_LastMapViewPivot;
    private Vector2 m_LastMoveInput;
    private Vector2 m_LastRotateInput;
    private Vector2 m_LastMouseRotateInput;
    private float m_LastZoomInput;
    private float m_LastMouseZoomInput;
    private float m_MapViewTimer;
    private AudioManager m_AudioManager;
    private CameraUpdateSystem m_CameraSystem;
    private CameraCollisionSystem m_CollisionSystem;

    public IEnumerable<ProxyAction> inputActions
    {
      get
      {
        if (this.m_MoveAction != null)
          yield return this.m_MoveAction;
        if (this.m_MoveFastAction != null)
          yield return this.m_MoveFastAction;
        if (this.m_RotateAction != null)
          yield return this.m_RotateAction;
        if (this.m_MouseRotateAction != null)
          yield return this.m_MouseRotateAction;
        if (this.m_ZoomAction != null)
          yield return this.m_ZoomAction;
        if (this.m_MouseZoomAction != null)
          yield return this.m_MouseZoomAction;
      }
    }

    public Action<bool> EventCameraMovingChanged { get; set; }

    public bool moving { get; private set; }

    public ref LensSettings lens => ref this.m_VCam.m_Lens;

    public ICinemachineCamera virtualCamera => (ICinemachineCamera) this.m_VCam;

    public Vector3 rotation
    {
      get => new Vector3(this.m_Angle.y, this.m_Angle.x, 0.0f);
      set => this.m_Angle = new float2(value.y, value.x);
    }

    public TerrainSystem terrainSystem
    {
      get
      {
        return World.DefaultGameObjectInjectionWorld != null ? World.DefaultGameObjectInjectionWorld.GetOrCreateSystemManaged<TerrainSystem>() : (TerrainSystem) null;
      }
    }

    public WaterSystem waterSystem
    {
      get
      {
        return World.DefaultGameObjectInjectionWorld != null ? World.DefaultGameObjectInjectionWorld.GetOrCreateSystemManaged<WaterSystem>() : (WaterSystem) null;
      }
    }

    public Vector3 pivot
    {
      get => (Vector3) this.m_Pivot;
      set => this.m_Pivot = (float3) value;
    }

    public Vector3 position
    {
      get => this.transform.position;
      set
      {
      }
    }

    public float2 angle
    {
      get => this.m_Angle;
      set => this.m_Angle = value;
    }

    public void TryMatchPosition(IGameCameraController other)
    {
      float terrainHeight;
      if (!this.TryGetTerrainHeight(other.position, out terrainHeight))
        return;
      float num1 = other.position.y - terrainHeight;
      float num2 = Mathf.Sin((float) Math.PI / 180f * other.rotation.x);
      float num3 = (float) (1.0 / (2.0 - 4.0 * (double) num2));
      float num4 = (float) ((8.0 * (double) this.zoomRange.min - 20.0 * (double) num1) * (double) num2 + (double) this.zoomRange.min - 2.0 * (double) num1);
      this.zoom = Mathf.Clamp(Mathf.Abs(num3 * (Mathf.Sqrt((float) ((double) num4 * (double) num4 - (4.0 - 8.0 * (double) num2) * (-4.0 * (double) this.zoomRange.min * (double) this.zoomRange.min + 18.0 * (double) this.zoomRange.min * (double) num1 - 20.0 * (double) num1 * (double) num1))) + num4)), this.zoomRange.min, this.zoomRange.max);
      Quaternion quaternion = Quaternion.Euler(other.rotation.x, other.rotation.y, other.rotation.z);
      this.pivot = other.position + quaternion * new Vector3(0.0f, 0.0f, this.zoom);
      this.angle = new float2(other.rotation.y, (double) other.rotation.x > 90.0 ? other.rotation.x - 360f : other.rotation.x);
      this.transform.rotation = quaternion;
      this.transform.position = other.position;
    }

    public float zoom
    {
      get => this.m_Zoom;
      set => this.m_Zoom = value;
    }

    public bool controllerEnabled
    {
      get => this.isActiveAndEnabled;
      set => this.gameObject.SetActive(value);
    }

    public bool inputEnabled { get; set; } = true;

    public Bounds1 zoomRange
    {
      get => MapTilesUISystem.mapTileViewActive ? this.m_MapTileToolZoomRange : this.m_ZoomRange;
    }

    public float3 cameraPosition { get; private set; }

    public float velocity { get; private set; }

    public bool edgeScrolling { get; set; }

    public float clipDistance { get; set; }

    private async void Awake()
    {
      CameraController cameraController = this;
      if (!await GameManager.instance.WaitForReadyState())
        return;
      if (!Application.isEditor)
      {
        cameraController.edgeScrolling = true;
        GameplaySettings gameplay = SharedSettings.instance?.gameplay;
        if (gameplay != null)
          cameraController.edgeScrolling = gameplay.edgeScrolling;
      }
      cameraController.m_VCam = cameraController.GetComponent<CinemachineVirtualCamera>();
      cameraController.m_InitialFarClip = cameraController.m_VCam.m_Lens.FarClipPlane;
      cameraController.m_InitialFov = cameraController.m_VCam.m_Lens.FieldOfView;
      cameraController.clipDistance = float.MaxValue;
      cameraController.m_CameraMap = InputManager.instance.FindActionMap("Camera");
      cameraController.m_MoveAction = cameraController.m_CameraMap.FindAction("Move");
      cameraController.m_MoveFastAction = cameraController.m_CameraMap.FindAction("Move Fast");
      cameraController.m_RotateAction = cameraController.m_CameraMap.FindAction("Rotate");
      cameraController.m_MouseRotateAction = cameraController.m_CameraMap.FindAction("Rotate Mouse");
      cameraController.m_ZoomAction = cameraController.m_CameraMap.FindAction("Zoom");
      cameraController.m_MouseZoomAction = cameraController.m_CameraMap.FindAction("Zoom Mouse");
      cameraController.m_CameraSystem = World.DefaultGameObjectInjectionWorld.GetOrCreateSystemManaged<CameraUpdateSystem>();
      cameraController.m_CameraSystem.gamePlayController = cameraController;
      cameraController.m_CollisionSystem = World.DefaultGameObjectInjectionWorld.GetOrCreateSystemManaged<CameraCollisionSystem>();
    }

    public void UpdateCamera()
    {
      if (this.m_MapTileToolViewEnabled && this.HandleMapViewCamera())
        return;
      float2 float2_1 = float2.zero;
      float2 x1 = float2.zero;
      float x2 = 0.0f;
      bool flag = false;
      if (this.m_CameraMap.enabled && this.inputEnabled)
      {
        Vector2 vector2_1 = this.m_MoveAction.ReadValue<Vector2>();
        Vector2 vector2_2 = this.m_MoveFastAction.ReadValue<Vector2>();
        float2_1.x = (double) Mathf.Abs(vector2_1.x) >= (double) Mathf.Abs(vector2_2.x) ? vector2_1.x : vector2_2.x;
        float2_1.y = (double) Mathf.Abs(vector2_1.y) >= (double) Mathf.Abs(vector2_2.y) ? vector2_1.y : vector2_2.y;
        float2_1 = (float2) CameraController.SmoothTime((Vector2) float2_1, ref this.m_LastMoveInput, this.m_MoveSmoothing);
        x1 = (float2) CameraController.SmoothTime(this.m_RotateAction.ReadValue<Vector2>(), ref this.m_LastRotateInput, this.m_RotateSmoothing);
        float2 x3 = (float2) CameraController.Smooth(this.m_MouseRotateAction.ReadValue<Vector2>(), ref this.m_LastMouseRotateInput, this.m_RotateSmoothing);
        if ((double) math.lengthsq(x3) > (double) math.lengthsq(x1))
          x1 = x3;
        x2 = CameraController.SmoothTime(this.m_ZoomAction.ReadValue<float>(), ref this.m_LastZoomInput, this.m_ZoomSmoothing);
        float x4 = CameraController.Smooth(this.m_MouseZoomAction.ReadValue<float>(), ref this.m_LastMouseZoomInput, this.m_ZoomSmoothing);
        if ((double) math.abs(x4) > (double) math.abs(x2))
          x2 = x4;
        if (this.edgeScrolling && InputManager.instance.activeControlScheme == InputManager.ControlScheme.KeyboardAndMouse && InputManager.instance.mouseOnScreen)
        {
          float num1 = 1f;
          float2 x5 = ((float3) InputManager.instance.mousePosition).xy * (2f / new float2((float) Screen.width, (float) Screen.height)) - 1f;
          float y = 0.02f;
          float2 float2_2 = new float2((float) Screen.height / (float) Screen.width * y, y);
          float num2 = num1 * math.saturate(math.cmax((math.abs(x5) - (1f - float2_2)) / float2_2)) * Time.deltaTime;
          float2_1 += math.normalizesafe(x5) * num2;
        }
      }
      else
      {
        this.m_LastMoveInput = Vector2.zero;
        this.m_LastRotateInput = Vector2.zero;
        this.m_LastMouseRotateInput = Vector2.zero;
        this.m_LastZoomInput = 0.0f;
        this.m_LastMouseZoomInput = 0.0f;
      }
      double zoom1 = (double) this.m_Zoom;
      this.m_Zoom = MathUtils.Clamp(math.pow(this.m_Zoom, 1f + x2), this.zoomRange);
      double zoom2 = (double) this.m_Zoom;
      if (zoom1 != zoom2)
        flag = true;
      x1.y = -x1.y;
      this.m_Angle += x1;
      this.m_Angle.y = math.clamp(this.m_Angle.y, -90f, 90f);
      if ((double) this.m_Angle.x < -180.0)
        this.m_Angle.x += 360f;
      if ((double) this.m_Angle.x > 180.0)
        this.m_Angle.x -= 360f;
      float2 float2_3 = math.radians(this.m_Angle);
      float3 cameraOffset;
      cameraOffset.x = -math.sin(float2_3.x);
      cameraOffset.y = 0.0f;
      cameraOffset.z = -math.cos(float2_3.x);
      float3 x6 = cameraOffset;
      cameraOffset *= math.cos(float2_3.y);
      cameraOffset.y = math.sin(float2_3.y);
      float3 float3 = -cameraOffset;
      cameraOffset *= this.m_Zoom;
      float3 y1 = math.cross(x6, new float3(0.0f, 1f, 0.0f));
      float3 up = math.cross(float3, y1);
      float2_1 *= this.m_Zoom;
      this.m_Pivot += float2_1.x * y1;
      this.m_Pivot -= float2_1.y * x6;
      float3 cameraPos = this.GetCameraPos(cameraOffset);
      if (this.terrainSystem != null)
      {
        // ISSUE: reference to a compiler-generated method
        TerrainHeightData heightData = this.terrainSystem.GetHeightData();
        WaterSurfaceData data = new WaterSurfaceData();
        if (this.waterSystem != null && this.waterSystem.Loaded)
        {
          JobHandle deps;
          // ISSUE: reference to a compiler-generated method
          data = this.waterSystem.GetSurfaceData(out deps);
          deps.Complete();
        }
        if (heightData.isCreated)
        {
          this.m_Pivot.y = !data.isCreated ? math.lerp(TerrainUtils.SampleHeight(ref heightData, this.m_Pivot), this.m_Pivot.y, this.m_MoveSmoothing) : math.lerp(WaterUtils.SampleHeight(ref data, ref heightData, this.m_Pivot), this.m_Pivot.y, this.m_MoveSmoothing);
          this.m_Pivot = MathUtils.Clamp(this.m_Pivot, GameManager.instance.gameMode.IsEditor() ? TerrainUtils.GetEditorCameraBounds(this.terrainSystem, ref heightData) : TerrainUtils.GetBounds(ref heightData));
          cameraPos = this.GetCameraPos(cameraOffset);
          float num3 = !data.isCreated ? (float) ((double) TerrainUtils.SampleHeight(ref heightData, cameraPos) + (double) this.zoomRange.min * 0.5 + ((double) this.m_Zoom - (double) this.zoomRange.min) * 0.10000000149011612) : (float) ((double) WaterUtils.SampleHeight(ref data, ref heightData, cameraPos) + (double) this.zoomRange.min * 0.5 + ((double) this.m_Zoom - (double) this.zoomRange.min) * 0.10000000149011612);
          float num4 = (cameraPos.y - num3) / this.m_Zoom;
          float num5 = (float) (((double) math.sqrt((float) ((double) num4 * (double) num4 + 0.20000000298023224)) - (double) num4) * (0.5 * (double) this.m_Zoom));
          cameraPos.y += num5;
        }
      }
      float3 cameraPosition = this.cameraPosition;
      quaternion rotation = quaternion.LookRotation(float3, up);
      if (this.m_CollisionSystem != null && this.m_CameraSystem != null && (UnityEngine.Object) this.m_CameraSystem.activeCamera != (UnityEngine.Object) null)
      {
        float nearClipPlane = this.m_CameraSystem.activeCamera.nearClipPlane;
        float2 fieldOfView;
        fieldOfView.y = this.m_CameraSystem.activeCamera.fieldOfView;
        fieldOfView.x = Camera.VerticalToHorizontalFieldOfView(fieldOfView.y, this.m_CameraSystem.activeCamera.aspect);
        // ISSUE: reference to a compiler-generated method
        this.m_CollisionSystem.CheckCollisions(ref cameraPos, cameraPosition, rotation, math.min(this.m_Zoom - this.zoomRange.min, 200f), math.min(this.zoomRange.max - this.m_Zoom, 200f), math.max(nearClipPlane * 2f, this.zoomRange.min * 0.5f), nearClipPlane, this.m_CollisionSmoothing, fieldOfView);
      }
      Quaternion localRotation = this.transform.localRotation;
      this.cameraPosition = cameraPos;
      this.transform.localPosition = (Vector3) cameraPos;
      this.transform.localRotation = (Quaternion) rotation;
      this.velocity = math.lengthsq(cameraPosition - this.cameraPosition) / Time.deltaTime;
      if (!localRotation.Equals(this.transform.localRotation) || !cameraPosition.Equals(this.cameraPosition))
        flag = true;
      if (this.moving != flag)
      {
        Action<bool> cameraMovingChanged = this.EventCameraMovingChanged;
        if (cameraMovingChanged != null)
          cameraMovingChanged(flag);
        this.moving = flag;
      }
      // ISSUE: reference to a compiler-generated method
      AudioManager.instance?.UpdateAudioListener(this.transform.position, this.transform.rotation);
    }

    private float3 GetCameraPos(float3 cameraOffset)
    {
      float3 cameraPos = this.m_Pivot + cameraOffset;
      cameraPos.y += this.zoomRange.min * 0.5f;
      return cameraPos;
    }

    public static float SmoothTime(float value, ref float lastValue, float smoothing)
    {
      return CameraController.Smooth(value, ref lastValue, smoothing) * Time.deltaTime;
    }

    public static float Smooth(float value, ref float lastValue, float smoothing)
    {
      if ((double) smoothing > 0.0)
      {
        smoothing = Mathf.Pow(smoothing, Time.deltaTime);
        value = Mathf.Lerp(value, lastValue, smoothing);
      }
      lastValue = value;
      return value;
    }

    public static Vector2 SmoothTime(Vector2 value, ref Vector2 lastValue, float smoothing)
    {
      return CameraController.Smooth(value, ref lastValue, smoothing) * Time.deltaTime;
    }

    public static Vector2 Smooth(Vector2 value, ref Vector2 lastValue, float smoothing)
    {
      if ((double) smoothing > 0.0)
      {
        smoothing = Mathf.Pow(smoothing, Time.deltaTime);
        value = Vector2.Lerp(value, lastValue, smoothing);
      }
      lastValue = value;
      return value;
    }

    private bool HandleMapViewCamera()
    {
      float y1;
      float2 to;
      float3 y2;
      float t;
      if (!MapTilesUISystem.mapTileViewActive)
      {
        if ((double) this.m_MapViewTimer == 0.0)
          return false;
        if ((double) Mathf.Abs(this.m_MapViewTimer - this.m_MapTileToolTransitionTime) < (double) Mathf.Epsilon)
        {
          this.m_Zoom = this.m_LastGameViewZoom;
          this.m_Angle = this.m_LastGameViewAngle;
          this.m_Pivot = this.m_LastGameViewPivot;
        }
        y1 = this.m_LastMapViewZoom;
        to = this.m_LastMapViewAngle;
        y2 = this.m_LastMapViewPivot;
        this.m_MapViewTimer = math.max(this.m_MapViewTimer - Time.deltaTime, 0.0f);
        t = (double) this.m_MapTileToolTransitionTime > 0.0 ? this.m_MapViewTimer / this.m_MapTileToolTransitionTime : 0.0f;
      }
      else
      {
        this.m_LastMapViewAngle = this.m_Angle;
        this.m_LastMapViewZoom = this.m_Zoom;
        this.m_LastMapViewPivot = this.m_Pivot;
        if ((double) Mathf.Abs(this.m_MapViewTimer - this.m_MapTileToolTransitionTime) < (double) Mathf.Epsilon)
          return false;
        this.m_MapViewTimer = math.min(this.m_MapViewTimer + Time.deltaTime, this.m_MapTileToolTransitionTime);
        t = (double) this.m_MapTileToolTransitionTime > 0.0 ? this.m_MapViewTimer / this.m_MapTileToolTransitionTime : 1f;
        if ((double) Mathf.Abs(t - 1f) < (double) Mathf.Epsilon)
        {
          this.m_LastGameViewZoom = this.m_Zoom;
          this.m_LastGameViewAngle = this.m_Angle;
          this.m_LastGameViewPivot = this.m_Pivot;
          this.m_Zoom = this.m_MapTileToolZoom;
          this.m_Angle = new float2(Mathf.Round(this.m_Angle.x / 90f) * 90f, this.m_MapTileToolAngle.y);
          this.m_Pivot = this.m_MapTileToolPivot;
        }
        y1 = this.m_MapTileToolZoom;
        to = new float2(Mathf.Round(this.m_Angle.x / 90f) * 90f, this.m_MapTileToolAngle.y);
        y2 = this.m_MapTileToolPivot;
      }
      float num1 = Mathf.SmoothStep(0.0f, 1f, t);
      float3 float3_1 = math.lerp(this.m_Pivot, y2, num1);
      float2 x1 = CameraController.LerpAngle(this.m_Angle, to, num1);
      float num2 = math.lerp(this.m_Zoom, y1, num1);
      this.m_VCam.m_Lens.FarClipPlane = math.lerp(this.m_InitialFarClip, this.m_MapTileToolFarclip, num1);
      this.m_VCam.m_Lens.FieldOfView = math.lerp(this.m_InitialFov, this.m_MapTileToolFOV, num1);
      float2 float2 = math.radians(x1);
      float3 float3_2;
      float3_2.x = -math.sin(float2.x);
      float3_2.y = 0.0f;
      float3_2.z = -math.cos(float2.x);
      float3 x2 = float3_2;
      float3_2 *= math.cos(float2.y);
      float3_2.y = math.sin(float2.y);
      float3 float3_3 = -float3_2;
      float3_2 *= num2;
      float3 worldPosition = float3_1 + float3_2;
      worldPosition.y += this.zoomRange.min * 0.5f;
      float3 y3 = new float3(0.0f, 1f, 0.0f);
      float3 y4 = math.cross(x2, y3);
      float3 up = math.cross(float3_3, y4);
      if (this.terrainSystem != null)
      {
        // ISSUE: reference to a compiler-generated method
        TerrainHeightData heightData = this.terrainSystem.GetHeightData();
        WaterSurfaceData data = new WaterSurfaceData();
        if (this.waterSystem != null)
        {
          JobHandle deps;
          // ISSUE: reference to a compiler-generated method
          data = this.waterSystem.GetSurfaceData(out deps);
          deps.Complete();
        }
        if (heightData.isCreated)
        {
          float num3 = !data.isCreated ? (float) ((double) TerrainUtils.SampleHeight(ref heightData, worldPosition) + (double) this.zoomRange.min * 0.5 + ((double) num2 - (double) this.zoomRange.min) * 0.10000000149011612) : (float) ((double) WaterUtils.SampleHeight(ref data, ref heightData, worldPosition) + (double) this.zoomRange.min * 0.5 + ((double) num2 - (double) this.zoomRange.min) * 0.10000000149011612);
          float num4 = (worldPosition.y - num3) / num2;
          float num5 = (float) (((double) math.sqrt((float) ((double) num4 * (double) num4 + 0.20000000298023224)) - (double) num4) * (0.5 * (double) num2));
          worldPosition.y += num5;
        }
      }
      this.transform.localPosition = (Vector3) worldPosition;
      this.transform.localRotation = (Quaternion) quaternion.LookRotation(float3_3, up);
      return true;
    }

    public static float2 LerpAngle(float2 from, float2 to, float t)
    {
      float num = (float) ((((double) to.x - (double) from.x) % 360.0 + 540.0) % 360.0 - 180.0);
      return new float2(from.x + (float) ((double) num * (double) t % 360.0), math.lerp(from.y, to.y, t));
    }

    private bool TryGetTerrainHeight(Vector3 pos, out float terrainHeight)
    {
      if (this.terrainSystem != null)
      {
        // ISSUE: reference to a compiler-generated method
        TerrainHeightData heightData = this.terrainSystem.GetHeightData();
        WaterSurfaceData data = new WaterSurfaceData();
        if (this.waterSystem != null)
        {
          JobHandle deps;
          // ISSUE: reference to a compiler-generated method
          data = this.waterSystem.GetSurfaceData(out deps);
          deps.Complete();
        }
        if (heightData.isCreated)
        {
          terrainHeight = !data.isCreated ? TerrainUtils.SampleHeight(ref heightData, (float3) pos) : WaterUtils.SampleHeight(ref data, ref heightData, (float3) pos);
          return true;
        }
      }
      terrainHeight = 0.0f;
      return false;
    }

    public static bool TryGet(out CameraController cameraController)
    {
      GameObject gameObjectWithTag = GameObject.FindGameObjectWithTag("GameplayCamera");
      if ((UnityEngine.Object) gameObjectWithTag != (UnityEngine.Object) null)
      {
        cameraController = gameObjectWithTag.GetComponent<CameraController>();
        return (UnityEngine.Object) cameraController != (UnityEngine.Object) null;
      }
      cameraController = (CameraController) null;
      return false;
    }
  }
}
