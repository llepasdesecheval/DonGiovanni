using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leporello
{
    public class BSMModel
    {
        private double m_stockPrice, m_drift, m_volatility, m_dividendYield, m_riskFreeRate;

        #region Accessors
        public double StockPrice { get => m_stockPrice; set => m_stockPrice = value; }
        public double Drift { get => m_drift; set => m_drift = value; }
        public double Volatility { get => m_volatility; set => m_volatility = value; }
        public double DividendYield { get => m_dividendYield; set => m_dividendYield = value; }
        public double RiskFreeRate { get => m_riskFreeRate; set => m_riskFreeRate = value; }
        #endregion

        public BSMModel(double stockPrice, double volatility, double rate = 0, double dividend = 0, double drift = 0)
        {
            m_stockPrice = stockPrice;
            m_volatility = volatility;
            m_riskFreeRate = rate;
            m_dividendYield = dividend;
            m_drift = drift;
        }

        public BSMModel ShiftSpot(double shift)
        {
            return new BSMModel(m_stockPrice + shift, m_volatility, m_riskFreeRate, m_dividendYield, m_drift);
        }

        public BSMModel ShiftVol(double shift)
        {
            return new BSMModel(m_stockPrice, m_volatility + shift, m_riskFreeRate, m_dividendYield, m_drift);
        }
    }
}
