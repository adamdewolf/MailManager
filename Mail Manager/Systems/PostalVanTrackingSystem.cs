using Game.Prefabs;
using Game.Simulation;
using Game;
using Unity.Entities;
using UnityEngine;

namespace MailManager.Systems
{
    public partial class PostalVanTrackingSystem : GameSystemBase
    {
        private int activePostalVanCount;
        private int totalMailCapacity;

        // Properties to expose counts for binding
        public int ActivePostalVansCount => activePostalVanCount;
        public int TotalMailCapacity => totalMailCapacity;

        protected override void OnUpdate()
        {
            // Reset counts at the start of each update
            activePostalVanCount = 0;
            totalMailCapacity = 0;

            // Query entities representing postal vans
            Entities
                .WithAll<ServiceDispatch>() // Filter entities with ServiceDispatch component
                .ForEach((in PostVanData vanData) =>
                {
                    activePostalVanCount++;
                    totalMailCapacity += vanData.m_MailCapacity;
                }).Run();

            // Optionally, log counts for debugging
            // Debug.Log($"Active Postal Vans: {activePostalVanCount}, Total Mail Capacity: {totalMailCapacity}");
        }

        // Override methods from GameSystemBase if needed
        protected override void OnGameLoaded(Context serializationContext)
        {
            base.OnGameLoaded(serializationContext);
            // Initialize or reset data as needed
        }

        protected override void OnGameLoadingComplete(Purpose purpose, GameMode mode)
        {
            base.OnGameLoadingComplete(purpose, mode);
            // Additional initialization after game loading completes
        }
    }
}
