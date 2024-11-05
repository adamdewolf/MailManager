import React from "react";
import { useValue } from "cs2/api";

const PostalVanCounter = () => {
    // Using `useValue` to bind ECS values to UI
    const activeVanCount = useValue<number>("MailManager", "ActivePostalVansCount", 0);
    const totalCapacity = useValue<number>("MailManager", "TotalMailCapacity", 0);

    return (
        <div style= {{ padding: "10px", backgroundColor: "#333", color: "#FFF", borderRadius: "5px" }
}>
    <h3>Active Postal Vans < /h3>
        < p > { activeVanCount } vans currently active < /p>
            < p > Total Mail Capacity: { totalCapacity } </p>
                < /div>
    );
};

export default PostalVanCounter;
