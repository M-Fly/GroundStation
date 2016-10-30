using System;

namespace GroundStation.DropPrediction
{
    class Vector3
    {
        public double x;
        public double y;
        public double z;


        // Vector3 Constructor
        //
        // Creates a new Vector3 from the given x/y/z variables.
        // The x/y/z variables are optional, and in the case that they are ommitted, the vector values will be set to 0.0
        //
        // REQUIRES:
        //      double x: X Value (Optional)
        //      double y: Y Value (Optional)
        //      double z: Z Value (Optional)
        // MODIFIES: Nothing
        // EFFECTS:  Nothing
        public Vector3(double x = 0.0, double y = 0.0, double z = 0.0)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        // Vector3 Copy-Constructor
        //
        // Constructs a new Vector3 by value from the passed-in Vector3 object
        //
        // REQUIRES:
        //      Vector3 v: Vector to be cloned into the new object
        // MODIFIES: Nothing
        // EFFECTS:  Nothing
        public Vector3(Vector3 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
        }

        // Norm
        // 
        // Returns a double containing the vector magnitude of the Vector3 object
        //
        // REQUIRES: Nothing
        // MODIFIES: Nothing
        // EFFECTS:  Nothing
        public double Norm()
        {
            return Math.Sqrt(x * x + y * y + z * z);
        }
    }
}
