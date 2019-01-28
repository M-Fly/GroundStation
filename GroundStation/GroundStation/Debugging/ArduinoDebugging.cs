using System;
using System.Windows.Forms;

using GroundStation.Constants;

namespace GroundStation.Debugging
{
    class ArduinoDebugging
    {
        // Time constant to determine how often the debugging function should run for
        int DEBUG_HERTZ = 5;

        #region Variables
        // Time to facilitate the debugging functions
        Timer debugTimer = new Timer();

        // Variables to keep track of persistent aircraft data
        Random randDebug = new Random((int)DateTime.UtcNow.Ticks);
        bool droppedDebug = false;
        bool droppedDebug_CDA = false;
        static DateTime timeDebugStart = DateTime.Now;

        int dropTime = -1;
        double dropAlt = -1;
        int dropTime_CDA = -1;
        double dropAlt_CDA = -1;

        // Variables to keep track of old and new position values for course calculation.
        private double old_dx = 0.0, old_dy = 0.0;

        // Callback delegate to call the parsing function in the Main Form
        public delegate void ParseFunctionDelegate(string message);
        ParseFunctionDelegate parseHandler;

        // Course Properties
        double COURSE_PERIOD_S = 60;

        double STARTING_LON = -83.7119997;
        double STARTING_LAT = 42.2936028;

        double SEMI_COURSE_HEIGHT_FT = 500;
        double SEMI_COURSE_LENGTH_FT = 800;

        double COURSE_VARIANCE_FT = 0;

        #endregion

        // ArduinoDebugging
        //
        // Creates a new Arduino Debugging object to feed sample data into the main groundstation application by
        // simulating the telemetry data from the aircraft, injected directly into the parsing function
        //
        // REQUIRES: ParseFunctionDelegate - Function of the form function(String) that will parse the
        //                                      telemetry data. MUST not be null
        //
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

        // Stop
        //
        // Disables and disposes of the debugTimer object to stop calling the parse function delegate with new
        // parsing data
        //
        public void Stop()
        {
            // Disable the debug timer -> no more looping
            debugTimer.Enabled = false;
            debugTimer.Dispose();
        }

        // LatLonHeading
        //
        // Private class to make it easy to return data from the following function in a readable manner
        private class LatLonHeading
        {
            public double latitude;
            public double longitude;
            public double heading;
        }

        // getLatLon
        //
        // Returns the new latitude/longitude/heading based on the current milliseconds and some random variance
        // as defined in the Course Parameters in the variables region above.
        //
        // REQUIRES:
        //      int millis - Represents the milliseconds ellapsed from the start of the flight.
        // MODIFIES:
        //      old_dx, old_dy
        //
        private LatLonHeading getLatLon(int millis)
        {
            // Calculate the current seconds
            double seconds = millis / 1000.0;
            
            // Calculate dx, dy from the middle of the course
            double dy = SEMI_COURSE_HEIGHT_FT * Math.Cos(2 * Math.PI / COURSE_PERIOD_S * seconds) + COURSE_VARIANCE_FT * (randDebug.NextDouble() * 2.0 - 1.0);
            double dx = SEMI_COURSE_LENGTH_FT * Math.Sin(2 * Math.PI / COURSE_PERIOD_S * seconds) + COURSE_VARIANCE_FT * (randDebug.NextDouble() * 2.0 - 1.0);

            // Calculate the aircraft heading
            double course = Math.Atan2(dx - old_dx, dy - old_dy) * ConversionFactors.RAD_TO_DEG;

            // Reset old dx, dy
            old_dx = dx;
            old_dy = dy;

            // Ensure that the course/heading is between 0 and 360
            while (course < 0) course += 360;
            while (course >= 360) course -= 360;

            // Find the new latitude and longitude for the course
            double lat = STARTING_LAT + dy / PhysicsConstants.EARTH_RADIUS_FT * ConversionFactors.RAD_TO_DEG;

            double lonRadius = PhysicsConstants.EARTH_RADIUS_FT * Math.Cos(lat * ConversionFactors.DEG_TO_RAD);
            double lon = STARTING_LON + dx / lonRadius * ConversionFactors.RAD_TO_DEG;

            // Return variables as a LAT, LON, HEADING

            return new LatLonHeading
            {
                latitude = lat,
                longitude = lon,
                heading = course
            };
        }

        // getAltMeters
        //
        // Returns the calculated altitude in meters using a sinusoidal pattern using variables as defined above in
        // the variables region above
        //
        // REQUIRES:
        //      int millis - Represents the milliseconds ellapsed from the start of the flight.
        //
        private double getAltMeters(int millis)
        {
            double seconds = millis / 1000.0;

            double targetAlt = 33;
            double variance = 1;

            return targetAlt * Math.Abs(Math.Sin(Math.PI / COURSE_PERIOD_S * seconds)) + variance * (randDebug.NextDouble() * 2.0 - 1.0);
        }

        // tmrDebugginTick
        //
        // Actual function that keeps track of the current time, determines location and altitude in the
        // simulated environment, creates sample telemetry data, and ultimately calls the parsing function
        //
        // EFFECTS:
        //      Calls the parseFunctionDelegate parseHandler with sample telemetry data
        //
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

            LatLonHeading latlng = getLatLon(millis);

            int lat_deg = (int)(latlng.latitude * 1000000.0);
            int long_deg = (int)(latlng.longitude * 1000000.0);

            int course = (int) (latlng.heading * 1000.0);

            // Determine a random drop time to test the drop mechanisms
            if (!droppedDebug && randDebug.Next(0, 10) == 0 && (millis / 1000.0) > 0.25 * COURSE_PERIOD_S) {
                dropTime = millis;
                dropAlt = altitude_meters;

                droppedDebug = true;
            }

            if (!droppedDebug_CDA && randDebug.Next(0, 10) == 0 && (millis / 1000.0) > 0.25 * COURSE_PERIOD_S) {
                dropTime_CDA = millis;
                dropAlt_CDA = altitude_meters;

                droppedDebug_CDA = true;
            }

            // Re-create the Arduino messages present in the DataAcquisitionSystem.ino files in GitHub
            string aMessageTest = String.Format("A,MX2,{0},{1},{2},{3},{4},{5},{6},{7},{8}", millis, altitude_meters, arduino_setting, press, temp, dropTime, dropAlt, dropTime_CDA, dropAlt_CDA);
            string bMessageTest = String.Format("B,MX2,{0},N,{1},{2},{3},{4},{5},10", millis, lat_deg, long_deg, gps_speed, course, gps_alt);
            string cMessageTest = String.Format("C,MX2,{0},1,2,3,4,5,6", millis);

            // Pass the testing data into the ParseData function for use.
            parseHandler(aMessageTest);
            parseHandler(bMessageTest);
            parseHandler(cMessageTest);
        }
    }
}
