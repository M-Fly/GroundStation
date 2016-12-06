namespace GroundStation.DropPrediction
{
    class PredictionAlgorithmEuler
    {
        // Time Constant of Integration
        private double dt = 0.0001;       // [ s ]

        // Gravitational Constant
        private double g = 9.807;       // [ m/s^2 ]

        // Air Density
        private double rho = 1.225;     // [ kg/m^2 ]

        // Payload Constants
        private double payload_mass = 1;    // [ kg ]
        private double payload_area = 0.2;  // [ m^2 ]
        private double payload_cdrg = 0.5;  // Drag Coefficient

        // PredictionIntegrationFunction
        //
        // Runs an Euler integration method to estimate the new position of the payload when the z-value of the position Vector3 is less than 0
        // ***Units must be in SI units for output parameters to make sense***
        // Does not modify the original inputted Vector3 position and velocity
        //
        // REQUIRES:
        //      Vector3 pos: Initial position Vector of the payload in m/s. Integration stops when pos.z <= 0
        //      Vector3 vel: Initial velocity vector of the payload in m/s
        // MODIFIES: Nothing
        // EFFECTS:  Nothing
        public Vector3 PredictionIntegrationFunction(Vector3 pos, Vector3 vel)
        {
            // Creates a clone of pos to ultimately return the new position at z=0 without modifying the original
            Vector3 posOut = new Vector3(pos);
            Vector3 velOut = new Vector3(vel);

            // Variable to hold the normal velocity during integration
            double velMag;

            // Loop the integration until pos.z < 0 (payload hits ground), using an Euler function
            while (posOut.z > 0)
            {
                // Find the magnitude of the velocity vector
                velMag = velOut.Norm();

                // Find the new position based on the current velocity and given integration timestep
                posOut.x = posOut.x + velOut.x * dt;
                posOut.y = posOut.y + velOut.y * dt;
                posOut.z = posOut.z + velOut.z * dt;

                // Find the new velocity based on the acceleration on particle and the given integration timestep
                velOut.x = velOut.x - 0.5 * rho * velMag * payload_area * payload_cdrg * velOut.x * dt / payload_mass;
                velOut.y = velOut.y - 0.5 * rho * velMag * payload_area * payload_cdrg * velOut.y * dt / payload_mass;
                velOut.z = velOut.z - 0.5 * rho * velMag * payload_area * payload_cdrg * velOut.z * dt / payload_mass - g * dt;
            }

            // Return the final position vector of the payload
            return posOut;
            /*
            % find final x, y, z positions given initial positions and initial
            % velocities and omega = k / m where k is CdA(rho)
            % things to do when converting to c#: make this a function
            % function predictionAlgorithm taking in [x0, y0, z0, v_x0, v_y0]
            % convert everything into ft i guess
            %function[percentSuccess, percentError] = predictionAlgorithm(x_f, y_f)
            omega = rho*payload_area*payload_cdrag/payload_mass;
            **replace thing in brackets with newton's method to find the final time
            {syms t
            fun = @(t) z0 + (g/(omega^2)) - (g/(omega^2))*exp(omega.* t) + (g/omega)*t;
            tf = fzero(fun, [0,100]);
            t = 0:.1:tf;}
            **
            for (int t = 0; t <= 10; t = t + .1)
                {
                z = z0 + (g/(omega^2)) - (g/(omega^2))*exp(omega * t) + (g/omega)*t;
                if (z = 0) 
                    {
                    tf = t;
                    }
                }
            double[] time;        
            **
            x = x0 + v_x0/omega - (v_x0/omega)*exp(-omega.* time);
            y = y0 + v_y0/omega - (v_y0/omega)*exp(-omega.* time);
            z = z0 + (g/(omega^2)) - (g/(omega^2))*exp(omega.* time) + (g/omega)*time;
            plot3(x, y, z)
            hold on
            x_f = 130;
            y_f = 130;
            r_circle = 10;
            t_circle = 0:.1:2*pi;
            x_circle = r_circle* cos(t_circle);
            y_circle = r_circle* sin(t_circle);
            plot(x_circle+x_f, y_circle+y_f)
            if (x(end) >= x_circle(1))&& (x(end) <= x_circle(end))
            if (y(end) >= y_circle(0))&& (y(end) <= y_circle(end))
            success = 'The payload will land in drop zone'
            end
            else
            success = 'Will not land in drop zone'
            end
            %matter of irritation is that fzero is a pretty bad approximation from 
            %what it seems
            %longitude and latitude 
            %plan is if it's possible to get %success from success of trials
            */

        }
    }
}
