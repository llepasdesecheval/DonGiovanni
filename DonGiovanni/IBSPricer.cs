using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leporello
{
    public enum Scheme
    {
        Backward = -1,
        Central = 0,
        Forward = 1
    }

    public interface IBSPricer
    {
        PricerOutput Price(VanillaOption option, BSMModel model);

        PricerOutput Delta(VanillaOption option, BSMModel model, double shift, Scheme scheme);

        PricerOutput Gamma(VanillaOption option, BSMModel model, double shift);

        PricerOutput Vega(VanillaOption option, BSMModel model, double shift, Scheme scheme);
    }
}
