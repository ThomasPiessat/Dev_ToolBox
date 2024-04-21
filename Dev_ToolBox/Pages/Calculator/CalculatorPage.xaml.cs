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
using Windows.ApplicationModel.Background;

namespace Dev_ToolBox.Pages.Calculator
{
    /// <summary>
    /// Interaction logic for CalculatorPage.xaml
    /// </summary>
    public partial class CalculatorPage : Page
    {
        private string currentInput = "";
        private double currentValue = 0;
        private string lastOperator = "";
        private bool isOperatorClicked = false;

        public CalculatorPage()
        {
            InitializeComponent();
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            string digit = (sender as Button).Content.ToString();
            currentInput += digit;
            txtDisplay.Text = currentInput;
            calcDisplay.Text = currentInput;
        }

        private void OperatorButton_Click(object sender, RoutedEventArgs e)
        {
            string operatorSymbol = (sender as Button).Content.ToString();
            if (!isOperatorClicked)
            {
                currentValue = double.Parse(currentInput);
                currentInput = "";
                lastOperator = operatorSymbol;
                isOperatorClicked = true;
                txtDisplay.Text = operatorSymbol;
                calcDisplay.Text += operatorSymbol;
            }
            else
            {
                Calculate();
                lastOperator = operatorSymbol;
            }
        }

        private void EqualButton_Click(object sender, RoutedEventArgs e)
        {
            Calculate();
            lastOperator = "";
            isOperatorClicked = false;
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            currentInput = "";
            currentValue = 0;
            lastOperator = "";
            isOperatorClicked = false;
            txtDisplay.Text = "";
            calcDisplay.Text = "";
        }

        private void Calculate()
        {
            double input = double.Parse(currentInput);
            switch (lastOperator)
            {
                case "+":
                    currentValue += input;
                    break;
                case "-":
                    currentValue -= input;
                    break;
                case "*":
                    currentValue *= input;
                    break;
                case "/":
                    if (input != 0)
                    {
                        currentValue /= input;
                    }
                    else
                    {
                        MessageBox.Show("Cannot divide by zero.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        ClearButton_Click(null, null);
                        return;
                    }
                    break;
            }
            txtDisplay.Text = currentValue.ToString();
            calcDisplay.Text = currentValue.ToString();
        }
    }
}
