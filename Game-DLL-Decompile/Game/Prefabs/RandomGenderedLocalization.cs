// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.RandomGenderedLocalization
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Mathematics;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("Localization/", new System.Type[] {})]
  public class RandomGenderedLocalization : RandomLocalization
  {
    public string m_MaleID;
    public string m_FemaleID;

    protected override int GetLocalizationCount()
    {
      int localizationCount1 = base.GetLocalizationCount();
      int localizationIndexCount1 = RandomLocalization.GetLocalizationIndexCount(this.prefab, this.m_MaleID);
      int localizationIndexCount2 = RandomLocalization.GetLocalizationIndexCount(this.prefab, this.m_FemaleID);
      int localizationCount2 = math.min(localizationCount1, math.min(localizationIndexCount1, localizationIndexCount2));
      if (localizationCount1 != localizationCount2 || localizationIndexCount1 != localizationCount2 || localizationIndexCount2 != localizationCount2)
        ComponentBase.baseLog.WarnFormat((UnityEngine.Object) this.prefab, "All gendered localization IDs should have the same variation count: {0} ({1}), {2} ({3}), {4} ({5})", (object) this.m_LocalizationID, (object) localizationCount1, (object) this.m_MaleID, (object) localizationIndexCount1, (object) this.m_FemaleID, (object) localizationIndexCount2);
      return localizationCount2;
    }
  }
}
