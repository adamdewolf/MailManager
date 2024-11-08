﻿using Game.Prefabs;
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

        // Properties for binding
        public int ActivePostalVansCount => activePostalVanCount;
        public int TotalMailCapacity => totalMailCapacity;

        protected override void OnUpdate()
        {
            // Reset counts at the start of each update
            activePostalVanCount = 0;
            totalMailCapacity = 0;

            // Query postal van entities
            Entities
                 .WithAll<ServiceDispatch>()
                 .ForEach((in PostVanData vanData) =>
                 {
                     int activeVanCount = 0;  // Use a local variable instead of instance fields
                     int totalCapacity = 0;
                     activeVanCount++;
                     totalCapacity += vanData.m_MailCapacity;
                 }).Run();  // Ensure you're using .Run() to avoid Burst issues


            Debug.Log($"Updated ActivePostalVansCount: {activePostalVanCount}, TotalMailCapacity: {totalMailCapacity}");
        }
    }
}
