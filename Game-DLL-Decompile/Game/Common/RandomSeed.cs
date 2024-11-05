// Decompiled with JetBrains decompiler
// Type: Game.Common.RandomSeed
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;
using Unity.Mathematics;

#nullable disable
namespace Game.Common
{
  public struct RandomSeed
  {
    private static Unity.Mathematics.Random m_Random = new Unity.Mathematics.Random((uint) DateTime.Now.Ticks);
    private uint m_Seed;

    public static RandomSeed Next()
    {
      return new RandomSeed()
      {
        m_Seed = RandomSeed.m_Random.NextUInt()
      };
    }

    public Unity.Mathematics.Random GetRandom(int index)
    {
      uint a = this.m_Seed ^ (uint) (370248451 * index);
      return new Unity.Mathematics.Random(math.select(a, 1851936439U, a == 0U));
    }
  }
}
