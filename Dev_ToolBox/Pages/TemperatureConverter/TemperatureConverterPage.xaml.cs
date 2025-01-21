using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Dev_ToolBox.Pages.TemperatureConverter
{
    /// <summary>
    /// Interaction logic for TemperatureConverterPage.xaml
    /// </summary>
    public partial class TemperatureConverterPage : Page
    {       
        public TemperatureConverterPage()
        {
            InitializeComponent();
        }

        private void ConvertTemperatureButton_Click(object sender, RoutedEventArgs e)
        {
            double inputTemperature = double.Parse(txtInputTemperature.Text);

            // Read source and target units
            string sourceUnit = ((ComboBoxItem)sourceUnitDropdown.SelectedItem)?.Content.ToString();
            string targetUnit = ((ComboBoxItem)targetUnitDropdown.SelectedItem)?.Content.ToString();


            if (sourceUnit == "Celsius" && targetUnit == "Fahrenheit")
                txtOutputTemperature.Text = CelsiusToFahrenheit(inputTemperature).ToString();
            else if (sourceUnit == "Celsius" && targetUnit == "Kelvin")
                txtOutputTemperature.Text = CelsiusToKelvin(inputTemperature).ToString();
            else if (sourceUnit == "Fahrenheit" && targetUnit == "Celsius")
                txtOutputTemperature.Text = FahrenheitToCelsius(inputTemperature).ToString();
            else if (sourceUnit == "Fahrenheit" && targetUnit == "Kelvin")
                txtOutputTemperature.Text = FahrenheitToKelvin(inputTemperature).ToString();
            else if (sourceUnit == "Kelvin" && targetUnit == "Celsius")
                txtOutputTemperature.Text = KelvinToCelsius(inputTemperature).ToString();
            else if (sourceUnit == "Kelvin" && targetUnit == "Fahrenheit")
                txtOutputTemperature.Text = KelvinToFahrenheit(inputTemperature).ToString();
            else if (sourceUnit == targetUnit)
                txtOutputTemperature.Text = inputTemperature.ToString();           
        }

        // Convert Celsius to Fahrenheit
        public static double CelsiusToFahrenheit(double celsius)
        {
            return (celsius * 9 / 5) + 32;
        }

        // Convert Celsius to Kelvin
        public static double CelsiusToKelvin(double celsius)
        {
            return celsius + 273.15;
        }

        // Convert Fahrenheit to Celsius
        public static double FahrenheitToCelsius(double fahrenheit)
        {
            return (fahrenheit - 32) * 5 / 9;
        }

        // Convert Fahrenheit to Kelvin
        public static double FahrenheitToKelvin(double fahrenheit)
        {
            return (fahrenheit - 32) * 5 / 9 + 273.15;
        }

        // Convert Kelvin to Celsius
        public static double KelvinToCelsius(double kelvin)
        {
            return kelvin - 273.15;
        }

        // Convert Kelvin to Fahrenheit
        public static double KelvinToFahrenheit(double kelvin)
        {
            return (kelvin - 273.15) * 9 / 5 + 32;
        }
    }
}
