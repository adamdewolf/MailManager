// Decompiled with JetBrains decompiler
// Type: Game.Vehicles.PersonalCar
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;

#nullable disable
namespace Game.Vehicles
{
  public struct PersonalCar : IComponentData, IQueryTypeParameter, ISerializable
  {
    public Entity m_Keeper;
    public PersonalCarFlags m_State;

    public PersonalCar(Entity keeper, PersonalCarFlags state)
    {
      this.m_Keeper = keeper;
      this.m_State = state;
    }

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_Keeper);
      writer.Write((uint) this.m_State);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read(out this.m_Keeper);
      uint num;
      reader.Read(out num);
      this.m_State = (PersonalCarFlags) num;
    }
  }
}
