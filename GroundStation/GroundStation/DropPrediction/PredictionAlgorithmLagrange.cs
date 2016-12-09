

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

		double omega = rho*payload_area*payload_cdrag/payload_mass;

		double t_max = 10, t_min = 0, tf = .5*t_max;

        double x0 = 60, y0 = 60, z0 = 100, v_x0 = 20, v_y0 = 20;

        static void Main(string[] args)
        {
            double z; 
			z = z0 + (g / (Math.Pow(omega, 2))) - (g / (Math.Pow(omega, 2))) * Math.Pow(exp, (omega * tf)) + (g / omega) * tf;
            while (z != 0)
				{
                if (z > 0)
                {
                    t_max = tf;
                    tf = .5 * (t_low + t_max);
                    z = z0 + (g / (Math.Pow(omega, 2))) - (g / (Math.Pow(omega, 2))) * Math.Pow(exp, (omega * tf)) + (g / omega) * tf;
                }
                else if (z < 0)
                {
                    t_low = tf;
                    tf = .5 * (t_low + t_max);
                    z = z0 + (g / (Math.Pow(omega, 2))) - (g / (Math.Pow(omega, 2))) * Math.Pow(exp, (omega * tf)) + (g / omega) * tf;
                }
                else
                {
                    tf = tf;
                }
            }

            double[] time = new double[100];

            double[] xDistance = new double[100];

            double[] yDistance = new double[100];

            double[] zDistance = new double[100];

            for (int i = 0; i <= 100; i++)
            {
                time[i] = i * tf / 100;
                xDistance[i] = x0 + v_x0 / omega - (v_x0 / omega) * (Math.Pow(exp, (-omega * time[i])));
                yDistance[i] = y0 + v_y0 / omega - (v_y0 / omega) * (Math.Pow(exp, (-omega * time[i])));
                zDistance[i] = z0 + (g / (Math.Pow(omega, 2))) - (g / (Math.Pow(omega, 2))) * Math.Pow(exp, (omega * time[i])) + (g / omega) * time[i];
            }
            return tf;
        }
	}
}