// src/index.tsx

import { ModRegistrar } from "cs2/modding";
import PostalVanCounter from "./mods/PostalVanCounter";

const register: ModRegistrar = (moduleRegistry) => {
    // Add PostalVanCounter to the game UI at a specific location
    moduleRegistry.append("GameTopRight", PostalVanCounter);
};

export default register;