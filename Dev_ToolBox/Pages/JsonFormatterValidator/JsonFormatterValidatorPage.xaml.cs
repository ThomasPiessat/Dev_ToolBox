using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
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

namespace Dev_ToolBox.Pages.JsonFormatterValidator
{
    /// <summary>
    /// Interaction logic for JsonFormatterValidatorPage.xaml
    /// </summary>
    public partial class JsonFormatterValidatorPage : Page
    {
        public JsonFormatterValidatorPage()
        {
            InitializeComponent();
        }

        private void ValidateJsonButton_Click(object sender, RoutedEventArgs e)
        {
            string inputJson = JsonInputBox.Text;

            try
            {
                JsonDocument.Parse(inputJson);
                MessageBox.Show("JSON is valid!", "Validation Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (JsonException ex)
            {
                MessageBox.Show($"Invalid JSON: {ex.Message}", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void FormatJsonButton_Click(object sender, RoutedEventArgs e)
        {
            string inputJson = JsonInputBox.Text;

            try
            {
                var parsedJson = JsonDocument.Parse(inputJson);
                var formattedJson = JsonSerializer.Serialize(parsedJson, new JsonSerializerOptions { WriteIndented = true });

                JsonOutputBox.Text = formattedJson;
            }
            catch (JsonException ex)
            {
                JsonOutputBox.Text = $"Error: {ex.Message}";
            }
        }

        private void MinifyJsonButton_Click(object sender, RoutedEventArgs e)
        {
            string inputJson = JsonInputBox.Text;

            try
            {
                var parsedJson = JsonDocument.Parse(inputJson);
                var minifiedJson = JsonSerializer.Serialize(parsedJson);

                JsonOutputBox.Text = minifiedJson;
            }
            catch (JsonException ex)
            {
                JsonOutputBox.Text = $"Error: {ex.Message}";
            }
        }
    }
}
