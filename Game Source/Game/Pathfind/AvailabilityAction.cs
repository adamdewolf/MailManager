// Decompiled with JetBrains decompiler
// Type: Game.Pathfind.AvailabilityAction
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Collections;
using System;
using Unity.Collections;

#nullable disable
namespace Game.Pathfind
{
  public struct AvailabilityAction : IDisposable
  {
    public NativeReference<AvailabilityActionData> m_Data;

    public AvailabilityAction(Allocator allocator, AvailabilityParameters parameters)
    {
      this.m_Data = new NativeReference<AvailabilityActionData>(new AvailabilityActionData(allocator, parameters), (AllocatorManager.AllocatorHandle) allocator);
    }

    public ref AvailabilityActionData data => ref this.m_Data.ValueAsRef<AvailabilityActionData>();

    public void Dispose()
    {
      this.data.Dispose();
      this.m_Data.Dispose();
    }
  }
}
