// Decompiled with JetBrains decompiler
// Type: Game.Tools.ToolBaseSystem
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Annotations;
using Colossal.Entities;
using Game.Areas;
using Game.Common;
using Game.Input;
using Game.Net;
using Game.Notifications;
using Game.Prefabs;
using Game.Routes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

#nullable disable
namespace Game.Tools
{
  [CompilerGenerated]
  public abstract class ToolBaseSystem : GameSystemBase, IEquatable<ToolBaseSystem>
  {
    public const Snap kSnapAllIgnoredMask = Snap.AutoParent | Snap.PrefabType | Snap.ContourLines;
    protected ToolSystem m_ToolSystem;
    protected PrefabSystem m_PrefabSystem;
    protected DefaultToolSystem m_DefaultToolSystem;
    protected ToolRaycastSystem m_ToolRaycastSystem;
    protected OriginalDeletedSystem m_OriginalDeletedSystem;
    protected EntityQuery m_ErrorQuery;
    protected Snap m_SnapOnMask;
    protected Snap m_SnapOffMask;
    protected bool m_HasFocus;
    protected bool m_FocusChanged;
    protected bool m_ForceUpdate;
    private UIInputAction.State m_ApplyAction;
    private UIInputAction.State m_SecondaryApplyAction;
    private UIInputAction.State m_CancelAction;
    private protected UIInputAction.State m_DefaultApply;
    private protected UIInputAction.State m_DefaultSecondaryApply;
    private protected UIInputAction.State m_DefaultCancel;
    private protected UIInputAction.State m_MouseCancel;
    private protected UIInputAction.State m_MouseApply;
    private ToolBaseSystem.TypeHandle __TypeHandle;

    public abstract string toolID { get; }

    public virtual void GetUIModes(List<ToolMode> modes)
    {
    }

    public virtual int uiModeIndex => 0;

    public virtual Color32 color { get; set; }

    public BrushPrefab brushType { get; set; }

    public float brushSize { get; set; }

    public float brushAngle { get; set; }

    public float brushStrength { get; set; }

    public bool requireZones { get; protected set; }

    public bool requireUnderground { get; protected set; }

    public bool requirePipelines { get; protected set; }

    public bool requireNetArrows { get; protected set; }

    public bool requireStopIcons { get; protected set; }

    public AreaTypeMask requireAreas { get; protected set; }

    public RouteType requireRoutes { get; protected set; }

    public TransportType requireStops { get; protected set; }

    public Layer requireNet { get; protected set; }

    public InfoviewPrefab infoview { get; private set; }

    public List<InfomodePrefab> infomodes { get; private set; }

    public virtual Snap selectedSnap { get; set; }

    public ApplyMode applyMode { get; protected set; }

    public virtual bool allowUnderground { get; protected set; }

    public virtual bool brushing => false;

    protected UIInputAction.State applyAction
    {
      get => this.m_ApplyAction ?? (this.m_ApplyAction = this.m_DefaultApply);
    }

    protected UIInputAction.State secondaryApplyAction
    {
      get
      {
        return this.m_SecondaryApplyAction ?? (this.m_SecondaryApplyAction = this.m_DefaultSecondaryApply);
      }
    }

    protected UIInputAction.State cancelAction
    {
      get => this.m_CancelAction ?? (this.m_CancelAction = this.m_DefaultCancel);
    }

    protected UIInputAction.State applyActionOverride
    {
      set => this.SetAction(ref this.m_ApplyAction, value ?? this.m_DefaultApply);
    }

    protected UIInputAction.State secondaryApplyActionOverride
    {
      set => this.SetAction(ref this.m_SecondaryApplyAction, value ?? this.m_DefaultSecondaryApply);
    }

    protected UIInputAction.State cancelActionOverride
    {
      set => this.SetAction(ref this.m_CancelAction, value ?? this.m_DefaultCancel);
    }

    protected virtual IEnumerable<UIInputAction.State> toolActions
    {
      get
      {
        yield break;
      }
    }

    private IEnumerable<UIInputAction.State> baseToolActions
    {
      get
      {
        yield return this.m_DefaultApply;
        yield return this.m_DefaultSecondaryApply;
        yield return this.m_DefaultCancel;
        yield return this.m_MouseCancel;
        yield return this.m_MouseApply;
      }
    }

    public bool Equals(ToolBaseSystem other) => this == other;

