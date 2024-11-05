// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.ObjectMeshInfo
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Objects;
using Game.UI.Widgets;
using System;
using Unity.Mathematics;
using UnityEngine;

#nullable disable
namespace Game.Prefabs
{
  [Serializable]
  public class ObjectMeshInfo
  {
    public RenderPrefabBase m_Mesh;
    [InputField]
    [Range(-10000f, 10000f)]
    public float3 m_Position;
    public quaternion m_Rotation = quaternion.identity;
    public ObjectState m_RequireState;
  }
}
