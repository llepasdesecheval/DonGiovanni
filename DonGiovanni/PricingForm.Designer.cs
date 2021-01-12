namespace Leporello
{
    partial class PricingForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.PriceButton = new System.Windows.Forms.Button();
            this.strikeLabel = new System.Windows.Forms.Label();
            this.maturityLabel = new System.Windows.Forms.Label();
            this.optionTypeLabel = new System.Windows.Forms.Label();
            this.optionTypeComboBox = new System.Windows.Forms.ComboBox();
            this.strikeTextBox = new System.Windows.Forms.TextBox();
            this.maturityTextBox = new System.Windows.Forms.TextBox();
            this.stockPriceLabel = new System.Windows.Forms.Label();
            this.interestRateLabel = new System.Windows.Forms.Label();
            this.volatilityLabel = new System.Windows.Forms.Label();
            this.interestRateTextBox = new System.Windows.Forms.TextBox();
            this.stockPriceTextBox = new System.Windows.Forms.TextBox();
            this.volatilityTextBox = new System.Windows.Forms.TextBox();
            this.radioCF = new System.Windows.Forms.RadioButton();
            this.radioMC = new System.Windows.Forms.RadioButton();
            this.pathsLabel = new System.Windows.Forms.Label();
            this.pathsTextBox = new System.Windows.Forms.TextBox();
            this.outputLabel = new System.Windows.Forms.Label();
            this.priceCheckBox = new System.Windows.Forms.CheckBox();
            this.deltaCheckBox = new System.Windows.Forms.CheckBox();
            this.gammaCheckBox = new System.Windows.Forms.CheckBox();
            this.vegaCheckBox = new System.Windows.Forms.CheckBox();
            this.deltaSchemeLabel = new System.Windows.Forms.Label();
            this.vegaSchemeLabel = new System.Windows.Forms.Label();
            this.deltaSchemeComboBox = new System.Windows.Forms.ComboBox();
            this.vegaSchemeComboBox = new System.Windows.Forms.ComboBox();
            this.stockPriceShiftLabel = new System.Windows.Forms.Label();
            this.volatilityShiftLabel = new System.Windows.Forms.Label();
            this.stockPriceShiftTextBox = new System.Windows.Forms.TextBox();
            this.volatilityShiftTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // PriceButton
            // 
            this.PriceButton.Location = new System.Drawing.Point(713, 473);
            this.PriceButton.Name = "PriceButton";
            this.PriceButton.Size = new System.Drawing.Size(75, 50);
            this.PriceButton.TabIndex = 29;
            this.PriceButton.Text = "Price";
            this.PriceButton.UseVisualStyleBackColor = true;
            this.PriceButton.Click += new System.EventHandler(this.PriceButton_Click);
            // 
            // strikeLabel
            // 
            this.strikeLabel.AutoSize = true;
            this.strikeLabel.Location = new System.Drawing.Point(12, 20);
            this.strikeLabel.Name = "strikeLabel";
            this.strikeLabel.Size = new System.Drawing.Size(89, 20);
            this.strikeLabel.TabIndex = 0;
            this.strikeLabel.Text = "Strike Price";
            // 
            // maturityLabel
            // 
            this.maturityLabel.AutoSize = true;
            this.maturityLabel.Location = new System.Drawing.Point(251, 20);
            this.maturityLabel.Name = "maturityLabel";
            this.maturityLabel.Size = new System.Drawing.Size(65, 20);
            this.maturityLabel.TabIndex = 2;
            this.maturityLabel.Text = "Maturity";
            // 
            // optionTypeLabel
            // 
            this.optionTypeLabel.AutoSize = true;
            this.optionTypeLabel.Location = new System.Drawing.Point(491, 23);
            this.optionTypeLabel.Name = "optionTypeLabel";
            this.optionTypeLabel.Size = new System.Drawing.Size(94, 20);
            this.optionTypeLabel.TabIndex = 4;
            this.optionTypeLabel.Text = "Option Type";
            // 
            // optionTypeComboBox
            // 
            this.optionTypeComboBox.FormattingEnabled = true;
            this.optionTypeComboBox.Items.AddRange(new object[] {
            "Call",
            "Put"});
            this.optionTypeComboBox.Location = new System.Drawing.Point(619, 20);
            this.optionTypeComboBox.Name = "optionTypeComboBox";
            this.optionTypeComboBox.Size = new System.Drawing.Size(169, 28);
            this.optionTypeComboBox.TabIndex = 5;
            this.optionTypeComboBox.Text = "Please select type";
            // 
            // strikeTextBox
            // 
            this.strikeTextBox.Location = new System.Drawing.Point(126, 20);
            this.strikeTextBox.Name = "strikeTextBox";
            this.strikeTextBox.Size = new System.Drawing.Size(93, 26);
            this.strikeTextBox.TabIndex = 1;
            // 
            // maturityTextBox
            // 
            this.maturityTextBox.Location = new System.Drawing.Point(381, 20);
            this.maturityTextBox.Name = "maturityTextBox";
            this.maturityTextBox.Size = new System.Drawing.Size(93, 26);
            this.maturityTextBox.TabIndex = 3;
            // 
            // stockPriceLabel
            // 
            this.stockPriceLabel.AutoSize = true;
            this.stockPriceLabel.Location = new System.Drawing.Point(12, 84);
            this.stockPriceLabel.Name = "stockPriceLabel";
            this.stockPriceLabel.Size = new System.Drawing.Size(89, 20);
            this.stockPriceLabel.TabIndex = 6;
            this.stockPriceLabel.Text = "Stock Price";
            // 
            // interestRateLabel
            // 
            this.interestRateLabel.AutoSize = true;
            this.interestRateLabel.Location = new System.Drawing.Point(251, 84);
            this.interestRateLabel.Name = "interestRateLabel";
            this.interestRateLabel.Size = new System.Drawing.Size(124, 20);
            this.interestRateLabel.TabIndex = 8;
            this.interestRateLabel.Text = "Interest rate (%)";
            // 
            // volatilityLabel
            // 
            this.volatilityLabel.AutoSize = true;
            this.volatilityLabel.Location = new System.Drawing.Point(491, 84);
            this.volatilityLabel.Name = "volatilityLabel";
            this.volatilityLabel.Size = new System.Drawing.Size(95, 20);
            this.volatilityLabel.TabIndex = 10;
            this.volatilityLabel.Text = "Volatility (%)";
            // 
            // interestRateTextBox
            // 
            this.interestRateTextBox.Location = new System.Drawing.Point(381, 84);
            this.interestRateTextBox.Name = "interestRateTextBox";
            this.interestRateTextBox.Size = new System.Drawing.Size(93, 26);
            this.interestRateTextBox.TabIndex = 9;
            // 
            // stockPriceTextBox
            // 
            this.stockPriceTextBox.Location = new System.Drawing.Point(126, 84);
            this.stockPriceTextBox.Name = "stockPriceTextBox";
            this.stockPriceTextBox.Size = new System.Drawing.Size(93, 26);
            this.stockPriceTextBox.TabIndex = 7;
            // 
            // volatilityTextBox
            // 
            this.volatilityTextBox.Location = new System.Drawing.Point(619, 84);
            this.volatilityTextBox.Name = "volatilityTextBox";
            this.volatilityTextBox.Size = new System.Drawing.Size(104, 26);
            this.volatilityTextBox.TabIndex = 11;
            // 
            // radioCF
            // 
            this.radioCF.AutoSize = true;
            this.radioCF.Checked = true;
            this.radioCF.Location = new System.Drawing.Point(20, 151);
            this.radioCF.Name = "radioCF";
            this.radioCF.Size = new System.Drawing.Size(145, 24);
            this.radioCF.TabIndex = 12;
            this.radioCF.TabStop = true;
            this.radioCF.Text = "Closed Formula";
            this.radioCF.UseVisualStyleBackColor = true;
            // 
            // radioMC
            // 
            this.radioMC.AutoSize = true;
            this.radioMC.Location = new System.Drawing.Point(255, 151);
            this.radioMC.Name = "radioMC";
            this.radioMC.Size = new System.Drawing.Size(120, 24);
            this.radioMC.TabIndex = 13;
            this.radioMC.TabStop = true;
            this.radioMC.Text = "Monte Carlo";
            this.radioMC.UseVisualStyleBackColor = true;
            this.radioMC.CheckedChanged += new System.EventHandler(this.radioMC_CheckedChanged);
            // 
            // pathsLabel
            // 
            this.pathsLabel.AutoSize = true;
            this.pathsLabel.Location = new System.Drawing.Point(491, 153);
            this.pathsLabel.Name = "pathsLabel";
            this.pathsLabel.Size = new System.Drawing.Size(91, 20);
            this.pathsLabel.TabIndex = 14;
            this.pathsLabel.Text = "Simulations";
            // 
            // pathsTextBox
            // 
            this.pathsTextBox.Enabled = false;
            this.pathsTextBox.Location = new System.Drawing.Point(619, 150);
            this.pathsTextBox.Name = "pathsTextBox";
            this.pathsTextBox.Size = new System.Drawing.Size(104, 26);
            this.pathsTextBox.TabIndex = 15;
            // 
            // outputLabel
            // 
            this.outputLabel.AutoSize = true;
            this.outputLabel.Location = new System.Drawing.Point(24, 202);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.Size = new System.Drawing.Size(58, 20);
            this.outputLabel.TabIndex = 16;
            this.outputLabel.Text = "Output";
            // 
            // priceCheckBox
            // 
            this.priceCheckBox.AutoSize = true;
            this.priceCheckBox.Checked = true;
            this.priceCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.priceCheckBox.Location = new System.Drawing.Point(46, 237);
            this.priceCheckBox.Name = "priceCheckBox";
            this.priceCheckBox.Size = new System.Drawing.Size(70, 24);
            this.priceCheckBox.TabIndex = 17;
            this.priceCheckBox.Text = "Price";
            this.priceCheckBox.UseVisualStyleBackColor = true;
            // 
            // deltaCheckBox
            // 
            this.deltaCheckBox.AutoSize = true;
            this.deltaCheckBox.Location = new System.Drawing.Point(46, 290);
            this.deltaCheckBox.Name = "deltaCheckBox";
            this.deltaCheckBox.Size = new System.Drawing.Size(73, 24);
            this.deltaCheckBox.TabIndex = 18;
            this.deltaCheckBox.Text = "Delta";
            this.deltaCheckBox.UseVisualStyleBackColor = true;
            this.deltaCheckBox.CheckedChanged += new System.EventHandler(this.deltaCheckBox_CheckedChanged);
            // 
            // gammaCheckBox
            // 
            this.gammaCheckBox.AutoSize = true;
            this.gammaCheckBox.Location = new System.Drawing.Point(46, 340);
            this.gammaCheckBox.Name = "gammaCheckBox";
            this.gammaCheckBox.Size = new System.Drawing.Size(92, 24);
            this.gammaCheckBox.TabIndex = 23;
            this.gammaCheckBox.Text = "Gamma";
            this.gammaCheckBox.UseVisualStyleBackColor = true;
            this.gammaCheckBox.CheckedChanged += new System.EventHandler(this.gammaCheckBox_CheckedChanged);
            // 
            // vegaCheckBox
            // 
            this.vegaCheckBox.AutoSize = true;
            this.vegaCheckBox.Location = new System.Drawing.Point(46, 394);
            this.vegaCheckBox.Name = "vegaCheckBox";
            this.vegaCheckBox.Size = new System.Drawing.Size(73, 24);
            this.vegaCheckBox.TabIndex = 24;
            this.vegaCheckBox.Text = "Vega";
            this.vegaCheckBox.UseVisualStyleBackColor = true;
            this.vegaCheckBox.CheckedChanged += new System.EventHandler(this.vegaCheckBox_CheckedChanged);
            // 
            // deltaSchemeLabel
            // 
            this.deltaSchemeLabel.AutoSize = true;
            this.deltaSchemeLabel.Location = new System.Drawing.Point(491, 294);
            this.deltaSchemeLabel.Name = "deltaSchemeLabel";
            this.deltaSchemeLabel.Size = new System.Drawing.Size(68, 20);
            this.deltaSchemeLabel.TabIndex = 21;
            this.deltaSchemeLabel.Text = "Scheme";
            // 
            // vegaSchemeLabel
            // 
            this.vegaSchemeLabel.AutoSize = true;
            this.vegaSchemeLabel.Location = new System.Drawing.Point(491, 401);
            this.vegaSchemeLabel.Name = "vegaSchemeLabel";
            this.vegaSchemeLabel.Size = new System.Drawing.Size(68, 20);
            this.vegaSchemeLabel.TabIndex = 27;
            this.vegaSchemeLabel.Text = "Scheme";
            // 
            // deltaSchemeComboBox
            // 
            this.deltaSchemeComboBox.Enabled = false;
            this.deltaSchemeComboBox.FormattingEnabled = true;
            this.deltaSchemeComboBox.Items.AddRange(new object[] {
            "Forward",
            "Central",
            "Backward"});
            this.deltaSchemeComboBox.Location = new System.Drawing.Point(595, 288);
            this.deltaSchemeComboBox.Name = "deltaSchemeComboBox";
            this.deltaSchemeComboBox.Size = new System.Drawing.Size(193, 28);
            this.deltaSchemeComboBox.TabIndex = 22;
            this.deltaSchemeComboBox.Text = "Please select scheme";
            // 
            // vegaSchemeComboBox
            // 
            this.vegaSchemeComboBox.Enabled = false;
            this.vegaSchemeComboBox.FormattingEnabled = true;
            this.vegaSchemeComboBox.Items.AddRange(new object[] {
            "Forward",
            "Central",
            "Backward"});
            this.vegaSchemeComboBox.Location = new System.Drawing.Point(595, 392);
            this.vegaSchemeComboBox.Name = "vegaSchemeComboBox";
            this.vegaSchemeComboBox.Size = new System.Drawing.Size(193, 28);
            this.vegaSchemeComboBox.TabIndex = 28;
            this.vegaSchemeComboBox.Text = "Please select scheme";
            // 
            // stockPriceShiftLabel
            // 
            this.stockPriceShiftLabel.AutoSize = true;
            this.stockPriceShiftLabel.Location = new System.Drawing.Point(251, 294);
            this.stockPriceShiftLabel.Name = "stockPriceShiftLabel";
            this.stockPriceShiftLabel.Size = new System.Drawing.Size(42, 20);
            this.stockPriceShiftLabel.TabIndex = 19;
            this.stockPriceShiftLabel.Text = "Shift";
            // 
            // volatilityShiftLabel
            // 
            this.volatilityShiftLabel.AutoSize = true;
            this.volatilityShiftLabel.Location = new System.Drawing.Point(251, 395);
            this.volatilityShiftLabel.Name = "volatilityShiftLabel";
            this.volatilityShiftLabel.Size = new System.Drawing.Size(70, 20);
            this.volatilityShiftLabel.TabIndex = 25;
            this.volatilityShiftLabel.Text = "Shift (%)";
            // 
            // stockPriceShiftTextBox
            // 
            this.stockPriceShiftTextBox.Enabled = false;
            this.stockPriceShiftTextBox.Location = new System.Drawing.Point(349, 291);
            this.stockPriceShiftTextBox.Name = "stockPriceShiftTextBox";
            this.stockPriceShiftTextBox.Size = new System.Drawing.Size(100, 26);
            this.stockPriceShiftTextBox.TabIndex = 20;
            // 
            // volatilityShiftTextBox
            // 
            this.volatilityShiftTextBox.Enabled = false;
            this.volatilityShiftTextBox.Location = new System.Drawing.Point(349, 392);
            this.volatilityShiftTextBox.Name = "volatilityShiftTextBox";
            this.volatilityShiftTextBox.Size = new System.Drawing.Size(100, 26);
            this.volatilityShiftTextBox.TabIndex = 26;
            // 
            // PricingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 535);
            this.Controls.Add(this.volatilityShiftTextBox);
            this.Controls.Add(this.stockPriceShiftTextBox);
            this.Controls.Add(this.volatilityShiftLabel);
            this.Controls.Add(this.stockPriceShiftLabel);
            this.Controls.Add(this.vegaSchemeComboBox);
            this.Controls.Add(this.deltaSchemeComboBox);
            this.Controls.Add(this.vegaSchemeLabel);
            this.Controls.Add(this.deltaSchemeLabel);
            this.Controls.Add(this.vegaCheckBox);
            this.Controls.Add(this.gammaCheckBox);
            this.Controls.Add(this.deltaCheckBox);
            this.Controls.Add(this.priceCheckBox);
            this.Controls.Add(this.outputLabel);
            this.Controls.Add(this.pathsTextBox);
            this.Controls.Add(this.pathsLabel);
            this.Controls.Add(this.radioMC);
            this.Controls.Add(this.radioCF);
            this.Controls.Add(this.volatilityTextBox);
            this.Controls.Add(this.interestRateTextBox);
            this.Controls.Add(this.stockPriceTextBox);
            this.Controls.Add(this.volatilityLabel);
            this.Controls.Add(this.interestRateLabel);
            this.Controls.Add(this.stockPriceLabel);
            this.Controls.Add(this.maturityTextBox);
            this.Controls.Add(this.strikeTextBox);
            this.Controls.Add(this.optionTypeComboBox);
            this.Controls.Add(this.optionTypeLabel);
            this.Controls.Add(this.maturityLabel);
            this.Controls.Add(this.strikeLabel);
            this.Controls.Add(this.PriceButton);
            this.Name = "PricingForm";
            this.Text = "Pricing";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button PriceButton;
        private System.Windows.Forms.Label strikeLabel;
        private System.Windows.Forms.Label maturityLabel;
        private System.Windows.Forms.Label optionTypeLabel;
        private System.Windows.Forms.ComboBox optionTypeComboBox;
        private System.Windows.Forms.TextBox strikeTextBox;
        private System.Windows.Forms.TextBox maturityTextBox;
        private System.Windows.Forms.Label stockPriceLabel;
        private System.Windows.Forms.Label interestRateLabel;
        private System.Windows.Forms.Label volatilityLabel;
        private System.Windows.Forms.TextBox interestRateTextBox;
        private System.Windows.Forms.TextBox stockPriceTextBox;
        private System.Windows.Forms.TextBox volatilityTextBox;
        private System.Windows.Forms.RadioButton radioCF;
        private System.Windows.Forms.RadioButton radioMC;
        private System.Windows.Forms.Label pathsLabel;
        private System.Windows.Forms.TextBox pathsTextBox;
        private System.Windows.Forms.Label outputLabel;
        private System.Windows.Forms.CheckBox priceCheckBox;
        private System.Windows.Forms.CheckBox deltaCheckBox;
        private System.Windows.Forms.CheckBox gammaCheckBox;
        private System.Windows.Forms.CheckBox vegaCheckBox;
        private System.Windows.Forms.Label deltaSchemeLabel;
        private System.Windows.Forms.Label vegaSchemeLabel;
        private System.Windows.Forms.ComboBox deltaSchemeComboBox;
        private System.Windows.Forms.ComboBox vegaSchemeComboBox;
        private System.Windows.Forms.Label stockPriceShiftLabel;
        private System.Windows.Forms.Label volatilityShiftLabel;
        private System.Windows.Forms.TextBox stockPriceShiftTextBox;
        private System.Windows.Forms.TextBox volatilityShiftTextBox;
    }
}