    [UnityEngine.Scripting.Preserve]
    protected override void OnCreate()
    {
      base.OnCreate();
      // ISSUE: reference to a compiler-generated field
      this.m_ToolSystem = this.World.GetOrCreateSystemManaged<ToolSystem>();
      // ISSUE: reference to a compiler-generated field
      this.m_PrefabSystem = this.World.GetOrCreateSystemManaged<PrefabSystem>();
      // ISSUE: reference to a compiler-generated field
      this.m_DefaultToolSystem = this.World.GetOrCreateSystemManaged<DefaultToolSystem>();
      // ISSUE: reference to a compiler-generated field
      this.m_ToolRaycastSystem = this.World.GetOrCreateSystemManaged<ToolRaycastSystem>();
      // ISSUE: reference to a compiler-generated field
      this.m_OriginalDeletedSystem = this.World.GetOrCreateSystemManaged<OriginalDeletedSystem>();
      string name = this.GetType().Name;
      // ISSUE: reference to a compiler-generated field
      this.m_DefaultApply = Game.Input.InputManager.instance.toolActionCollection.GetActionState("Apply", name);
      // ISSUE: reference to a compiler-generated field
      this.m_DefaultSecondaryApply = Game.Input.InputManager.instance.toolActionCollection.GetActionState("Secondary Apply", name);
      // ISSUE: reference to a compiler-generated field
      this.m_DefaultCancel = Game.Input.InputManager.instance.toolActionCollection.GetActionState("Cancel", name);
      // ISSUE: reference to a compiler-generated field
      this.m_MouseCancel = Game.Input.InputManager.instance.toolActionCollection.GetActionState("Mouse Cancel", name);
      // ISSUE: reference to a compiler-generated field
      this.m_MouseApply = Game.Input.InputManager.instance.toolActionCollection.GetActionState("Mouse Apply", name);
      this.requireAreas = AreaTypeMask.None;
      this.requireRoutes = RouteType.None;
      this.requireStops = TransportType.None;
      this.selectedSnap = Snap.All;
      this.Enabled = false;
      // ISSUE: reference to a compiler-generated field
      this.m_HasFocus = true;
      // ISSUE: reference to a compiler-generated field
      this.m_ErrorQuery = this.GetEntityQuery(ComponentType.ReadOnly<Error>());
      this.infomodes = new List<InfomodePrefab>();
      // ISSUE: reference to a compiler-generated field
      this.m_ToolSystem.tools.Add(this);
    }

    protected override void OnFocusChanged(bool hasfocus)
    {
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.m_FocusChanged = hasfocus != this.m_HasFocus;
      // ISSUE: reference to a compiler-generated field
      this.m_HasFocus = hasfocus;
    }

    [UnityEngine.Scripting.Preserve]
    protected override void OnStartRunning()
    {
      base.OnStartRunning();
      // ISSUE: reference to a compiler-generated field
      this.m_ForceUpdate = true;
      // ISSUE: reference to a compiler-generated method
      this.SetActions();
    }

    [UnityEngine.Scripting.Preserve]
    protected override void OnStopRunning()
    {
      this.infoview = (InfoviewPrefab) null;
      this.infomodes.Clear();
      // ISSUE: reference to a compiler-generated method
      this.ResetActions();
      base.OnStopRunning();
    }

    private protected virtual void SetActions() => this.SetInteraction(true);

    private protected virtual void ResetActions()
    {
      // ISSUE: reference to a compiler-generated method
      this.SetInteraction(false);
      this.applyAction.enabled = false;
      this.secondaryApplyAction.enabled = false;
      this.cancelAction.enabled = false;
      this.applyActionOverride = (UIInputAction.State) null;
      this.secondaryApplyActionOverride = (UIInputAction.State) null;
      this.cancelActionOverride = (UIInputAction.State) null;
    }

    private void SetInteraction(bool set)
    {
      foreach (ProxyAction proxyAction in this.baseToolActions.Concat<UIInputAction.State>(this.toolActions).Select<UIInputAction.State, ProxyAction>((Func<UIInputAction.State, ProxyAction>) (a => a.action)).Distinct<ProxyAction>().ToArray<ProxyAction>())
      {
        if (set)
          proxyAction.onInteraction += (Action<ProxyAction, InputActionPhase>) ((action, phase) =>
          {
            if (phase != InputActionPhase.Performed)
              return;
            Action<ProxyAction> toolActionPerformed = Game.Input.InputManager.instance.EventToolActionPerformed;
            if (toolActionPerformed == null)
              return;
            toolActionPerformed(action);
          });
        else
          proxyAction.onInteraction -= (Action<ProxyAction, InputActionPhase>) ((action, phase) =>
          {
            if (phase != InputActionPhase.Performed)
              return;
            Action<ProxyAction> toolActionPerformed = Game.Input.InputManager.instance.EventToolActionPerformed;
            if (toolActionPerformed == null)
              return;
            toolActionPerformed(action);
          });
      }
    }

