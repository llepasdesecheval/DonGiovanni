using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Leporello.GaussianDistribution;
using static Leporello.Stats;

namespace Leporello
{
    public class PricerOutput
    {
        private readonly double m_estimate, m_confidence;

        public double Estimate => m_estimate;

        public double Confidence => m_confidence;

        #region Constructors
        /// <summary>
        /// Creates a pricing output for a Monte Carlo simulation sample
        /// </summary>
        /// <param name="sample">1-D data array</param>
        /// <param name="confidenceLevel">Confidence level</param>
        public PricerOutput(double[] sample, double confidenceLevel)
        {
            m_estimate = Mean(sample);
            m_confidence = NormSDistInv((1 + confidenceLevel) / 2) * StDev(sample) / Math.Sqrt(sample.Length);
        }

        /// <summary>
        /// Creates a pricing output from known estimate and confidence interval size
        /// </summary>
        /// <param name="estimate"></param>
        /// <param name="confidence"></param>
        public PricerOutput(double estimate, double confidence)
        {
            m_estimate = estimate;
            m_confidence = confidence;
        }

        /// <summary>
        /// Creates a pricing output for a closed formula
        /// </summary>
        /// <param name="number">Output of the closed formula</param>
        public PricerOutput(double number)
        {
            m_estimate = number;
            // Since there is no randomness, the confidence interval is a singleton.
            m_confidence = 0.0;
        }
        #endregion
    }
}
