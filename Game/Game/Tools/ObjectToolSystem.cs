// Decompiled with JetBrains decompiler
// Type: Game.Tools.ObjectToolSystem
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Annotations;
using Colossal.Collections;
using Colossal.Entities;
using Colossal.Mathematics;
using Game.Areas;
using Game.Audio;
using Game.Buildings;
using Game.City;
using Game.Common;
using Game.Input;
using Game.Net;
using Game.Objects;
using Game.Prefabs;
using Game.Simulation;
using Game.Zones;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;

#nullable disable
namespace Game.Tools
{
  [CompilerGenerated]
  public class ObjectToolSystem : ObjectToolBaseSystem
  {
    public const string kToolID = "Object Tool";
    private AreaToolSystem m_AreaToolSystem;
    private Game.Net.SearchSystem m_NetSearchSystem;
    private Game.Zones.SearchSystem m_ZoneSearchSystem;
    private CityConfigurationSystem m_CityConfigurationSystem;
    private AudioManager m_AudioManager;
    private EntityQuery m_DefinitionQuery;
    private EntityQuery m_TempQuery;
    private EntityQuery m_ContainerQuery;
    private EntityQuery m_BrushQuery;
    private EntityQuery m_LotQuery;
    private EntityQuery m_BuildingQuery;
    private EntityQuery m_VisibleQuery;
    private UIInputAction.State m_EraseObject;
    private UIInputAction.State m_MoveObject;
    private UIInputAction.State m_PaintObject;
    private UIInputAction.State m_PlaceObject;
    private UIInputAction.State m_PlaceUpgrade;
    private UIInputAction.State m_PreciseRotation;
    private UIInputAction.State m_RotateObject;
    private NativeList<ControlPoint> m_ControlPoints;
    private NativeList<SubSnapPoint> m_SubSnapPoints;
    private NativeValue<ObjectToolSystem.Rotation> m_Rotation;
    private ControlPoint m_LastRaycastPoint;
    private ControlPoint m_StartPoint;
    private Entity m_UpgradingObject;
    private Entity m_MovingObject;
    private Entity m_MovingInitialized;
    private ObjectToolSystem.State m_State;
    private bool m_RotationModified;
    private bool m_ForceCancel;
    private float3 m_RotationStartPosition;
    private quaternion m_StartRotation;
    private float m_StartCameraAngle;
    private EntityQuery m_SoundQuery;
    private RandomSeed m_RandomSeed;
    private ObjectPrefab m_Prefab;
    private ObjectPrefab m_SelectedPrefab;
    private TransformPrefab m_TransformPrefab;
    private CameraController m_CameraController;
    private ObjectToolSystem.TypeHandle __TypeHandle;

    public override string toolID => "Object Tool";

    public override int uiModeIndex => (int) this.actualMode;

    public override void GetUIModes(List<ToolMode> modes)
    {
      // ISSUE: variable of a compiler-generated type
      ObjectToolSystem.Mode mode1 = this.mode;
      switch (mode1)
      {
        case ObjectToolSystem.Mode.Create:
        case ObjectToolSystem.Mode.Brush:
        case ObjectToolSystem.Mode.Stamp:
          if (this.allowCreate)
          {
            List<ToolMode> toolModeList = modes;
            // ISSUE: variable of a compiler-generated type
            ObjectToolSystem.Mode mode2 = ObjectToolSystem.Mode.Create;
            ToolMode toolMode = new ToolMode(mode2.ToString(), 0);
            toolModeList.Add(toolMode);
          }
          if (this.allowBrush)
          {
            List<ToolMode> toolModeList = modes;
            // ISSUE: variable of a compiler-generated type
            ObjectToolSystem.Mode mode3 = ObjectToolSystem.Mode.Brush;
            ToolMode toolMode = new ToolMode(mode3.ToString(), 3);
            toolModeList.Add(toolMode);
          }
          if (!this.allowStamp)
            break;
          List<ToolMode> toolModeList1 = modes;
          // ISSUE: variable of a compiler-generated type
          ObjectToolSystem.Mode mode4 = ObjectToolSystem.Mode.Stamp;
          ToolMode toolMode1 = new ToolMode(mode4.ToString(), 4);
          toolModeList1.Add(toolMode1);
          break;
      }
    }

    public ObjectToolSystem.Mode mode { get; set; }

    public ObjectToolSystem.Mode actualMode
    {
      get
      {
        ObjectToolSystem.Mode actualMode = this.mode;
        if (!this.allowBrush && actualMode == ObjectToolSystem.Mode.Brush)
          actualMode = ObjectToolSystem.Mode.Create;
        if (!this.allowStamp && actualMode == ObjectToolSystem.Mode.Stamp)
          actualMode = ObjectToolSystem.Mode.Create;
        if (!this.allowCreate && this.allowBrush && actualMode == ObjectToolSystem.Mode.Create)
          actualMode = ObjectToolSystem.Mode.Brush;
        if (!this.allowCreate && this.allowStamp && actualMode == ObjectToolSystem.Mode.Create)
          actualMode = ObjectToolSystem.Mode.Stamp;
        return actualMode;
      }
    }

    public AgeMask ageMask { get; set; }

    public AgeMask actualAgeMask
    {
      get
      {
        return !this.allowAge || (this.ageMask & (AgeMask.Sapling | AgeMask.Young | AgeMask.Mature | AgeMask.Elderly)) == (AgeMask) 0 ? AgeMask.Sapling : this.ageMask;
      }
    }

    [CanBeNull]
    public ObjectPrefab prefab
    {
      get => this.m_SelectedPrefab;
      set
      {
        if (!((UnityEngine.Object) value != (UnityEngine.Object) this.m_SelectedPrefab))
          return;
        this.m_SelectedPrefab = value;
        this.m_ForceUpdate = true;
        this.allowCreate = true;
        this.allowBrush = false;
        this.allowStamp = false;
        this.allowAge = false;
        if ((UnityEngine.Object) value != (UnityEngine.Object) null)
        {
          this.m_TransformPrefab = (TransformPrefab) null;
          ObjectGeometryData component;
          if (this.m_PrefabSystem.TryGetComponentData<ObjectGeometryData>((PrefabBase) this.m_SelectedPrefab, out component))
          {
            this.allowBrush = (component.m_Flags & Game.Objects.GeometryFlags.Brushable) != 0;
            this.allowStamp = (component.m_Flags & Game.Objects.GeometryFlags.Stampable) != 0;
            this.allowCreate = !this.allowStamp || this.m_ToolSystem.actionMode.IsEditor();
          }
          this.allowAge = this.m_ToolSystem.actionMode.IsGame() && this.m_PrefabSystem.HasComponent<TreeData>((PrefabBase) this.m_SelectedPrefab);
        }
        Action<PrefabBase> eventPrefabChanged = this.m_ToolSystem.EventPrefabChanged;
        if (eventPrefabChanged == null)
          return;
        eventPrefabChanged((PrefabBase) value);
      }
    }

    public TransformPrefab transform
    {
      get => this.m_TransformPrefab;
      set
      {
        if (!((UnityEngine.Object) value != (UnityEngine.Object) this.m_TransformPrefab))
          return;
        this.m_TransformPrefab = value;
        this.m_ForceUpdate = true;
        if ((UnityEngine.Object) value != (UnityEngine.Object) null)
        {
          this.m_SelectedPrefab = (ObjectPrefab) null;
          this.allowCreate = true;
          this.allowBrush = false;
          this.allowStamp = false;
          this.allowAge = false;
        }
        Action<PrefabBase> eventPrefabChanged = this.m_ToolSystem.EventPrefabChanged;
        if (eventPrefabChanged == null)
          return;
        eventPrefabChanged((PrefabBase) value);
      }
    }

    public bool underground { get; set; }

    public bool allowCreate { get; private set; }

    public bool allowBrush { get; private set; }

    public bool allowStamp { get; private set; }

    public bool allowAge { get; private set; }

    public override bool brushing => this.actualMode == ObjectToolSystem.Mode.Brush;

    protected override IEnumerable<UIInputAction.State> toolActions
    {
      get
      {
        yield return this.m_EraseObject;
        yield return this.m_MoveObject;
        yield return this.m_PaintObject;
        yield return this.m_PlaceObject;
        yield return this.m_PlaceUpgrade;
        yield return this.m_PreciseRotation;
        yield return this.m_RotateObject;
      }
    }

    [UnityEngine.Scripting.Preserve]
    protected override void OnCreate()
    {
      // ISSUE: reference to a compiler-generated method
      base.OnCreate();
      // ISSUE: reference to a compiler-generated field
      this.m_ToolOutputBarrier = this.World.GetOrCreateSystemManaged<ToolOutputBarrier>();
      // ISSUE: reference to a compiler-generated field
      this.m_AreaToolSystem = this.World.GetOrCreateSystemManaged<AreaToolSystem>();
      // ISSUE: reference to a compiler-generated field
      this.m_ObjectSearchSystem = this.World.GetOrCreateSystemManaged<Game.Objects.SearchSystem>();
      // ISSUE: reference to a compiler-generated field
      this.m_NetSearchSystem = this.World.GetOrCreateSystemManaged<Game.Net.SearchSystem>();
      // ISSUE: reference to a compiler-generated field
      this.m_ZoneSearchSystem = this.World.GetOrCreateSystemManaged<Game.Zones.SearchSystem>();
      // ISSUE: reference to a compiler-generated field
      this.m_WaterSystem = this.World.GetOrCreateSystemManaged<WaterSystem>();
      // ISSUE: reference to a compiler-generated field
      this.m_TerrainSystem = this.World.GetOrCreateSystemManaged<TerrainSystem>();
      // ISSUE: reference to a compiler-generated field
      this.m_CityConfigurationSystem = this.World.GetOrCreateSystemManaged<CityConfigurationSystem>();
      // ISSUE: reference to a compiler-generated field
      this.m_AudioManager = this.World.GetOrCreateSystemManaged<AudioManager>();
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated method
      this.m_DefinitionQuery = this.GetDefinitionQuery();
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated method
      this.m_ContainerQuery = this.GetContainerQuery();
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated method
      this.m_BrushQuery = this.GetBrushQuery();
      // ISSUE: reference to a compiler-generated field
      this.m_ControlPoints = new NativeList<ControlPoint>(1, (AllocatorManager.AllocatorHandle) Allocator.Persistent);
      // ISSUE: reference to a compiler-generated field
      this.m_SubSnapPoints = new NativeList<SubSnapPoint>(10, (AllocatorManager.AllocatorHandle) Allocator.Persistent);
      // ISSUE: reference to a compiler-generated field
      this.m_Rotation = new NativeValue<ObjectToolSystem.Rotation>(Allocator.Persistent);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: object of a compiler-generated type is created
      this.m_Rotation.value = new ObjectToolSystem.Rotation()
      {
        m_Rotation = quaternion.identity,
        m_ParentRotation = quaternion.identity,
        m_IsAligned = true
      };
      // ISSUE: reference to a compiler-generated field
      this.m_SoundQuery = this.GetEntityQuery(ComponentType.ReadOnly<ToolUXSoundSettingsData>());
      // ISSUE: reference to a compiler-generated field
      this.m_LotQuery = this.GetEntityQuery(ComponentType.ReadOnly<Game.Areas.Lot>(), ComponentType.ReadOnly<Temp>());
      // ISSUE: reference to a compiler-generated field
      this.m_BuildingQuery = this.GetEntityQuery(ComponentType.ReadOnly<Game.Prefabs.BuildingData>(), ComponentType.ReadOnly<SpawnableBuildingData>(), ComponentType.ReadOnly<BuildingSpawnGroupData>(), ComponentType.ReadOnly<PrefabData>());
      // ISSUE: reference to a compiler-generated field
      this.m_TempQuery = this.GetEntityQuery(ComponentType.ReadOnly<Temp>());
      // ISSUE: reference to a compiler-generated field
      this.m_VisibleQuery = this.GetEntityQuery(ComponentType.ReadOnly<Brush>(), ComponentType.Exclude<Hidden>(), ComponentType.Exclude<Deleted>());
      // ISSUE: reference to a compiler-generated field
      this.m_EraseObject = InputManager.instance.toolActionCollection.GetActionState("Erase Object", nameof (ObjectToolSystem));
      // ISSUE: reference to a compiler-generated field
      this.m_MoveObject = InputManager.instance.toolActionCollection.GetActionState("Move Object", nameof (ObjectToolSystem));
      // ISSUE: reference to a compiler-generated field
      this.m_PaintObject = InputManager.instance.toolActionCollection.GetActionState("Paint Object", nameof (ObjectToolSystem));
      // ISSUE: reference to a compiler-generated field
      this.m_PlaceObject = InputManager.instance.toolActionCollection.GetActionState("Place Object", nameof (ObjectToolSystem));
      // ISSUE: reference to a compiler-generated field
      this.m_PlaceUpgrade = InputManager.instance.toolActionCollection.GetActionState("Place Upgrade", nameof (ObjectToolSystem));
      // ISSUE: reference to a compiler-generated field
      this.m_PreciseRotation = InputManager.instance.toolActionCollection.GetActionState("Precise Rotation", nameof (ObjectToolSystem));
      // ISSUE: reference to a compiler-generated field
      this.m_RotateObject = InputManager.instance.toolActionCollection.GetActionState("Rotate Object", nameof (ObjectToolSystem));
      this.brushSize = 200f;
      this.brushAngle = 0.0f;
      this.brushStrength = 0.5f;
      this.selectedSnap &= ~(Snap.AutoParent | Snap.ContourLines);
      this.ageMask = AgeMask.Sapling;
    }

    protected override void OnGameLoaded(Colossal.Serialization.Entities.Context serializationContext)
    {
      base.OnGameLoaded(serializationContext);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated method
      this.brushType = this.FindDefaultBrush(this.m_BrushQuery);
      this.brushSize = 200f;
      this.brushAngle = 0.0f;
      this.brushStrength = 0.5f;
    }

    [UnityEngine.Scripting.Preserve]
    protected override void OnDestroy()
    {
      // ISSUE: reference to a compiler-generated field
      this.m_ControlPoints.Dispose();
      // ISSUE: reference to a compiler-generated field
      this.m_SubSnapPoints.Dispose();
      // ISSUE: reference to a compiler-generated field
      this.m_Rotation.Dispose();
      base.OnDestroy();
    }

    [UnityEngine.Scripting.Preserve]
    protected override void OnStartRunning()
    {
      // ISSUE: reference to a compiler-generated method
      base.OnStartRunning();
      // ISSUE: reference to a compiler-generated field
      this.m_ControlPoints.Clear();
      // ISSUE: reference to a compiler-generated field
      this.m_SubSnapPoints.Clear();
      // ISSUE: reference to a compiler-generated field
      this.m_LastRaycastPoint = new ControlPoint();
      // ISSUE: reference to a compiler-generated field
      this.m_StartPoint = new ControlPoint();
      // ISSUE: reference to a compiler-generated field
      this.m_State = ObjectToolSystem.State.Default;
      // ISSUE: reference to a compiler-generated field
      this.m_MovingInitialized = Entity.Null;
      // ISSUE: reference to a compiler-generated field
      this.m_ForceCancel = false;
      // ISSUE: reference to a compiler-generated method
      this.Randomize();
      this.requireZones = false;
      this.requireUnderground = false;
      this.requireNetArrows = false;
      this.requireAreas = AreaTypeMask.Lots;
      this.requireNet = Layer.None;
      // ISSUE: reference to a compiler-generated field
      if (!this.m_ToolSystem.actionMode.IsEditor())
        return;
      this.requireAreas |= AreaTypeMask.Spaces;
    }

    private protected override void SetActions()
    {
      // ISSUE: reference to a compiler-generated method
      base.SetActions();
      // ISSUE: reference to a compiler-generated field
      this.cancelActionOverride = this.m_MouseCancel;
      this.applyAction.enabled = true;
      // ISSUE: reference to a compiler-generated method
      this.UpdateActions();
    }

    private protected override void ResetActions()
    {
      // ISSUE: reference to a compiler-generated method
      base.ResetActions();
      // ISSUE: reference to a compiler-generated field
      this.m_PreciseRotation.enabled = false;
    }

    public override void ToggleToolOptions(bool enabled)
    {
      this.applyAction.enabled = !enabled;
      // ISSUE: reference to a compiler-generated method
      this.UpdateActions();
    }

    public override PrefabBase GetPrefab()
    {
      // ISSUE: variable of a compiler-generated type
      ObjectToolSystem.Mode actualMode = this.actualMode;
      switch (actualMode)
      {
        case ObjectToolSystem.Mode.Create:
        case ObjectToolSystem.Mode.Brush:
        case ObjectToolSystem.Mode.Stamp:
          return !((UnityEngine.Object) this.prefab != (UnityEngine.Object) null) ? (PrefabBase) this.transform : (PrefabBase) this.prefab;
        default:
          return (PrefabBase) null;
      }
    }

    private void UpdateActions()
    {
      this.secondaryApplyAction.enabled = this.applyAction.enabled;
      this.cancelAction.enabled = this.applyAction.enabled && this.actualMode == ObjectToolSystem.Mode.Upgrade;
      // ISSUE: reference to a compiler-generated field
      this.m_PreciseRotation.enabled = this.applyAction.enabled && this.actualMode != ObjectToolSystem.Mode.Brush && (InputManager.instance.activeControlScheme != InputManager.ControlScheme.KeyboardAndMouse || !InputManager.instance.mouseOverUI);
      if (this.actualMode == ObjectToolSystem.Mode.Upgrade)
      {
        // ISSUE: reference to a compiler-generated field
        this.applyActionOverride = this.m_PlaceUpgrade;
        // ISSUE: reference to a compiler-generated field
        this.secondaryApplyActionOverride = this.m_RotateObject;
      }
      else if (this.actualMode == ObjectToolSystem.Mode.Move)
      {
        // ISSUE: reference to a compiler-generated field
        this.applyActionOverride = this.m_MoveObject;
        // ISSUE: reference to a compiler-generated field
        this.secondaryApplyActionOverride = this.m_RotateObject;
      }
      else if (this.actualMode == ObjectToolSystem.Mode.Brush)
      {
        // ISSUE: reference to a compiler-generated field
        this.applyActionOverride = this.m_PaintObject;
        // ISSUE: reference to a compiler-generated field
        this.secondaryApplyActionOverride = this.m_EraseObject;
      }
      else
      {
        // ISSUE: reference to a compiler-generated field
        this.applyActionOverride = this.m_PlaceObject;
        // ISSUE: reference to a compiler-generated field
        this.secondaryApplyActionOverride = this.m_RotateObject;
      }
    }

    public NativeList<ControlPoint> GetControlPoints(out JobHandle dependencies)
    {
      dependencies = this.Dependency;
      // ISSUE: reference to a compiler-generated field
      return this.m_ControlPoints;
    }

    public NativeList<SubSnapPoint> GetSubSnapPoints(out JobHandle dependencies)
    {
      dependencies = this.Dependency;
      // ISSUE: reference to a compiler-generated field
      return this.m_SubSnapPoints;
    }

    protected override bool GetAllowApply()
    {
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated field
      return base.GetAllowApply() && !this.m_TempQuery.IsEmptyIgnoreFilter;
    }

    public override bool TrySetPrefab(PrefabBase prefab)
    {
      switch (prefab)
      {
        case ObjectPrefab objectPrefab:
          // ISSUE: variable of a compiler-generated type
          ObjectToolSystem.Mode mode = this.mode;
          // ISSUE: reference to a compiler-generated field
          if (!this.m_ToolSystem.actionMode.IsEditor() && prefab.Has<Game.Prefabs.ServiceUpgrade>())
          {
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated method
            Entity entity = this.m_PrefabSystem.GetEntity(prefab);
            this.CheckedStateRef.EntityManager.CompleteDependencyBeforeRO<PlaceableObjectData>();
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            this.__TypeHandle.__Game_Prefabs_PlaceableObjectData_RO_ComponentLookup.Update(ref this.CheckedStateRef);
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            if (!this.__TypeHandle.__Game_Prefabs_PlaceableObjectData_RO_ComponentLookup.HasComponent(entity))
              return false;
            mode = ObjectToolSystem.Mode.Upgrade;
          }
          else if (mode == ObjectToolSystem.Mode.Upgrade || mode == ObjectToolSystem.Mode.Move)
            mode = ObjectToolSystem.Mode.Create;
          this.prefab = objectPrefab;
          this.mode = mode;
          return true;
        case TransformPrefab transformPrefab:
          this.transform = transformPrefab;
          this.mode = ObjectToolSystem.Mode.Create;
          return true;
        default:
          return false;
      }
    }