    private void OnActionInteraction(ProxyAction action, InputActionPhase phase)
    {
      if (phase != InputActionPhase.Performed)
        return;
      Action<ProxyAction> toolActionPerformed = Game.Input.InputManager.instance.EventToolActionPerformed;
      if (toolActionPerformed == null)
        return;
      toolActionPerformed(action);
    }

    [UnityEngine.Scripting.Preserve]
    protected override sealed void OnUpdate()
    {
      // ISSUE: reference to a compiler-generated method
      this.Dependency = this.OnUpdate(this.Dependency);
      // ISSUE: reference to a compiler-generated field
      this.m_FocusChanged = false;
      // ISSUE: reference to a compiler-generated field
      this.m_ForceUpdate = false;
    }

    [UnityEngine.Scripting.Preserve]
    protected virtual JobHandle OnUpdate(JobHandle inputDeps) => inputDeps;

    [CanBeNull]
    public abstract PrefabBase GetPrefab();

    public abstract bool TrySetPrefab(PrefabBase prefab);

    public virtual void InitializeRaycast()
    {
      // ISSUE: reference to a compiler-generated field
      this.m_ToolRaycastSystem.raycastFlags &= ~(RaycastFlags.ElevateOffset | RaycastFlags.SubElements | RaycastFlags.Placeholders | RaycastFlags.Markers | RaycastFlags.NoMainElements | RaycastFlags.UpgradeIsMain | RaycastFlags.OutsideConnections | RaycastFlags.Outside | RaycastFlags.Cargo | RaycastFlags.Passenger | RaycastFlags.Decals | RaycastFlags.EditorContainers | RaycastFlags.SubBuildings | RaycastFlags.PartialSurface | RaycastFlags.BuildingLots);
      // ISSUE: reference to a compiler-generated field
      this.m_ToolRaycastSystem.collisionMask = CollisionMask.OnGround | CollisionMask.Overground;
      // ISSUE: reference to a compiler-generated field
      this.m_ToolRaycastSystem.typeMask = TypeMask.None;
      // ISSUE: reference to a compiler-generated field
      this.m_ToolRaycastSystem.netLayerMask = Layer.None;
      // ISSUE: reference to a compiler-generated field
      this.m_ToolRaycastSystem.areaTypeMask = AreaTypeMask.None;
      // ISSUE: reference to a compiler-generated field
      this.m_ToolRaycastSystem.routeType = RouteType.None;
      // ISSUE: reference to a compiler-generated field
      this.m_ToolRaycastSystem.transportType = TransportType.None;
      // ISSUE: reference to a compiler-generated field
      this.m_ToolRaycastSystem.iconLayerMask = IconLayerMask.None;
      // ISSUE: reference to a compiler-generated field
      this.m_ToolRaycastSystem.utilityTypeMask = UtilityTypes.None;
      // ISSUE: reference to a compiler-generated field
      this.m_ToolRaycastSystem.rayOffset = new float3();
    }

    public virtual void GetAvailableSnapMask(out Snap onMask, out Snap offMask)
    {
      onMask = Snap.None;
      offMask = Snap.None;
    }

    public virtual void ToggleToolOptions(bool enabled)
    {
    }

    public virtual void SetUnderground(bool underground)
    {
    }

    public virtual void ElevationUp()
    {
    }

    public virtual void ElevationDown()
    {
    }

    public virtual void ElevationScroll()
    {
    }

    public static Snap GetActualSnap(Snap selectedSnap, Snap onMask, Snap offMask)
    {
      return (selectedSnap | ~offMask) & onMask;
    }

    protected Snap GetActualSnap()
    {
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated method
      return ToolBaseSystem.GetActualSnap(this.selectedSnap, this.m_SnapOnMask, this.m_SnapOffMask);
    }

