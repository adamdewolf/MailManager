// Decompiled with JetBrains decompiler
// Type: Game.UI.InGame.CitizenHappiness
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.UI.Binding;
using System;

#nullable disable
namespace Game.UI.InGame
{
  public readonly struct CitizenHappiness : IJsonWritable
  {
    private static readonly string[] kHappinessPaths = new string[5]
    {
      "Media/Game/Icons/Depressed.svg",
      "Media/Game/Icons/Sad.svg",
      "Media/Game/Icons/Neutral.svg",
      "Media/Game/Icons/Content.svg",
      "Media/Game/Icons/Happy.svg"
    };

    private CitizenHappinessKey key { get; }

    public CitizenHappiness(CitizenHappinessKey key) => this.key = key;

    public void Write(IJsonWriter writer)
    {
      writer.TypeBegin(typeof (CitizenHappiness).FullName);
      writer.PropertyName("key");
      writer.Write(Enum.GetName(typeof (CitizenHappinessKey), (object) this.key));
      writer.PropertyName("iconPath");
      writer.Write(CitizenHappiness.kHappinessPaths[(int) this.key]);
      writer.TypeEnd();
    }
  }
}