    public void StartMoving(Entity movingObject)
    {
      // ISSUE: reference to a compiler-generated field
      this.m_MovingObject = movingObject;
      Owner component;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      if (this.m_ToolSystem.actionMode.IsEditor() && this.EntityManager.HasComponent<Game.Buildings.ServiceUpgrade>(this.m_MovingObject) && this.EntityManager.TryGetComponent<Owner>(this.m_MovingObject, out component))
      {
        // ISSUE: reference to a compiler-generated field
        this.m_MovingObject = component.m_Owner;
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated method
      this.m_AudioManager.PlayUISound(this.m_SoundQuery.GetSingleton<ToolUXSoundSettingsData>().m_RelocateBuildingSound);
      this.mode = ObjectToolSystem.Mode.Move;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated method
      this.prefab = this.m_PrefabSystem.GetPrefab<ObjectPrefab>(this.EntityManager.GetComponentData<PrefabRef>(this.m_MovingObject));
    }

    private void Randomize()
    {
      // ISSUE: reference to a compiler-generated field
      this.m_RandomSeed = RandomSeed.Next();
      PlaceableObjectData component;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated method
      if (!((UnityEngine.Object) this.m_SelectedPrefab != (UnityEngine.Object) null) || !this.m_PrefabSystem.TryGetComponentData<PlaceableObjectData>((PrefabBase) this.m_SelectedPrefab, out component) || component.m_RotationSymmetry == RotationSymmetry.None)
        return;
      // ISSUE: reference to a compiler-generated field
      Unity.Mathematics.Random random = this.m_RandomSeed.GetRandom(567890109);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: variable of a compiler-generated type
      ObjectToolSystem.Rotation rotation = this.m_Rotation.value;
      float max = 6.28318548f;
      float angle;
      if (component.m_RotationSymmetry == RotationSymmetry.Any)
      {
        angle = random.NextFloat(max);
        // ISSUE: reference to a compiler-generated field
        rotation.m_IsAligned = false;
      }
      else
        angle = max * ((float) random.NextInt((int) component.m_RotationSymmetry) / (float) component.m_RotationSymmetry);
      if ((component.m_Flags & Game.Objects.PlacementFlags.Wall) != Game.Objects.PlacementFlags.None)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        rotation.m_Rotation = math.normalizesafe(math.mul(rotation.m_Rotation, quaternion.RotateZ(angle)), quaternion.identity);
        // ISSUE: reference to a compiler-generated field
        if (rotation.m_IsAligned)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated method
          ObjectToolSystem.SnapJob.AlignRotation(ref rotation.m_Rotation, rotation.m_ParentRotation, true);
        }
      }
      else
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        rotation.m_Rotation = math.normalizesafe(math.mul(rotation.m_Rotation, quaternion.RotateY(angle)), quaternion.identity);
        // ISSUE: reference to a compiler-generated field
        if (rotation.m_IsAligned)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated method
          ObjectToolSystem.SnapJob.AlignRotation(ref rotation.m_Rotation, rotation.m_ParentRotation, false);
        }
      }
      // ISSUE: reference to a compiler-generated field
      this.m_Rotation.value = rotation;
    }

    private ObjectPrefab GetObjectPrefab()
    {
      Entity transformContainer;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated method
      if (this.m_ToolSystem.actionMode.IsEditor() && (UnityEngine.Object) this.m_TransformPrefab != (UnityEngine.Object) null && this.GetContainers(this.m_ContainerQuery, out Entity _, out transformContainer))
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated method
        return this.m_PrefabSystem.GetPrefab<ObjectPrefab>(transformContainer);
      }
      if (this.actualMode == ObjectToolSystem.Mode.Move)
      {
        // ISSUE: reference to a compiler-generated field
        Entity entity = this.m_MovingObject;
        Owner component1;
        // ISSUE: reference to a compiler-generated field
        if (this.m_ToolSystem.actionMode.IsEditor() && this.EntityManager.HasComponent<Game.Buildings.ServiceUpgrade>(entity) && this.EntityManager.TryGetComponent<Owner>(entity, out component1))
          entity = component1.m_Owner;
        PrefabRef component2;
        if (this.EntityManager.TryGetComponent<PrefabRef>(entity, out component2))
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated method
          return this.m_PrefabSystem.GetPrefab<ObjectPrefab>(component2);
        }
      }
      // ISSUE: reference to a compiler-generated field
      return this.m_SelectedPrefab;
    }

    public override void SetUnderground(bool underground) => this.underground = underground;

    public override void ElevationUp() => this.underground = false;

    public override void ElevationDown() => this.underground = true;

    public override void ElevationScroll() => this.underground = !this.underground;

    public override void InitializeRaycast()
    {
      // ISSUE: reference to a compiler-generated method
      base.InitializeRaycast();
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated method
      this.m_Prefab = this.GetObjectPrefab();
      // ISSUE: reference to a compiler-generated field
      if ((UnityEngine.Object) this.m_Prefab != (UnityEngine.Object) null)
      {
        float3 float3 = new float3();
        Bounds3 bounds3 = new Bounds3();
        ObjectGeometryData component1;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated method
        if (this.m_PrefabSystem.TryGetComponentData<ObjectGeometryData>((PrefabBase) this.m_Prefab, out component1))
        {
          float3.y -= component1.m_Pivot.y;
          bounds3 = component1.m_Bounds;
        }
        PlaceableObjectData component2;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated method
        if (this.m_PrefabSystem.TryGetComponentData<PlaceableObjectData>((PrefabBase) this.m_Prefab, out component2))
        {
          float3.y -= component2.m_PlacementOffset.y;
          if ((component2.m_Flags & Game.Objects.PlacementFlags.Hanging) != Game.Objects.PlacementFlags.None)
            float3.y += bounds3.max.y;
        }
        // ISSUE: reference to a compiler-generated field
        this.m_ToolRaycastSystem.rayOffset = float3;
        Snap onMask;
        Snap offMask;
        // ISSUE: reference to a compiler-generated method
        this.GetAvailableSnapMask(out onMask, out offMask);
        // ISSUE: reference to a compiler-generated method
        int actualSnap = (int) ToolBaseSystem.GetActualSnap(this.selectedSnap, onMask, offMask);
        if ((actualSnap & 4112) != 0)
        {
          // ISSUE: reference to a compiler-generated field
          this.m_ToolRaycastSystem.typeMask |= TypeMask.Net;
          // ISSUE: reference to a compiler-generated field
          this.m_ToolRaycastSystem.netLayerMask |= Layer.Road | Layer.TrainTrack | Layer.TramTrack | Layer.SubwayTrack | Layer.PublicTransportRoad;
        }
        if ((actualSnap & 8192) != 0)
        {
          // ISSUE: reference to a compiler-generated field
          this.m_ToolRaycastSystem.typeMask |= TypeMask.StaticObjects;
          // ISSUE: reference to a compiler-generated field
          if (this.m_ToolSystem.actionMode.IsEditor())
          {
            // ISSUE: reference to a compiler-generated field
            this.m_ToolRaycastSystem.raycastFlags |= RaycastFlags.Placeholders;
          }
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated method
        if ((actualSnap & 12304) != 0 && !this.m_PrefabSystem.HasComponent<Game.Prefabs.BuildingData>((PrefabBase) this.m_Prefab))
        {
          if (this.underground)
          {
            // ISSUE: reference to a compiler-generated field
            this.m_ToolRaycastSystem.collisionMask = CollisionMask.Underground;
            // ISSUE: reference to a compiler-generated field
            this.m_ToolRaycastSystem.raycastFlags |= RaycastFlags.PartialSurface;
          }
          else
          {
            // ISSUE: reference to a compiler-generated field
            this.m_ToolRaycastSystem.typeMask |= TypeMask.Terrain;
            if ((component2.m_Flags & (Game.Objects.PlacementFlags.Shoreline | Game.Objects.PlacementFlags.Floating | Game.Objects.PlacementFlags.Hovering)) != Game.Objects.PlacementFlags.None)
            {
              // ISSUE: reference to a compiler-generated field
              this.m_ToolRaycastSystem.typeMask |= TypeMask.Water;
            }
            // ISSUE: reference to a compiler-generated field
            this.m_ToolRaycastSystem.raycastFlags |= RaycastFlags.Outside;
            // ISSUE: reference to a compiler-generated field
            this.m_ToolRaycastSystem.collisionMask = CollisionMask.OnGround | CollisionMask.Overground;
          }
        }
        else
        {
          // ISSUE: reference to a compiler-generated field
          this.m_ToolRaycastSystem.typeMask |= TypeMask.Terrain;
          if ((component2.m_Flags & (Game.Objects.PlacementFlags.Shoreline | Game.Objects.PlacementFlags.Floating | Game.Objects.PlacementFlags.Hovering)) != Game.Objects.PlacementFlags.None)
          {
            // ISSUE: reference to a compiler-generated field
            this.m_ToolRaycastSystem.typeMask |= TypeMask.Water;
          }
          // ISSUE: reference to a compiler-generated field
          this.m_ToolRaycastSystem.raycastFlags |= RaycastFlags.Outside;
          // ISSUE: reference to a compiler-generated field
          this.m_ToolRaycastSystem.netLayerMask |= Layer.None;
        }
      }
      else
      {
        // ISSUE: reference to a compiler-generated field
        this.m_ToolRaycastSystem.typeMask = TypeMask.Terrain | TypeMask.Water;
        // ISSUE: reference to a compiler-generated field
        this.m_ToolRaycastSystem.raycastFlags |= RaycastFlags.Outside;
        // ISSUE: reference to a compiler-generated field
        this.m_ToolRaycastSystem.netLayerMask = Layer.None;
        // ISSUE: reference to a compiler-generated field
        this.m_ToolRaycastSystem.rayOffset = new float3();
      }
      // ISSUE: reference to a compiler-generated field
      if (!this.m_ToolSystem.actionMode.IsEditor())
        return;
      // ISSUE: reference to a compiler-generated field
      this.m_ToolRaycastSystem.raycastFlags |= RaycastFlags.SubElements;
    }

    private void InitializeRotation(Entity entity, PlaceableObjectData placeableObjectData)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      ObjectToolSystem.Rotation rotation1 = new ObjectToolSystem.Rotation()
      {
        m_Rotation = quaternion.identity,
        m_ParentRotation = quaternion.identity,
        m_IsAligned = true
      };
      Game.Objects.Transform component1;
      if (this.EntityManager.TryGetComponent<Game.Objects.Transform>(entity, out component1))
      {
        // ISSUE: reference to a compiler-generated field
        rotation1.m_Rotation = component1.m_Rotation;
      }
      Owner component2;
      if (this.EntityManager.TryGetComponent<Owner>(entity, out component2))
      {
        Entity owner = component2.m_Owner;
        Game.Objects.Transform component3;
        if (this.EntityManager.TryGetComponent<Game.Objects.Transform>(owner, out component3))
        {
          // ISSUE: reference to a compiler-generated field
          rotation1.m_ParentRotation = component3.m_Rotation;
        }
        while (this.EntityManager.TryGetComponent<Owner>(owner, out component2) && !this.EntityManager.HasComponent<Building>(owner))
        {
          owner = component2.m_Owner;
          if (this.EntityManager.TryGetComponent<Game.Objects.Transform>(owner, out component3))
          {
            // ISSUE: reference to a compiler-generated field
            rotation1.m_ParentRotation = component3.m_Rotation;
          }
        }
      }
      // ISSUE: reference to a compiler-generated field
      quaternion rotation2 = rotation1.m_Rotation;
      if ((placeableObjectData.m_Flags & Game.Objects.PlacementFlags.Wall) != Game.Objects.PlacementFlags.None)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated method
        ObjectToolSystem.SnapJob.AlignRotation(ref rotation2, rotation1.m_ParentRotation, true);
      }
      else
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated method
        ObjectToolSystem.SnapJob.AlignRotation(ref rotation2, rotation1.m_ParentRotation, false);
      }
      // ISSUE: reference to a compiler-generated field
      if ((double) MathUtils.RotationAngle(rotation1.m_Rotation, rotation2) > 0.0099999997764825821)
      {
        // ISSUE: reference to a compiler-generated field
        rotation1.m_IsAligned = false;
      }
      // ISSUE: reference to a compiler-generated field
      this.m_Rotation.value = rotation1;
    }

    [UnityEngine.Scripting.Preserve]
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
      // ISSUE: reference to a compiler-generated field
      this.m_UpgradingObject = Entity.Null;
      // ISSUE: variable of a compiler-generated type
      ObjectToolSystem.Mode actualMode = this.actualMode;
      if (actualMode == ObjectToolSystem.Mode.Brush && (UnityEngine.Object) this.brushType == (UnityEngine.Object) null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated method
        this.brushType = this.FindDefaultBrush(this.m_BrushQuery);
      }
      if (actualMode != ObjectToolSystem.Mode.Move)
      {
        // ISSUE: reference to a compiler-generated field
        this.m_MovingObject = Entity.Null;
      }
      // ISSUE: reference to a compiler-generated field
      bool forceCancel = this.m_ForceCancel;
      // ISSUE: reference to a compiler-generated field
      this.m_ForceCancel = false;
      CameraController cameraController;
      // ISSUE: reference to a compiler-generated field
      if ((UnityEngine.Object) this.m_CameraController == (UnityEngine.Object) null && CameraController.TryGet(out cameraController))
      {
        // ISSUE: reference to a compiler-generated field
        this.m_CameraController = cameraController;
      }
      // ISSUE: reference to a compiler-generated method
      this.UpdateActions();
      // ISSUE: reference to a compiler-generated field
      if ((UnityEngine.Object) this.m_Prefab != (UnityEngine.Object) null)
      {
        this.allowUnderground = false;
        this.requireUnderground = false;
        this.requireNet = Layer.None;
        this.requireNetArrows = false;
        this.requireStops = TransportType.None;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated method
        this.UpdateInfoview(this.m_ToolSystem.actionMode.IsEditor() ? Entity.Null : this.m_PrefabSystem.GetEntity((PrefabBase) this.m_Prefab));
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated method
        this.GetAvailableSnapMask(out this.m_SnapOnMask, out this.m_SnapOffMask);
        ObjectGeometryData component1;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated method
        this.m_PrefabSystem.TryGetComponentData<ObjectGeometryData>((PrefabBase) this.m_Prefab, out component1);
        PlaceableObjectData component2;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated method
        if (this.m_PrefabSystem.TryGetComponentData<PlaceableObjectData>((PrefabBase) this.m_Prefab, out component2))
        {
          if ((component2.m_Flags & Game.Objects.PlacementFlags.HasUndergroundElements) != Game.Objects.PlacementFlags.None)
            this.requireNet |= Layer.Road;
          if ((component2.m_Flags & (Game.Objects.PlacementFlags.Shoreline | Game.Objects.PlacementFlags.Floating)) != Game.Objects.PlacementFlags.None)
            this.requireNet |= Layer.Waterway;
        }
        switch (actualMode)
        {
          case ObjectToolSystem.Mode.Upgrade:
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated method
            if (this.m_PrefabSystem.HasComponent<ServiceUpgradeData>((PrefabBase) this.m_Prefab))
            {
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              this.m_UpgradingObject = this.m_ToolSystem.selected;
              break;
            }
            break;
          case ObjectToolSystem.Mode.Move:
            // ISSUE: reference to a compiler-generated field
            if (!this.EntityManager.Exists(this.m_MovingObject))
            {
              // ISSUE: reference to a compiler-generated field
              this.m_MovingObject = Entity.Null;
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            if (this.m_MovingInitialized != this.m_MovingObject)
            {
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              this.m_MovingInitialized = this.m_MovingObject;
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated method
              this.InitializeRotation(this.m_MovingObject, component2);
              break;
            }
            break;
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated method
        if ((ToolBaseSystem.GetActualSnap(this.selectedSnap, this.m_SnapOnMask, this.m_SnapOffMask) & (Snap.NetArea | Snap.NetNode | Snap.ObjectSurface)) != Snap.None && !this.m_PrefabSystem.HasComponent<Game.Prefabs.BuildingData>((PrefabBase) this.m_Prefab))
          this.allowUnderground = true;
        TransportStopData component3;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated method
        if (this.m_PrefabSystem.TryGetComponentData<TransportStopData>((PrefabBase) this.m_Prefab, out component3))
        {
          this.requireNetArrows = component3.m_TransportType != TransportType.Post;
          this.requireStops = component3.m_TransportType;
        }
        this.requireUnderground = this.allowUnderground && this.underground;
        this.requireZones = !this.requireUnderground && ((component2.m_Flags & Game.Objects.PlacementFlags.RoadSide) != Game.Objects.PlacementFlags.None || (component1.m_Flags & Game.Objects.GeometryFlags.OccupyZone) != Game.Objects.GeometryFlags.None && this.requireStops == TransportType.None);
        // ISSUE: reference to a compiler-generated field
        if (this.m_State != ObjectToolSystem.State.Default && !this.applyAction.action.enabled)
        {
          // ISSUE: reference to a compiler-generated field
          this.m_State = ObjectToolSystem.State.Default;
        }
        // ISSUE: reference to a compiler-generated field
        if ((this.m_ToolRaycastSystem.raycastFlags & (RaycastFlags.DebugDisable | RaycastFlags.UIDisable)) == (RaycastFlags) 0)
        {
          if (this.cancelAction.action.WasPressedThisFrame())
          {
            // ISSUE: reference to a compiler-generated field
            if (actualMode == ObjectToolSystem.Mode.Upgrade && (this.m_SnapOffMask & Snap.OwnerSide) == Snap.None)
            {
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              this.m_ToolSystem.activeTool = (ToolBaseSystem) this.m_DefaultToolSystem;
            }
            // ISSUE: reference to a compiler-generated method
            return this.Cancel(inputDeps, this.cancelAction.action.WasReleasedThisFrame());
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          if (this.m_State == ObjectToolSystem.State.Adding || this.m_State == ObjectToolSystem.State.Removing)
          {
            if (this.applyAction.action.WasPressedThisFrame() || this.applyAction.action.WasReleasedThisFrame())
            {
              // ISSUE: reference to a compiler-generated method
              return this.Apply(inputDeps);
            }
            // ISSUE: reference to a compiler-generated method
            // ISSUE: reference to a compiler-generated method
            return forceCancel || this.secondaryApplyAction.action.WasPressedThisFrame() || this.secondaryApplyAction.action.WasReleasedThisFrame() ? this.Cancel(inputDeps) : this.Update(inputDeps);
          }
          // ISSUE: reference to a compiler-generated field
          if ((actualMode != ObjectToolSystem.Mode.Upgrade || (this.m_SnapOffMask & Snap.OwnerSide) != Snap.None) && this.secondaryApplyAction.action.WasPressedThisFrame())
          {
            // ISSUE: reference to a compiler-generated method
            return this.Cancel(inputDeps, this.secondaryApplyAction.action.WasReleasedThisFrame());
          }
          // ISSUE: reference to a compiler-generated field
          if (this.m_State == ObjectToolSystem.State.Rotating && this.secondaryApplyAction.action.WasReleasedThisFrame())
          {
            // ISSUE: reference to a compiler-generated field
            if (this.m_RotationModified)
            {
              // ISSUE: reference to a compiler-generated field
              this.m_RotationModified = false;
            }
            else
            {
              // ISSUE: reference to a compiler-generated method
              this.Rotate(0.7853982f, false, true);
            }
            // ISSUE: reference to a compiler-generated field
            this.m_State = ObjectToolSystem.State.Default;
            // ISSUE: reference to a compiler-generated method
            return this.Update(inputDeps);
          }
          if (this.applyAction.action.WasPressedThisFrame())
          {
            if (actualMode == ObjectToolSystem.Mode.Move)
            {
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              this.m_ToolSystem.activeTool = (ToolBaseSystem) this.m_DefaultToolSystem;
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated method
              this.m_TerrainSystem.OnBuildingMoved(this.m_MovingObject);
            }
            // ISSUE: reference to a compiler-generated method
            return this.Apply(inputDeps, this.applyAction.action.WasReleasedThisFrame());
          }
          // ISSUE: reference to a compiler-generated field
          if (this.m_PreciseRotation.action.IsPressed())
          {
            // ISSUE: reference to a compiler-generated field
            if (this.m_State == ObjectToolSystem.State.Default)
            {
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated method
              this.Rotate(1.57079637f * this.m_PreciseRotation.action.ReadValue<float>() * UnityEngine.Time.deltaTime, false, false);
            }
            // ISSUE: reference to a compiler-generated method
            return this.Update(inputDeps);
          }
          // ISSUE: reference to a compiler-generated field
          if (this.m_State != ObjectToolSystem.State.Rotating || InputManager.instance.activeControlScheme != InputManager.ControlScheme.KeyboardAndMouse)
          {
            // ISSUE: reference to a compiler-generated method
            return this.Update(inputDeps);
          }
          float3 mousePosition = (float3) InputManager.instance.mousePosition;
          // ISSUE: reference to a compiler-generated field
          if ((double) mousePosition.x != (double) this.m_RotationStartPosition.x)
          {
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated method
            this.Rotate((float) (((double) mousePosition.x - (double) this.m_RotationStartPosition.x) * 6.2831854820251465 * (1.0 / 500.0)), true, false);
            // ISSUE: reference to a compiler-generated field
            this.m_RotationModified = true;
          }
          // ISSUE: reference to a compiler-generated method
          return this.Update(inputDeps);
        }
      }
      else
      {
        this.requireUnderground = false;
        this.requireZones = false;
        this.requireNetArrows = false;
        this.requireNet = Layer.None;
        // ISSUE: reference to a compiler-generated method
        this.UpdateInfoview(Entity.Null);
      }
      // ISSUE: reference to a compiler-generated field
      if (this.m_State != ObjectToolSystem.State.Default && (this.applyAction.action.WasReleasedThisFrame() || this.secondaryApplyAction.action.WasReleasedThisFrame()))
      {
        // ISSUE: reference to a compiler-generated field
        this.m_State = ObjectToolSystem.State.Default;
      }
      // ISSUE: reference to a compiler-generated method
      return this.Clear(inputDeps);
    }

    public override void GetAvailableSnapMask(out Snap onMask, out Snap offMask)
    {
      // ISSUE: reference to a compiler-generated field
      if ((UnityEngine.Object) this.m_Prefab != (UnityEngine.Object) null)
      {
        int actualMode = (int) this.actualMode;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated method
        bool isBuilding = this.m_PrefabSystem.HasComponent<Game.Prefabs.BuildingData>((PrefabBase) this.m_Prefab);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated method
        bool isAssetStamp = !isBuilding && this.m_PrefabSystem.HasComponent<AssetStampData>((PrefabBase) this.m_Prefab);
        bool brushing = actualMode == 3;
        bool stamping = actualMode == 4;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated method
        if (this.m_PrefabSystem.HasComponent<PlaceableObjectData>((PrefabBase) this.m_Prefab))
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated method
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated method
          ObjectToolSystem.GetAvailableSnapMask(this.m_PrefabSystem.GetComponentData<PlaceableObjectData>((PrefabBase) this.m_Prefab), this.m_ToolSystem.actionMode.IsEditor(), isBuilding, isAssetStamp, brushing, stamping, out onMask, out offMask);
        }
        else
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated method
          ObjectToolSystem.GetAvailableSnapMask(new PlaceableObjectData(), this.m_ToolSystem.actionMode.IsEditor(), isBuilding, isAssetStamp, brushing, stamping, out onMask, out offMask);
        }
      }
      else
      {
        // ISSUE: reference to a compiler-generated method
        base.GetAvailableSnapMask(out onMask, out offMask);
      }
    }

    private static void GetAvailableSnapMask(
      PlaceableObjectData prefabPlaceableData,
      bool editorMode,
      bool isBuilding,
      bool isAssetStamp,
      bool brushing,
      bool stamping,
      out Snap onMask,
      out Snap offMask)
    {
      onMask = Snap.Upright;
      offMask = Snap.None;
      if ((prefabPlaceableData.m_Flags & (Game.Objects.PlacementFlags.RoadSide | Game.Objects.PlacementFlags.OwnerSide)) == Game.Objects.PlacementFlags.OwnerSide)
        onMask |= Snap.OwnerSide;
      else if ((prefabPlaceableData.m_Flags & (Game.Objects.PlacementFlags.RoadSide | Game.Objects.PlacementFlags.Shoreline | Game.Objects.PlacementFlags.Floating | Game.Objects.PlacementFlags.Hovering)) != Game.Objects.PlacementFlags.None)
      {
        if ((prefabPlaceableData.m_Flags & Game.Objects.PlacementFlags.OwnerSide) != Game.Objects.PlacementFlags.None)
        {
          onMask |= Snap.OwnerSide;
          offMask |= Snap.OwnerSide;
        }
        if ((prefabPlaceableData.m_Flags & Game.Objects.PlacementFlags.RoadSide) != Game.Objects.PlacementFlags.None)
        {
          onMask |= Snap.NetSide;
          offMask |= Snap.NetSide;
        }
        if ((prefabPlaceableData.m_Flags & Game.Objects.PlacementFlags.RoadEdge) != Game.Objects.PlacementFlags.None)
        {
          onMask |= Snap.NetArea;
          offMask |= Snap.NetArea;
        }
        if ((prefabPlaceableData.m_Flags & Game.Objects.PlacementFlags.Shoreline) != Game.Objects.PlacementFlags.None)
        {
          onMask |= Snap.Shoreline;
          offMask |= Snap.Shoreline;
        }
        if ((prefabPlaceableData.m_Flags & Game.Objects.PlacementFlags.Hovering) != Game.Objects.PlacementFlags.None)
        {
          onMask |= Snap.ObjectSurface;
          offMask |= Snap.ObjectSurface;
        }
        if ((prefabPlaceableData.m_Flags & Game.Objects.PlacementFlags.SubNetSnap) != Game.Objects.PlacementFlags.None)
        {
          onMask |= Snap.ExistingGeometry;
          offMask |= Snap.ExistingGeometry;
        }
      }
      else if ((prefabPlaceableData.m_Flags & (Game.Objects.PlacementFlags.RoadNode | Game.Objects.PlacementFlags.RoadEdge)) != Game.Objects.PlacementFlags.None)
      {
        if ((prefabPlaceableData.m_Flags & Game.Objects.PlacementFlags.RoadNode) != Game.Objects.PlacementFlags.None)
          onMask |= Snap.NetNode;
        if ((prefabPlaceableData.m_Flags & Game.Objects.PlacementFlags.RoadEdge) != Game.Objects.PlacementFlags.None)
          onMask |= Snap.NetArea;
      }
      else
      {
        if (editorMode && !isBuilding)
        {
          onMask |= Snap.ObjectSurface;
          offMask |= Snap.ObjectSurface;
          offMask |= Snap.Upright;
        }
        if ((prefabPlaceableData.m_Flags & Game.Objects.PlacementFlags.SubNetSnap) != Game.Objects.PlacementFlags.None)
        {
          onMask |= Snap.ExistingGeometry;
          offMask |= Snap.ExistingGeometry;
        }
      }
      if (editorMode && !isAssetStamp | stamping)
      {
        onMask |= Snap.AutoParent;
        offMask |= Snap.AutoParent;
      }
      if (brushing)
      {
        onMask &= Snap.Upright;
        offMask &= Snap.Upright;
        onMask |= Snap.PrefabType;
        offMask |= Snap.PrefabType;
      }
      if (!(isBuilding | isAssetStamp))
        return;
      onMask |= Snap.ContourLines;
      offMask |= Snap.ContourLines;
    }

    private JobHandle Clear(JobHandle inputDeps)
    {
      this.applyMode = ApplyMode.Clear;
      return inputDeps;
    }

    private JobHandle Cancel(JobHandle inputDeps, bool singleFrameOnly = false)
    {
      if (this.actualMode == ObjectToolSystem.Mode.Brush)
      {
        // ISSUE: reference to a compiler-generated field
        if (this.m_State == ObjectToolSystem.State.Default)
        {
          this.applyMode = ApplyMode.Clear;
          // ISSUE: reference to a compiler-generated method
          this.Randomize();
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          this.m_StartPoint = this.m_LastRaycastPoint;
          // ISSUE: reference to a compiler-generated field
          this.m_State = ObjectToolSystem.State.Removing;
          // ISSUE: reference to a compiler-generated field
          this.m_ForceCancel = singleFrameOnly;
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated method
          this.GetRaycastResult(out this.m_LastRaycastPoint);
          // ISSUE: reference to a compiler-generated method
          return this.UpdateDefinitions(inputDeps);
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated method
        if (this.m_State == ObjectToolSystem.State.Removing && this.GetAllowApply())
        {
          this.applyMode = ApplyMode.Apply;
          // ISSUE: reference to a compiler-generated method
          this.Randomize();
          // ISSUE: reference to a compiler-generated field
          this.m_StartPoint = new ControlPoint();
          // ISSUE: reference to a compiler-generated field
          this.m_State = ObjectToolSystem.State.Default;
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated method
          this.GetRaycastResult(out this.m_LastRaycastPoint);
          // ISSUE: reference to a compiler-generated method
          return this.UpdateDefinitions(inputDeps);
        }
        this.applyMode = ApplyMode.Clear;
        // ISSUE: reference to a compiler-generated field
        this.m_StartPoint = new ControlPoint();
        // ISSUE: reference to a compiler-generated field
        this.m_State = ObjectToolSystem.State.Default;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated method
        this.GetRaycastResult(out this.m_LastRaycastPoint);
        // ISSUE: reference to a compiler-generated method
        return this.UpdateDefinitions(inputDeps);
      }
      // ISSUE: reference to a compiler-generated field
      if (this.actualMode != ObjectToolSystem.Mode.Upgrade || (this.m_SnapOffMask & Snap.OwnerSide) != Snap.None)
      {
        if (singleFrameOnly)
        {
          // ISSUE: reference to a compiler-generated method
          this.Rotate(0.7853982f, false, true);
        }
        else
        {
          // ISSUE: reference to a compiler-generated field
          this.m_State = ObjectToolSystem.State.Rotating;
          // ISSUE: reference to a compiler-generated field
          this.m_RotationStartPosition = (float3) InputManager.instance.mousePosition;
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          this.m_StartRotation = this.m_Rotation.value.m_Rotation;
          // ISSUE: reference to a compiler-generated field
          this.m_StartCameraAngle = this.cameraAngle;
        }
      }
      this.applyMode = ApplyMode.Clear;
      // ISSUE: reference to a compiler-generated field
      this.m_ControlPoints.Clear();
      ControlPoint controlPoint;
      // ISSUE: reference to a compiler-generated method
      if (this.GetRaycastResult(out controlPoint))
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        controlPoint.m_Rotation = this.m_Rotation.value.m_Rotation;
        // ISSUE: reference to a compiler-generated field
        this.m_ControlPoints.Add(in controlPoint);
        // ISSUE: reference to a compiler-generated method
        inputDeps = this.SnapControlPoint(inputDeps);
        // ISSUE: reference to a compiler-generated method
        inputDeps = this.UpdateDefinitions(inputDeps);
      }
      return inputDeps;
    }

    private void Rotate(float angle, bool fromStart, bool align)
    {
      PlaceableObjectData component;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated method
      this.m_PrefabSystem.TryGetComponentData<PlaceableObjectData>((PrefabBase) this.m_Prefab, out component);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: variable of a compiler-generated type
      ObjectToolSystem.Rotation rotation = this.m_Rotation.value;
      bool zAxis = (component.m_Flags & Game.Objects.PlacementFlags.Wall) != 0;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      rotation.m_Rotation = math.mul(fromStart ? this.m_StartRotation : rotation.m_Rotation, zAxis ? quaternion.RotateZ(angle) : quaternion.RotateY(angle));
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      rotation.m_Rotation = math.normalizesafe(rotation.m_Rotation, quaternion.identity);
      if (align)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated method
        ObjectToolSystem.SnapJob.AlignRotation(ref rotation.m_Rotation, rotation.m_ParentRotation, zAxis);
      }
      // ISSUE: reference to a compiler-generated field
      rotation.m_IsAligned = align;
      // ISSUE: reference to a compiler-generated field
      this.m_Rotation.value = rotation;
    }

    private float cameraAngle
    {
      get
      {
        return !((UnityEngine.Object) this.m_CameraController != (UnityEngine.Object) null) ? 0.0f : this.m_CameraController.angle.x;
      }
    }

    private JobHandle Apply(JobHandle inputDeps, bool singleFrameOnly = false)
    {
      if (this.actualMode == ObjectToolSystem.Mode.Brush)
      {
        // ISSUE: reference to a compiler-generated method
        bool allowApply = this.GetAllowApply();
        // ISSUE: reference to a compiler-generated field
        if (this.m_State == ObjectToolSystem.State.Default)
        {
          this.applyMode = allowApply ? ApplyMode.Apply : ApplyMode.Clear;
          // ISSUE: reference to a compiler-generated method
          this.Randomize();
          if (!singleFrameOnly)
          {
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            this.m_StartPoint = this.m_LastRaycastPoint;
            // ISSUE: reference to a compiler-generated field
            this.m_State = ObjectToolSystem.State.Adding;
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated method
          this.GetRaycastResult(out this.m_LastRaycastPoint);
          // ISSUE: reference to a compiler-generated method
          return this.UpdateDefinitions(inputDeps);
        }
        // ISSUE: reference to a compiler-generated field
        if (this.m_State == ObjectToolSystem.State.Adding & allowApply)
        {
          this.applyMode = ApplyMode.Apply;
          // ISSUE: reference to a compiler-generated method
          this.Randomize();
          // ISSUE: reference to a compiler-generated field
          this.m_StartPoint = new ControlPoint();
          // ISSUE: reference to a compiler-generated field
          this.m_State = ObjectToolSystem.State.Default;
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated method
          this.GetRaycastResult(out this.m_LastRaycastPoint);
          // ISSUE: reference to a compiler-generated method
          return this.UpdateDefinitions(inputDeps);
        }
        this.applyMode = ApplyMode.Clear;
        // ISSUE: reference to a compiler-generated field
        this.m_StartPoint = new ControlPoint();
        // ISSUE: reference to a compiler-generated field
        this.m_State = ObjectToolSystem.State.Default;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated method
        this.GetRaycastResult(out this.m_LastRaycastPoint);
        // ISSUE: reference to a compiler-generated method
        return this.UpdateDefinitions(inputDeps);
      }
      // ISSUE: reference to a compiler-generated method
      if (this.GetAllowApply())
      {
        this.applyMode = ApplyMode.Apply;
        // ISSUE: reference to a compiler-generated method
        this.Randomize();
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        if (this.m_Prefab is BuildingPrefab || this.m_Prefab is AssetStampPrefab)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated method
          this.m_AudioManager.PlayUISound(this.m_SoundQuery.GetSingleton<ToolUXSoundSettingsData>().m_PlaceBuildingSound);
        }
        else
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          if (this.m_Prefab is StaticObjectPrefab || this.m_ToolSystem.actionMode.IsEditor())
          {
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated method
            this.m_AudioManager.PlayUISound(this.m_SoundQuery.GetSingleton<ToolUXSoundSettingsData>().m_PlacePropSound);
          }
        }
        // ISSUE: reference to a compiler-generated field
        this.m_ControlPoints.Clear();
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        if (this.m_ToolSystem.actionMode.IsGame() && !this.m_LotQuery.IsEmptyIgnoreFilter)
        {
          // ISSUE: reference to a compiler-generated field
          using (NativeArray<Entity> entityArray = this.m_LotQuery.ToEntityArray((AllocatorManager.AllocatorHandle) Allocator.TempJob))
          {
            for (int index = 0; index < entityArray.Length; ++index)
            {
              Entity entity = entityArray[index];
              Area componentData1 = this.EntityManager.GetComponentData<Area>(entity);
              Temp componentData2 = this.EntityManager.GetComponentData<Temp>(entity);
              if ((componentData1.m_Flags & AreaFlags.Slave) == (AreaFlags) 0 && (componentData2.m_Flags & TempFlags.Create) != (TempFlags) 0)
              {
                // ISSUE: reference to a compiler-generated field
                this.m_AreaToolSystem.recreate = entity;
                // ISSUE: reference to a compiler-generated field
                // ISSUE: reference to a compiler-generated field
                // ISSUE: reference to a compiler-generated method
                this.m_AreaToolSystem.prefab = this.m_PrefabSystem.GetPrefab<AreaPrefab>(this.EntityManager.GetComponentData<PrefabRef>(entity));
                // ISSUE: reference to a compiler-generated field
                this.m_AreaToolSystem.mode = AreaToolSystem.Mode.Edit;
                // ISSUE: reference to a compiler-generated field
                // ISSUE: reference to a compiler-generated field
                this.m_ToolSystem.activeTool = (ToolBaseSystem) this.m_AreaToolSystem;
                return inputDeps;
              }
            }
          }
        }
        ControlPoint controlPoint;
        // ISSUE: reference to a compiler-generated method
        if (this.GetRaycastResult(out controlPoint))
        {
          // ISSUE: reference to a compiler-generated field
          if (this.m_ToolSystem.actionMode.IsGame())
          {
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            Game.PSI.Telemetry.PlaceBuilding(this.m_UpgradingObject, (PrefabBase) this.m_Prefab, controlPoint.m_Position);
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          controlPoint.m_Rotation = this.m_Rotation.value.m_Rotation;
          // ISSUE: reference to a compiler-generated field
          this.m_ControlPoints.Add(in controlPoint);
          // ISSUE: reference to a compiler-generated method
          inputDeps = this.SnapControlPoint(inputDeps);
          // ISSUE: reference to a compiler-generated method
          inputDeps = this.UpdateDefinitions(inputDeps);
        }
      }
      else
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated method
        this.m_AudioManager.PlayUISound(this.m_SoundQuery.GetSingleton<ToolUXSoundSettingsData>().m_PlaceBuildingFailSound);
        // ISSUE: reference to a compiler-generated method
        inputDeps = this.Update(inputDeps);
      }
      return inputDeps;
    }

    private JobHandle Update(JobHandle inputDeps)
    {
      if (this.actualMode == ObjectToolSystem.Mode.Brush)
      {
        ControlPoint controlPoint;
        bool forceUpdate;
        // ISSUE: reference to a compiler-generated method
        if (this.GetRaycastResult(out controlPoint, out forceUpdate))
        {
          // ISSUE: reference to a compiler-generated field
          if (this.m_State != ObjectToolSystem.State.Default)
          {
            // ISSUE: reference to a compiler-generated method
            this.applyMode = this.GetAllowApply() ? ApplyMode.Apply : ApplyMode.Clear;
            // ISSUE: reference to a compiler-generated method
            this.Randomize();
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            this.m_StartPoint = this.m_LastRaycastPoint;
            // ISSUE: reference to a compiler-generated field
            this.m_LastRaycastPoint = controlPoint;
            // ISSUE: reference to a compiler-generated method
            return this.UpdateDefinitions(inputDeps);
          }
          // ISSUE: reference to a compiler-generated field
          if (this.m_LastRaycastPoint.Equals(controlPoint) && !forceUpdate)
          {
            // ISSUE: reference to a compiler-generated method
            if (this.HaveBrushSettingsChanged())
            {
              this.applyMode = ApplyMode.Clear;
              // ISSUE: reference to a compiler-generated method
              return this.UpdateDefinitions(inputDeps);
            }
            this.applyMode = ApplyMode.None;
            return inputDeps;
          }
          this.applyMode = ApplyMode.Clear;
          // ISSUE: reference to a compiler-generated field
          this.m_StartPoint = controlPoint;
          // ISSUE: reference to a compiler-generated field
          this.m_LastRaycastPoint = controlPoint;
          // ISSUE: reference to a compiler-generated method
          return this.UpdateDefinitions(inputDeps);
        }
        // ISSUE: reference to a compiler-generated field
        if (this.m_LastRaycastPoint.Equals(new ControlPoint()) && !forceUpdate)
        {
          this.applyMode = ApplyMode.None;
          return inputDeps;
        }
        // ISSUE: reference to a compiler-generated field
        if (this.m_State != ObjectToolSystem.State.Default)
        {
          // ISSUE: reference to a compiler-generated method
          this.applyMode = this.GetAllowApply() ? ApplyMode.Apply : ApplyMode.Clear;
          // ISSUE: reference to a compiler-generated method
          this.Randomize();
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          this.m_StartPoint = this.m_LastRaycastPoint;
          // ISSUE: reference to a compiler-generated field
          this.m_LastRaycastPoint = new ControlPoint();
        }
        else
        {
          this.applyMode = ApplyMode.Clear;
          // ISSUE: reference to a compiler-generated field
          this.m_StartPoint = new ControlPoint();
          // ISSUE: reference to a compiler-generated field
          this.m_LastRaycastPoint = new ControlPoint();
        }
        // ISSUE: reference to a compiler-generated method
        return this.UpdateDefinitions(inputDeps);
      }
      ControlPoint controlPoint1;
      bool forceUpdate1;
      // ISSUE: reference to a compiler-generated method
      if (this.GetRaycastResult(out controlPoint1, out forceUpdate1))
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        controlPoint1.m_Rotation = this.m_Rotation.value.m_Rotation;
        this.applyMode = ApplyMode.None;
        // ISSUE: reference to a compiler-generated field
        if (!this.m_LastRaycastPoint.Equals(controlPoint1) | forceUpdate1)
        {
          // ISSUE: reference to a compiler-generated field
          this.m_LastRaycastPoint = controlPoint1;
          ControlPoint controlPoint2 = new ControlPoint();
          // ISSUE: reference to a compiler-generated field
          if (this.m_ControlPoints.Length != 0)
          {
            // ISSUE: reference to a compiler-generated field
            controlPoint2 = this.m_ControlPoints[0];
            // ISSUE: reference to a compiler-generated field
            this.m_ControlPoints.Clear();
          }
          // ISSUE: reference to a compiler-generated field
          this.m_ControlPoints.Add(in controlPoint1);
          // ISSUE: reference to a compiler-generated method
          inputDeps = this.SnapControlPoint(inputDeps);
          JobHandle.ScheduleBatchedJobs();
          if (!forceUpdate1)
          {
            inputDeps.Complete();
            // ISSUE: reference to a compiler-generated field
            ControlPoint controlPoint3 = this.m_ControlPoints[0];
            forceUpdate1 = !controlPoint2.EqualsIgnoreHit(controlPoint3);
          }
          if (forceUpdate1)
          {
            this.applyMode = ApplyMode.Clear;
            // ISSUE: reference to a compiler-generated method
            inputDeps = this.UpdateDefinitions(inputDeps);
          }
        }
      }
      else
      {
        this.applyMode = ApplyMode.Clear;
        // ISSUE: reference to a compiler-generated field
        this.m_LastRaycastPoint = new ControlPoint();
      }
      return inputDeps;
    }

    private bool HaveBrushSettingsChanged()
    {
      // ISSUE: reference to a compiler-generated field
      using (NativeArray<ArchetypeChunk> archetypeChunkArray = this.m_VisibleQuery.ToArchetypeChunkArray((AllocatorManager.AllocatorHandle) Allocator.TempJob))
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Game_Tools_Brush_RO_ComponentTypeHandle.Update(ref this.CheckedStateRef);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        ComponentTypeHandle<Brush> componentTypeHandle = this.__TypeHandle.__Game_Tools_Brush_RO_ComponentTypeHandle;
        for (int index1 = 0; index1 < archetypeChunkArray.Length; ++index1)
        {
          NativeArray<Brush> nativeArray = archetypeChunkArray[index1].GetNativeArray<Brush>(ref componentTypeHandle);
          for (int index2 = 0; index2 < nativeArray.Length; ++index2)
          {
            if (!nativeArray[index2].m_Size.Equals(this.brushSize))
              return true;
          }
        }
        return false;
      }
    }

    private JobHandle SnapControlPoint(JobHandle inputDeps)
    {
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      Entity entity = this.actualMode == ObjectToolSystem.Mode.Move ? this.m_MovingObject : this.m_ToolSystem.selected;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Prefabs_SubNet_RO_BufferLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Prefabs_NetCompositionArea_RO_BufferLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Net_ConnectedEdge_RO_BufferLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Objects_SubObject_RO_BufferLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Zones_Block_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Prefabs_RoadData_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Prefabs_NetGeometryData_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Prefabs_NetData_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Prefabs_ServiceUpgradeData_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Prefabs_StackData_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Prefabs_TransportStopData_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Prefabs_NetObjectData_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Prefabs_OutsideConnectionData_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Prefabs_AssetStampData_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Prefabs_MovingObjectData_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Prefabs_PlaceableObjectData_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Prefabs_NetCompositionData_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Prefabs_BuildingExtensionData_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Prefabs_BuildingData_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Prefabs_ObjectGeometryData_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Prefabs_PrefabRef_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Net_EndNodeGeometry_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Net_StartNodeGeometry_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Net_EdgeGeometry_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Net_Composition_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Net_Curve_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Net_Orphan_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Net_Node_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Net_Edge_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Tools_LocalTransformCache_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Common_Terrain_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Objects_Attached_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Objects_Transform_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Common_Owner_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      JobHandle dependencies1;
      JobHandle dependencies2;
      JobHandle dependencies3;
      JobHandle deps;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: object of a compiler-generated type is created
      JobHandle jobHandle = new ObjectToolSystem.SnapJob()
      {
        m_EditorMode = this.m_ToolSystem.actionMode.IsEditor(),
        m_Snap = this.GetActualSnap(),
        m_Mode = this.actualMode,
        m_Prefab = this.m_PrefabSystem.GetEntity((PrefabBase) this.m_Prefab),
        m_Selected = entity,
        m_OwnerData = this.__TypeHandle.__Game_Common_Owner_RO_ComponentLookup,
        m_TransformData = this.__TypeHandle.__Game_Objects_Transform_RO_ComponentLookup,
        m_AttachedData = this.__TypeHandle.__Game_Objects_Attached_RO_ComponentLookup,
        m_TerrainData = this.__TypeHandle.__Game_Common_Terrain_RO_ComponentLookup,
        m_LocalTransformCacheData = this.__TypeHandle.__Game_Tools_LocalTransformCache_RO_ComponentLookup,
        m_EdgeData = this.__TypeHandle.__Game_Net_Edge_RO_ComponentLookup,
        m_NodeData = this.__TypeHandle.__Game_Net_Node_RO_ComponentLookup,
        m_OrphanData = this.__TypeHandle.__Game_Net_Orphan_RO_ComponentLookup,
        m_CurveData = this.__TypeHandle.__Game_Net_Curve_RO_ComponentLookup,
        m_CompositionData = this.__TypeHandle.__Game_Net_Composition_RO_ComponentLookup,
        m_EdgeGeometryData = this.__TypeHandle.__Game_Net_EdgeGeometry_RO_ComponentLookup,
        m_StartNodeGeometryData = this.__TypeHandle.__Game_Net_StartNodeGeometry_RO_ComponentLookup,
        m_EndNodeGeometryData = this.__TypeHandle.__Game_Net_EndNodeGeometry_RO_ComponentLookup,
        m_PrefabRefData = this.__TypeHandle.__Game_Prefabs_PrefabRef_RO_ComponentLookup,
        m_ObjectGeometryData = this.__TypeHandle.__Game_Prefabs_ObjectGeometryData_RO_ComponentLookup,
        m_BuildingData = this.__TypeHandle.__Game_Prefabs_BuildingData_RO_ComponentLookup,
        m_BuildingExtensionData = this.__TypeHandle.__Game_Prefabs_BuildingExtensionData_RO_ComponentLookup,
        m_PrefabCompositionData = this.__TypeHandle.__Game_Prefabs_NetCompositionData_RO_ComponentLookup,
        m_PlaceableObjectData = this.__TypeHandle.__Game_Prefabs_PlaceableObjectData_RO_ComponentLookup,
        m_MovingObjectData = this.__TypeHandle.__Game_Prefabs_MovingObjectData_RO_ComponentLookup,
        m_AssetStampData = this.__TypeHandle.__Game_Prefabs_AssetStampData_RO_ComponentLookup,
        m_OutsideConnectionData = this.__TypeHandle.__Game_Prefabs_OutsideConnectionData_RO_ComponentLookup,
        m_NetObjectData = this.__TypeHandle.__Game_Prefabs_NetObjectData_RO_ComponentLookup,
        m_TransportStopData = this.__TypeHandle.__Game_Prefabs_TransportStopData_RO_ComponentLookup,
        m_StackData = this.__TypeHandle.__Game_Prefabs_StackData_RO_ComponentLookup,
        m_ServiceUpgradeData = this.__TypeHandle.__Game_Prefabs_ServiceUpgradeData_RO_ComponentLookup,
        m_NetData = this.__TypeHandle.__Game_Prefabs_NetData_RO_ComponentLookup,
        m_NetGeometryData = this.__TypeHandle.__Game_Prefabs_NetGeometryData_RO_ComponentLookup,
        m_RoadData = this.__TypeHandle.__Game_Prefabs_RoadData_RO_ComponentLookup,
        m_BlockData = this.__TypeHandle.__Game_Zones_Block_RO_ComponentLookup,
        m_SubObjects = this.__TypeHandle.__Game_Objects_SubObject_RO_BufferLookup,
        m_ConnectedEdges = this.__TypeHandle.__Game_Net_ConnectedEdge_RO_BufferLookup,
        m_PrefabCompositionAreas = this.__TypeHandle.__Game_Prefabs_NetCompositionArea_RO_BufferLookup,
        m_PrefabSubNets = this.__TypeHandle.__Game_Prefabs_SubNet_RO_BufferLookup,
        m_ObjectSearchTree = this.m_ObjectSearchSystem.GetStaticSearchTree(true, out dependencies1),
        m_NetSearchTree = this.m_NetSearchSystem.GetNetSearchTree(true, out dependencies2),
        m_ZoneSearchTree = this.m_ZoneSearchSystem.GetSearchTree(true, out dependencies3),
        m_WaterSurfaceData = this.m_WaterSystem.GetSurfaceData(out deps),
        m_TerrainHeightData = this.m_TerrainSystem.GetHeightData(),
        m_ControlPoints = this.m_ControlPoints,
        m_SubSnapPoints = this.m_SubSnapPoints,
        m_Rotation = this.m_Rotation
      }.Schedule<ObjectToolSystem.SnapJob>(JobUtils.CombineDependencies(inputDeps, dependencies1, dependencies2, dependencies3, deps));
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated method
      this.m_ObjectSearchSystem.AddStaticSearchTreeReader(jobHandle);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated method
      this.m_NetSearchSystem.AddNetSearchTreeReader(jobHandle);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated method
      this.m_ZoneSearchSystem.AddSearchTreeReader(jobHandle);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated method
      this.m_WaterSystem.AddSurfaceReader(jobHandle);
      return jobHandle;
    }

    private JobHandle UpdateDefinitions(JobHandle inputDeps)
    {
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated method
      JobHandle jobHandle = this.DestroyDefinitions(this.m_DefinitionQuery, this.m_ToolOutputBarrier, inputDeps);
      // ISSUE: reference to a compiler-generated field
      if ((UnityEngine.Object) this.m_Prefab != (UnityEngine.Object) null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated method
        Entity entity1 = this.m_PrefabSystem.GetEntity((PrefabBase) this.m_Prefab);
        Entity laneContainer = Entity.Null;
        Entity entity2 = Entity.Null;
        Entity entity3 = Entity.Null;
        float deltaTime = UnityEngine.Time.deltaTime;
        // ISSUE: reference to a compiler-generated field
        if (this.m_ToolSystem.actionMode.IsEditor())
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated method
          this.GetContainers(this.m_ContainerQuery, out laneContainer, out Entity _);
        }
        // ISSUE: reference to a compiler-generated field
        if ((UnityEngine.Object) this.m_TransformPrefab != (UnityEngine.Object) null)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated method
          entity2 = this.m_PrefabSystem.GetEntity((PrefabBase) this.m_TransformPrefab);
        }
        if (this.actualMode == ObjectToolSystem.Mode.Brush && (UnityEngine.Object) this.brushType != (UnityEngine.Object) null)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated method
          entity3 = this.m_PrefabSystem.GetEntity((PrefabBase) this.brushType);
          // ISSUE: reference to a compiler-generated method
          this.EnsureCachedBrushData();
          // ISSUE: reference to a compiler-generated field
          ControlPoint startPoint = this.m_StartPoint;
          // ISSUE: reference to a compiler-generated field
          ControlPoint lastRaycastPoint = this.m_LastRaycastPoint;
          startPoint.m_OriginalEntity = Entity.Null;
          lastRaycastPoint.m_OriginalEntity = Entity.Null;
          // ISSUE: reference to a compiler-generated field
          this.m_ControlPoints.Clear();
          // ISSUE: reference to a compiler-generated field
          this.m_ControlPoints.Add(in startPoint);
          // ISSUE: reference to a compiler-generated field
          this.m_ControlPoints.Add(in lastRaycastPoint);
          // ISSUE: reference to a compiler-generated field
          if (this.m_State == ObjectToolSystem.State.Default)
            deltaTime = 0.1f;
        }
        NativeReference<ObjectToolBaseSystem.AttachmentData> attachmentPrefab = new NativeReference<ObjectToolBaseSystem.AttachmentData>();
        PlaceholderBuildingData component;
        // ISSUE: reference to a compiler-generated field
        if (!this.m_ToolSystem.actionMode.IsEditor() && this.EntityManager.TryGetComponent<PlaceholderBuildingData>(entity1, out component))
        {
          ZoneData componentData1 = this.EntityManager.GetComponentData<ZoneData>(component.m_ZonePrefab);
          Game.Prefabs.BuildingData componentData2 = this.EntityManager.GetComponentData<Game.Prefabs.BuildingData>(entity1);
          // ISSUE: reference to a compiler-generated field
          this.m_BuildingQuery.ResetFilter();
          // ISSUE: reference to a compiler-generated field
          this.m_BuildingQuery.SetSharedComponentFilter<BuildingSpawnGroupData>(new BuildingSpawnGroupData(componentData1.m_ZoneType));
          attachmentPrefab = new NativeReference<ObjectToolBaseSystem.AttachmentData>((AllocatorManager.AllocatorHandle) Allocator.TempJob);
          JobHandle outJobHandle;
          // ISSUE: reference to a compiler-generated field
          NativeList<ArchetypeChunk> archetypeChunkListAsync = this.m_BuildingQuery.ToArchetypeChunkListAsync((AllocatorManager.AllocatorHandle) Allocator.TempJob, out outJobHandle);
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          this.__TypeHandle.__Game_Prefabs_SpawnableBuildingData_RO_ComponentTypeHandle.Update(ref this.CheckedStateRef);
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          this.__TypeHandle.__Game_Prefabs_BuildingData_RO_ComponentTypeHandle.Update(ref this.CheckedStateRef);
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          this.__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref this.CheckedStateRef);
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          // ISSUE: object of a compiler-generated type is created
          inputDeps = new ObjectToolSystem.FindAttachmentBuildingJob()
          {
            m_EntityType = this.__TypeHandle.__Unity_Entities_Entity_TypeHandle,
            m_BuildingDataType = this.__TypeHandle.__Game_Prefabs_BuildingData_RO_ComponentTypeHandle,
            m_SpawnableBuildingType = this.__TypeHandle.__Game_Prefabs_SpawnableBuildingData_RO_ComponentTypeHandle,
            m_BuildingData = componentData2,
            m_RandomSeed = this.m_RandomSeed,
            m_Chunks = archetypeChunkListAsync,
            m_AttachmentPrefab = attachmentPrefab
          }.Schedule<ObjectToolSystem.FindAttachmentBuildingJob>(JobHandle.CombineDependencies(inputDeps, outJobHandle));
          archetypeChunkListAsync.Dispose(inputDeps);
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated method
        jobHandle = JobHandle.CombineDependencies(jobHandle, this.CreateDefinitions(entity1, entity2, entity3, this.m_UpgradingObject, this.m_MovingObject, laneContainer, this.m_CityConfigurationSystem.defaultTheme, this.m_ControlPoints, attachmentPrefab, this.m_ToolSystem.actionMode.IsEditor(), this.m_CityConfigurationSystem.leftHandTraffic, this.m_State == ObjectToolSystem.State.Removing, this.actualMode == ObjectToolSystem.Mode.Stamp, this.brushSize, math.radians(this.brushAngle), this.brushStrength, deltaTime, this.m_RandomSeed, this.GetActualSnap(), this.actualAgeMask, inputDeps));
        if (attachmentPrefab.IsCreated)
          attachmentPrefab.Dispose(jobHandle);
      }
      return jobHandle;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void __AssignQueries(ref SystemState state)
    {
    }

    protected override void OnCreateForCompiler()
    {
      // ISSUE: reference to a compiler-generated method
      base.OnCreateForCompiler();
      // ISSUE: reference to a compiler-generated method
      this.__AssignQueries(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated method
      this.__TypeHandle.__AssignHandles(ref this.CheckedStateRef);
    }

    [UnityEngine.Scripting.Preserve]
    public ObjectToolSystem()
    {
    }

    public enum Mode
    {
      Create,
      Upgrade,
      Move,
      Brush,
      Stamp,
    }

    private enum State
    {
      Default,
      Rotating,
      Adding,
      Removing,
    }

    private struct Rotation
    {
      public quaternion m_Rotation;
      public quaternion m_ParentRotation;
      public bool m_IsAligned;
    }

    [BurstCompile]
    private struct SnapJob : IJob
    {
      [ReadOnly]
      public bool m_EditorMode;
      [ReadOnly]
      public Snap m_Snap;
      [ReadOnly]
      public ObjectToolSystem.Mode m_Mode;
      [ReadOnly]
      public Entity m_Prefab;
      [ReadOnly]
      public Entity m_Selected;
      [ReadOnly]
      public ComponentLookup<Owner> m_OwnerData;
      [ReadOnly]
      public ComponentLookup<Game.Objects.Transform> m_TransformData;
      [ReadOnly]
      public ComponentLookup<Attached> m_AttachedData;
      [ReadOnly]
      public ComponentLookup<Game.Common.Terrain> m_TerrainData;
      [ReadOnly]
      public ComponentLookup<LocalTransformCache> m_LocalTransformCacheData;
      [ReadOnly]
      public ComponentLookup<Game.Net.Edge> m_EdgeData;
      [ReadOnly]
      public ComponentLookup<Game.Net.Node> m_NodeData;
      [ReadOnly]
      public ComponentLookup<Orphan> m_OrphanData;
      [ReadOnly]
      public ComponentLookup<Curve> m_CurveData;
      [ReadOnly]
      public ComponentLookup<Composition> m_CompositionData;
      [ReadOnly]
      public ComponentLookup<EdgeGeometry> m_EdgeGeometryData;
      [ReadOnly]
      public ComponentLookup<StartNodeGeometry> m_StartNodeGeometryData;
      [ReadOnly]
      public ComponentLookup<EndNodeGeometry> m_EndNodeGeometryData;
      [ReadOnly]
      public ComponentLookup<PrefabRef> m_PrefabRefData;
      [ReadOnly]
      public ComponentLookup<ObjectGeometryData> m_ObjectGeometryData;
      [ReadOnly]
      public ComponentLookup<Game.Prefabs.BuildingData> m_BuildingData;
      [ReadOnly]
      public ComponentLookup<BuildingExtensionData> m_BuildingExtensionData;
      [ReadOnly]
      public ComponentLookup<NetCompositionData> m_PrefabCompositionData;
      [ReadOnly]
      public ComponentLookup<PlaceableObjectData> m_PlaceableObjectData;
      [ReadOnly]
      public ComponentLookup<MovingObjectData> m_MovingObjectData;
      [ReadOnly]
      public ComponentLookup<AssetStampData> m_AssetStampData;
      [ReadOnly]
      public ComponentLookup<OutsideConnectionData> m_OutsideConnectionData;
      [ReadOnly]
      public ComponentLookup<NetObjectData> m_NetObjectData;
      [ReadOnly]
      public ComponentLookup<TransportStopData> m_TransportStopData;
      [ReadOnly]
      public ComponentLookup<StackData> m_StackData;
      [ReadOnly]
      public ComponentLookup<ServiceUpgradeData> m_ServiceUpgradeData;
      [ReadOnly]
      public ComponentLookup<NetData> m_NetData;
      [ReadOnly]
      public ComponentLookup<NetGeometryData> m_NetGeometryData;
      [ReadOnly]
      public ComponentLookup<RoadData> m_RoadData;
      [ReadOnly]
      public ComponentLookup<Game.Zones.Block> m_BlockData;
      [ReadOnly]
      public BufferLookup<Game.Objects.SubObject> m_SubObjects;
      [ReadOnly]
      public BufferLookup<ConnectedEdge> m_ConnectedEdges;
      [ReadOnly]
      public BufferLookup<NetCompositionArea> m_PrefabCompositionAreas;
      [ReadOnly]
      public BufferLookup<Game.Prefabs.SubNet> m_PrefabSubNets;
      [ReadOnly]
      public NativeQuadTree<Entity, QuadTreeBoundsXZ> m_ObjectSearchTree;
      [ReadOnly]
      public NativeQuadTree<Entity, QuadTreeBoundsXZ> m_NetSearchTree;
      [ReadOnly]
      public NativeQuadTree<Entity, Bounds2> m_ZoneSearchTree;
      [ReadOnly]
      public WaterSurfaceData m_WaterSurfaceData;
      [ReadOnly]
      public TerrainHeightData m_TerrainHeightData;
      public NativeList<ControlPoint> m_ControlPoints;
      public NativeList<SubSnapPoint> m_SubSnapPoints;
      public NativeValue<ObjectToolSystem.Rotation> m_Rotation;

      public void Execute()
      {
        // ISSUE: reference to a compiler-generated field
        this.m_SubSnapPoints.Clear();
        // ISSUE: reference to a compiler-generated field
        ControlPoint controlPoint1 = this.m_ControlPoints[0];
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        if ((this.m_Snap & (Snap.NetArea | Snap.NetNode)) != Snap.None && this.m_TerrainData.HasComponent(controlPoint1.m_OriginalEntity) && !this.m_BuildingData.HasComponent(this.m_Prefab))
        {
          // ISSUE: reference to a compiler-generated method
          this.FindLoweredParent(ref controlPoint1);
        }
        ControlPoint controlPoint2 = controlPoint1 with
        {
          m_OriginalEntity = Entity.Null
        };
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        if (this.m_OutsideConnectionData.HasComponent(this.m_Prefab))
        {
          // ISSUE: reference to a compiler-generated method
          this.HandleWorldSize(ref controlPoint2, controlPoint1);
        }
        float minValue = float.MinValue;
        // ISSUE: reference to a compiler-generated field
        if ((this.m_Snap & Snap.Shoreline) != Snap.None)
        {
          float radius = 1f;
          float3 offset = (float3) 0.0f;
          Game.Prefabs.BuildingData componentData1;
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          if (this.m_BuildingData.TryGetComponent(this.m_Prefab, out componentData1))
          {
            radius = math.length((float2) componentData1.m_LotSize) * 4f;
          }
          else
          {
            BuildingExtensionData componentData2;
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            if (this.m_BuildingExtensionData.TryGetComponent(this.m_Prefab, out componentData2))
              radius = math.length((float2) componentData2.m_LotSize) * 4f;
          }
          PlaceableObjectData componentData3;
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          if (this.m_PlaceableObjectData.TryGetComponent(this.m_Prefab, out componentData3))
            offset = componentData3.m_PlacementOffset;
          // ISSUE: reference to a compiler-generated method
          this.SnapShoreline(controlPoint1, ref controlPoint2, ref minValue, radius, offset);
        }
        // ISSUE: reference to a compiler-generated field
        if ((this.m_Snap & Snap.NetSide) != Snap.None)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          Game.Prefabs.BuildingData buildingData = this.m_BuildingData[this.m_Prefab];
          float num1 = (float) ((double) buildingData.m_LotSize.y * 4.0 + 16.0);
          float num2 = (float) ((double) math.cmin(buildingData.m_LotSize) * 4.0 + 16.0);
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          // ISSUE: object of a compiler-generated type is created
          // ISSUE: variable of a compiler-generated type
          ObjectToolSystem.SnapJob.ZoneBlockIterator iterator = new ObjectToolSystem.SnapJob.ZoneBlockIterator()
          {
            m_ControlPoint = controlPoint1,
            m_BestSnapPosition = controlPoint2,
            m_BestDistance = num2,
            m_LotSize = buildingData.m_LotSize,
            m_Bounds = new Bounds2(controlPoint1.m_Position.xz - num1, controlPoint1.m_Position.xz + num1),
            m_Direction = math.forward(this.m_Rotation.value.m_Rotation).xz,
            m_IgnoreOwner = this.m_Mode == ObjectToolSystem.Mode.Move ? this.m_Selected : Entity.Null,
            m_OwnerData = this.m_OwnerData,
            m_BlockData = this.m_BlockData
          };
          // ISSUE: reference to a compiler-generated field
          this.m_ZoneSearchTree.Iterate<ObjectToolSystem.SnapJob.ZoneBlockIterator>(ref iterator);
          // ISSUE: reference to a compiler-generated field
          controlPoint2 = iterator.m_BestSnapPosition;
        }
        DynamicBuffer<Game.Prefabs.SubNet> bufferData;
        float3 float3;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        if ((this.m_Snap & Snap.ExistingGeometry) != Snap.None && this.m_PrefabSubNets.TryGetBuffer(this.m_Prefab, out bufferData))
        {
          float a1 = 2f;
          // ISSUE: reference to a compiler-generated field
          if (this.m_Mode == ObjectToolSystem.Mode.Stamp)
          {
            for (int index = 0; index < bufferData.Length; ++index)
            {
              Game.Prefabs.SubNet subNet = bufferData[index];
              if (subNet.m_Snapping.x)
                a1 = math.clamp(math.length(subNet.m_Curve.a.xz) * 0.02f, a1, 4f);
              if (subNet.m_Snapping.y)
                a1 = math.clamp(math.length(subNet.m_Curve.d.xz) * 0.02f, a1, 4f);
            }
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          // ISSUE: object of a compiler-generated type is created
          // ISSUE: variable of a compiler-generated type
          ObjectToolSystem.SnapJob.NetIterator iterator = new ObjectToolSystem.SnapJob.NetIterator()
          {
            m_ControlPoint = controlPoint1,
            m_BestSnapPosition = controlPoint2,
            m_Rotation = this.m_Rotation.value.m_Rotation,
            m_IgnoreOwner = this.m_Mode == ObjectToolSystem.Mode.Move ? this.m_Selected : Entity.Null,
            m_SnapFactor = 1f / a1,
            m_SubSnapPoints = this.m_SubSnapPoints,
            m_OwnerData = this.m_OwnerData,
            m_NodeData = this.m_NodeData,
            m_EdgeData = this.m_EdgeData,
            m_CurveData = this.m_CurveData,
            m_PrefabRefData = this.m_PrefabRefData,
            m_PrefabNetData = this.m_NetData,
            m_PrefabNetGeometryData = this.m_NetGeometryData,
            m_ConnectedEdges = this.m_ConnectedEdges
          };
          for (int index = 0; index < bufferData.Length; ++index)
          {
            Game.Prefabs.SubNet subNet = bufferData[index];
            if (subNet.m_Snapping.x)
            {
              float3 = ObjectUtils.LocalToWorld(controlPoint1.m_HitPosition, controlPoint1.m_Rotation, subNet.m_Curve.a);
              float2 xz = float3.xz;
              // ISSUE: reference to a compiler-generated field
              iterator.m_Bounds = new Bounds2(xz - 8f * a1, xz + 8f * a1);
              // ISSUE: reference to a compiler-generated field
              iterator.m_LocalOffset = subNet.m_Curve.a;
              ref ObjectToolSystem.SnapJob.NetIterator local = ref iterator;
              float2 a2 = new float2();
              float3 = MathUtils.StartTangent(subNet.m_Curve);
              float2 b = math.normalizesafe(float3.xz);
              int num = subNet.m_NodeIndex.y != subNet.m_NodeIndex.x ? 1 : 0;
              float2 float2 = math.select(a2, b, num != 0);
              // ISSUE: reference to a compiler-generated field
              local.m_LocalTangent = float2;
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              this.m_NetData.TryGetComponent(subNet.m_Prefab, out iterator.m_NetData);
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              this.m_NetGeometryData.TryGetComponent(subNet.m_Prefab, out iterator.m_NetGeometryData);
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              this.m_RoadData.TryGetComponent(subNet.m_Prefab, out iterator.m_RoadData);
              // ISSUE: reference to a compiler-generated field
              this.m_NetSearchTree.Iterate<ObjectToolSystem.SnapJob.NetIterator>(ref iterator);
            }
            if (subNet.m_Snapping.y)
            {
              float3 = ObjectUtils.LocalToWorld(controlPoint1.m_HitPosition, controlPoint1.m_Rotation, subNet.m_Curve.d);
              float2 xz = float3.xz;
              // ISSUE: reference to a compiler-generated field
              iterator.m_Bounds = new Bounds2(xz - 8f * a1, xz + 8f * a1);
              // ISSUE: reference to a compiler-generated field
              iterator.m_LocalOffset = subNet.m_Curve.d;
              ref ObjectToolSystem.SnapJob.NetIterator local = ref iterator;
              float3 = MathUtils.EndTangent(subNet.m_Curve);
              float2 float2 = math.normalizesafe(-float3.xz);
              // ISSUE: reference to a compiler-generated field
              local.m_LocalTangent = float2;
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              this.m_NetData.TryGetComponent(subNet.m_Prefab, out iterator.m_NetData);
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              this.m_NetGeometryData.TryGetComponent(subNet.m_Prefab, out iterator.m_NetGeometryData);
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              this.m_RoadData.TryGetComponent(subNet.m_Prefab, out iterator.m_RoadData);
              // ISSUE: reference to a compiler-generated field
              this.m_NetSearchTree.Iterate<ObjectToolSystem.SnapJob.NetIterator>(ref iterator);
            }
          }
          // ISSUE: reference to a compiler-generated field
          controlPoint2 = iterator.m_BestSnapPosition;
        }
        // ISSUE: reference to a compiler-generated field
        if ((this.m_Snap & Snap.OwnerSide) != Snap.None)
        {
          Entity entity = Entity.Null;
          // ISSUE: reference to a compiler-generated field
          if (this.m_Mode == ObjectToolSystem.Mode.Upgrade)
          {
            // ISSUE: reference to a compiler-generated field
            entity = this.m_Selected;
          }
          else
          {
            Owner componentData;
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            if (this.m_Mode == ObjectToolSystem.Mode.Move && this.m_OwnerData.TryGetComponent(this.m_Selected, out componentData))
              entity = componentData.m_Owner;
          }
          if (entity != Entity.Null)
          {
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            Game.Prefabs.BuildingData buildingData1 = this.m_BuildingData[this.m_Prefab];
            // ISSUE: reference to a compiler-generated field
            PrefabRef prefabRef = this.m_PrefabRefData[entity];
            // ISSUE: reference to a compiler-generated field
            Game.Objects.Transform transform = this.m_TransformData[entity];
            // ISSUE: reference to a compiler-generated field
            Game.Prefabs.BuildingData buildingData2 = this.m_BuildingData[prefabRef.m_Prefab];
            int2 lotSize = buildingData2.m_LotSize + buildingData1.m_LotSize.y;
            Quad2 xz = BuildingUtils.CalculateCorners(transform, lotSize).xz;
            int num = buildingData1.m_LotSize.x - 1;
            bool forceSnap = false;
            ServiceUpgradeData componentData;
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            if (this.m_ServiceUpgradeData.TryGetComponent(this.m_Prefab, out componentData))
            {
              num = math.select(num, componentData.m_MaxPlacementOffset, componentData.m_MaxPlacementOffset >= 0);
              forceSnap |= (double) componentData.m_MaxPlacementDistance == 0.0;
            }
            if (!forceSnap)
            {
              float2 halfLotSize = (float2) buildingData1.m_LotSize * 4f - 0.4f;
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              forceSnap = MathUtils.Intersect(BuildingUtils.CalculateCorners(transform, buildingData2.m_LotSize).xz, BuildingUtils.CalculateCorners(controlPoint1.m_HitPosition, this.m_Rotation.value.m_Rotation, halfLotSize).xz) && MathUtils.Intersect(xz, controlPoint1.m_HitPosition.xz);
            }
            // ISSUE: reference to a compiler-generated method
            ObjectToolSystem.SnapJob.CheckSnapLine(buildingData1, transform, controlPoint1, ref controlPoint2, new Line2(xz.a, xz.b), num, 0.0f, forceSnap);
            // ISSUE: reference to a compiler-generated method
            ObjectToolSystem.SnapJob.CheckSnapLine(buildingData1, transform, controlPoint1, ref controlPoint2, new Line2(xz.b, xz.c), num, 1.57079637f, forceSnap);
            // ISSUE: reference to a compiler-generated method
            ObjectToolSystem.SnapJob.CheckSnapLine(buildingData1, transform, controlPoint1, ref controlPoint2, new Line2(xz.c, xz.d), num, 3.14159274f, forceSnap);
            // ISSUE: reference to a compiler-generated method
            ObjectToolSystem.SnapJob.CheckSnapLine(buildingData1, transform, controlPoint1, ref controlPoint2, new Line2(xz.d, xz.a), num, 4.712389f, forceSnap);
          }
        }
        // ISSUE: reference to a compiler-generated field
        if ((this.m_Snap & Snap.NetArea) != Snap.None)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          if (this.m_BuildingData.HasComponent(this.m_Prefab))
          {
            Curve componentData;
            // ISSUE: reference to a compiler-generated field
            if (this.m_CurveData.TryGetComponent(controlPoint1.m_OriginalEntity, out componentData))
            {
              ControlPoint snapPosition = controlPoint1 with
              {
                m_OriginalEntity = Entity.Null,
                m_Position = MathUtils.Position(componentData.m_Bezier, controlPoint1.m_CurvePosition)
              };
              ref ControlPoint local = ref snapPosition;
              float3 = MathUtils.Tangent(componentData.m_Bezier, controlPoint1.m_CurvePosition);
              float2 float2 = math.normalizesafe(float3.xz);
              local.m_Direction = float2;
              snapPosition.m_Direction = MathUtils.Left(snapPosition.m_Direction);
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              float3 = math.forward(this.m_Rotation.value.m_Rotation);
              if ((double) math.dot(float3.xz, snapPosition.m_Direction) < 0.0)
                snapPosition.m_Direction = -snapPosition.m_Direction;
              snapPosition.m_Rotation = ToolUtils.CalculateRotation(snapPosition.m_Direction);
              snapPosition.m_SnapPriority = ToolUtils.CalculateSnapPriority(1f, 1f, controlPoint1.m_HitPosition.xz, snapPosition.m_Position.xz, snapPosition.m_Direction);
              // ISSUE: reference to a compiler-generated method
              ObjectToolSystem.SnapJob.AddSnapPosition(ref controlPoint2, snapPosition);
            }
          }
          else
          {
            // ISSUE: reference to a compiler-generated field
            if (this.m_EdgeGeometryData.HasComponent(controlPoint1.m_OriginalEntity))
            {
              // ISSUE: reference to a compiler-generated field
              EdgeGeometry edgeGeometry = this.m_EdgeGeometryData[controlPoint1.m_OriginalEntity];
              // ISSUE: reference to a compiler-generated field
              Composition composition = this.m_CompositionData[controlPoint1.m_OriginalEntity];
              // ISSUE: reference to a compiler-generated field
              NetCompositionData prefabCompositionData1 = this.m_PrefabCompositionData[composition.m_Edge];
              // ISSUE: reference to a compiler-generated field
              DynamicBuffer<NetCompositionArea> prefabCompositionArea = this.m_PrefabCompositionAreas[composition.m_Edge];
              float num = 0.0f;
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              if (this.m_ObjectGeometryData.HasComponent(this.m_Prefab))
              {
                // ISSUE: reference to a compiler-generated field
                // ISSUE: reference to a compiler-generated field
                ObjectGeometryData objectGeometryData = this.m_ObjectGeometryData[this.m_Prefab];
                if ((objectGeometryData.m_Flags & Game.Objects.GeometryFlags.Standing) != Game.Objects.GeometryFlags.None)
                {
                  num = objectGeometryData.m_LegSize.z * 0.5f;
                  if ((double) objectGeometryData.m_LegSize.y <= (double) prefabCompositionData1.m_HeightRange.max)
                    num = math.max(num, objectGeometryData.m_Size.z * 0.5f);
                }
                else
                  num = objectGeometryData.m_Size.z * 0.5f;
              }
              // ISSUE: reference to a compiler-generated method
              this.SnapSegmentAreas(controlPoint1, ref controlPoint2, num, controlPoint1.m_OriginalEntity, edgeGeometry.m_Start, prefabCompositionData1, prefabCompositionArea);
              // ISSUE: reference to a compiler-generated method
              this.SnapSegmentAreas(controlPoint1, ref controlPoint2, num, controlPoint1.m_OriginalEntity, edgeGeometry.m_End, prefabCompositionData1, prefabCompositionArea);
            }
            else
            {
              // ISSUE: reference to a compiler-generated field
              if (this.m_ConnectedEdges.HasBuffer(controlPoint1.m_OriginalEntity))
              {
                // ISSUE: reference to a compiler-generated field
                DynamicBuffer<ConnectedEdge> connectedEdge = this.m_ConnectedEdges[controlPoint1.m_OriginalEntity];
                for (int index = 0; index < connectedEdge.Length; ++index)
                {
                  Entity edge1 = connectedEdge[index].m_Edge;
                  // ISSUE: reference to a compiler-generated field
                  Game.Net.Edge edge2 = this.m_EdgeData[edge1];
                  // ISSUE: reference to a compiler-generated field
                  if ((!(edge2.m_Start != controlPoint1.m_OriginalEntity) || !(edge2.m_End != controlPoint1.m_OriginalEntity)) && this.m_EdgeGeometryData.HasComponent(edge1))
                  {
                    // ISSUE: reference to a compiler-generated field
                    EdgeGeometry edgeGeometry = this.m_EdgeGeometryData[edge1];
                    // ISSUE: reference to a compiler-generated field
                    Composition composition = this.m_CompositionData[edge1];
                    // ISSUE: reference to a compiler-generated field
                    NetCompositionData prefabCompositionData1 = this.m_PrefabCompositionData[composition.m_Edge];
                    // ISSUE: reference to a compiler-generated field
                    DynamicBuffer<NetCompositionArea> prefabCompositionArea = this.m_PrefabCompositionAreas[composition.m_Edge];
                    float num = 0.0f;
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    if (this.m_ObjectGeometryData.HasComponent(this.m_Prefab))
                    {
                      // ISSUE: reference to a compiler-generated field
                      // ISSUE: reference to a compiler-generated field
                      ObjectGeometryData objectGeometryData = this.m_ObjectGeometryData[this.m_Prefab];
                      if ((objectGeometryData.m_Flags & Game.Objects.GeometryFlags.Standing) != Game.Objects.GeometryFlags.None)
                      {
                        num = objectGeometryData.m_LegSize.z * 0.5f;
                        if ((double) objectGeometryData.m_LegSize.y <= (double) prefabCompositionData1.m_HeightRange.max)
                          num = math.max(num, objectGeometryData.m_Size.z * 0.5f);
                      }
                      else
                        num = objectGeometryData.m_Size.z * 0.5f;
                    }
                    // ISSUE: reference to a compiler-generated method
                    this.SnapSegmentAreas(controlPoint1, ref controlPoint2, num, edge1, edgeGeometry.m_Start, prefabCompositionData1, prefabCompositionArea);
                    // ISSUE: reference to a compiler-generated method
                    this.SnapSegmentAreas(controlPoint1, ref controlPoint2, num, edge1, edgeGeometry.m_End, prefabCompositionData1, prefabCompositionArea);
                  }
                }
              }
            }
          }
        }
        // ISSUE: reference to a compiler-generated field
        if ((this.m_Snap & Snap.NetNode) != Snap.None)
        {
          // ISSUE: reference to a compiler-generated field
          if (this.m_NodeData.HasComponent(controlPoint1.m_OriginalEntity))
          {
            // ISSUE: reference to a compiler-generated field
            Game.Net.Node node = this.m_NodeData[controlPoint1.m_OriginalEntity];
            // ISSUE: reference to a compiler-generated method
            this.SnapNode(controlPoint1, ref controlPoint2, controlPoint1.m_OriginalEntity, node);
          }
          else
          {
            // ISSUE: reference to a compiler-generated field
            if (this.m_EdgeData.HasComponent(controlPoint1.m_OriginalEntity))
            {
              // ISSUE: reference to a compiler-generated field
              Game.Net.Edge edge = this.m_EdgeData[controlPoint1.m_OriginalEntity];
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated method
              this.SnapNode(controlPoint1, ref controlPoint2, edge.m_Start, this.m_NodeData[edge.m_Start]);
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated method
              this.SnapNode(controlPoint1, ref controlPoint2, edge.m_End, this.m_NodeData[edge.m_End]);
            }
          }
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        if ((this.m_Snap & Snap.ObjectSurface) != Snap.None && this.m_TransformData.HasComponent(controlPoint1.m_OriginalEntity))
        {
          int parentMesh1 = controlPoint1.m_ElementIndex.x;
          Entity entity;
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          for (entity = controlPoint1.m_OriginalEntity; this.m_OwnerData.HasComponent(entity); entity = this.m_OwnerData[entity].m_Owner)
          {
            // ISSUE: reference to a compiler-generated field
            if (this.m_LocalTransformCacheData.HasComponent(entity))
            {
              // ISSUE: reference to a compiler-generated field
              int parentMesh2 = this.m_LocalTransformCacheData[entity].m_ParentMesh;
              parentMesh1 = parentMesh2 + math.select(1000, -1000, parentMesh2 < 0);
            }
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          if (this.m_TransformData.HasComponent(entity) && this.m_SubObjects.HasBuffer(entity))
          {
            // ISSUE: reference to a compiler-generated method
            this.SnapSurface(controlPoint1, ref controlPoint2, entity, parentMesh1);
          }
        }
        // ISSUE: reference to a compiler-generated method
        this.CalculateHeight(ref controlPoint2, minValue);
        // ISSUE: reference to a compiler-generated field
        if (this.m_EditorMode)
        {
          // ISSUE: reference to a compiler-generated field
          if ((this.m_Snap & Snap.AutoParent) == Snap.None)
          {
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            if ((this.m_Snap & (Snap.NetArea | Snap.NetNode)) == Snap.None || this.m_TransformData.HasComponent(controlPoint2.m_OriginalEntity) || this.m_BuildingData.HasComponent(this.m_Prefab))
              controlPoint2.m_OriginalEntity = Entity.Null;
          }
          else if (controlPoint2.m_OriginalEntity == Entity.Null)
          {
            ObjectGeometryData geometryData = new ObjectGeometryData();
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            if (this.m_ObjectGeometryData.HasComponent(this.m_Prefab))
            {
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              geometryData = this.m_ObjectGeometryData[this.m_Prefab];
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            // ISSUE: object of a compiler-generated type is created
            // ISSUE: variable of a compiler-generated type
            ObjectToolSystem.SnapJob.ParentObjectIterator iterator = new ObjectToolSystem.SnapJob.ParentObjectIterator()
            {
              m_ControlPoint = controlPoint2,
              m_BestSnapPosition = controlPoint2,
              m_Bounds = ObjectUtils.CalculateBounds(controlPoint2.m_Position, controlPoint2.m_Rotation, geometryData),
              m_BestOverlap = float.MaxValue,
              m_IsBuilding = this.m_BuildingData.HasComponent(this.m_Prefab),
              m_PrefabObjectGeometryData1 = geometryData,
              m_TransformData = this.m_TransformData,
              m_BuildingData = this.m_BuildingData,
              m_AssetStampData = this.m_AssetStampData,
              m_PrefabRefData = this.m_PrefabRefData,
              m_PrefabObjectGeometryData = this.m_ObjectGeometryData
            };
            // ISSUE: reference to a compiler-generated field
            this.m_ObjectSearchTree.Iterate<ObjectToolSystem.SnapJob.ParentObjectIterator>(ref iterator);
            // ISSUE: reference to a compiler-generated field
            controlPoint2 = iterator.m_BestSnapPosition;
          }
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        if (this.m_Mode == ObjectToolSystem.Mode.Create && this.m_NetObjectData.HasComponent(this.m_Prefab) && (this.m_NodeData.HasComponent(controlPoint2.m_OriginalEntity) || this.m_EdgeData.HasComponent(controlPoint2.m_OriginalEntity)))
        {
          // ISSUE: reference to a compiler-generated method
          this.FindOriginalObject(ref controlPoint2, controlPoint1);
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: variable of a compiler-generated type
        ObjectToolSystem.Rotation rotation = this.m_Rotation.value;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        rotation.m_IsAligned &= rotation.m_Rotation.Equals(controlPoint2.m_Rotation);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated method
        this.AlignObject(ref controlPoint2, ref rotation.m_ParentRotation, rotation.m_IsAligned);
        // ISSUE: reference to a compiler-generated field
        rotation.m_Rotation = controlPoint2.m_Rotation;
        // ISSUE: reference to a compiler-generated field
        this.m_Rotation.value = rotation;
        ObjectGeometryData componentData4;
        PlaceableObjectData componentData5;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        if ((controlPoint2.m_OriginalEntity == Entity.Null || controlPoint2.m_ElementIndex.x == -1 || (double) controlPoint2.m_HitDirection.y > 0.99000000953674316) && this.m_ObjectGeometryData.TryGetComponent(this.m_Prefab, out componentData4) && (double) componentData4.m_Bounds.min.y <= -0.0099999997764825821 && (this.m_PlaceableObjectData.TryGetComponent(this.m_Prefab, out componentData5) && (componentData5.m_Flags & (Game.Objects.PlacementFlags.Wall | Game.Objects.PlacementFlags.Hanging)) != Game.Objects.PlacementFlags.None && (this.m_Snap & Snap.Upright) != Snap.None || this.m_EditorMode && this.m_MovingObjectData.HasComponent(this.m_Prefab)))
        {
          controlPoint2.m_Elevation -= componentData4.m_Bounds.min.y;
          controlPoint2.m_Position.y -= componentData4.m_Bounds.min.y;
        }
        StackData componentData6;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        if (this.m_StackData.TryGetComponent(this.m_Prefab, out componentData6) && componentData6.m_Direction == StackDirection.Up)
        {
          float num = componentData6.m_FirstBounds.max + MathUtils.Size(componentData6.m_MiddleBounds) * 2f - componentData6.m_LastBounds.min;
          controlPoint2.m_Elevation += num;
          controlPoint2.m_Position.y += num;
        }
        // ISSUE: reference to a compiler-generated field
        this.m_ControlPoints[0] = controlPoint2;
      }

      private void FindLoweredParent(ref ControlPoint controlPoint)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        ObjectToolSystem.SnapJob.LoweredParentIterator iterator = new ObjectToolSystem.SnapJob.LoweredParentIterator()
        {
          m_Result = controlPoint,
          m_Position = controlPoint.m_HitPosition,
          m_EdgeData = this.m_EdgeData,
          m_NodeData = this.m_NodeData,
          m_OrphanData = this.m_OrphanData,
          m_CurveData = this.m_CurveData,
          m_CompositionData = this.m_CompositionData,
          m_EdgeGeometryData = this.m_EdgeGeometryData,
          m_StartNodeGeometryData = this.m_StartNodeGeometryData,
          m_EndNodeGeometryData = this.m_EndNodeGeometryData,
          m_PrefabCompositionData = this.m_PrefabCompositionData
        };
        // ISSUE: reference to a compiler-generated field
        this.m_NetSearchTree.Iterate<ObjectToolSystem.SnapJob.LoweredParentIterator>(ref iterator);
        // ISSUE: reference to a compiler-generated field
        controlPoint = iterator.m_Result;
      }

      private void FindOriginalObject(ref ControlPoint bestSnapPosition, ControlPoint controlPoint)
      {
        ObjectGeometryData componentData1;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: variable of a compiler-generated type
        ObjectToolSystem.SnapJob.OriginalObjectIterator iterator = new ObjectToolSystem.SnapJob.OriginalObjectIterator()
        {
          m_Parent = bestSnapPosition.m_OriginalEntity,
          m_BestDistance = float.MaxValue,
          m_EditorMode = this.m_EditorMode,
          m_OwnerData = this.m_OwnerData,
          m_AttachedData = this.m_AttachedData,
          m_PrefabRefData = this.m_PrefabRefData,
          m_NetObjectData = this.m_NetObjectData,
          m_TransportStopData = this.m_TransportStopData
        } with
        {
          m_Bounds = !this.m_ObjectGeometryData.TryGetComponent(this.m_Prefab, out componentData1) ? new Bounds3(bestSnapPosition.m_Position - 1f, bestSnapPosition.m_Position + 1f) : ObjectUtils.CalculateBounds(bestSnapPosition.m_Position, bestSnapPosition.m_Rotation, componentData1)
        };
        TransportStopData componentData2;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        if (this.m_TransportStopData.TryGetComponent(this.m_Prefab, out componentData2))
        {
          // ISSUE: reference to a compiler-generated field
          iterator.m_TransportStopData1 = componentData2;
        }
        // ISSUE: reference to a compiler-generated field
        this.m_ObjectSearchTree.Iterate<ObjectToolSystem.SnapJob.OriginalObjectIterator>(ref iterator);
        // ISSUE: reference to a compiler-generated field
        if (!(iterator.m_Result != Entity.Null))
          return;
        // ISSUE: reference to a compiler-generated field
        bestSnapPosition.m_OriginalEntity = iterator.m_Result;
      }

      private void HandleWorldSize(ref ControlPoint bestSnapPosition, ControlPoint controlPoint)
      {
        // ISSUE: reference to a compiler-generated field
        Bounds3 bounds = TerrainUtils.GetBounds(ref this.m_TerrainHeightData);
        bool2 bool2 = (bool2) false;
        float2 float2 = (float2) 0.0f;
        Bounds3 bounds3 = new Bounds3(controlPoint.m_HitPosition, controlPoint.m_HitPosition);
        ObjectGeometryData componentData;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        if (this.m_ObjectGeometryData.TryGetComponent(this.m_Prefab, out componentData))
          bounds3 = ObjectUtils.CalculateBounds(controlPoint.m_HitPosition, controlPoint.m_Rotation, componentData);
        if ((double) bounds3.min.x < (double) bounds.min.x)
        {
          bool2.x = true;
          float2.x = bounds.min.x;
        }
        else if ((double) bounds3.max.x > (double) bounds.max.x)
        {
          bool2.x = true;
          float2.x = bounds.max.x;
        }
        if ((double) bounds3.min.z < (double) bounds.min.z)
        {
          bool2.y = true;
          float2.y = bounds.min.z;
        }
        else if ((double) bounds3.max.z > (double) bounds.max.z)
        {
          bool2.y = true;
          float2.y = bounds.max.z;
        }
        if (!math.any(bool2))
          return;
        ControlPoint snapPosition = controlPoint with
        {
          m_OriginalEntity = Entity.Null,
          m_Direction = new float2(0.0f, 1f)
        };
        snapPosition.m_Position.xz = math.select(controlPoint.m_HitPosition.xz, float2, bool2);
        snapPosition.m_Position.y = controlPoint.m_HitPosition.y;
        snapPosition.m_SnapPriority = ToolUtils.CalculateSnapPriority(2f, 1f, controlPoint.m_HitPosition.xz, snapPosition.m_Position.xz, snapPosition.m_Direction);
        snapPosition.m_Rotation = quaternion.LookRotationSafe(new float3()
        {
          xz = math.sign(float2)
        }, math.up());
        // ISSUE: reference to a compiler-generated method
        ObjectToolSystem.SnapJob.AddSnapPosition(ref bestSnapPosition, snapPosition);
      }

      public static void AlignRotation(
        ref quaternion rotation,
        quaternion parentRotation,
        bool zAxis)
      {
        if (zAxis)
        {
          quaternion a = quaternion.LookRotationSafe(math.rotate(rotation, new float3(0.0f, 0.0f, 1f)), math.rotate(parentRotation, new float3(0.0f, 1f, 0.0f)));
          quaternion q = rotation;
          float num1 = float.MaxValue;
          for (int index = 0; index < 8; ++index)
          {
            quaternion b = math.mul(a, quaternion.RotateZ((float) index * 0.7853982f));
            float num2 = MathUtils.RotationAngle(rotation, b);
            if ((double) num2 < (double) num1)
            {
              q = b;
              num1 = num2;
            }
          }
          rotation = math.normalizesafe(q, quaternion.identity);
        }
        else
        {
          quaternion a = math.mul(quaternion.LookRotationSafe(math.rotate(rotation, new float3(0.0f, 1f, 0.0f)), math.rotate(parentRotation, new float3(1f, 0.0f, 0.0f))), quaternion.RotateX(1.57079637f));
          quaternion q = rotation;
          float num3 = float.MaxValue;
          for (int index = 0; index < 8; ++index)
          {
            quaternion b = math.mul(a, quaternion.RotateY((float) index * 0.7853982f));
            float num4 = MathUtils.RotationAngle(rotation, b);
            if ((double) num4 < (double) num3)
            {
              q = b;
              num3 = num4;
            }
          }
          rotation = math.normalizesafe(q, quaternion.identity);
        }
      }

      private void AlignObject(
        ref ControlPoint controlPoint,
        ref quaternion parentRotation,
        bool alignRotation)
      {
        PlaceableObjectData placeableObjectData = new PlaceableObjectData();
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        if (this.m_PlaceableObjectData.HasComponent(this.m_Prefab))
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          placeableObjectData = this.m_PlaceableObjectData[this.m_Prefab];
        }
        if ((placeableObjectData.m_Flags & Game.Objects.PlacementFlags.Hanging) != Game.Objects.PlacementFlags.None)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          ObjectGeometryData objectGeometryData = this.m_ObjectGeometryData[this.m_Prefab];
          controlPoint.m_Position.y -= objectGeometryData.m_Bounds.max.y;
        }
        parentRotation = quaternion.identity;
        // ISSUE: reference to a compiler-generated field
        if (this.m_TransformData.HasComponent(controlPoint.m_OriginalEntity))
        {
          Entity entity = controlPoint.m_OriginalEntity;
          // ISSUE: reference to a compiler-generated field
          PrefabRef prefabRef = this.m_PrefabRefData[entity];
          // ISSUE: reference to a compiler-generated field
          parentRotation = this.m_TransformData[entity].m_Rotation;
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          while (this.m_OwnerData.HasComponent(entity) && !this.m_BuildingData.HasComponent(prefabRef.m_Prefab))
          {
            // ISSUE: reference to a compiler-generated field
            entity = this.m_OwnerData[entity].m_Owner;
            // ISSUE: reference to a compiler-generated field
            prefabRef = this.m_PrefabRefData[entity];
            // ISSUE: reference to a compiler-generated field
            if (this.m_TransformData.HasComponent(entity))
            {
              // ISSUE: reference to a compiler-generated field
              parentRotation = this.m_TransformData[entity].m_Rotation;
            }
          }
        }
        if ((placeableObjectData.m_Flags & Game.Objects.PlacementFlags.Wall) != Game.Objects.PlacementFlags.None)
        {
          float3 x = math.forward(controlPoint.m_Rotation);
          float3 y = controlPoint.m_HitDirection;
          // ISSUE: reference to a compiler-generated field
          y.y = math.select(y.y, 0.0f, (this.m_Snap & Snap.Upright) > Snap.None);
          if (!MathUtils.TryNormalize(ref y))
          {
            y = x;
            // ISSUE: reference to a compiler-generated field
            y.y = math.select(y.y, 0.0f, (this.m_Snap & Snap.Upright) > Snap.None);
            if (!MathUtils.TryNormalize(ref y))
              y = new float3(0.0f, 0.0f, 1f);
          }
          float3 axis = math.cross(x, y);
          if (MathUtils.TryNormalize(ref axis))
          {
            float angle = math.acos(math.clamp(math.dot(x, y), -1f, 1f));
            controlPoint.m_Rotation = math.normalizesafe(math.mul(quaternion.AxisAngle(axis, angle), controlPoint.m_Rotation), quaternion.identity);
            if (alignRotation)
            {
              // ISSUE: reference to a compiler-generated method
              ObjectToolSystem.SnapJob.AlignRotation(ref controlPoint.m_Rotation, parentRotation, true);
            }
          }
          controlPoint.m_Position += math.forward(controlPoint.m_Rotation) * placeableObjectData.m_PlacementOffset.z;
        }
        else
        {
          float3 x = math.rotate(controlPoint.m_Rotation, new float3(0.0f, 1f, 0.0f));
          // ISSUE: reference to a compiler-generated field
          float3 y = math.select(controlPoint.m_HitDirection, new float3(0.0f, 1f, 0.0f), (this.m_Snap & Snap.Upright) > Snap.None);
          if (!MathUtils.TryNormalize(ref y))
            y = x;
          float3 axis = math.cross(x, y);
          if (!MathUtils.TryNormalize(ref axis))
            return;
          float angle = math.acos(math.clamp(math.dot(x, y), -1f, 1f));
          controlPoint.m_Rotation = math.normalizesafe(math.mul(quaternion.AxisAngle(axis, angle), controlPoint.m_Rotation), quaternion.identity);
          if (!alignRotation)
            return;
          // ISSUE: reference to a compiler-generated method
          ObjectToolSystem.SnapJob.AlignRotation(ref controlPoint.m_Rotation, parentRotation, false);
        }
      }

      private void CalculateHeight(ref ControlPoint controlPoint, float waterSurfaceHeight)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        if (!this.m_PlaceableObjectData.HasComponent(this.m_Prefab))
          return;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        PlaceableObjectData placeableObjectData = this.m_PlaceableObjectData[this.m_Prefab];
        // ISSUE: reference to a compiler-generated field
        if (this.m_SubObjects.HasBuffer(controlPoint.m_OriginalEntity))
        {
          controlPoint.m_Position.y += placeableObjectData.m_PlacementOffset.y;
        }
        else
        {
          float x;
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          if ((placeableObjectData.m_Flags & Game.Objects.PlacementFlags.RoadSide) != Game.Objects.PlacementFlags.None && this.m_BuildingData.HasComponent(this.m_Prefab))
          {
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            Game.Prefabs.BuildingData buildingData = this.m_BuildingData[this.m_Prefab];
            // ISSUE: reference to a compiler-generated field
            x = TerrainUtils.SampleHeight(ref this.m_TerrainHeightData, BuildingUtils.CalculateFrontPosition(new Game.Objects.Transform(controlPoint.m_Position, controlPoint.m_Rotation), buildingData.m_LotSize.y));
          }
          else
          {
            // ISSUE: reference to a compiler-generated field
            x = TerrainUtils.SampleHeight(ref this.m_TerrainHeightData, controlPoint.m_Position);
          }
          if ((placeableObjectData.m_Flags & Game.Objects.PlacementFlags.Hovering) != Game.Objects.PlacementFlags.None)
          {
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            float y = WaterUtils.SampleHeight(ref this.m_WaterSurfaceData, ref this.m_TerrainHeightData, controlPoint.m_Position) + placeableObjectData.m_PlacementOffset.y;
            controlPoint.m_Elevation = math.max(0.0f, y - x);
            x = math.max(x, y);
          }
          else if ((placeableObjectData.m_Flags & (Game.Objects.PlacementFlags.Shoreline | Game.Objects.PlacementFlags.Floating)) == Game.Objects.PlacementFlags.None)
          {
            x += placeableObjectData.m_PlacementOffset.y;
          }
          else
          {
            float waterDepth;
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            float num = WaterUtils.SampleHeight(ref this.m_WaterSurfaceData, ref this.m_TerrainHeightData, controlPoint.m_Position, out waterDepth);
            if ((double) waterDepth >= 0.20000000298023224)
            {
              float y = num + placeableObjectData.m_PlacementOffset.y;
              if ((placeableObjectData.m_Flags & Game.Objects.PlacementFlags.Floating) != Game.Objects.PlacementFlags.None)
                controlPoint.m_Elevation = math.max(0.0f, y - x);
              x = math.max(x, y);
            }
          }
          // ISSUE: reference to a compiler-generated field
          if ((this.m_Snap & Snap.Shoreline) != Snap.None)
            x = math.max(x, waterSurfaceHeight + placeableObjectData.m_PlacementOffset.y);
          controlPoint.m_Position.y = x;
        }
      }

      private void SnapSurface(
        ControlPoint controlPoint,
        ref ControlPoint bestPosition,
        Entity entity,
        int parentMesh)
      {
        // ISSUE: reference to a compiler-generated field
        Game.Objects.Transform transform = this.m_TransformData[entity];
        ControlPoint snapPosition = controlPoint with
        {
          m_OriginalEntity = entity
        };
        snapPosition.m_ElementIndex.x = parentMesh;
        snapPosition.m_Position = controlPoint.m_HitPosition;
        snapPosition.m_Direction = math.forward(transform.m_Rotation).xz;
        snapPosition.m_SnapPriority = ToolUtils.CalculateSnapPriority(0.0f, 1f, controlPoint.m_HitPosition.xz, snapPosition.m_Position.xz, snapPosition.m_Direction);
        // ISSUE: reference to a compiler-generated method
        ObjectToolSystem.SnapJob.AddSnapPosition(ref bestPosition, snapPosition);
      }

      private void SnapNode(
        ControlPoint controlPoint,
        ref ControlPoint bestPosition,
        Entity entity,
        Game.Net.Node node)
      {
        Bounds1 bounds1 = new Bounds1(float.MaxValue, float.MinValue);
        // ISSUE: reference to a compiler-generated field
        DynamicBuffer<ConnectedEdge> connectedEdge = this.m_ConnectedEdges[entity];
        for (int index = 0; index < connectedEdge.Length; ++index)
        {
          Entity edge1 = connectedEdge[index].m_Edge;
          // ISSUE: reference to a compiler-generated field
          Game.Net.Edge edge2 = this.m_EdgeData[edge1];
          if (edge2.m_Start == entity)
          {
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            NetCompositionData netCompositionData = this.m_PrefabCompositionData[this.m_CompositionData[edge1].m_StartNode];
            bounds1 |= netCompositionData.m_SurfaceHeight;
          }
          else if (edge2.m_End == entity)
          {
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            NetCompositionData netCompositionData = this.m_PrefabCompositionData[this.m_CompositionData[edge1].m_EndNode];
            bounds1 |= netCompositionData.m_SurfaceHeight;
          }
        }
        ControlPoint snapPosition = controlPoint with
        {
          m_OriginalEntity = entity,
          m_Position = node.m_Position
        };
        if ((double) bounds1.min < 3.4028234663852886E+38)
          snapPosition.m_Position.y += bounds1.min;
        snapPosition.m_Direction = math.normalizesafe(math.forward(node.m_Rotation)).xz;
        snapPosition.m_Rotation = node.m_Rotation;
        snapPosition.m_SnapPriority = ToolUtils.CalculateSnapPriority(1f, 1f, controlPoint.m_HitPosition.xz, snapPosition.m_Position.xz, snapPosition.m_Direction);
        // ISSUE: reference to a compiler-generated method
        ObjectToolSystem.SnapJob.AddSnapPosition(ref bestPosition, snapPosition);
      }

      private void SnapShoreline(
        ControlPoint controlPoint,
        ref ControlPoint bestPosition,
        ref float waterSurfaceHeight,
        float radius,
        float3 offset)
      {
        // ISSUE: reference to a compiler-generated field
        int2 x1 = (int2) math.floor(WaterUtils.ToSurfaceSpace(ref this.m_WaterSurfaceData, controlPoint.m_HitPosition - radius).xz);
        // ISSUE: reference to a compiler-generated field
        int2 x2 = (int2) math.ceil(WaterUtils.ToSurfaceSpace(ref this.m_WaterSurfaceData, controlPoint.m_HitPosition + radius).xz);
        int2 int2_1 = math.max(x1, new int2());
        // ISSUE: reference to a compiler-generated field
        int2 int2_2 = math.min(x2, this.m_WaterSurfaceData.resolution.xz - 1);
        float3 float3_1 = new float3();
        float3 float3_2 = new float3();
        float2 float2 = new float2();
        for (int y1 = int2_1.y; y1 <= int2_2.y; ++y1)
        {
          for (int x3 = int2_1.x; x3 <= int2_2.x; ++x3)
          {
            // ISSUE: reference to a compiler-generated field
            float3 worldPosition = WaterUtils.GetWorldPosition(ref this.m_WaterSurfaceData, new int2(x3, y1));
            if ((double) worldPosition.y > 0.20000000298023224)
            {
              // ISSUE: reference to a compiler-generated field
              float num = TerrainUtils.SampleHeight(ref this.m_TerrainHeightData, worldPosition) + worldPosition.y;
              float y2 = math.max(0.0f, radius * radius - math.distancesq(worldPosition.xz, controlPoint.m_HitPosition.xz));
              worldPosition.y = (worldPosition.y - 0.2f) * y2;
              worldPosition.xz *= worldPosition.y;
              float3_2 += worldPosition;
              float x4 = num * y2;
              float2 += new float2(x4, y2);
            }
            else if ((double) worldPosition.y < 0.20000000298023224)
            {
              float num = math.max(0.0f, radius * radius - math.distancesq(worldPosition.xz, controlPoint.m_HitPosition.xz));
              worldPosition.y = (0.2f - worldPosition.y) * num;
              worldPosition.xz *= worldPosition.y;
              float3_1 += worldPosition;
            }
          }
        }
        if ((double) float3_1.y == 0.0 || (double) float3_2.y == 0.0 || (double) float2.y == 0.0)
          return;
        float3 float3_3 = float3_1 / float3_1.y;
        float3 float3_4 = float3_2 / float3_2.y;
        float3 float3_5 = new float3();
        float3_5.xz = float3_3.xz - float3_4.xz;
        if (!MathUtils.TryNormalize(ref float3_5))
          return;
        waterSurfaceHeight = float2.x / float2.y;
        bestPosition = controlPoint;
        bestPosition.m_Position.xz = math.lerp(float3_4.xz, float3_3.xz, 0.5f);
        bestPosition.m_Position.y = waterSurfaceHeight + offset.y;
        bestPosition.m_Position += float3_5 * offset.z;
        bestPosition.m_Direction = float3_5.xz;
        bestPosition.m_Rotation = ToolUtils.CalculateRotation(bestPosition.m_Direction);
        bestPosition.m_SnapPriority = ToolUtils.CalculateSnapPriority(0.0f, 1f, controlPoint.m_HitPosition.xz, bestPosition.m_Position.xz, bestPosition.m_Direction);
        bestPosition.m_OriginalEntity = Entity.Null;
      }

      private void SnapSegmentAreas(
        ControlPoint controlPoint,
        ref ControlPoint bestPosition,
        float radius,
        Entity entity,
        Game.Net.Segment segment1,
        NetCompositionData prefabCompositionData1,
        DynamicBuffer<NetCompositionArea> areas1)
      {
        for (int index = 0; index < areas1.Length; ++index)
        {
          NetCompositionArea netCompositionArea = areas1[index];
          if ((netCompositionArea.m_Flags & NetAreaFlags.Buildable) != (NetAreaFlags) 0)
          {
            float num1 = netCompositionArea.m_Width * 0.51f;
            if ((double) radius < (double) num1)
            {
              Bezier4x3 curve = MathUtils.Lerp(segment1.m_Left, segment1.m_Right, (float) ((double) netCompositionArea.m_Position.x / (double) prefabCompositionData1.m_Width + 0.5));
              float t;
              double num2 = (double) MathUtils.Distance(curve.xz, controlPoint.m_HitPosition.xz, out t);
              ControlPoint snapPosition = controlPoint with
              {
                m_OriginalEntity = entity,
                m_Position = MathUtils.Position(curve, t),
                m_Direction = math.normalizesafe(MathUtils.Tangent(curve, t).xz)
              };
              snapPosition.m_Direction = (netCompositionArea.m_Flags & NetAreaFlags.Invert) == (NetAreaFlags) 0 ? MathUtils.Left(snapPosition.m_Direction) : MathUtils.Right(snapPosition.m_Direction);
              float3 float3 = MathUtils.Position(MathUtils.Lerp(segment1.m_Left, segment1.m_Right, (float) ((double) netCompositionArea.m_SnapPosition.x / (double) prefabCompositionData1.m_Width + 0.5)), t);
              float maxLength1 = math.max(0.0f, math.min(netCompositionArea.m_Width * 0.5f, math.abs(netCompositionArea.m_SnapPosition.x - netCompositionArea.m_Position.x) + netCompositionArea.m_SnapWidth * 0.5f) - radius);
              float maxLength2 = math.max(0.0f, netCompositionArea.m_SnapWidth * 0.5f - radius);
              snapPosition.m_Position.xz += MathUtils.ClampLength(float3.xz - snapPosition.m_Position.xz, maxLength1);
              snapPosition.m_Position.xz += MathUtils.ClampLength(controlPoint.m_HitPosition.xz - snapPosition.m_Position.xz, maxLength2);
              snapPosition.m_Position.y += netCompositionArea.m_Position.y;
              snapPosition.m_Rotation = ToolUtils.CalculateRotation(snapPosition.m_Direction);
              snapPosition.m_SnapPriority = ToolUtils.CalculateSnapPriority(1f, 1f, controlPoint.m_HitPosition.xz, snapPosition.m_Position.xz, snapPosition.m_Direction);
              // ISSUE: reference to a compiler-generated method
              ObjectToolSystem.SnapJob.AddSnapPosition(ref bestPosition, snapPosition);
            }
          }
        }
      }

      private static Bounds3 SetHeightRange(Bounds3 bounds, Bounds1 heightRange)
      {
        bounds.min.y += heightRange.min;
        bounds.max.y += heightRange.max;
        return bounds;
      }

      private static void CheckSnapLine(
        Game.Prefabs.BuildingData buildingData,
        Game.Objects.Transform ownerTransformData,
        ControlPoint controlPoint,
        ref ControlPoint bestPosition,
        Line2 line,
        int maxOffset,
        float angle,
        bool forceSnap)
      {
        float t;
        double num1 = (double) MathUtils.Distance(line, controlPoint.m_Position.xz, out t);
        float num2 = math.select(0.0f, 4f, (buildingData.m_LotSize.x - buildingData.m_LotSize.y & 1) != 0);
        float num3 = (float) math.min(2 * maxOffset - buildingData.m_LotSize.y - buildingData.m_LotSize.x, buildingData.m_LotSize.y - buildingData.m_LotSize.x) * 4f;
        float num4 = math.distance(line.a, line.b);
        float num5 = math.clamp(MathUtils.Snap(t * num4 + num2, 8f) - num2, -num3, num4 + num3);
        ControlPoint snapPosition = controlPoint with
        {
          m_OriginalEntity = Entity.Null
        };
        snapPosition.m_Position.y = ownerTransformData.m_Position.y;
        snapPosition.m_Position.xz = MathUtils.Position(line, num5 / num4);
        snapPosition.m_Direction = math.mul(math.mul(ownerTransformData.m_Rotation, quaternion.RotateY(angle)), new float3(0.0f, 0.0f, 1f)).xz;
        snapPosition.m_Rotation = ToolUtils.CalculateRotation(snapPosition.m_Direction);
        float level = math.select(0.0f, 1f, forceSnap);
        snapPosition.m_SnapPriority = ToolUtils.CalculateSnapPriority(level, 1f, controlPoint.m_HitPosition.xz * 0.5f, snapPosition.m_Position.xz * 0.5f, snapPosition.m_Direction);
        // ISSUE: reference to a compiler-generated method
        ObjectToolSystem.SnapJob.AddSnapPosition(ref bestPosition, snapPosition);
      }

      private static void AddSnapPosition(
        ref ControlPoint bestSnapPosition,
        ControlPoint snapPosition)
      {
        if (!ToolUtils.CompareSnapPriority(snapPosition.m_SnapPriority, bestSnapPosition.m_SnapPriority))
          return;
        bestSnapPosition = snapPosition;
      }

      private struct LoweredParentIterator : 
        INativeQuadTreeIterator<Entity, QuadTreeBoundsXZ>,
        IUnsafeQuadTreeIterator<Entity, QuadTreeBoundsXZ>
      {
        public ControlPoint m_Result;
        public float3 m_Position;
        public ComponentLookup<Game.Net.Edge> m_EdgeData;
        public ComponentLookup<Game.Net.Node> m_NodeData;
        public ComponentLookup<Orphan> m_OrphanData;
        public ComponentLookup<Curve> m_CurveData;
        public ComponentLookup<Composition> m_CompositionData;
        public ComponentLookup<EdgeGeometry> m_EdgeGeometryData;
        public ComponentLookup<StartNodeGeometry> m_StartNodeGeometryData;
        public ComponentLookup<EndNodeGeometry> m_EndNodeGeometryData;
        public ComponentLookup<NetCompositionData> m_PrefabCompositionData;

        public bool Intersect(QuadTreeBoundsXZ bounds)
        {
          // ISSUE: reference to a compiler-generated field
          return MathUtils.Intersect(bounds.m_Bounds.xz, this.m_Position.xz);
        }

        public void Iterate(QuadTreeBoundsXZ bounds, Entity entity)
        {
          // ISSUE: reference to a compiler-generated field
          if (!MathUtils.Intersect(bounds.m_Bounds.xz, this.m_Position.xz))
            return;
          // ISSUE: reference to a compiler-generated field
          if (this.m_EdgeGeometryData.HasComponent(entity))
          {
            // ISSUE: reference to a compiler-generated method
            this.CheckEdge(entity);
          }
          else
          {
            // ISSUE: reference to a compiler-generated field
            if (!this.m_OrphanData.HasComponent(entity))
              return;
            // ISSUE: reference to a compiler-generated method
            this.CheckNode(entity);
          }
        }

        private void CheckNode(Entity entity)
        {
          // ISSUE: reference to a compiler-generated field
          Game.Net.Node node = this.m_NodeData[entity];
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          NetCompositionData netCompositionData = this.m_PrefabCompositionData[this.m_OrphanData[entity].m_Composition];
          if ((netCompositionData.m_State & CompositionState.Marker) != (CompositionState) 0 || ((netCompositionData.m_Flags.m_Left | netCompositionData.m_Flags.m_Right) & CompositionFlags.Side.Lowered) == (CompositionFlags.Side) 0)
            return;
          float3 position = node.m_Position;
          position.y += netCompositionData.m_SurfaceHeight.max;
          // ISSUE: reference to a compiler-generated field
          if ((double) math.distance(this.m_Position.xz, position.xz) > (double) netCompositionData.m_Width * 0.5)
            return;
          // ISSUE: reference to a compiler-generated field
          this.m_Result.m_OriginalEntity = entity;
          // ISSUE: reference to a compiler-generated field
          this.m_Result.m_Position = node.m_Position;
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          this.m_Result.m_HitPosition = this.m_Position;
          // ISSUE: reference to a compiler-generated field
          this.m_Result.m_HitPosition.y = position.y;
          // ISSUE: reference to a compiler-generated field
          this.m_Result.m_HitDirection = new float3();
        }

        private void CheckEdge(Entity entity)
        {
          // ISSUE: reference to a compiler-generated field
          EdgeGeometry edgeGeometry = this.m_EdgeGeometryData[entity];
          // ISSUE: reference to a compiler-generated field
          EdgeNodeGeometry geometry1 = this.m_StartNodeGeometryData[entity].m_Geometry;
          // ISSUE: reference to a compiler-generated field
          EdgeNodeGeometry geometry2 = this.m_EndNodeGeometryData[entity].m_Geometry;
          bool3 x;
          // ISSUE: reference to a compiler-generated field
          x.x = MathUtils.Intersect(edgeGeometry.m_Bounds.xz, this.m_Position.xz);
          // ISSUE: reference to a compiler-generated field
          x.y = MathUtils.Intersect(geometry1.m_Bounds.xz, this.m_Position.xz);
          // ISSUE: reference to a compiler-generated field
          x.z = MathUtils.Intersect(geometry2.m_Bounds.xz, this.m_Position.xz);
          if (!math.any(x))
            return;
          // ISSUE: reference to a compiler-generated field
          Composition composition = this.m_CompositionData[entity];
          // ISSUE: reference to a compiler-generated field
          Game.Net.Edge edge = this.m_EdgeData[entity];
          // ISSUE: reference to a compiler-generated field
          Curve curve = this.m_CurveData[entity];
          if (x.x)
          {
            // ISSUE: reference to a compiler-generated field
            NetCompositionData prefabCompositionData = this.m_PrefabCompositionData[composition.m_Edge];
            if ((prefabCompositionData.m_State & CompositionState.Marker) == (CompositionState) 0 && ((prefabCompositionData.m_Flags.m_Left | prefabCompositionData.m_Flags.m_Right) & CompositionFlags.Side.Lowered) != (CompositionFlags.Side) 0)
            {
              // ISSUE: reference to a compiler-generated method
              this.CheckSegment(entity, edgeGeometry.m_Start, curve.m_Bezier, prefabCompositionData);
              // ISSUE: reference to a compiler-generated method
              this.CheckSegment(entity, edgeGeometry.m_End, curve.m_Bezier, prefabCompositionData);
            }
          }
          if (x.y)
          {
            // ISSUE: reference to a compiler-generated field
            NetCompositionData prefabCompositionData = this.m_PrefabCompositionData[composition.m_StartNode];
            if ((prefabCompositionData.m_State & CompositionState.Marker) == (CompositionState) 0 && ((prefabCompositionData.m_Flags.m_Left | prefabCompositionData.m_Flags.m_Right) & CompositionFlags.Side.Lowered) != (CompositionFlags.Side) 0)
            {
              if ((double) geometry1.m_MiddleRadius > 0.0)
              {
                // ISSUE: reference to a compiler-generated method
                this.CheckSegment(edge.m_Start, geometry1.m_Left, curve.m_Bezier, prefabCompositionData);
                Game.Net.Segment right1 = geometry1.m_Right;
                Game.Net.Segment right2 = geometry1.m_Right;
                right1.m_Right = MathUtils.Lerp(geometry1.m_Right.m_Left, geometry1.m_Right.m_Right, 0.5f);
                right2.m_Left = MathUtils.Lerp(geometry1.m_Right.m_Left, geometry1.m_Right.m_Right, 0.5f);
                right1.m_Right.d = geometry1.m_Middle.d;
                right2.m_Left.d = geometry1.m_Middle.d;
                // ISSUE: reference to a compiler-generated method
                this.CheckSegment(edge.m_Start, right1, curve.m_Bezier, prefabCompositionData);
                // ISSUE: reference to a compiler-generated method
                this.CheckSegment(edge.m_Start, right2, curve.m_Bezier, prefabCompositionData);
              }
              else
              {
                Game.Net.Segment left = geometry1.m_Left;
                Game.Net.Segment right = geometry1.m_Right;
                // ISSUE: reference to a compiler-generated method
                this.CheckSegment(edge.m_Start, left, curve.m_Bezier, prefabCompositionData);
                // ISSUE: reference to a compiler-generated method
                this.CheckSegment(edge.m_Start, right, curve.m_Bezier, prefabCompositionData);
                left.m_Right = geometry1.m_Middle;
                right.m_Left = geometry1.m_Middle;
                // ISSUE: reference to a compiler-generated method
                this.CheckSegment(edge.m_Start, left, curve.m_Bezier, prefabCompositionData);
                // ISSUE: reference to a compiler-generated method
                this.CheckSegment(edge.m_Start, right, curve.m_Bezier, prefabCompositionData);
              }
            }
          }
          if (!x.z)
            return;
          // ISSUE: reference to a compiler-generated field
          NetCompositionData prefabCompositionData1 = this.m_PrefabCompositionData[composition.m_EndNode];
          if ((prefabCompositionData1.m_State & CompositionState.Marker) != (CompositionState) 0 || ((prefabCompositionData1.m_Flags.m_Left | prefabCompositionData1.m_Flags.m_Right) & CompositionFlags.Side.Lowered) == (CompositionFlags.Side) 0)
            return;
          if ((double) geometry2.m_MiddleRadius > 0.0)
          {
            // ISSUE: reference to a compiler-generated method
            this.CheckSegment(edge.m_End, geometry2.m_Left, curve.m_Bezier, prefabCompositionData1);
            Game.Net.Segment right3 = geometry2.m_Right;
            Game.Net.Segment right4 = geometry2.m_Right;
            right3.m_Right = MathUtils.Lerp(geometry2.m_Right.m_Left, geometry2.m_Right.m_Right, 0.5f);
            right3.m_Right.d = geometry2.m_Middle.d;
            right4.m_Left = right3.m_Right;
            // ISSUE: reference to a compiler-generated method
            this.CheckSegment(edge.m_End, right3, curve.m_Bezier, prefabCompositionData1);
            // ISSUE: reference to a compiler-generated method
            this.CheckSegment(edge.m_End, right4, curve.m_Bezier, prefabCompositionData1);
          }
          else
          {
            Game.Net.Segment left = geometry2.m_Left;
            Game.Net.Segment right = geometry2.m_Right;
            // ISSUE: reference to a compiler-generated method
            this.CheckSegment(edge.m_End, left, curve.m_Bezier, prefabCompositionData1);
            // ISSUE: reference to a compiler-generated method
            this.CheckSegment(edge.m_End, right, curve.m_Bezier, prefabCompositionData1);
            left.m_Right = geometry2.m_Middle;
            right.m_Left = geometry2.m_Middle;
            // ISSUE: reference to a compiler-generated method
            this.CheckSegment(edge.m_End, left, curve.m_Bezier, prefabCompositionData1);
            // ISSUE: reference to a compiler-generated method
            this.CheckSegment(edge.m_End, right, curve.m_Bezier, prefabCompositionData1);
          }
        }

        private void CheckSegment(
          Entity entity,
          Game.Net.Segment segment,
          Bezier4x3 curve,
          NetCompositionData prefabCompositionData)
        {
          float3 _a1 = segment.m_Left.a;
          float3 float3_1 = segment.m_Right.a;
          for (int index = 1; index <= 8; ++index)
          {
            float t1 = (float) index / 8f;
            float3 float3_2 = MathUtils.Position(segment.m_Left, t1);
            float3 _a2 = MathUtils.Position(segment.m_Right, t1);
            Triangle3 triangle3_1 = new Triangle3(_a1, float3_1, float3_2);
            Triangle3 triangle3_2 = new Triangle3(_a2, float3_2, float3_1);
            float2 t2;
            // ISSUE: reference to a compiler-generated field
            if (MathUtils.Intersect(triangle3_1.xz, this.m_Position.xz, out t2))
            {
              // ISSUE: reference to a compiler-generated field
              float3 position = this.m_Position with
              {
                y = MathUtils.Position(triangle3_1.y, t2) + prefabCompositionData.m_SurfaceHeight.max
              };
              float t3;
              double num = (double) MathUtils.Distance(curve.xz, position.xz, out t3);
              // ISSUE: reference to a compiler-generated field
              this.m_Result.m_OriginalEntity = entity;
              // ISSUE: reference to a compiler-generated field
              this.m_Result.m_Position = MathUtils.Position(curve, t3);
              // ISSUE: reference to a compiler-generated field
              this.m_Result.m_HitPosition = position;
              // ISSUE: reference to a compiler-generated field
              this.m_Result.m_HitDirection = new float3();
              // ISSUE: reference to a compiler-generated field
              this.m_Result.m_CurvePosition = t3;
            }
            else
            {
              // ISSUE: reference to a compiler-generated field
              if (MathUtils.Intersect(triangle3_2.xz, this.m_Position.xz, out t2))
              {
                // ISSUE: reference to a compiler-generated field
                float3 position = this.m_Position with
                {
                  y = MathUtils.Position(triangle3_2.y, t2) + prefabCompositionData.m_SurfaceHeight.max
                };
                float t4;
                double num = (double) MathUtils.Distance(curve.xz, position.xz, out t4);
                // ISSUE: reference to a compiler-generated field
                this.m_Result.m_OriginalEntity = entity;
                // ISSUE: reference to a compiler-generated field
                this.m_Result.m_Position = MathUtils.Position(curve, t4);
                // ISSUE: reference to a compiler-generated field
                this.m_Result.m_HitPosition = position;
                // ISSUE: reference to a compiler-generated field
                this.m_Result.m_HitDirection = new float3();
                // ISSUE: reference to a compiler-generated field
                this.m_Result.m_CurvePosition = t4;
              }
            }
            _a1 = float3_2;
            float3_1 = _a2;
          }
        }
      }

      private struct OriginalObjectIterator : 
        INativeQuadTreeIterator<Entity, QuadTreeBoundsXZ>,
        IUnsafeQuadTreeIterator<Entity, QuadTreeBoundsXZ>
      {
        public Entity m_Parent;
        public Entity m_Result;
        public Bounds3 m_Bounds;
        public float m_BestDistance;
        public bool m_EditorMode;
        public TransportStopData m_TransportStopData1;
        public ComponentLookup<Owner> m_OwnerData;
        public ComponentLookup<Attached> m_AttachedData;
        public ComponentLookup<PrefabRef> m_PrefabRefData;
        public ComponentLookup<NetObjectData> m_NetObjectData;
        public ComponentLookup<TransportStopData> m_TransportStopData;

        public bool Intersect(QuadTreeBoundsXZ bounds)
        {
          // ISSUE: reference to a compiler-generated field
          return MathUtils.Intersect(bounds.m_Bounds, this.m_Bounds);
        }

        public void Iterate(QuadTreeBoundsXZ bounds, Entity item)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          if (!MathUtils.Intersect(bounds.m_Bounds, this.m_Bounds) || !this.m_AttachedData.HasComponent(item) || !this.m_EditorMode && this.m_OwnerData.HasComponent(item) || this.m_AttachedData[item].m_Parent != this.m_Parent)
            return;
          // ISSUE: reference to a compiler-generated field
          PrefabRef prefabRef = this.m_PrefabRefData[item];
          // ISSUE: reference to a compiler-generated field
          if (!this.m_NetObjectData.HasComponent(prefabRef.m_Prefab))
            return;
          TransportStopData transportStopData = new TransportStopData();
          // ISSUE: reference to a compiler-generated field
          if (this.m_TransportStopData.HasComponent(prefabRef.m_Prefab))
          {
            // ISSUE: reference to a compiler-generated field
            transportStopData = this.m_TransportStopData[prefabRef.m_Prefab];
          }
          // ISSUE: reference to a compiler-generated field
          if (this.m_TransportStopData1.m_TransportType != transportStopData.m_TransportType)
            return;
          // ISSUE: reference to a compiler-generated field
          float num = math.distance(MathUtils.Center(this.m_Bounds), MathUtils.Center(bounds.m_Bounds));
          // ISSUE: reference to a compiler-generated field
          if ((double) num >= (double) this.m_BestDistance)
            return;
          // ISSUE: reference to a compiler-generated field
          this.m_Result = item;
          // ISSUE: reference to a compiler-generated field
          this.m_BestDistance = num;
        }
      }

      private struct ParentObjectIterator : 
        INativeQuadTreeIterator<Entity, QuadTreeBoundsXZ>,
        IUnsafeQuadTreeIterator<Entity, QuadTreeBoundsXZ>
      {
        public ControlPoint m_ControlPoint;
        public ControlPoint m_BestSnapPosition;
        public Bounds3 m_Bounds;
        public float m_BestOverlap;
        public bool m_IsBuilding;
        public ObjectGeometryData m_PrefabObjectGeometryData1;
        public ComponentLookup<Game.Objects.Transform> m_TransformData;
        public ComponentLookup<PrefabRef> m_PrefabRefData;
        public ComponentLookup<Game.Prefabs.BuildingData> m_BuildingData;
        public ComponentLookup<AssetStampData> m_AssetStampData;
        public ComponentLookup<ObjectGeometryData> m_PrefabObjectGeometryData;

        public bool Intersect(QuadTreeBoundsXZ bounds)
        {
          // ISSUE: reference to a compiler-generated field
          return MathUtils.Intersect(bounds.m_Bounds.xz, this.m_Bounds.xz);
        }

        public void Iterate(QuadTreeBoundsXZ bounds, Entity item)
        {
          // ISSUE: reference to a compiler-generated field
          if (!MathUtils.Intersect(bounds.m_Bounds.xz, this.m_Bounds.xz))
            return;
          // ISSUE: reference to a compiler-generated field
          PrefabRef prefabRef = this.m_PrefabRefData[item];
          // ISSUE: reference to a compiler-generated field
          bool flag1 = this.m_BuildingData.HasComponent(prefabRef.m_Prefab);
          // ISSUE: reference to a compiler-generated field
          bool flag2 = this.m_AssetStampData.HasComponent(prefabRef.m_Prefab);
          // ISSUE: reference to a compiler-generated field
          if (this.m_IsBuilding && !flag2)
            return;
          // ISSUE: reference to a compiler-generated field
          float num = this.m_BestOverlap;
          if (flag1 | flag2)
          {
            // ISSUE: reference to a compiler-generated field
            Game.Objects.Transform transform = this.m_TransformData[item];
            // ISSUE: reference to a compiler-generated field
            ObjectGeometryData objectGeometryData = this.m_PrefabObjectGeometryData[prefabRef.m_Prefab];
            float3 float3 = MathUtils.Center(bounds.m_Bounds);
            // ISSUE: reference to a compiler-generated field
            if ((this.m_PrefabObjectGeometryData1.m_Flags & Game.Objects.GeometryFlags.Circular) != Game.Objects.GeometryFlags.None)
            {
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              Circle2 circle2_1 = new Circle2((float) ((double) this.m_PrefabObjectGeometryData1.m_Size.x * 0.5 - 0.0099999997764825821), (this.m_ControlPoint.m_Position - float3).xz);
              if ((objectGeometryData.m_Flags & Game.Objects.GeometryFlags.Circular) != Game.Objects.GeometryFlags.None)
              {
                Circle2 circle2_2 = new Circle2((float) ((double) objectGeometryData.m_Size.x * 0.5 - 0.0099999997764825821), (transform.m_Position - float3).xz);
                if (MathUtils.Intersect(circle2_1, circle2_2))
                {
                  // ISSUE: reference to a compiler-generated field
                  // ISSUE: reference to a compiler-generated field
                  num = math.distance(new float3()
                  {
                    xz = float3.xz + MathUtils.Center(MathUtils.Bounds(circle2_1) & MathUtils.Bounds(circle2_2)),
                    y = MathUtils.Center(bounds.m_Bounds.y & this.m_Bounds.y)
                  }, this.m_ControlPoint.m_Position);
                }
              }
              else
              {
                Bounds2 intersection;
                if (MathUtils.Intersect(ObjectUtils.CalculateBaseCorners(transform.m_Position - float3, transform.m_Rotation, MathUtils.Expand(objectGeometryData.m_Bounds, (float3) -0.01f)).xz, circle2_1, out intersection))
                {
                  // ISSUE: reference to a compiler-generated field
                  // ISSUE: reference to a compiler-generated field
                  num = math.distance(new float3()
                  {
                    xz = float3.xz + MathUtils.Center(intersection),
                    y = MathUtils.Center(bounds.m_Bounds.y & this.m_Bounds.y)
                  }, this.m_ControlPoint.m_Position);
                }
              }
            }
            else
            {
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              Quad2 xz1 = ObjectUtils.CalculateBaseCorners(this.m_ControlPoint.m_Position - float3, this.m_ControlPoint.m_Rotation, MathUtils.Expand(this.m_PrefabObjectGeometryData1.m_Bounds, (float3) -0.01f)).xz;
              if ((objectGeometryData.m_Flags & Game.Objects.GeometryFlags.Circular) != Game.Objects.GeometryFlags.None)
              {
                Circle2 circle = new Circle2((float) ((double) objectGeometryData.m_Size.x * 0.5 - 0.0099999997764825821), (transform.m_Position - float3).xz);
                Bounds2 intersection;
                if (MathUtils.Intersect(xz1, circle, out intersection))
                {
                  // ISSUE: reference to a compiler-generated field
                  // ISSUE: reference to a compiler-generated field
                  num = math.distance(new float3()
                  {
                    xz = float3.xz + MathUtils.Center(intersection),
                    y = MathUtils.Center(bounds.m_Bounds.y & this.m_Bounds.y)
                  }, this.m_ControlPoint.m_Position);
                }
              }
              else
              {
                Quad2 xz2 = ObjectUtils.CalculateBaseCorners(transform.m_Position - float3, transform.m_Rotation, MathUtils.Expand(objectGeometryData.m_Bounds, (float3) -0.01f)).xz;
                Bounds2 intersection;
                if (MathUtils.Intersect(xz1, xz2, out intersection))
                {
                  // ISSUE: reference to a compiler-generated field
                  // ISSUE: reference to a compiler-generated field
                  num = math.distance(new float3()
                  {
                    xz = float3.xz + MathUtils.Center(intersection),
                    y = MathUtils.Center(bounds.m_Bounds.y & this.m_Bounds.y)
                  }, this.m_ControlPoint.m_Position);
                }
              }
            }
          }
          else
          {
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            if (!MathUtils.Intersect(bounds.m_Bounds, this.m_Bounds) || !this.m_PrefabObjectGeometryData.HasComponent(prefabRef.m_Prefab))
              return;
            // ISSUE: reference to a compiler-generated field
            Game.Objects.Transform transform = this.m_TransformData[item];
            // ISSUE: reference to a compiler-generated field
            ObjectGeometryData objectGeometryData = this.m_PrefabObjectGeometryData[prefabRef.m_Prefab];
            float3 float3_1 = MathUtils.Center(bounds.m_Bounds);
            // ISSUE: reference to a compiler-generated field
            quaternion q1 = math.inverse(this.m_ControlPoint.m_Rotation);
            quaternion q2 = math.inverse(transform.m_Rotation);
            // ISSUE: reference to a compiler-generated field
            float3 v = this.m_ControlPoint.m_Position - float3_1;
            float3 float3_2 = math.mul(q1, v);
            float3 float3_3 = math.mul(q2, transform.m_Position - float3_1);
            // ISSUE: reference to a compiler-generated field
            if ((this.m_PrefabObjectGeometryData1.m_Flags & Game.Objects.GeometryFlags.Circular) != Game.Objects.GeometryFlags.None)
            {
              Cylinder3 cylinder3 = new Cylinder3();
              // ISSUE: reference to a compiler-generated field
              cylinder3.circle = new Circle2((float) ((double) this.m_PrefabObjectGeometryData1.m_Size.x * 0.5 - 0.0099999997764825821), float3_2.xz);
              // ISSUE: reference to a compiler-generated field
              cylinder3.height = new Bounds1(0.01f, this.m_PrefabObjectGeometryData1.m_Size.y - 0.01f) + float3_2.y;
              // ISSUE: reference to a compiler-generated field
              cylinder3.rotation = this.m_ControlPoint.m_Rotation;
              if ((objectGeometryData.m_Flags & Game.Objects.GeometryFlags.Circular) != Game.Objects.GeometryFlags.None)
              {
                Cylinder3 cylinder2 = new Cylinder3();
                cylinder2.circle = new Circle2((float) ((double) objectGeometryData.m_Size.x * 0.5 - 0.0099999997764825821), float3_3.xz);
                cylinder2.height = new Bounds1(0.01f, objectGeometryData.m_Size.y - 0.01f) + float3_3.y;
                cylinder2.rotation = transform.m_Rotation;
                float3 pos = new float3();
                if (Game.Objects.ValidationHelpers.Intersect(cylinder3, cylinder2, ref pos))
                {
                  // ISSUE: reference to a compiler-generated field
                  num = math.distance(pos, this.m_ControlPoint.m_Position);
                }
              }
              else
              {
                Box3 box = new Box3()
                {
                  bounds = objectGeometryData.m_Bounds + float3_3
                };
                box.bounds = MathUtils.Expand(box.bounds, (float3) -0.01f);
                box.rotation = transform.m_Rotation;
                Bounds3 cylinderIntersection;
                Bounds3 boxIntersection;
                if (MathUtils.Intersect(cylinder3, box, out cylinderIntersection, out boxIntersection))
                {
                  float3 x = math.mul(cylinder3.rotation, MathUtils.Center(cylinderIntersection));
                  float3 y = math.mul(box.rotation, MathUtils.Center(boxIntersection));
                  // ISSUE: reference to a compiler-generated field
                  num = math.distance(float3_1 + math.lerp(x, y, 0.5f), this.m_ControlPoint.m_Position);
                }
              }
            }
            else
            {
              // ISSUE: reference to a compiler-generated field
              Box3 box3 = new Box3()
              {
                bounds = this.m_PrefabObjectGeometryData1.m_Bounds + float3_2
              };
              box3.bounds = MathUtils.Expand(box3.bounds, (float3) -0.01f);
              // ISSUE: reference to a compiler-generated field
              box3.rotation = this.m_ControlPoint.m_Rotation;
              if ((objectGeometryData.m_Flags & Game.Objects.GeometryFlags.Circular) != Game.Objects.GeometryFlags.None)
              {
                Cylinder3 cylinder = new Cylinder3();
                cylinder.circle = new Circle2((float) ((double) objectGeometryData.m_Size.x * 0.5 - 0.0099999997764825821), float3_3.xz);
                cylinder.height = new Bounds1(0.01f, objectGeometryData.m_Size.y - 0.01f) + float3_3.y;
                cylinder.rotation = transform.m_Rotation;
                Bounds3 cylinderIntersection;
                Bounds3 boxIntersection;
                if (MathUtils.Intersect(cylinder, box3, out cylinderIntersection, out boxIntersection))
                {
                  float3 x = math.mul(box3.rotation, MathUtils.Center(boxIntersection));
                  float3 y = math.mul(cylinder.rotation, MathUtils.Center(cylinderIntersection));
                  // ISSUE: reference to a compiler-generated field
                  num = math.distance(float3_1 + math.lerp(x, y, 0.5f), this.m_ControlPoint.m_Position);
                }
              }
              else
              {
                Box3 box2 = new Box3()
                {
                  bounds = objectGeometryData.m_Bounds + float3_3
                };
                box2.bounds = MathUtils.Expand(box2.bounds, (float3) -0.01f);
                box2.rotation = transform.m_Rotation;
                Bounds3 intersection1;
                Bounds3 intersection2;
                if (MathUtils.Intersect(box3, box2, out intersection1, out intersection2))
                {
                  float3 x = math.mul(box3.rotation, MathUtils.Center(intersection1));
                  float3 y = math.mul(box2.rotation, MathUtils.Center(intersection2));
                  // ISSUE: reference to a compiler-generated field
                  num = math.distance(float3_1 + math.lerp(x, y, 0.5f), this.m_ControlPoint.m_Position);
                }
              }
            }
          }
          // ISSUE: reference to a compiler-generated field
          if ((double) num >= (double) this.m_BestOverlap)
            return;
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          this.m_BestSnapPosition = this.m_ControlPoint;
          // ISSUE: reference to a compiler-generated field
          this.m_BestSnapPosition.m_OriginalEntity = item;
          // ISSUE: reference to a compiler-generated field
          this.m_BestSnapPosition.m_ElementIndex = new int2(-1, -1);
          // ISSUE: reference to a compiler-generated field
          this.m_BestOverlap = num;
        }
      }

      private struct NetIterator : 
        INativeQuadTreeIterator<Entity, QuadTreeBoundsXZ>,
        IUnsafeQuadTreeIterator<Entity, QuadTreeBoundsXZ>
      {
        public ControlPoint m_ControlPoint;
        public ControlPoint m_BestSnapPosition;
        public quaternion m_Rotation;
        public Bounds2 m_Bounds;
        public float3 m_LocalOffset;
        public float2 m_LocalTangent;
        public Entity m_IgnoreOwner;
        public float m_SnapFactor;
        public NetData m_NetData;
        public NetGeometryData m_NetGeometryData;
        public RoadData m_RoadData;
        public NativeList<SubSnapPoint> m_SubSnapPoints;
        public ComponentLookup<Owner> m_OwnerData;
        public ComponentLookup<Game.Net.Node> m_NodeData;
        public ComponentLookup<Game.Net.Edge> m_EdgeData;
        public ComponentLookup<Curve> m_CurveData;
        public ComponentLookup<PrefabRef> m_PrefabRefData;
        public ComponentLookup<NetData> m_PrefabNetData;
        public ComponentLookup<NetGeometryData> m_PrefabNetGeometryData;
        public BufferLookup<ConnectedEdge> m_ConnectedEdges;

        public bool Intersect(QuadTreeBoundsXZ bounds)
        {
          // ISSUE: reference to a compiler-generated field
          return MathUtils.Intersect(bounds.m_Bounds.xz, this.m_Bounds);
        }

        public void Iterate(QuadTreeBoundsXZ bounds, Entity netEntity)
        {
          Game.Net.Node componentData1;
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          if (!MathUtils.Intersect(bounds.m_Bounds.xz, this.m_Bounds) || !this.m_NodeData.TryGetComponent(netEntity, out componentData1))
            return;
          // ISSUE: reference to a compiler-generated field
          if (this.m_IgnoreOwner != Entity.Null)
          {
            Owner componentData2;
            // ISSUE: reference to a compiler-generated field
            for (Entity entity = netEntity; this.m_OwnerData.TryGetComponent(entity, out componentData2); entity = componentData2.m_Owner)
            {
              // ISSUE: reference to a compiler-generated field
              if (componentData2.m_Owner == this.m_IgnoreOwner)
                return;
            }
          }
          bool flag1 = true;
          float num1 = float.MaxValue;
          float num2 = float.MaxValue;
          float3 float3_1 = new float3();
          float2 float2_1 = new float2();
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          float3 float3_2 = math.mul(this.m_Rotation, this.m_LocalOffset);
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          float2 xz = math.mul(this.m_Rotation, new float3(this.m_LocalTangent.x, 0.0f, this.m_LocalTangent.y)).xz;
          // ISSUE: reference to a compiler-generated field
          ControlPoint controlPoint = this.m_ControlPoint with
          {
            m_OriginalEntity = Entity.Null
          };
          ref ControlPoint local1 = ref controlPoint;
          // ISSUE: reference to a compiler-generated field
          float3 float3_3 = math.forward(this.m_Rotation);
          float2 float2_2 = math.normalizesafe(float3_3.xz);
          local1.m_Direction = float2_2;
          // ISSUE: reference to a compiler-generated field
          controlPoint.m_Rotation = this.m_Rotation;
          DynamicBuffer<ConnectedEdge> bufferData;
          // ISSUE: reference to a compiler-generated field
          if (this.m_ConnectedEdges.TryGetBuffer(netEntity, out bufferData))
          {
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            bool flag2 = (this.m_NetGeometryData.m_Flags & Game.Net.GeometryFlags.StrictNodes) == (Game.Net.GeometryFlags) 0 && (this.m_RoadData.m_Flags & Game.Prefabs.RoadFlags.EnableZoning) != 0;
            for (int index1 = 0; index1 < bufferData.Length; ++index1)
            {
              Entity edge1 = bufferData[index1].m_Edge;
              // ISSUE: reference to a compiler-generated field
              Game.Net.Edge edge2 = this.m_EdgeData[edge1];
              // ISSUE: reference to a compiler-generated field
              Curve curve = this.m_CurveData[edge1];
              float3 float3_4;
              float2 float2_3;
              if (edge2.m_Start == netEntity)
              {
                float3_4 = curve.m_Bezier.a;
                float3_3 = MathUtils.StartTangent(curve.m_Bezier);
                float2_3 = math.normalizesafe(float3_3.xz);
              }
              else if (edge2.m_End == netEntity)
              {
                float3_4 = curve.m_Bezier.d;
                float3_3 = MathUtils.EndTangent(curve.m_Bezier);
                float2_3 = math.normalizesafe(-float3_3.xz);
              }
              else
                continue;
              flag1 = false;
              // ISSUE: reference to a compiler-generated field
              PrefabRef prefabRef = this.m_PrefabRefData[edge1];
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              if ((this.m_NetData.m_RequiredLayers & this.m_PrefabNetData[prefabRef.m_Prefab].m_RequiredLayers) != Layer.None)
              {
                // ISSUE: reference to a compiler-generated field
                float defaultWidth = this.m_NetGeometryData.m_DefaultWidth;
                NetGeometryData componentData3;
                // ISSUE: reference to a compiler-generated field
                // ISSUE: reference to a compiler-generated field
                if ((this.m_NetGeometryData.m_Flags & Game.Net.GeometryFlags.StrictNodes) == (Game.Net.GeometryFlags) 0 && this.m_PrefabNetGeometryData.TryGetComponent(prefabRef.m_Prefab, out componentData3))
                  defaultWidth = componentData3.m_DefaultWidth;
                int num3;
                float x;
                float num4;
                if (flag2)
                {
                  // ISSUE: reference to a compiler-generated field
                  int cellWidth = ZoneUtils.GetCellWidth(this.m_NetGeometryData.m_DefaultWidth);
                  num3 = 1 + math.abs(ZoneUtils.GetCellWidth(defaultWidth) - cellWidth);
                  x = (float) (num3 - 1) * -4f;
                  num4 = 8f;
                }
                else
                {
                  // ISSUE: reference to a compiler-generated field
                  float num5 = math.abs(defaultWidth - this.m_NetGeometryData.m_DefaultWidth);
                  if ((double) num5 > 1.6000000238418579)
                  {
                    num3 = 3;
                    x = num5 * -0.5f;
                    num4 = num5 * 0.5f;
                  }
                  else
                  {
                    num3 = 1;
                    x = 0.0f;
                    num4 = 0.0f;
                  }
                }
                for (int index2 = 0; index2 < num3; ++index2)
                {
                  float3 float3_5 = float3_4;
                  if ((double) math.abs(x) >= 0.079999998211860657)
                    float3_5.xz += MathUtils.Left(float2_3) * x;
                  // ISSUE: reference to a compiler-generated field
                  float num6 = math.distancesq(float3_5 - float3_2, this.m_ControlPoint.m_HitPosition);
                  if ((double) num6 < (double) num1)
                  {
                    num1 = num6;
                    float3_1 = float3_5;
                  }
                  x += num4;
                }
                float num7 = math.dot(xz, float2_3);
                if ((double) num7 < (double) num2)
                {
                  num2 = num7;
                  float2_1 = float2_3;
                }
              }
            }
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          if (flag1 && (this.m_NetData.m_RequiredLayers & this.m_PrefabNetData[this.m_PrefabRefData[netEntity].m_Prefab].m_RequiredLayers) != Layer.None && (double) math.distancesq(componentData1.m_Position - float3_2, this.m_ControlPoint.m_HitPosition) < (double) num1)
            float3_1 = componentData1.m_Position;
          if ((double) num1 == 3.4028234663852886E+38)
            return;
          controlPoint.m_Position = float3_1 - float3_2;
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          controlPoint.m_SnapPriority = ToolUtils.CalculateSnapPriority(0.0f, 1f, this.m_ControlPoint.m_HitPosition.xz * this.m_SnapFactor, controlPoint.m_Position.xz * this.m_SnapFactor, controlPoint.m_Direction);
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated method
          ObjectToolSystem.SnapJob.AddSnapPosition(ref this.m_BestSnapPosition, controlPoint);
          // ISSUE: reference to a compiler-generated field
          if ((double) num2 != 3.4028234663852886E+38 && !this.m_LocalTangent.Equals(new float2()))
          {
            // ISSUE: reference to a compiler-generated field
            controlPoint.m_Rotation = quaternion.RotateY(MathUtils.RotationAngleSignedRight(this.m_LocalTangent, -float2_1));
            ref ControlPoint local2 = ref controlPoint;
            float3_3 = math.forward(controlPoint.m_Rotation);
            float2 float2_4 = math.normalizesafe(float3_3.xz);
            local2.m_Direction = float2_4;
            // ISSUE: reference to a compiler-generated field
            controlPoint.m_Position = float3_1 - math.mul(controlPoint.m_Rotation, this.m_LocalOffset);
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            controlPoint.m_SnapPriority = ToolUtils.CalculateSnapPriority(0.0f, 1f, this.m_ControlPoint.m_HitPosition.xz * this.m_SnapFactor, controlPoint.m_Position.xz * this.m_SnapFactor, controlPoint.m_Direction);
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated method
            ObjectToolSystem.SnapJob.AddSnapPosition(ref this.m_BestSnapPosition, controlPoint);
          }
          // ISSUE: reference to a compiler-generated field
          this.m_SubSnapPoints.Add(new SubSnapPoint()
          {
            m_Position = float3_1,
            m_Tangent = float2_1
          });
        }
      }

      private struct ZoneBlockIterator : 
        INativeQuadTreeIterator<Entity, Bounds2>,
        IUnsafeQuadTreeIterator<Entity, Bounds2>
      {
        public ControlPoint m_ControlPoint;
        public ControlPoint m_BestSnapPosition;
        public float m_BestDistance;
        public int2 m_LotSize;
        public Bounds2 m_Bounds;
        public float2 m_Direction;
        public Entity m_IgnoreOwner;
        public ComponentLookup<Owner> m_OwnerData;
        public ComponentLookup<Game.Zones.Block> m_BlockData;

        public bool Intersect(Bounds2 bounds) => MathUtils.Intersect(bounds, this.m_Bounds);

        public void Iterate(Bounds2 bounds, Entity blockEntity)
        {
          // ISSUE: reference to a compiler-generated field
          if (!MathUtils.Intersect(bounds, this.m_Bounds))
            return;
          // ISSUE: reference to a compiler-generated field
          if (this.m_IgnoreOwner != Entity.Null)
          {
            Owner componentData;
            // ISSUE: reference to a compiler-generated field
            for (Entity entity = blockEntity; this.m_OwnerData.TryGetComponent(entity, out componentData); entity = componentData.m_Owner)
            {
              // ISSUE: reference to a compiler-generated field
              if (componentData.m_Owner == this.m_IgnoreOwner)
                return;
            }
          }
          // ISSUE: reference to a compiler-generated field
          Game.Zones.Block block = this.m_BlockData[blockEntity];
          Quad2 corners = ZoneUtils.CalculateCorners(block);
          Line2.Segment line1 = new Line2.Segment(corners.a, corners.b);
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          Line2.Segment segment = new Line2.Segment(this.m_ControlPoint.m_HitPosition.xz, this.m_ControlPoint.m_HitPosition.xz);
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          float2 float2_1 = this.m_Direction * (math.max(0.0f, (float) (this.m_LotSize.y - this.m_LotSize.x)) * 4f);
          segment.a -= float2_1;
          segment.b += float2_1;
          Line2.Segment line2 = segment;
          float2 float2_2;
          ref float2 local = ref float2_2;
          float num1 = MathUtils.Distance(line1, line2, out local);
          if ((double) num1 == 0.0)
            num1 -= 0.5f - math.abs(float2_2.y - 0.5f);
          // ISSUE: reference to a compiler-generated field
          if ((double) num1 >= (double) this.m_BestDistance)
            return;
          // ISSUE: reference to a compiler-generated field
          this.m_BestDistance = num1;
          // ISSUE: reference to a compiler-generated field
          float2 y = this.m_ControlPoint.m_HitPosition.xz - block.m_Position.xz;
          float2 x = MathUtils.Left(block.m_Direction);
          float num2 = (float) block.m_Size.y * 4f;
          // ISSUE: reference to a compiler-generated field
          float num3 = (float) this.m_LotSize.y * 4f;
          float num4 = math.dot(block.m_Direction, y);
          float num5 = math.dot(x, y);
          // ISSUE: reference to a compiler-generated field
          float num6 = math.select(0.0f, 0.5f, ((block.m_Size.x ^ this.m_LotSize.x) & 1) != 0);
          float num7 = num5 - (float) (((double) math.round(num5 / 8f - num6) + (double) num6) * 8.0);
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          this.m_BestSnapPosition = this.m_ControlPoint;
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          this.m_BestSnapPosition.m_Position = this.m_ControlPoint.m_HitPosition;
          // ISSUE: reference to a compiler-generated field
          this.m_BestSnapPosition.m_Position.xz += block.m_Direction * (num2 - num3 - num4);
          // ISSUE: reference to a compiler-generated field
          this.m_BestSnapPosition.m_Position.xz -= x * num7;
          // ISSUE: reference to a compiler-generated field
          this.m_BestSnapPosition.m_Direction = block.m_Direction;
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          this.m_BestSnapPosition.m_Rotation = ToolUtils.CalculateRotation(this.m_BestSnapPosition.m_Direction);
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          this.m_BestSnapPosition.m_SnapPriority = ToolUtils.CalculateSnapPriority(0.0f, 1f, this.m_ControlPoint.m_HitPosition.xz * 0.5f, this.m_BestSnapPosition.m_Position.xz * 0.5f, this.m_BestSnapPosition.m_Direction);
          // ISSUE: reference to a compiler-generated field
          this.m_BestSnapPosition.m_OriginalEntity = blockEntity;
        }
      }
    }

    [BurstCompile]
    private struct FindAttachmentBuildingJob : IJob
    {
      [ReadOnly]
      public EntityTypeHandle m_EntityType;
      [ReadOnly]
      public ComponentTypeHandle<Game.Prefabs.BuildingData> m_BuildingDataType;
      [ReadOnly]
      public ComponentTypeHandle<SpawnableBuildingData> m_SpawnableBuildingType;
      [ReadOnly]
      public Game.Prefabs.BuildingData m_BuildingData;
      [ReadOnly]
      public RandomSeed m_RandomSeed;
      [ReadOnly]
      public NativeList<ArchetypeChunk> m_Chunks;
      public NativeReference<ObjectToolBaseSystem.AttachmentData> m_AttachmentPrefab;

      public void Execute()
      {
        // ISSUE: reference to a compiler-generated field
        Unity.Mathematics.Random random = this.m_RandomSeed.GetRandom(2000000);
        // ISSUE: reference to a compiler-generated field
        int2 lotSize1 = this.m_BuildingData.m_LotSize;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        bool2 bool2_1 = new bool2((this.m_BuildingData.m_Flags & Game.Prefabs.BuildingFlags.LeftAccess) > (Game.Prefabs.BuildingFlags) 0, (this.m_BuildingData.m_Flags & Game.Prefabs.BuildingFlags.RightAccess) > (Game.Prefabs.BuildingFlags) 0);
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        ObjectToolBaseSystem.AttachmentData attachmentData = new ObjectToolBaseSystem.AttachmentData();
        Game.Prefabs.BuildingData buildingData1 = new Game.Prefabs.BuildingData();
        float num1 = 0.0f;
        // ISSUE: reference to a compiler-generated field
        for (int index1 = 0; index1 < this.m_Chunks.Length; ++index1)
        {
          // ISSUE: reference to a compiler-generated field
          ArchetypeChunk chunk = this.m_Chunks[index1];
          // ISSUE: reference to a compiler-generated field
          NativeArray<Entity> nativeArray1 = chunk.GetNativeArray(this.m_EntityType);
          // ISSUE: reference to a compiler-generated field
          NativeArray<Game.Prefabs.BuildingData> nativeArray2 = chunk.GetNativeArray<Game.Prefabs.BuildingData>(ref this.m_BuildingDataType);
          // ISSUE: reference to a compiler-generated field
          NativeArray<SpawnableBuildingData> nativeArray3 = chunk.GetNativeArray<SpawnableBuildingData>(ref this.m_SpawnableBuildingType);
          for (int index2 = 0; index2 < nativeArray3.Length; ++index2)
          {
            if (nativeArray3[index2].m_Level == (byte) 1)
            {
              Game.Prefabs.BuildingData buildingData2 = nativeArray2[index2];
              int2 lotSize2 = buildingData2.m_LotSize;
              bool2 bool2_2 = new bool2((buildingData2.m_Flags & Game.Prefabs.BuildingFlags.LeftAccess) > (Game.Prefabs.BuildingFlags) 0, (buildingData2.m_Flags & Game.Prefabs.BuildingFlags.RightAccess) > (Game.Prefabs.BuildingFlags) 0);
              if (math.all(lotSize2 <= lotSize1))
              {
                int2 int2 = math.select(lotSize1 - lotSize2, (int2) 0, lotSize2 == lotSize1 - 1);
                float num2 = ((float) (lotSize2.x * lotSize2.y) * random.NextFloat(1f, 1.05f) + (float) (int2.x * lotSize2.y) * random.NextFloat(0.95f, 1f) + (float) (lotSize1.x * int2.y) * random.NextFloat(0.55f, 0.6f)) / (float) (lotSize1.x * lotSize1.y) * math.csum(math.select((float2) 0.01f, (float2) 0.5f, bool2_1 == bool2_2));
                if ((double) num2 > (double) num1)
                {
                  // ISSUE: reference to a compiler-generated field
                  attachmentData.m_Entity = nativeArray1[index2];
                  buildingData1 = buildingData2;
                  num1 = num2;
                }
              }
            }
          }
        }
        // ISSUE: reference to a compiler-generated field
        if (attachmentData.m_Entity != Entity.Null)
        {
          // ISSUE: reference to a compiler-generated field
          float z = (float) (this.m_BuildingData.m_LotSize.y - buildingData1.m_LotSize.y) * 4f;
          // ISSUE: reference to a compiler-generated field
          attachmentData.m_Offset = new float3(0.0f, 0.0f, z);
        }
        // ISSUE: reference to a compiler-generated field
        this.m_AttachmentPrefab.Value = attachmentData;
      }
    }

    private new struct TypeHandle
    {
      [ReadOnly]
      public ComponentLookup<PlaceableObjectData> __Game_Prefabs_PlaceableObjectData_RO_ComponentLookup;
      [ReadOnly]
      public ComponentTypeHandle<Brush> __Game_Tools_Brush_RO_ComponentTypeHandle;
      [ReadOnly]
      public ComponentLookup<Owner> __Game_Common_Owner_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<Game.Objects.Transform> __Game_Objects_Transform_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<Attached> __Game_Objects_Attached_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<Game.Common.Terrain> __Game_Common_Terrain_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<LocalTransformCache> __Game_Tools_LocalTransformCache_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<Game.Net.Edge> __Game_Net_Edge_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<Game.Net.Node> __Game_Net_Node_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<Orphan> __Game_Net_Orphan_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<Curve> __Game_Net_Curve_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<Composition> __Game_Net_Composition_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<EdgeGeometry> __Game_Net_EdgeGeometry_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<StartNodeGeometry> __Game_Net_StartNodeGeometry_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<EndNodeGeometry> __Game_Net_EndNodeGeometry_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<PrefabRef> __Game_Prefabs_PrefabRef_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<ObjectGeometryData> __Game_Prefabs_ObjectGeometryData_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<Game.Prefabs.BuildingData> __Game_Prefabs_BuildingData_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<BuildingExtensionData> __Game_Prefabs_BuildingExtensionData_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<NetCompositionData> __Game_Prefabs_NetCompositionData_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<MovingObjectData> __Game_Prefabs_MovingObjectData_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<AssetStampData> __Game_Prefabs_AssetStampData_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<OutsideConnectionData> __Game_Prefabs_OutsideConnectionData_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<NetObjectData> __Game_Prefabs_NetObjectData_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<TransportStopData> __Game_Prefabs_TransportStopData_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<StackData> __Game_Prefabs_StackData_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<ServiceUpgradeData> __Game_Prefabs_ServiceUpgradeData_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<NetData> __Game_Prefabs_NetData_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<NetGeometryData> __Game_Prefabs_NetGeometryData_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<RoadData> __Game_Prefabs_RoadData_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<Game.Zones.Block> __Game_Zones_Block_RO_ComponentLookup;
      [ReadOnly]
      public BufferLookup<Game.Objects.SubObject> __Game_Objects_SubObject_RO_BufferLookup;
      [ReadOnly]
      public BufferLookup<ConnectedEdge> __Game_Net_ConnectedEdge_RO_BufferLookup;
      [ReadOnly]
      public BufferLookup<NetCompositionArea> __Game_Prefabs_NetCompositionArea_RO_BufferLookup;
      [ReadOnly]
      public BufferLookup<Game.Prefabs.SubNet> __Game_Prefabs_SubNet_RO_BufferLookup;
      [ReadOnly]
      public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;
      [ReadOnly]
      public ComponentTypeHandle<Game.Prefabs.BuildingData> __Game_Prefabs_BuildingData_RO_ComponentTypeHandle;
      [ReadOnly]
      public ComponentTypeHandle<SpawnableBuildingData> __Game_Prefabs_SpawnableBuildingData_RO_ComponentTypeHandle;

      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      public void __AssignHandles(ref SystemState state)
      {
        // ISSUE: reference to a compiler-generated field
        this.__Game_Prefabs_PlaceableObjectData_RO_ComponentLookup = state.GetComponentLookup<PlaceableObjectData>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Tools_Brush_RO_ComponentTypeHandle = state.GetComponentTypeHandle<Brush>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Common_Owner_RO_ComponentLookup = state.GetComponentLookup<Owner>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Objects_Transform_RO_ComponentLookup = state.GetComponentLookup<Game.Objects.Transform>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Objects_Attached_RO_ComponentLookup = state.GetComponentLookup<Attached>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Common_Terrain_RO_ComponentLookup = state.GetComponentLookup<Game.Common.Terrain>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Tools_LocalTransformCache_RO_ComponentLookup = state.GetComponentLookup<LocalTransformCache>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Net_Edge_RO_ComponentLookup = state.GetComponentLookup<Game.Net.Edge>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Net_Node_RO_ComponentLookup = state.GetComponentLookup<Game.Net.Node>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Net_Orphan_RO_ComponentLookup = state.GetComponentLookup<Orphan>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Net_Curve_RO_ComponentLookup = state.GetComponentLookup<Curve>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Net_Composition_RO_ComponentLookup = state.GetComponentLookup<Composition>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Net_EdgeGeometry_RO_ComponentLookup = state.GetComponentLookup<EdgeGeometry>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Net_StartNodeGeometry_RO_ComponentLookup = state.GetComponentLookup<StartNodeGeometry>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Net_EndNodeGeometry_RO_ComponentLookup = state.GetComponentLookup<EndNodeGeometry>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Prefabs_PrefabRef_RO_ComponentLookup = state.GetComponentLookup<PrefabRef>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Prefabs_ObjectGeometryData_RO_ComponentLookup = state.GetComponentLookup<ObjectGeometryData>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Prefabs_BuildingData_RO_ComponentLookup = state.GetComponentLookup<Game.Prefabs.BuildingData>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Prefabs_BuildingExtensionData_RO_ComponentLookup = state.GetComponentLookup<BuildingExtensionData>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Prefabs_NetCompositionData_RO_ComponentLookup = state.GetComponentLookup<NetCompositionData>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Prefabs_MovingObjectData_RO_ComponentLookup = state.GetComponentLookup<MovingObjectData>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Prefabs_AssetStampData_RO_ComponentLookup = state.GetComponentLookup<AssetStampData>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Prefabs_OutsideConnectionData_RO_ComponentLookup = state.GetComponentLookup<OutsideConnectionData>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Prefabs_NetObjectData_RO_ComponentLookup = state.GetComponentLookup<NetObjectData>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Prefabs_TransportStopData_RO_ComponentLookup = state.GetComponentLookup<TransportStopData>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Prefabs_StackData_RO_ComponentLookup = state.GetComponentLookup<StackData>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Prefabs_ServiceUpgradeData_RO_ComponentLookup = state.GetComponentLookup<ServiceUpgradeData>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Prefabs_NetData_RO_ComponentLookup = state.GetComponentLookup<NetData>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Prefabs_NetGeometryData_RO_ComponentLookup = state.GetComponentLookup<NetGeometryData>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Prefabs_RoadData_RO_ComponentLookup = state.GetComponentLookup<RoadData>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Zones_Block_RO_ComponentLookup = state.GetComponentLookup<Game.Zones.Block>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Objects_SubObject_RO_BufferLookup = state.GetBufferLookup<Game.Objects.SubObject>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Net_ConnectedEdge_RO_BufferLookup = state.GetBufferLookup<ConnectedEdge>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Prefabs_NetCompositionArea_RO_BufferLookup = state.GetBufferLookup<NetCompositionArea>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Prefabs_SubNet_RO_BufferLookup = state.GetBufferLookup<Game.Prefabs.SubNet>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
        // ISSUE: reference to a compiler-generated field
        this.__Game_Prefabs_BuildingData_RO_ComponentTypeHandle = state.GetComponentTypeHandle<Game.Prefabs.BuildingData>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Prefabs_SpawnableBuildingData_RO_ComponentTypeHandle = state.GetComponentTypeHandle<SpawnableBuildingData>(true);
      }
    }
  }
}
