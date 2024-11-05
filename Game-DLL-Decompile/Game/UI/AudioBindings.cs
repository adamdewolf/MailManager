// Decompiled with JetBrains decompiler
// Type: Game.UI.AudioBindings
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.UI.Binding;
using System;

#nullable disable
namespace Game.UI
{
  public class AudioBindings : CompositeBinding
  {
    private const string kGroup = "audio";
    private UISoundCollection m_SoundCollection;

    public AudioBindings()
    {
      this.m_SoundCollection = UnityEngine.Resources.Load<UISoundCollection>("Audio/UI Sounds");
      this.AddBinding((IBinding) new TriggerBinding<string, float>("audio", "playSound", new Action<string, float>(this.PlayUISound)));
    }

    private void PlayUISound(string soundName, float volume)
    {
      if (!((UnityEngine.Object) this.m_SoundCollection != (UnityEngine.Object) null))
        return;
      this.m_SoundCollection.PlaySound(soundName, volume);
    }
  }
}
