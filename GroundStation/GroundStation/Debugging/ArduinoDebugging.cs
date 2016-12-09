using System;
using System.Windows.Forms;

using GroundStation.Constants;

namespace GroundStation.Debugging
{
    class ArduinoDebugging
    {
        // Time constant to determine how often the debugging function should run for
        int DEBUG_HERTZ = 5;

        // Time to facilitate the debugging functions
        Timer debugTimer = new Timer();

        // Variables to keep track of persistent aircraft data
        Random randDebug = new Random((int)DateTime.UtcNow.Ticks);
        bool droppedDebug = false;
        static DateTime timeDebugStart = DateTime.Now;

        int dropTime = -1;
        double dropAlt = -1;

        // Callback delegate to call the parsing function in the Main Form
        public delegate void ParseFunctionDelegate(string message);
        ParseFunctionDelegate parseHandler;

        // Course Properties
        double COURSE_PERIOD_S = 60;

        public ArduinoDebugging(ParseFunctionDelegate parseFunction)
        {
            // Initialize the timer
            debugTimer.Interval = 1000 / DEBUG_HERTZ;
            debugTimer.Tick += tmrDebuggingTick;

            // Enable the timer
            debugTimer.Enabled = true;

            // Set the parsing delegate to the one passed in
            parseHandler = parseFunction;
        }

        private double[] getLatLon(int millis)
        {
            double seconds = millis / 1000.0;

            double startingLon = -83.7119997;
            double startingLat = 42.2936028;

            double semiCourseHeightFt = 1000;
            double semiCourseLengthFt = 3000;

            double variance = 25;

            double dy = semiCourseHeightFt * Math.Cos(2 * Math.PI / COURSE_PERIOD_S * seconds) + variance * (randDebug.NextDouble() * 2.0 - 1.0);
            double dx = semiCourseLengthFt * Math.Sin(2 * Math.PI / COURSE_PERIOD_S * seconds) + variance * (randDebug.NextDouble() * 2.0 - 1.0);

            double lat = startingLat + dy / PhysicsConstants.EARTH_RADIUS_FT * ConversionFactors.RAD_TO_DEG;

            double lonRadius = PhysicsConstants.EARTH_RADIUS_FT * Math.Cos(lat * ConversionFactors.DEG_TO_RAD);

            double lon = startingLon + dx / lonRadius * ConversionFactors.RAD_TO_DEG;

            return new double[] { lat, lon };
        }

        private double getAltMeters(int millis)
        {
            double seconds = millis / 1000.0;

            double targetAlt = 33;
            double variance = 1;

            return targetAlt * Math.Abs(Math.Sin(Math.PI / COURSE_PERIOD_S * seconds)) + variance * (randDebug.NextDouble() * 2.0 - 1.0);
        }

        private void tmrDebuggingTick(object sender, EventArgs e)
        {
            // Get Milliseconds from Initial Start Time
            int millis = (int)DateTime.Now.Subtract(timeDebugStart).TotalMilliseconds;

            // Create sample data for airpseed, altitude, ground speed, altitude, latitude/longitude, course, and time
            int arduino_setting = randDebug.Next(528, 546);

            double altitude_meters = getAltMeters(millis);

            double temp = 21.80;
            double press = 98700;
            double airspeed_knots = DataRecording.PitotLibrary.GetAirspeedFeetSeconds(arduino_setting, temp, press) * 0.592484;

            int gps_speed = (int)(airspeed_knots * 1000);
            int gps_alt = (int)(getAltMeters(millis) * 1000);

            double[] latlng = getLatLon(millis);

            int lat_deg = (int)(latlng[0] * 1000000.0);
            int long_deg = (int)(latlng[1] * 1000000.0);

            int course = randDebug.Next(0, 360);

            int q = randDebug.Next(0, 25);

            // Determine a random drop time to test the drop mechanisms
            if (!droppedDebug && q == 0 && (millis / 1000.0) > 0.25 * COURSE_PERIOD_S)
            {
                dropTime = millis;
                dropAlt = altitude_meters;

                droppedDebug = true;
            }

            // Re-create the Arduino messages present in the DataAcquisitionSystem.ino files in GitHub
            string aMessageTest = String.Format("A,MX2,{0},{1},{2},{3},{4},{5},{6}", millis, altitude_meters, arduino_setting, press, temp, dropTime, dropAlt);
            string bMessageTest = String.Format("B,MX2,{0},N,{1},{2},{3},{4},{5},10,100", millis, lat_deg, long_deg, gps_speed, course, gps_alt);
            string cMessageTest = String.Format("C,MX2,{0},1,2,3,4,5,6", millis);

            // Pass the testing data into the ParseData function for use.
            parseHandler(aMessageTest);
            parseHandler(bMessageTest);
            parseHandler(cMessageTest);
        }
    }
}
