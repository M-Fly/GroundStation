using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroundStation.Constants
{
    class ConversionFactors
    {
        // Time
        public const double MILLIS_TO_SECONDS = 0.001;

        // Distance
        public const double METERS_TO_FEET = 3.28084;

        // Velocity
        public const double KNOTS_TO_FPS = 1.68781;
        public const double METERS_SECONDS_TO_FEET_SECONDS = METERS_TO_FEET;

        // Temperature
        public const double CELSIUS_TO_KELVINS = 273.15;

        // Angles
        public const double RAD_TO_DEG = 180.0 / Math.PI;
        public const double DEG_TO_RAD = Math.PI / 180.0;
    }
}
