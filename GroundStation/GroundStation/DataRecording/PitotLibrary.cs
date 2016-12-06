using System;

namespace GroundStation.DataRecording
{
    class PitotLibrary
    {
        const double GAMMA = 1.4;
        const double R_AIR = 287; // J / kg K

        const double CELSIUS_TO_KELVINS = 273.15;
        const double METERS_SECONDS_TO_FEET_SECONDS = 3.28084;

        public static double GetAirspeedFeetSeconds(int analogValue, double temperature_c, double static_pressure_pa)
        {
            double dynamic_pa = DynamicPressureFromArduino(analogValue);
            double msVel = VelocityMetersSeconds(temperature_c + CELSIUS_TO_KELVINS, static_pressure_pa, dynamic_pa);
            double ftS = msVel * METERS_SECONDS_TO_FEET_SECONDS;
            return ftS;
        }

        static double DynamicPressureFromArduino(int analogValue)
        {
            // Returns dynamic pressure in Pa from the Analog Arduino Value
            double dynamic_pa = 4.8513 * analogValue - 2561.4;

            // Ensure that there are no negative values
            if (dynamic_pa < 0.0) dynamic_pa = 0.0;

            return dynamic_pa;
        }

        static double VelocityMetersSeconds(double temperature_k, double static_pressure, double dynamic_pressure) {
            double speedOfSound_ms = Math.Sqrt(GAMMA * R_AIR * temperature_k);
            double pressureTerm_coeff = Math.Sqrt((Math.Pow(1 + dynamic_pressure / static_pressure, (GAMMA - 1) / GAMMA) - 1) * (2 / (GAMMA - 1)));
            return pressureTerm_coeff * speedOfSound_ms;
        }
    }
}
