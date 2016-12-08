using System;

using GroundStation.Constants;

namespace GroundStation.DataRecording
{
    class PitotLibrary
    {
        // Calibrated zero position for MPXV7002 sensor and Arduino
        // NOTE: This may have to be changed depending on the final configuration to
        //          properly zero-out the sensor
        const int CALIBRATED_ZERO_POSITION = 528;

        // STP Properties for Air
        const double GAMMA_AIR = 1.4;
        const double R_AIR = 287; // J / kg K
        

        // GetAirspeedFeetSeconds
        //
        // Returns the current airspeed in Feet/Secondfor a given Arduino analog value
        // from the MPXV7002 sensor, temperature, and pressure, as defined below
        //
        // REQUIRES:
        //      int analogValue             : Current analog read value from the Arduino MPXV7002 sensor ( > 0 )
        //      double temperature_c        : Current temperature in Celsius ( > 273.15 C )
        //      double static_pressure_pa   : Current static pressure in Pascals ( > 0 )
        // MODIFIES: Nothing
        // EFFECTS:  Nothing
        public static double GetAirspeedFeetSeconds(int analogValue, double temperature_c, double static_pressure_pa)
        {
            double dynamic_pa = DynamicPressurePaFromArduino(analogValue);
            double msVel = VelocityMetersSeconds(temperature_c + ConversionFactors.CELSIUS_TO_KELVINS, static_pressure_pa, dynamic_pa);
            double ftS = msVel * ConversionFactors.METERS_SECONDS_TO_FEET_SECONDS;
            return ftS;
        }

        // DynamicPressureFromArduino
        //
        // Returns the dynamic pressure in pascals
        //
        // REQUIRES:
        //      int analogValue : Current analog read value from the Arduino MPXV7002 sensor ( > 0 )
        // MODIFIES: Nothing
        // EFFECTS:  Nothing
        private static double DynamicPressurePaFromArduino(int analogValue)
        {
            // Returns dynamic pressure in Pa from the Analog Arduino Value
            double dynamic_pa = 4.8513 * (analogValue - CALIBRATED_ZERO_POSITION) - 0.1323;

            // Ensure that there are no negative values
            if (dynamic_pa < 0.0) dynamic_pa = 0.0;

            return dynamic_pa;
        }

        // VelocityMetersSeconds
        //
        // Returns the current airspeed in Meters/Seconds from the given parameters below
        //
        // REQUIRES:
        //      double temperature_k        : Current temperature in Kelvins ( > 0 )
        //      double static_pressure      : Current static pressure in the same units as dynamic pressure ( > 0 )
        //      double dynamic_pressure     : Current dynamic pressure in the same units as static pressure ( > 0 )
        // MODIFIES: Nothing
        // EFFECTS:  Nothing
        private static double VelocityMetersSeconds(double temperature_k, double static_pressure, double dynamic_pressure) {
            double speedOfSound_ms = Math.Sqrt(GAMMA_AIR * R_AIR * temperature_k);
            double pressureTerm_coeff = Math.Sqrt((Math.Pow(1 + dynamic_pressure / static_pressure, (GAMMA_AIR - 1) / GAMMA_AIR) - 1) * (2 / (GAMMA_AIR - 1)));
            return pressureTerm_coeff * speedOfSound_ms;
        }
    }
}
