using System;

namespace GroundStation.DropPrediction
{
    class PredictionAlgorithmLagrange
    {
        public double g = 9.807;

        public double rho = 1.225;

        public double payload_mass = 1;

        public double payload_area = 0.2;

        public double payload_cdrg = 0.5;

        public double exp = Math.E;

        public double EulerLagrange(double x0, double y0, double z0, double v_x0, double v_y0)
        {
            double z;

            double omega = rho * payload_area * payload_cdrg / payload_mass;

            double t_max = 10, t_min = 0, tf = .5 * t_max;

            double simplification1 = (g / (Math.Pow(omega, 2)));

            double simplification2 = Math.Pow(exp, (omega * tf));

            double simplification3 = g / omega;

            z = z0 + simplification1 - (simplification1 * simplification2) + (simplification3 * tf);
            
            while (Math.Abs(z) > .1)
            {
                if (z < 0)
                {
                    t_max = tf;
                    tf = .5 * (t_min + t_max);
                    simplification2 = Math.Pow(exp, (omega * tf));
                    z = z0 + simplification1 - (simplification1 * simplification2) + (simplification3 * tf);
                }
                else
                {
                    t_min = tf;
                    tf = .5 * (t_min + t_max);
                    simplification2 = Math.Pow(exp, (omega * tf));
                    z = z0 + simplification1 - (simplification1 * simplification2) + (simplification3 * tf);
                }
            }

            double hi = tf;
            
            double[] time = new double[100];

            double[] xDistance = new double[100];

            double[] yDistance = new double[100];

            double[] zDistance = new double[100];

            
            double xDistanceYo = x0 + (v_x0 / omega) - (v_x0 / omega) * (Math.Pow(exp, (-omega * tf)));
            double yDistanceYo = y0 + (v_y0 / omega) - (v_y0 / omega) * (Math.Pow(exp, (-omega * tf)));
            for (int i = 0; i <= 100; i++)
            {
                double simplification4 = Math.Pow(exp, (omega * time[i]));
                time[i] = i * tf / 100;
                xDistance[i] = x0 + v_x0 / omega - (v_x0 / omega) * (Math.Pow(exp, (-omega * time[i])));
                yDistance[i] = y0 + v_y0 / omega - (v_y0 / omega) * (Math.Pow(exp, (-omega * time[i])));
                zDistance[i] = z0 + simplification1 - (simplification1 * simplification4) + (simplification3 * time[i]);
            }
            return tf;
        }
    }
}