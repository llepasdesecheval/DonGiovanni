using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leporello
{
    /// <summary>
    /// Pseudo-random number generator
    /// </summary>
    public class RandomGenerator
    {
        private static readonly Random m_generator = new Random();

        /// <summary>
        /// Gaussian pseudo-random number generator
        /// </summary>
        /// <param name="nSimulations">Number of simulations</param>
        /// <param name="mean">Mean of the simulated Gaussian distribution, 0 by default</param>
        /// <param name="standardDeviation">Standard deviation of the simulated Gaussian distribution, 1 by default</param>
        /// <returns></returns>
        public static double[] Gaussian(int nSimulations, double mean = 0.0, double standardDeviation = 1.0)
        {
            double[] result = new double[nSimulations];
            int roundUpN = (nSimulations % 2 == 0) ? nSimulations : nSimulations + 1;

            for (int i = 0; i < roundUpN - 2; i += 2)
            {
                double v1, v2, norm;

                do
                {
                    v1 = 2 * m_generator.NextDouble() - 1.0;
                    v2 = 2 * m_generator.NextDouble() - 1.0;
                    norm = v1 * v1 + v2 * v2;
                } while ((norm >= 1.0) || (norm <= 0.0));

                result[i] = mean + standardDeviation * v1 * Math.Sqrt(-2.0 * Math.Log(norm) / norm);
                result[i + 1] = mean + standardDeviation * v2 * Math.Sqrt(-2.0 * Math.Log(norm) / norm);
            }

            double x, y, s;

            do
            {
                x = 2 * m_generator.NextDouble() - 1.0;
                y = 2 * m_generator.NextDouble() - 1.0;
                s = x * x + y * y;
            } while ((s >= 1.0) || (s <= 0.0));

            result[roundUpN - 2] = mean + standardDeviation * x * Math.Sqrt(-2.0 * Math.Log(s) / s);
            if (roundUpN == nSimulations)
                result[roundUpN - 1] = mean + standardDeviation * y * Math.Sqrt(-2.0 * Math.Log(s) / s);

            return result;
        }
    }
}
