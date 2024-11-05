import React, { useState, useEffect } from "react";
import { bindValue } from "cs2/api";

const PostalVanCounter = () => {
    const [activeVanCount, setActiveVanCount] = useState(0);
    const [totalCapacity, setTotalCapacity] = useState(0);

    // Bind to ECS values in PostalVanTrackingSystem
    const vanCountBinding = bindValue<number>("MailManager", "ActivePostalVansCount");
    const capacityBinding = bindValue<number>("MailManager", "TotalMailCapacity");

    useEffect(() => {
        // Subscribe to active van count updates
        const vanSubscription = vanCountBinding.subscribe((value) => setActiveVanCount(value ?? 0));

        // Subscribe to total mail capacity updates
        const capacitySubscription = capacityBinding.subscribe((value) => setTotalCapacity(value ?? 0));

        // Cleanup subscriptions on unmount
        return () => {
            vanSubscription.dispose();
            capacitySubscription.dispose();
        };
    }, [vanCountBinding, capacityBinding]);

    return (
        <div style={{ padding: "10px", backgroundColor: "#333", color: "#FFF", borderRadius: "5px" }}>
            <h3>Active Postal Vans</h3>
            <p>{activeVanCount} vans currently active</p>
            <p>Total Mail Capacity: {totalCapacity}</p>
        </div>
    );
};

export default PostalVanCounter;

