// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.AnimationClip
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Mathematics;
using Game.Rendering;
using Unity.Entities;
using Unity.Mathematics;

#nullable disable
namespace Game.Prefabs
{
  [InternalBufferCapacity(0)]
  public struct AnimationClip : IBufferElementData
  {
    public float m_TextureOffset;
    public float m_TextureRange;
    public float m_OnePixelOffset;
    public float m_TextureWidth;
    public float m_OneOverTextureWidth;
    public float m_OneOverPixelOffset;
    public float m_AnimationLength;
    public float m_MovementSpeed;
    public float m_TargetValue;
    public float m_FrameRate;
    public int m_RootMotionBone;
    public int m_InfoIndex;
    public int m_PropClipIndex;
    public int2 m_MotionRange;
    public float3 m_RootOffset;
    public quaternion m_RootRotation;
    public Bounds1 m_SpeedRange;
    public AnimatedPropID m_PropID;
    public AnimationType m_Type;
    public AnimationLayer m_Layer;
    public ActivityType m_Activity;
    public ActivityCondition m_Conditions;
    public AnimationPlayback m_Playback;
  }
}
