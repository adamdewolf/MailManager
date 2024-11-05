using Colossal.UI;
using Unity.Entities;
using UnityEngine;
using MailManager.Systems;

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
    }
}
