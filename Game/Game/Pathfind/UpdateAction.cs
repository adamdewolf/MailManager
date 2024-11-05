// Decompiled with JetBrains decompiler
// Type: Game.Pathfind.UpdateAction
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;
using Unity.Collections;

#nullable disable
namespace Game.Pathfind
{
  public struct UpdateAction : IDisposable
  {
    public NativeArray<UpdateActionData> m_UpdateData;

    public UpdateAction(int size, Allocator allocator)
    {
      this.m_UpdateData = new NativeArray<UpdateActionData>(size, allocator);
    }

    public void Dispose() => this.m_UpdateData.Dispose();
  }
}
