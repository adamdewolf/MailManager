// Decompiled with JetBrains decompiler
// Type: Game.Pathfind.DeleteAction
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;
using Unity.Collections;

#nullable disable
namespace Game.Pathfind
{
  public struct DeleteAction : IDisposable
  {
    public NativeArray<DeleteActionData> m_DeleteData;

    public DeleteAction(int size, Allocator allocator)
    {
      this.m_DeleteData = new NativeArray<DeleteActionData>(size, allocator);
    }

    public void Dispose() => this.m_DeleteData.Dispose();
  }
}
