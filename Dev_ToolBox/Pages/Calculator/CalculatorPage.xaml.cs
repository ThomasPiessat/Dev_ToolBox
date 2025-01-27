using System;
using System.Collections.Generic;
using System.Data;
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
using Windows.ApplicationModel.Background;

namespace Dev_ToolBox.Pages.Calculator
{
    /// <summary>
    /// Interaction logic for CalculatorPage.xaml
    /// </summary>
    public partial class CalculatorPage : Page
    {
        private string currentOperator = string.Empty;
        private string calculationHistory = string.Empty;

        public CalculatorPage()
        {
            InitializeComponent();
        }

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                CalculatorDisplay.Text += button.Content.ToString();
            }
        }

        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                currentOperator = button.Content.ToString();
                calculationHistory += $"{CalculatorDisplay.Text} {currentOperator} ";
                CalculatorHistory.Text = calculationHistory;
                CalculatorDisplay.Clear();
            }
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string result = new DataTable().Compute($"{calculationHistory} {CalculatorDisplay.Text}", null).ToString();
                CalculatorDisplay.Text = result;
                calculationHistory = string.Empty;
                CalculatorHistory.Text = string.Empty;
            }
            catch
            {
                CalculatorDisplay.Text = "Error";
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            CalculatorDisplay.Clear();
            calculationHistory = string.Empty;
            CalculatorHistory.Text = string.Empty;
        }

        private void Backspace_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(CalculatorDisplay.Text))
            {
                CalculatorDisplay.Text = CalculatorDisplay.Text.Substring(0, CalculatorDisplay.Text.Length - 1);
            }
        }

        private void ToggleSign_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(CalculatorDisplay.Text, out double value))
            {
                CalculatorDisplay.Text = (-value).ToString();
            }
        }
    }
}