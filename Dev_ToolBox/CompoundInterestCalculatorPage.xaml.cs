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
                double annualInterestRate = Convert.ToDouble(txtAnnualInterestRate.Text) / 100;
                double timePeriod = Convert.ToDouble(txtTimePeriod.Text);

                // Compounding frequency in a year
                int compoundingFrequency = 1; // Default to Annually
                if (cmbCompoundingFrequency.SelectedItem != null)
                {
                    switch (cmbCompoundingFrequency.SelectedIndex)
                    {
                        case 1: compoundingFrequency = 2; // Semi-Annually
                            break; 
                        case 2: compoundingFrequency = 4; // Quarterly
                            break; 
                        case 3: compoundingFrequency = 12; // Monthly
                            break; 
                    }
                }

                // Calculate compound interest on principal amount
                double compoundInterest = principalAmount * Math.Pow(1 + annualInterestRate / compoundingFrequency, compoundingFrequency * timePeriod);

                // Calculate additional contributions
                double additionalContributions = Convert.ToDouble(txtAdditionalContributions.Text);
                double additionalCompoundInterest = additionalContributions * ((Math.Pow(1 + annualInterestRate / compoundingFrequency, compoundingFrequency * timePeriod) - 1) / (annualInterestRate / compoundingFrequency));

                // Total amount after compound interest with additional contributions
                double totalAmount = compoundInterest + additionalCompoundInterest;

                // Total Additional deposits
                double totalAdditionalDeposits = compoundingFrequency * timePeriod * additionalContributions;

                // Total interest earned
                double totalInterestEarned = totalAmount - totalAdditionalDeposits - principalAmount; 

                // Total percentage return
                double timeWeightedReturn = ((principalAmount * Math.Pow(1 + annualInterestRate / compoundingFrequency, compoundingFrequency * timePeriod) - principalAmount) / 1000) * 100;
             
                txtTotalAmountResult.Text = $"Total Amount: {totalAmount:C2}";
                txtTotalInterestEarnedResult.Text = $"Total Interest Earned: {totalInterestEarned:C2}";
                txtTotalAdditionalDepositsResult.Text = $"Total Additional Deposits: {totalAdditionalDeposits:C2}";
                txtInitialBalance.Text = $"Initial Balance: {principalAmount:C2}";
                txtAllTimeRateOfReturnResult.Text = $"All-time Rate of Return: {timeWeightedReturn:F2}%";

            }
            catch (FormatException)
            {
                txtTotalAmountResult.Text = "Invalid input. Please enter valid numbers.";
            }
        }
    }
}
