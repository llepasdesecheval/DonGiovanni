using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Leporello
{
    public partial class PricingForm : Form
    {
        public PricingForm()
        {
            InitializeComponent();
        }

        private void PriceButton_Click(object sender, EventArgs e)
        {
            #region Check option and model parameters
            List<Label> labels = new List<Label> { strikeLabel, maturityLabel, stockPriceLabel, interestRateLabel, volatilityLabel };
            List<TextBox> inputs = new List<TextBox> { strikeTextBox, maturityTextBox, stockPriceTextBox, interestRateTextBox,
            volatilityTextBox };
            // Creates a dictionary from the two lists.
            Dictionary<Label, TextBox> userInputs = labels.Zip(inputs, (k, v) => new { k, v }).ToDictionary(x => x.k, x => x.v);

            string output = string.Empty;

            foreach (KeyValuePair<Label, TextBox> userInput in userInputs)
            {
                bool parseSucceed = Double.TryParse(userInput.Value.Text, out _);
                if (!parseSucceed)
                {
                    MessageBox.Show($"Unable to parse input for {userInput.Key.Text}, please check input.");
                    return;
                }
                output += userInput.Key.Text + ": " + userInput.Value.Text + Environment.NewLine;
            }

            double strike = Double.Parse(strikeTextBox.Text);
            double maturity = Double.Parse(maturityTextBox.Text);
            double spot = Double.Parse(stockPriceTextBox.Text);
            double rate = Double.Parse(interestRateTextBox.Text) / 100.0;
            double volatility = Double.Parse(volatilityTextBox.Text) / 100.0;
            #endregion

            #region Check option type
            if (optionTypeComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select option type.");
                return;
            }
            VanillaOption.Type optionType = optionTypeComboBox.SelectedItem.ToString() == "Put" ?
                VanillaOption.Type.Put : VanillaOption.Type.Call;
            output += optionTypeLabel.Text + ": " + optionTypeComboBox.Text + Environment.NewLine;
            #endregion

            #region Difference schemes for Greeks
            Scheme deltaScheme = Scheme.Central;
            Scheme vegaScheme = Scheme.Central;
            if (deltaCheckBox.Checked)
            {
                if (deltaSchemeComboBox.Text == "Forward")
                    deltaScheme = Scheme.Forward;
                else if (deltaSchemeComboBox.Text == "Backward")
                    deltaScheme = Scheme.Backward;
                else if (deltaSchemeComboBox.Text == "Central")
                    deltaScheme = Scheme.Central;
                else
                {
                    MessageBox.Show("Please select difference scheme for delta computation.");
                    return;
                }
            }

            if (vegaCheckBox.Checked)
            {
                if (vegaSchemeComboBox.Text == "Forward")
                    vegaScheme = Scheme.Forward;
                else if (vegaSchemeComboBox.Text == "Backward")
                    vegaScheme = Scheme.Backward;
                else if (vegaSchemeComboBox.Text == "Central")
                    vegaScheme = Scheme.Central;
                else
                {
                    MessageBox.Show("Please select difference scheme for vega computation.");
                    return;
                }
            }
            #endregion

            #region Check prices to compute
            bool computePrice = (priceCheckBox.Checked) || (gammaCheckBox.Checked)
                || ((deltaCheckBox.Checked) && ((deltaScheme == Scheme.Forward) || (deltaScheme == Scheme.Backward)))
                || ((vegaCheckBox.Checked) && ((vegaScheme == Scheme.Forward) || (vegaScheme == Scheme.Backward)));
            bool computeSpotUpPrice = (gammaCheckBox.Checked)
                || ((deltaCheckBox.Checked) && ((deltaScheme == Scheme.Forward) || (deltaScheme == Scheme.Central)));
            bool computeSpotDownPrice = (gammaCheckBox.Checked)
                || ((deltaCheckBox.Checked) && ((deltaScheme == Scheme.Central) || (deltaScheme == Scheme.Backward))); ;
            bool computeVolUpPrice = (vegaCheckBox.Checked) && ((vegaScheme == Scheme.Forward) || (vegaScheme == Scheme.Central));
            bool computeVolDownPrice = (vegaCheckBox.Checked) && ((vegaScheme == Scheme.Central) || (vegaScheme == Scheme.Backward));
            #endregion

            #region Check shifts
            double stockPriceShift = 0;
            double volatilityShift = 0;
            if (stockPriceShiftTextBox.Enabled)
            {
                // If no value is provided, spot is shifted by 1%.
                if (stockPriceShiftTextBox.Text == "")
                    stockPriceShift = spot / 100;
                else
                {
                    double result;
                    bool parse = Double.TryParse(stockPriceShiftTextBox.Text, out result);
                    if (!parse)
                    {
                        MessageBox.Show("Unable to parse input for Stock price shift, please check input.");
                        return;
                    }
                    else if (result <= 0)
                        MessageBox.Show("Shift must have a positive value.");
                    else
                        stockPriceShift = result;
                }
            }

            if (volatilityShiftTextBox.Enabled)
            {
                // If no value is provided, volatility is shited by 1 basis point.
                if (volatilityShiftTextBox.Text == "")
                    volatilityShift = 1E-2;
                else
                {
                    double result;
                    bool parse = Double.TryParse(volatilityShiftTextBox.Text, out result);
                    if (!parse)
                    {
                        MessageBox.Show("Unable to parse input for Volatility shift, please check input");
                        return;
                    }
                    else if (result <= 0)
                        MessageBox.Show("Shift must have a positive value");
                    else
                        volatilityShift = result / 100;
                }
            }
            #endregion

            VanillaOption option = new VanillaOption(strike, maturity, optionType);
            BSMModel model = new BSMModel(spot, volatility, rate);

            #region Pricing method
            IBSPricer pricer;
            if (radioMC.Checked)
            {
                int result;
                bool parse = Int32.TryParse(pathsTextBox.Text, out result);
                if (!parse)
                {
                    MessageBox.Show($"Unable to parse input for {pathsLabel.Text}, please check input.");
                    return;
                }
                int nPaths = result;
                pricer = new BSMMonteCarlo(nPaths, 1, 0.99);
                output += "Pricing method: Monte Carlo" + Environment.NewLine;
            }
            else { 
                pricer = new BSMClosedForm();
                output += "Pricing method: Closed form" + Environment.NewLine;
            }
            #endregion

            Stopwatch elapsed = new Stopwatch();
            elapsed.Start();

            #region Compute prices
            PricerOutput price = null;
            PricerOutput upSpotPrice = null;
            PricerOutput downSpotPrice = null;
            PricerOutput upVolPrice = null;
            PricerOutput downVolPrice = null;

            if (computePrice)
                price = pricer.Price(option, model);
            if (computeSpotUpPrice)
                upSpotPrice = pricer.Price(option, model.ShiftSpot(stockPriceShift));
            if (computeSpotDownPrice)
                downSpotPrice = pricer.Price(option, model.ShiftSpot(-stockPriceShift));
            if (computeVolUpPrice)
                upVolPrice = pricer.Price(option, model.ShiftVol(volatilityShift));
            if (computeVolDownPrice)
                downVolPrice = pricer.Price(option, model.ShiftVol(-volatilityShift));
            #endregion

            output += Environment.NewLine;
            if (priceCheckBox.Checked)
                output += $"The price is: {String.Format("{0:0.0000}", price.Estimate)}"
                + $"+/- {String.Format("{0:0.0000}", price.Confidence)}" + Environment.NewLine;
            // "{0:E4}" for scientific format with 4 digits

            #region Compute Greeks
            PricerOutput delta = null;
            PricerOutput gamma = null;
            PricerOutput vega = null;

            if (deltaCheckBox.Checked)
            {
                double deltaEstimate, deltaConfidence;
                switch (deltaScheme)
                {
                    case Scheme.Forward:
                        deltaEstimate = (upSpotPrice.Estimate - price.Estimate) / stockPriceShift;
                        deltaConfidence = (upSpotPrice.Confidence + price.Confidence) / stockPriceShift;
                        break;
                    case Scheme.Backward:
                        deltaEstimate = (price.Estimate - downSpotPrice.Estimate) / stockPriceShift;
                        deltaConfidence = (price.Confidence + downSpotPrice.Confidence) / stockPriceShift;
                        break;
                    default: // We have ensured before that if schemes is not backward or forward, it is central.
                        deltaEstimate = (upSpotPrice.Estimate - downSpotPrice.Estimate) / (2.0 * stockPriceShift);
                        deltaConfidence = (upSpotPrice.Confidence + downSpotPrice.Confidence) / (2.0 * stockPriceShift);
                        break;
                }
                delta = new PricerOutput(deltaEstimate, deltaConfidence);
                output += $"The delta is: {String.Format("{0:0.0000}", deltaEstimate)}"
                + $"+/- {String.Format("{0:0.0000}", deltaConfidence)}" + Environment.NewLine;
            }

            if (gammaCheckBox.Checked)
            {
                double gammaEstimate = (upSpotPrice.Estimate - 2.0 * price.Estimate + downSpotPrice.Estimate)
                    / (stockPriceShift * stockPriceShift);
                double gammaConfidence = (upSpotPrice.Confidence + 2.0 * price.Confidence + downSpotPrice.Confidence)
                    / (stockPriceShift * stockPriceShift);

                gamma = new PricerOutput(gammaEstimate, gammaConfidence);
                output += $"The gamma is: {String.Format("{0:0.0000}", gammaEstimate)}"
                + $"+/- {String.Format("{0:0.0000}", gammaConfidence)}" + Environment.NewLine;
            }

            if (vegaCheckBox.Checked)
            {
                double vegaEstimate, vegaConfidence;
                switch (deltaScheme)
                {
                    case Scheme.Forward:
                        vegaEstimate = (upVolPrice.Estimate - price.Estimate) / volatilityShift;
                        vegaConfidence = (upVolPrice.Confidence + price.Confidence) / volatilityShift;
                        break;
                    case Scheme.Backward:
                        vegaEstimate = (price.Estimate - downVolPrice.Estimate) / volatilityShift;
                        vegaConfidence = (price.Confidence + downVolPrice.Confidence) / volatilityShift;
                        break;
                    default: // We have ensured before that if schemes is not backward or forward, it is central.
                        vegaEstimate = (upVolPrice.Estimate - downVolPrice.Estimate) / (2.0 * volatilityShift);
                        vegaConfidence = (upVolPrice.Confidence + downVolPrice.Confidence) / (2.0 * volatilityShift);
                        break;
                }
                vega = new PricerOutput(vegaEstimate, vegaConfidence);
                output += $"The vega is: {String.Format("{0:0.0000}", vegaEstimate)}"
                + $"+/- {String.Format("{0:0.0000}", vegaConfidence)}" + Environment.NewLine;
            }
            #endregion

            elapsed.Stop();

            output += $"Running time: {elapsed.ElapsedMilliseconds} ms.";
            // MessageBox.Show($"Hello there!");
            MessageBox.Show(output);
        }

        private void radioMC_CheckedChanged(object sender, EventArgs e)
        {
            if (radioMC.Checked)
                pathsTextBox.Enabled = true;
            else
            {
                pathsTextBox.Clear();
                pathsTextBox.Enabled = false;
            }
        }

        private void deltaCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (deltaCheckBox.Checked)
            {
                deltaSchemeComboBox.Enabled = true;
                stockPriceShiftTextBox.Enabled = true;
            }
            else
            {
                deltaSchemeComboBox.SelectedIndex = -1;
                deltaSchemeComboBox.Text = "Please select scheme";
                deltaSchemeComboBox.Enabled = false;

                if (!gammaCheckBox.Checked)
                {
                    stockPriceShiftTextBox.Clear();
                    stockPriceShiftTextBox.Enabled = false;
                }
            }
        }

        private void vegaCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (vegaCheckBox.Checked)
            {
                vegaSchemeComboBox.Enabled = true;
                volatilityShiftTextBox.Enabled = true;
            }
            else
            {
                vegaSchemeComboBox.SelectedIndex = -1;
                vegaSchemeComboBox.Text = "Please select scheme";
                vegaSchemeComboBox.Enabled = false;
                volatilityShiftTextBox.Clear();
                volatilityShiftTextBox.Enabled = false;
            }
        }

        private void gammaCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (gammaCheckBox.Checked)
                stockPriceShiftTextBox.Enabled = true;
            else if (!deltaCheckBox.Checked)
            {
                stockPriceShiftTextBox.Clear();
                stockPriceShiftTextBox.Enabled = false;
            }
        }
    }
}
