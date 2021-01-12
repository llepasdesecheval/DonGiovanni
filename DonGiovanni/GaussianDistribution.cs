using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leporello
{
    /// <summary>
    /// General class for functions related to the Gaussian distribution
    /// </summary>
    public class GaussianDistribution
    {
        private static double invRoot2Pi = Math.Pow(2.0 * Math.PI, -0.5);

        // Constants required for Moro's algorithm
        private const double a0 = 2.50662823884;
        private const double a1 = -18.61500062529;
        private const double a2 = 41.39119773534;
        private const double a3 = -25.44106049637;
        private const double b1 = -8.47351093090;
        private const double b2 = 23.08336743743;
        private const double b3 = -21.06224101826;
        private const double b4 = 3.13082909833;
        private const double c0 = 0.3374754822726147;
        private const double c1 = 0.9761690190917186;
        private const double c2 = 0.1607979714918209;
        private const double c3 = 0.0276438810333863;
        private const double c4 = 0.0038405729373609;
        private const double c5 = 0.0003951896511919;
        private const double c6 = 0.0000321767881768;
        private const double c7 = 0.0000002888167364;
        private const double c8 = 0.0000003960315187;

        // Horner polynomials
        private static double Horner(double x, double a0, double a1)
        {
            return a0 + x * a1;
        }

        private static double Horner(double x, double a0, double a1, double a2)
        {
            return a0 + x * Horner(x, a1, a2);
        }

        private static double Horner(double x, double a0, double a1, double a2, double a3)
        {
            return a0 + x * Horner(x, a1, a2, a3);
        }

        private static double Horner(double x, double a0, double a1, double a2, double a3, double a4)
        {
            return a0 + x * Horner(x, a1, a2, a3, a4);
        }

        private static double Horner(double x, double a0, double a1, double a2, double a3, double a4, double a5)
        {
            return a0 + x * Horner(x, a1, a2, a3, a4, a5);
        }

        private static double Horner(double x, double a0, double a1, double a2, double a3, double a4, double a5, double a6)
        {
            return a0 + x * Horner(x, a1, a2, a3, a4, a5, a6);
        }

        private static double Horner(double x, double a0, double a1, double a2, double a3, double a4, double a5, double a6, double a7)
        {
            return a0 + x * Horner(x, a1, a2, a3, a4, a5, a6, a7);
        }

        private static double Horner(double x, double a0, double a1, double a2, double a3, double a4, double a5, double a6, double a7,
            double a8)
        {
            return a0 + x * Horner(x, a1, a2, a3, a4, a5, a6, a7, a8);
        }

        private static double normPDF(double x)
        {
            return invRoot2Pi * Math.Exp(-0.5 * x * x);
        }

        private static double normCDF(double x)
        {
            double k, polynom, scale = invRoot2Pi * Math.Exp(-0.5 * x * x);

            if (x < 0)
                return 1 - normCDF(-x);
            else
            {
                k = 1.0 / (1.0 + 0.2316419 * x);
                polynom = Horner(k, 0, 0.319381530, -0.356563782, 1.781477937, -1.821255978, 1.330274429);
                return 1.0 - scale * polynom;
            }
        }

        /// <summary>
        /// Fonction de densité/répartition de la loi normale centrée réduite
        /// </summary>
        /// <param name="x">Argument</param>
        /// <param name="cumulative">Cumumative</param>
        /// <returns>Si cumulative, renvoie la fonction de répartition, sinon de densité</returns>
        public static double NormSDist(double x, bool cumulative = true)
        {
            if (cumulative)
                return normCDF(x);
            else
                return normPDF(x);
        }
        /// <summary>
        /// Fonction de répartition inverse de la loi normale
        /// </summary>
        /// <param name="x">Argument</param>
        /// <returns>Renvoie la probabilité qu'une variable gaussienne centrée réduite soit inférieure à la valeur donnée</returns>
        public static double NormSDistInv(double x)
        {
            if ((x <= 0.0) || (x >= 1.0))
                throw new ArgumentOutOfRangeException("Input must be between 0.0 and 1.0");

            double y, r, s, t;

            y = x - 0.5;
            if (Math.Abs(y) < 0.42)
            {
                r = y * y;
                return y * Horner(r, a0, a1, a2, a3) / Horner(r, 1.0, b1, b2, b3, b4);
            }
            else if (y < 0)
                r = x;
            else
                r = 1.0 - x;

            s = Math.Log(-Math.Log(r));
            t = Horner(s, c0, c1, c2, c3, c4, c5, c6, c7, c8);

            return x > 0.5 ? t : -t;
        }
    }
}
