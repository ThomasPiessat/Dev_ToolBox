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

namespace Dev_ToolBox.Pages.RegexChecker
{
    /// <summary>
    /// Interaction logic for RegexCheckerPage.xaml
    /// </summary>
    public partial class RegexCheckerPage : Page
    {
        public RegexCheckerPage()
        {
            InitializeComponent();
        }

        private void BtnCheckRegex_Click(object sender, RoutedEventArgs e)
        {
            lstMatches.Items.Clear(); // Clear previous results

            string regexPattern = txtRegex.Text;
            string testString = txtTestString.Text;

            try
            {
                var regex = new Regex(regexPattern);
                var matches = regex.Matches(testString);

                if (matches.Count > 0)
                {
                    foreach (Match match in matches)
                    {
                        lstMatches.Items.Add($"Match: {match.Value} (Index: {match.Index})");
                    }
                }
                else
                {
                    lstMatches.Items.Add("No matches found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Invalid regex pattern. Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
