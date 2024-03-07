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
    }
}
