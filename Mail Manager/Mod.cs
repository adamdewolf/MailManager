using Colossal.IO.AssetDatabase;
using Colossal.Logging;
using Game;
using Game.Input;
using Game.Modding;
using Game.SceneFlow;
using UnityEngine;
using MailManager.Systems;
using Game.Settings;
using Unity.Entities;

namespace MailManager
{
    public class Mod : IMod
    {
        public void OnLoad(UpdateSystem updateSystem)
        {
            Debug.Log("MailManager Mod Loaded");

            // Register PostalVanTrackingSystem in the UIUpdate phase
            updateSystem.UpdateAt<PostalVanTrackingSystem>(SystemUpdatePhase.UIUpdate);

            // Setting up value bindings for the UI
            var world = World.DefaultGameObjectInjectionWorld;
            var vanSystem = world.GetOrCreateSystem<PostalVanTrackingSystem>();

            UI.bindValue<int>("MailManager", "ActivePostalVansCount", () => vanSystem.ActivePostalVansCount);
            UI.bindValue<int>("MailManager", "TotalMailCapacity", () => vanSystem.TotalMailCapacity);
        }

        public void OnUnload()
        {
            Debug.Log("MailManager Mod Unloaded");
            // Additional cleanup, if needed
        }

        public void OnDispose()
        {
            //log.Info(nameof(OnDispose));
          //  if (m_Setting != null)
         //   {
         //       m_Setting.UnregisterInOptionsUI();
         //       m_Setting = null;
         //   }
        }
    }
}
