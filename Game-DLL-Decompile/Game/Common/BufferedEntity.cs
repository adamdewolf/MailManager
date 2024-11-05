// Decompiled with JetBrains decompiler
// Type: Game.Common.BufferedEntity
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;

#nullable disable
namespace Game.Common
{
  public struct BufferedEntity
  {
    public Entity m_Value;
    public bool m_Stored;

    public BufferedEntity(Entity value, bool stored)
    {
      this.m_Value = value;
      this.m_Stored = stored;
    }

    public override string ToString()
    {
      return string.Format("{0}: {1}, {2}: {3}", (object) "m_Value", (object) this.m_Value, (object) "m_Stored", (object) this.m_Stored);
    }
  }
}
