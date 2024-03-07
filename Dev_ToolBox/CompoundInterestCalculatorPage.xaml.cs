using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dev_ToolBox
{
    /// <summary>
    /// Interaction logic for CompoundInterestCalculatorPage.xaml
    /// </summary>
    public partial class CompoundInterestCalculatorPage : Page
    {
        public CompoundInterestCalculatorPage()
        {
            InitializeComponent();
        }

        private void CalculateCompoundInterestButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double principalAmount = Convert.ToDouble(txtPrincipalAmount.Text);
                double annualInterestRate = Convert.ToDouble(txtAnnualInterestRate.Text);
                double timePeriod = Convert.ToDouble(txtTimePeriod.Text);

                // Compounding frequency in a year
                int compoundingFrequency = 1; // Default to Annually
                if (cmbCompoundingFrequency.SelectedItem != null)
                {
                    switch (cmbCompoundingFrequency.SelectedIndex)
                    {
                        case 1: compoundingFrequency = 2; break; // Semi-Annually
                        case 2: compoundingFrequency = 4; break; // Quarterly
                        case 3: compoundingFrequency = 12; break; // Monthly
                    }
                }

                double compoundInterest = principalAmount * Math.Pow(1 + (annualInterestRate / (compoundingFrequency * 100)), compoundingFrequency * timePeriod) - principalAmount;

                txtCompoundInterestResult.Text = $"Compound Interest: {compoundInterest:F2}";
            }
            catch (FormatException)
            {
                txtCompoundInterestResult.Text = "Invalid input. Please enter valid numbers.";
            }
        }

        private void CalculateAllTimeRateOfReturnButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double principalAmount = Convert.ToDouble(txtPrincipalAmount.Text);
                double additionalContributions = Convert.ToDouble(txtAdditionalContributions.Text);
                double allTimeValue = principalAmount + additionalContributions;

                double allTimeRateOfReturn = (Math.Pow(allTimeValue / principalAmount, 1.0 / double.Parse(txtTimePeriod.Text)) - 1) * 100;

                txtAllTimeRateOfReturnResult.Text = $"All-time Rate of Return: {allTimeRateOfReturn:F2}%";
            }
            catch (FormatException)
            {
                txtAllTimeRateOfReturnResult.Text = "Invalid input. Please enter valid numbers.";
            }
        }
    }
}
