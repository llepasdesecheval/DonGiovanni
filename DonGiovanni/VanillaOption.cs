using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leporello
{
    public class VanillaOption
    {
        public enum Type
        {
            Put = -1,
            Call = 1
        }

        private Type m_optionType;
        private double m_strike, m_maturity;

        public VanillaOption(double strike, double maturity, Type optionType)
        {
            m_strike = strike;
            m_maturity = maturity;
            m_optionType = optionType;
        }

        public Type OptionType { get => m_optionType; set => m_optionType = value; }
        public double Strike { get => m_strike; set => m_strike = value; }
        public double Maturity { get => m_maturity; set => m_maturity = value; }

        public double Payoff(double stockPrice)
        {
            return ((int)m_optionType * (stockPrice - m_strike) > 0) ? (int)m_optionType * (stockPrice - m_strike) : 0.0;
        }
    }
}
