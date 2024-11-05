using UnityEngine;
using Colossal.Game;
using Unity.Entities;
using Game.Modding;
using Game;
using MailManager.Systems;

namespace MailManager
{
    public class Mod : IMod
    {
        public void OnLoad(UpdateSystem updateSystem)
        {
            Debug.Log("MailManager Mod Loaded");

            // Register the PostalVanTrackingSystem to update during the GameSimulation phase
            updateSystem.UpdateAt<PostalVanTrackingSystem>(SystemUpdatePhase.GameSimulation);
        }

        public void OnUnload()
        {
            Debug.Log("MailManager Mod Unloaded");
            // No additional cleanup needed; ECS handles system lifecycles
        }
    }
}
