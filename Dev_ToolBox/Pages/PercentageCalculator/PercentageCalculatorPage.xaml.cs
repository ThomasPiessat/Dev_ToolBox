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

namespace Dev_ToolBox.Pages.PercentageCalculator
{
    /// <summary>
    /// Interaction logic for PercentageCalculatorPage.xaml
    /// </summary>
    public partial class PercentageCalculatorPage : Page
    {
        public PercentageCalculatorPage()
        {
            InitializeComponent();
        }


        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double totalValue = Convert.ToDouble(txtTotalValue.Text);
                double percentage = Convert.ToDouble(txtPercentage.Text);

                double result = (percentage / 100) * totalValue;

                txtResult.Text = $"Result: {result:F2}";
            }
            catch (FormatException)
            {
                txtResult.Text = "Invalid input. Please enter valid numbers.";
            }
        }

        private void CalculateVariationButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double firstValue = Convert.ToDouble(txtFirstValue.Text);
                double secondValue = Convert.ToDouble(txtSecondValue.Text);

                if (secondValue != 0)
                {
                    double variation = ((secondValue - firstValue) / firstValue) * 100;
                    txtVariationResult.Text = $"Variation: {variation:F2}%";
                }
                else
                {
                    txtVariationResult.Text = "Cannot calculate variation. Second value cannot be zero.";
                }
            }
            catch (FormatException)
            {
                txtVariationResult.Text = "Invalid input. Please enter valid numbers.";
            }
        }


        private void CalculateAugmentationButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double baseValue = Convert.ToDouble(txtBaseValue.Text);
                double augmentationPercentage = Convert.ToDouble(txtAugmentationPercentage.Text);

                double augmentedValue = baseValue + (augmentationPercentage / 100 * baseValue);

                txtAugmentationResult.Text = $"Augmented Value: {augmentedValue:F2}";
            }
            catch (FormatException)
            {
                txtAugmentationResult.Text = "Invalid input. Please enter valid numbers.";
            }
        }
    }
}
