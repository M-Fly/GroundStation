﻿namespace GroundStation.DropPrediction
{
    class PredictionAlgorithmEuler
    {
        // Time Constant of Integration
        private const double dt = 0.0001;       // [ s ]

        // Gravitational Constant
        private const double g = 9.807;       // [ m/s^2 ]

        // Air Density
        private const double rho = 1.225;     // [ kg/m^2 ]

        // Payload Constants
        private const double payload_mass = 1;    // [ kg ]
        private const double payload_area = 0.1;  // [ m^2 ]
        private const double payload_cdrg = 0.0;  // Drag Coefficient

        // PredictionIntegrationFunction
        //
        // Runs an Euler integration method to estimate the new position of the payload when the z-value of the position Vector3 is less than 0
        // ***Units must be in SI units for output parameters to make sense***
        // Does not modify the original inputted Vector3 position and velocity
        //
        // REQUIRES:
        //      Vector3 pos:        Initial position Vector of the payload in m/s. Integration stops when pos.z <= 0
        //      Vector3 vel:        Initial velocity vector of the payload in m/s
        //      Vector3 windVel:    Wind velocity vector (in terms of where the wind is blowing to) in m/s
        // MODIFIES: Nothing
        // EFFECTS:  Nothing
        public static Vector3 PredictionIntegrationFunction(Vector3 pos, Vector3 vel, Vector3 windVel)
        {
            // Creates a clone of pos to ultimately return the new position at z=0 without modifying the original
            Vector3 posOut = new Vector3(pos);
            Vector3 velOut = new Vector3(vel);

            // Variable to hold the normal velocity during integration
            double velRelMag;

            // Loop the integration until pos.z < 0 (payload hits ground), using an Euler function
            while (posOut.z > 0)
            {
                // Find the relative velocity between the payload and the air
                Vector3 velRel = velOut - windVel;

                // Find the magnitude of the velocity vector
                velRelMag = velRel.Norm();

                // Find the new position based on the current velocity and given integration timestep
                posOut.x = posOut.x + velOut.x * dt;
                posOut.y = posOut.y + velOut.y * dt;
                posOut.z = posOut.z + velOut.z * dt;

                // Find the new velocity based on the acceleration on particle and the given integration timestep
                velOut.x = velOut.x - 0.5 * rho * velRelMag * payload_area * payload_cdrg * velRel.x * dt / payload_mass;
                velOut.y = velOut.y - 0.5 * rho * velRelMag * payload_area * payload_cdrg * velRel.y * dt / payload_mass;
                velOut.z = velOut.z - 0.5 * rho * velRelMag * payload_area * payload_cdrg * velRel.z * dt / payload_mass - g * dt;
            }

            // Return the final position vector of the payload
            return posOut;
        }
    }
}
