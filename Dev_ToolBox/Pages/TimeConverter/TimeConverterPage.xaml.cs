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

namespace Dev_ToolBox.Pages.TimeConverter
{
    /// <summary>
    /// Interaction logic for TimeConverterPage.xaml
    /// </summary>
    public partial class TimeConverterPage : Page
    {
        private string input = string.Empty;

        public TimeConverterPage()
        {
            InitializeComponent();
        }

        private void BtnConvert_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txtInputTime.Text, out double inputTime) &&
                cmbInputUnit.SelectedItem is ComboBoxItem inputUnit &&
                cmbOutputUnit.SelectedItem is ComboBoxItem outputUnit)
            {
                string inputUnitText = inputUnit.Content.ToString();
                string outputUnitText = outputUnit.Content.ToString();

                double inputInSeconds = ConvertToSeconds(inputTime, inputUnitText);
                double result = ConvertFromSeconds(inputInSeconds, outputUnitText);

                txtConvertedTime.Text = $"{inputTime} {inputUnitText} = {result:F2} {outputUnitText}";
            }
            else
            {
                MessageBox.Show("Please enter a valid time value and select units.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private double ConvertToSeconds(double time, string unit)
        {
            return unit switch
            {
                "Seconds" => time,
                "Minutes" => time * 60,
                "Hours" => time * 3600,
                "Days" => time * 86400,
                "Weeks" => time * 604800,
                _ => throw new ArgumentException("Invalid input unit"),
            };
        }

        private double ConvertFromSeconds(double timeInSeconds, string unit)
        {
            return unit switch
            {
                "Seconds" => timeInSeconds,
                "Minutes" => timeInSeconds / 60,
                "Hours" => timeInSeconds / 3600,
                "Days" => timeInSeconds / 86400,
                "Weeks" => timeInSeconds / 604800,
                _ => throw new ArgumentException("Invalid output unit"),
            };
        }
    }
}
