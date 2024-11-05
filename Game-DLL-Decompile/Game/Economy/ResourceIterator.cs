// Decompiled with JetBrains decompiler
// Type: Game.Economy.ResourceIterator
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Economy
{
  public struct ResourceIterator
  {
    public Resource resource;

    public static ResourceIterator GetIterator()
    {
      return new ResourceIterator()
      {
        resource = Resource.NoResource
      };
    }

    public bool Next()
    {
      this.resource = (Resource) Math.Max(1UL, (ulong) this.resource << 1);
      return this.resource != Resource.Last;
    }
  }
}
