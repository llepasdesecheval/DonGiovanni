using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Leporello.GaussianDistribution;

namespace Leporello
{
    public class BSMClosedForm : IBSPricer
    {
        public PricerOutput Price(VanillaOption option, BSMModel model)
        {
            double z = (option.OptionType == VanillaOption.Type.Put) ? -1.0 : 1.0;

            double d1 = (Math.Log(model.StockPrice / option.Strike) + (model.RiskFreeRate - model.DividendYield
                + 0.5 * model.Volatility * model.Volatility) * option.Maturity) / (model.Volatility * Math.Sqrt(option.Maturity));

            double price = z * (model.StockPrice * Math.Exp(-model.DividendYield * option.Maturity) * NormSDist(z * d1)
                - option.Strike * Math.Exp(-model.RiskFreeRate * option.Maturity)
                * NormSDist(z * (d1 - model.Volatility * Math.Sqrt(option.Maturity))));

            return new PricerOutput(price);
        }

        public PricerOutput Delta(VanillaOption option, BSMModel model, double shift, Scheme scheme)
        {
            double delta;
            switch (scheme)
            {
                case Scheme.Central:
                    delta = (Price(option, model.ShiftSpot(shift)).Estimate - Price(option, model.ShiftSpot(-shift)).Estimate)
                        / (2.0 * shift);
                    return new PricerOutput(delta);
                case Scheme.Forward:
                    delta = (Price(option, model.ShiftSpot(shift)).Estimate - Price(option, model).Estimate) / shift;
                    return new PricerOutput(delta);
                case Scheme.Backward:
                    delta = (Price(option, model).Estimate - Price(option, model.ShiftSpot(-shift)).Estimate) / shift;
                    return new PricerOutput(delta);
                default:
                    throw new ArgumentOutOfRangeException("Incorrect Value for the difference scheme");
            }
        }

        public PricerOutput Gamma(VanillaOption option, BSMModel model, double shift)
        {
            double gamma = (Price(option, model.ShiftSpot(shift)).Estimate + Price(option, model.ShiftSpot(-shift)).Estimate
                - 2.0 * Price(option, model).Estimate) / (shift * shift);
            return new PricerOutput(gamma);
        }

        public PricerOutput Vega(VanillaOption option, BSMModel model, double shift, Scheme scheme)
        {
            double vega;
            switch (scheme)
            {
                case Scheme.Central:
                    vega = (Price(option, model.ShiftVol(shift)).Estimate - Price(option, model.ShiftVol(-shift)).Estimate)
                        / (2.0 * shift);
                    return new PricerOutput(vega);
                case Scheme.Forward:
                    vega = (Price(option, model.ShiftVol(shift)).Estimate - Price(option, model).Estimate) / shift;
                    return new PricerOutput(vega);
                case Scheme.Backward:
                    vega = (Price(option, model).Estimate - Price(option, model.ShiftVol(-shift)).Estimate) / shift;
                    return new PricerOutput(vega);
                default:
                    throw new ArgumentOutOfRangeException("Incorrect Value for the difference scheme");
            }
        }
    }
}
