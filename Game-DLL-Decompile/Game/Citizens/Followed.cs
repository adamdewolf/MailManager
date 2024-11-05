// Decompiled with JetBrains decompiler
// Type: Game.Citizens.Followed
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;

#nullable disable
namespace Game.Citizens
{
  public struct Followed : IComponentData, IQueryTypeParameter, ISerializable
  {
    public uint m_Priority;
    public bool m_StartedFollowingAsChild;

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_Priority);
      writer.Write(this.m_StartedFollowingAsChild);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      if (reader.context.version >= Version.localizationIndex)
        reader.Read(out this.m_Priority);
      if (!(reader.context.version >= Version.stalkerAchievement))
        return;
      reader.Read(out this.m_StartedFollowingAsChild);
    }
  }
}
