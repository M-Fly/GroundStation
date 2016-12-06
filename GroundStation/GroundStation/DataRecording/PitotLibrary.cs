using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroundStation.DataRecording
{
    class PitotLibrary
    {
        const double GAMMA = 1.4;
        const double R_AIR = 287; // J / kg K

        static double VelocityMetersSeconds(double temperature_k, double static_pressure, double dynamic_pressure) {
            double speedOfSound = Math.Sqrt(GAMMA * R_AIR * temperature_k);
            double pressureTerm = Math.Sqrt((Math.Pow(1 + dynamic_pressure / static_pressure, (GAMMA - 1) / GAMMA) - 1) * (2 / (GAMMA - 1)));
            return pressureTerm * speedOfSound;
        }

        static bool TESTING()
        {
            double[] dynamic_pressure_kpa = { 0, 0.0846056, 0.3782368, 0.4479120 };
            double static_pressure_kpa = 96.94218653;
            double temperature_k = 294.2611111;

            double[] expected_ms = { 0, 12.13941813, 25.65344792, 27.91288005 };

            if (dynamic_pressure_kpa.Length != expected_ms.Length) return false;

            for (int i = 0; i < expected_ms.Length; ++i)
            {
                double vel = VelocityMetersSeconds(temperature_k, static_pressure_kpa, dynamic_pressure_kpa[i]);

                if (Math.Abs(vel - expected_ms[i]) > 0.0001) return false;
            }

            return true;
        }
    }
}
