// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.ObjectSubAreaInfo
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.UI.Widgets;
using System;
using Unity.Mathematics;
using UnityEngine;

#nullable disable
namespace Game.Prefabs
{
  [Serializable]
  public class ObjectSubAreaInfo
  {
    public AreaPrefab m_AreaPrefab;
    [InputField]
    [Range(-10000f, 10000f)]
    public float3[] m_NodePositions;
    public int[] m_ParentMeshes;
  }
}