    protected void UpdateInfoview(Entity prefab)
    {
      this.infomodes.Clear();
      DynamicBuffer<SubObject> buffer1;
      if (this.EntityManager.HasComponent<NetData>(prefab) && this.EntityManager.TryGetBuffer<SubObject>(prefab, true, out buffer1))
      {
        for (int index = 0; index < buffer1.Length; ++index)
        {
          SubObject subObject = buffer1[index];
          if ((subObject.m_Flags & SubObjectFlags.MakeOwner) != (SubObjectFlags) 0)
          {
            prefab = subObject.m_Prefab;
            break;
          }
        }
      }
      DynamicBuffer<PlaceableInfoviewItem> buffer2;
      if (this.EntityManager.TryGetBuffer<PlaceableInfoviewItem>(prefab, true, out buffer2) && buffer2.Length != 0)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated method
        this.infoview = this.m_PrefabSystem.GetPrefab<InfoviewPrefab>(buffer2[0].m_Item);
        for (int index = 1; index < buffer2.Length; ++index)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated method
          this.infomodes.Add(this.m_PrefabSystem.GetPrefab<InfomodePrefab>(buffer2[index].m_Item));
        }
      }
      else
        this.infoview = (InfoviewPrefab) null;
    }

    protected JobHandle DestroyDefinitions(
      EntityQuery group,
      ToolOutputBarrier barrier,
      JobHandle inputDeps)
    {
      if (group.IsEmptyIgnoreFilter)
        return inputDeps;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: object of a compiler-generated type is created
      JobHandle producerJob = new ToolBaseSystem.DestroyDefinitionsJob()
      {
        m_EntityType = this.__TypeHandle.__Unity_Entities_Entity_TypeHandle,
        m_CommandBuffer = barrier.CreateCommandBuffer().AsParallelWriter()
      }.ScheduleParallel<ToolBaseSystem.DestroyDefinitionsJob>(group, inputDeps);
      barrier.AddJobHandleForProducer(producerJob);
      return producerJob;
    }

    protected JobHandle InvertBrushes(EntityQuery group, JobHandle inputDeps)
    {
      if (group.IsEmptyIgnoreFilter)
        return inputDeps;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Tools_Brush_RW_ComponentTypeHandle.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: object of a compiler-generated type is created
      return new ToolBaseSystem.InvertBrushesJob()
      {
        m_BrushType = this.__TypeHandle.__Game_Tools_Brush_RW_ComponentTypeHandle
      }.ScheduleParallel<ToolBaseSystem.InvertBrushesJob>(group, inputDeps);
    }

    protected virtual bool GetAllowApply()
    {
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated method
      return (this.m_ToolSystem.ignoreErrors || this.m_ErrorQuery.IsEmptyIgnoreFilter) && !this.m_OriginalDeletedSystem.GetOriginalDeletedResult(0);
    }

    protected bool GetRaycastResult(out Entity entity, out RaycastHit hit)
    {
      RaycastResult result;
      // ISSUE: reference to a compiler-generated field
      if (this.m_ToolRaycastSystem.GetRaycastResult(out result) && !this.EntityManager.HasComponent<Deleted>(result.m_Owner))
      {
        entity = result.m_Owner;
        hit = result.m_Hit;
        return true;
      }
      entity = Entity.Null;
      hit = new RaycastHit();
      return false;
    }

    protected bool GetRaycastResult(out Entity entity, out RaycastHit hit, out bool forceUpdate)
    {
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated field
      forceUpdate = this.m_OriginalDeletedSystem.GetOriginalDeletedResult(1) || this.m_ForceUpdate;
      // ISSUE: reference to a compiler-generated method
      return this.GetRaycastResult(out entity, out hit);
    }

    protected virtual bool GetRaycastResult(out ControlPoint controlPoint)
    {
      Entity entity;
      RaycastHit hit;
      // ISSUE: reference to a compiler-generated method
      if (this.GetRaycastResult(out entity, out hit))
      {
        controlPoint = new ControlPoint(entity, hit);
        return true;
      }
      controlPoint = new ControlPoint();
      return false;
    }

    protected virtual bool GetRaycastResult(out ControlPoint controlPoint, out bool forceUpdate)
    {
      Entity entity;
      RaycastHit hit;
      // ISSUE: reference to a compiler-generated method
      if (this.GetRaycastResult(out entity, out hit, out forceUpdate))
      {
        controlPoint = new ControlPoint(entity, hit);
        return true;
      }
      controlPoint = new ControlPoint();
      return false;
    }

    protected bool GetContainers(
      EntityQuery group,
      out Entity laneContainer,
      out Entity transformContainer)
    {
      laneContainer = Entity.Null;
      transformContainer = Entity.Null;
      if (group.IsEmptyIgnoreFilter)
        return false;
      NativeArray<Entity> entityArray = group.ToEntityArray((AllocatorManager.AllocatorHandle) Allocator.TempJob);
      for (int index = 0; index < entityArray.Length; ++index)
      {
        Entity entity = entityArray[index];
        if (this.EntityManager.HasComponent<NetData>(entity))
          laneContainer = entity;
        else if (this.EntityManager.HasComponent<ObjectData>(entity))
          transformContainer = entity;
      }
      entityArray.Dispose();
      return true;
    }

    protected BrushPrefab FindDefaultBrush(EntityQuery query)
    {
      BrushPrefab defaultBrush = (BrushPrefab) null;
      int num = int.MaxValue;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Prefabs_PrefabData_RO_ComponentTypeHandle.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      ComponentTypeHandle<PrefabData> componentTypeHandle1 = this.__TypeHandle.__Game_Prefabs_PrefabData_RO_ComponentTypeHandle;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Prefabs_BrushData_RO_ComponentTypeHandle.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      ComponentTypeHandle<BrushData> componentTypeHandle2 = this.__TypeHandle.__Game_Prefabs_BrushData_RO_ComponentTypeHandle;
      using (NativeArray<ArchetypeChunk> archetypeChunkArray = query.ToArchetypeChunkArray((AllocatorManager.AllocatorHandle) Allocator.TempJob))
      {
        for (int index1 = 0; index1 < archetypeChunkArray.Length; ++index1)
        {
          ArchetypeChunk archetypeChunk = archetypeChunkArray[index1];
          NativeArray<PrefabData> nativeArray1 = archetypeChunk.GetNativeArray<PrefabData>(ref componentTypeHandle1);
          NativeArray<BrushData> nativeArray2 = archetypeChunk.GetNativeArray<BrushData>(ref componentTypeHandle2);
          for (int index2 = 0; index2 < nativeArray2.Length; ++index2)
          {
            BrushData brushData = nativeArray2[index2];
            if (brushData.m_Priority < num)
            {
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated method
              defaultBrush = this.m_PrefabSystem.GetPrefab<BrushPrefab>(nativeArray1[index2]);
              num = brushData.m_Priority;
            }
          }
        }
      }
      return defaultBrush;
    }

    protected void EnsureCachedBrushData()
    {
      if (!((UnityEngine.Object) this.brushType != (UnityEngine.Object) null))
        return;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated method
      Entity entity = this.m_PrefabSystem.GetEntity((PrefabBase) this.brushType);
      BrushData componentData = this.EntityManager.GetComponentData<BrushData>(entity);
      if (math.all(componentData.m_Resolution != 0) || (UnityEngine.Object) this.brushType.m_Texture == (UnityEngine.Object) null || this.brushType.m_Texture.width == 0 || this.brushType.m_Texture.height == 0)
        return;
      int2 int2 = new int2(this.brushType.m_Texture.width, this.brushType.m_Texture.height);
      componentData.m_Resolution = int2;
      int num1 = 1;
      float num2 = 1f;
      while (math.any(componentData.m_Resolution > 128) && math.all(componentData.m_Resolution > 1))
      {
        componentData.m_Resolution /= 2;
        num1 *= 2;
        num2 *= 0.25f;
      }
      this.EntityManager.SetComponentData<BrushData>(entity, componentData);
      DynamicBuffer<BrushCell> buffer = this.EntityManager.GetBuffer<BrushCell>(entity);
      UnityEngine.Color[] pixels = this.brushType.m_Texture.GetPixels();
      buffer.ResizeUninitialized(componentData.m_Resolution.x * componentData.m_Resolution.y);
      int num3 = 0;
      int num4 = 0;
      for (int index1 = 0; index1 < componentData.m_Resolution.y; ++index1)
      {
        for (int index2 = 0; index2 < componentData.m_Resolution.x; ++index2)
        {
          BrushCell brushCell = new BrushCell();
          int num5 = num3;
          for (int index3 = 0; index3 < num1; ++index3)
          {
            for (int index4 = 0; index4 < num1; ++index4)
              brushCell.m_Opacity += pixels[num5++].a;
            num5 += int2.x - num1;
          }
          brushCell.m_Opacity *= num2;
          buffer[num4++] = brushCell;
          num3 += num1;
        }
        num3 += int2.x * (num1 - 1);
      }
    }

    protected EntityQuery GetDefinitionQuery()
    {
      return this.GetEntityQuery(ComponentType.ReadOnly<CreationDefinition>(), ComponentType.Exclude<Updated>());
    }

    protected EntityQuery GetContainerQuery()
    {
      return this.GetEntityQuery(ComponentType.ReadOnly<EditorContainerData>());
    }

    protected EntityQuery GetBrushQuery()
    {
      return this.GetEntityQuery(ComponentType.ReadOnly<BrushData>());
    }

    protected void SetAction(ref UIInputAction.State action, UIInputAction.State newAction)
    {
      if (newAction == action)
        return;
      if (action == null)
        action = newAction;
      else if (newAction == null)
      {
        action.enabled = false;
        action = (UIInputAction.State) null;
      }
      else if (action.action == newAction.action)
      {
        newAction.displayName.shouldBeActive = action.displayName.shouldBeActive;
        action.displayName.shouldBeActive = false;
        action = newAction;
      }
      else
      {
        newAction.enabled = action.enabled;
        action.enabled = false;
        action = newAction;
      }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void __AssignQueries(ref SystemState state)
    {
    }

    protected override void OnCreateForCompiler()
    {
      base.OnCreateForCompiler();
      // ISSUE: reference to a compiler-generated method
      this.__AssignQueries(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated method
      this.__TypeHandle.__AssignHandles(ref this.CheckedStateRef);
    }

    [UnityEngine.Scripting.Preserve]
    protected ToolBaseSystem()
    {
    }

    [BurstCompile]
    private struct DestroyDefinitionsJob : IJobChunk
    {
      [ReadOnly]
      public EntityTypeHandle m_EntityType;
      public EntityCommandBuffer.ParallelWriter m_CommandBuffer;

      public void Execute(
        in ArchetypeChunk chunk,
        int unfilteredChunkIndex,
        bool useEnabledMask,
        in v128 chunkEnabledMask)
      {
        // ISSUE: reference to a compiler-generated field
        NativeArray<Entity> nativeArray = chunk.GetNativeArray(this.m_EntityType);
        for (int index = 0; index < nativeArray.Length; ++index)
        {
          // ISSUE: reference to a compiler-generated field
          this.m_CommandBuffer.DestroyEntity(unfilteredChunkIndex, nativeArray[index]);
        }
      }

      void IJobChunk.Execute(
        in ArchetypeChunk chunk,
        int unfilteredChunkIndex,
        bool useEnabledMask,
        in v128 chunkEnabledMask)
      {
        // ISSUE: reference to a compiler-generated method
        this.Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
      }
    }

    [BurstCompile]
    private struct InvertBrushesJob : IJobChunk
    {
      public ComponentTypeHandle<Brush> m_BrushType;

      public void Execute(
        in ArchetypeChunk chunk,
        int unfilteredChunkIndex,
        bool useEnabledMask,
        in v128 chunkEnabledMask)
      {
        // ISSUE: reference to a compiler-generated field
        NativeArray<Brush> nativeArray = chunk.GetNativeArray<Brush>(ref this.m_BrushType);
        for (int index = 0; index < nativeArray.Length; ++index)
        {
          Brush brush = nativeArray[index];
          brush.m_Strength = -brush.m_Strength;
          nativeArray[index] = brush;
        }
      }

      void IJobChunk.Execute(
        in ArchetypeChunk chunk,
        int unfilteredChunkIndex,
        bool useEnabledMask,
        in v128 chunkEnabledMask)
      {
        // ISSUE: reference to a compiler-generated method
        this.Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
      }
    }

    private struct TypeHandle
    {
      [ReadOnly]
      public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;
      public ComponentTypeHandle<Brush> __Game_Tools_Brush_RW_ComponentTypeHandle;
      [ReadOnly]
      public ComponentTypeHandle<PrefabData> __Game_Prefabs_PrefabData_RO_ComponentTypeHandle;
      [ReadOnly]
      public ComponentTypeHandle<BrushData> __Game_Prefabs_BrushData_RO_ComponentTypeHandle;

      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      public void __AssignHandles(ref SystemState state)
      {
        // ISSUE: reference to a compiler-generated field
        this.__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
        // ISSUE: reference to a compiler-generated field
        this.__Game_Tools_Brush_RW_ComponentTypeHandle = state.GetComponentTypeHandle<Brush>();
        // ISSUE: reference to a compiler-generated field
        this.__Game_Prefabs_PrefabData_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PrefabData>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Prefabs_BrushData_RO_ComponentTypeHandle = state.GetComponentTypeHandle<BrushData>(true);
      }
    }
  }
}
