using System;
using System.Collections.Generic;
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

namespace Dev_ToolBox.Pages.SortDedupeLine
{
    /// <summary>
    /// Interaction logic for PercentageCalculatorPage.xaml
    /// </summary>
    public partial class SortDedupeLinePage : Page
    {
        public SortDedupeLinePage()
        {
            InitializeComponent();
        }

        private void ProcessButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(InputTextBox.Text))
            {
                MessageBox.Show("Please enter text to process.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string inputText = InputTextBox.Text.Trim();

            // Detect delimiter: comma (,) or newline (\n)
            bool isCommaSeparated = inputText.Contains(",");

            List<string> lines;

            if (isCommaSeparated)
            {
                // Split using commas and trim spaces
                lines = inputText.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                 .Select(s => s.Trim())
                                 .ToList();
            }
            else
            {
                // Split using new lines
                lines = inputText.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                                 .Select(s => s.Trim())
                                 .ToList();
            }

            // Remove duplicates if checkbox is checked
            if (DedupeCheckBox.IsChecked == true)
            {
                lines = lines.Distinct().ToList();
            }

            // Determine sorting method
            string selectedSort = ((ComboBoxItem)SortTypeComboBox.SelectedItem).Content.ToString();
            switch (selectedSort)
            {
                case "A → Z (Alphabetical)":
                    lines = lines.OrderBy(line => line).ToList();
                    break;

                case "Z → A (Reverse Alphabetical)":
                    lines = lines.OrderByDescending(line => line).ToList();
                    break;

                case "Ascending Numbers (1 → 9)":
                    lines = lines.OrderBy(line => ExtractNumber(line)).ToList();
                    break;

                case "Descending Numbers (9 → 1)":
                    lines = lines.OrderByDescending(line => ExtractNumber(line)).ToList();
                    break;
            }

            // Join output based on the detected delimiter
            OutputTextBox.Text = isCommaSeparated
                ? string.Join(", ", lines)  // Preserve comma-separated format
                : string.Join(Environment.NewLine, lines); // Preserve line-separated format
        }

        private void CopyButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(OutputTextBox.Text))
            {
                Clipboard.SetText(OutputTextBox.Text);
                MessageBox.Show("Copied to clipboard!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private int ExtractNumber(string input)
        {
            // Extract the first number found in the string
            Match match = Regex.Match(input, @"\d+");
            return match.Success ? int.Parse(match.Value) : int.MaxValue;
        }
    }
}
