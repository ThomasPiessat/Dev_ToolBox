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

namespace Dev_ToolBox.Pages.SpeedConverter
{
    /// <summary>
    /// Interaction logic for SpeedConverterPage.xaml
    /// </summary>
    public partial class SpeedConverterPage : Page
    {       
        public SpeedConverterPage()
        {
            InitializeComponent();
        }

        private void ConvertSpeedButton_Click(object sender, RoutedEventArgs e)
        {
            double inputSpeed = double.Parse(txtInputSpeed.Text);

            // Read source and target units
            string sourceUnit = ((ComboBoxItem)sourceUnitDropdown.SelectedItem)?.Content.ToString();
            string targetUnit = ((ComboBoxItem)targetUnitDropdown.SelectedItem)?.Content.ToString();

            // Convert source unit to meters per second (m/s)
            double speedInMetersPerSecond = sourceUnit switch
            {
                "Centimeters per second" => inputSpeed / 100.0,
                "Metres per second (m/s)" => inputSpeed,
                "Kilometres per hour (km/h)" => inputSpeed / 3.6,
                "Miles per hour (mph)" => inputSpeed * 0.44704,
                "Mach (M)" => inputSpeed * 343.0,
                _ => throw new NotImplementedException()
            };

            // Convert meters per second to target unit
            double convertedSpeed = targetUnit switch
            {
                "Centimeters per second" => speedInMetersPerSecond * 100.0,
                "Metres per second (m/s)" => speedInMetersPerSecond,
                "Kilometres per hour (km/h)" => speedInMetersPerSecond * 3.6,
                "Miles per hour (mph)" => speedInMetersPerSecond / 0.44704,
                "Mach (M)" => speedInMetersPerSecond / 343.0,
                _ => throw new NotImplementedException()
            };

            txtOutputSpeed.Text = $"{convertedSpeed:F3}";
        }
    }
}
