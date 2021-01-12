using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leporello
{
    /// <summary>
    /// Statistical functions
    /// </summary>
    public class Stats
    {
        public static double Mean(double[] data)
        {
            int size = data.Length;
            double sum = 0;
            for(int i = 0; i < size; ++i)
            {
                sum += data[i];
            }
            return sum / size;
        }

        public static double StDev(double[] data, bool sample = true)
        {
            int size = data.Length;
            double sum = 0;
            double sumSquared = 0;

            for (int i = 0; i < size; ++i)
            {
                double elt = data[i];
                sum += elt;
                sumSquared += elt * elt;
            }

            double mean = sum / size;

            if (sample)
                return Math.Sqrt((double)size / (size - 1) * (sumSquared / size - mean * mean));
            else
                return Math.Sqrt(sumSquared / size - mean * mean);
        }
    }
}
