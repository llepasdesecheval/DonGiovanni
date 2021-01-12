using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leporello
{
    public class BSMMonteCarlo : IBSPricer
    {
        #region Attributes
        int m_nPaths, m_nSteps;
        double m_confidenceLevel;
        double[] m_simulations;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a Monte Carlo Pricer under the Black-Scholes-Merton model
        /// </summary>
        /// <param name="nPaths">Number of simulated paths</param>
        /// <param name="nSteps">Number of steps per path</param>
        /// <param name="confidenceLevel">Desired level of confidence</param>
        public BSMMonteCarlo(int nPaths, int nSteps, double confidenceLevel)
        {
            m_nPaths = nPaths;
            m_nSteps = nSteps;
            m_confidenceLevel = confidenceLevel;
            m_simulations = RandomGenerator.Gaussian(nPaths * nSteps);
        }
        #endregion

        private double[,] generatePricePaths(BSMModel model, double toDate, bool riskNeutral = true)
        {
            // nSteps + 1 steps per path to include current stock price
            double[,] paths = new double[m_nPaths, m_nSteps + 1];
            double step = toDate / m_nSteps;
            for (int i = 0; i < m_nPaths; ++i)
            {
                paths[i, 0] = model.StockPrice;
                double logPrice = Math.Log(model.StockPrice);
                double logDriftTerm = riskNeutral ? (model.RiskFreeRate - model.DividendYield
                    - 0.5 * model.Volatility * model.Volatility) * step : model.Drift * step;
                double logDiffusionTerm = model.Volatility * Math.Sqrt(step);
                for (int j = 0; j < m_nSteps; ++j)
                {
                    logPrice += logDriftTerm + logDiffusionTerm * m_simulations[i + j * m_nPaths];
                    paths[i, j + 1] = Math.Exp(logPrice);
                }
            }
            return paths;
        }

        public PricerOutput Price(VanillaOption option, BSMModel model)
        {
            double[,] pricePaths = generatePricePaths(model, option.Maturity);
            double[] payoffs = new double[m_nPaths];
            for (int i = 0; i < m_nPaths; ++i)
            {
                payoffs[i] = option.Payoff(pricePaths[i, m_nSteps]);
            }
            return new PricerOutput(payoffs, m_confidenceLevel);
        }

        public PricerOutput Delta(VanillaOption option, BSMModel model, double shift, Scheme scheme)
        {
            double delta, confidence;
            PricerOutput priceUp, priceDown;
            switch (scheme)
            {
                case Scheme.Central:
                    priceUp = Price(option, model.ShiftSpot(shift));
                    priceDown = Price(option, model.ShiftSpot(-shift));
                    delta = (priceUp.Estimate - priceDown.Estimate) / (2.0 * shift);
                    confidence = (priceUp.Confidence + priceDown.Confidence) / (2.0 * shift);
                    return new PricerOutput(delta, confidence);
                case Scheme.Forward:
                    priceUp = Price(option, model.ShiftSpot(shift));
                    priceDown = Price(option, model);
                    delta = (priceUp.Estimate - priceDown.Estimate) / shift;
                    confidence = (priceUp.Confidence + priceDown.Confidence) / shift;
                    return new PricerOutput(delta, confidence);
                case Scheme.Backward:
                    priceUp = Price(option, model);
                    priceDown = Price(option, model.ShiftSpot(-shift));
                    delta = (priceUp.Estimate - priceDown.Estimate) / shift;
                    confidence = (priceUp.Confidence + priceDown.Confidence) / shift;
                    return new PricerOutput(delta, confidence);
                default:
                    throw new ArgumentOutOfRangeException("Incorrect Value for the difference scheme");
            }
        }

        public PricerOutput Gamma(VanillaOption option, BSMModel model, double shift)
        {
            double gamma, confidence;
            PricerOutput priceUp = Price(option, model.ShiftSpot(shift));
            PricerOutput price = Price(option, model);
            PricerOutput priceDown = Price(option, model.ShiftSpot(-shift));
            gamma = (priceUp.Estimate + priceDown.Estimate - 2.0 * price.Estimate) / (shift * shift);
            confidence = (priceUp.Confidence + priceDown.Confidence + 2.0 * price.Confidence) / (shift * shift);

            return new PricerOutput(gamma, confidence);
        }

        public PricerOutput Vega(VanillaOption option, BSMModel model, double shift, Scheme scheme)
        {
            double vega, confidence;
            PricerOutput priceUp, priceDown;
            switch (scheme)
            {
                case Scheme.Central:
                    priceUp = Price(option, model.ShiftVol(shift));
                    priceDown = Price(option, model.ShiftVol(-shift));
                    vega = (priceUp.Estimate - priceDown.Estimate) / (2.0 * shift);
                    confidence = (priceUp.Confidence + priceDown.Confidence) / (2.0 * shift);
                    return new PricerOutput(vega, confidence);
                case Scheme.Forward:
                    priceUp = Price(option, model.ShiftVol(shift));
                    priceDown = Price(option, model);
                    vega = (priceUp.Estimate - priceDown.Estimate) / shift;
                    confidence = (priceUp.Confidence + priceDown.Confidence) / shift;
                    return new PricerOutput(vega, confidence);
                case Scheme.Backward:
                    priceUp = Price(option, model);
                    priceDown = Price(option, model.ShiftVol(-shift));
                    vega = (priceUp.Estimate - priceDown.Estimate) / shift;
                    confidence = (priceUp.Confidence + priceDown.Confidence) / shift;
                    return new PricerOutput(vega, confidence);
                default:
                    throw new ArgumentOutOfRangeException("Incorrect Value for the difference scheme");
            }
        }
    }
}
