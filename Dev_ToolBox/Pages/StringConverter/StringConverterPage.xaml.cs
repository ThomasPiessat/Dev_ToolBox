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

namespace Dev_ToolBox.Pages.StringConverter
{
    /// <summary>
    /// Interaction logic for StringConverterPage.xaml
    /// </summary>
    public partial class StringConverterPage : Page
    {
        private string input = string.Empty;

        public StringConverterPage()
        {
            InitializeComponent();
        }

        private void Convert_Click(object sender, RoutedEventArgs e)
        {
            input = txtInput.Text;
            //< ComboBoxItem Content = "lowercase" />
            //< ComboBoxItem Content = "UPPER CASE" />
            //< ComboBoxItem Content = "camelCase" />
            //< ComboBoxItem Content = "PascalCase" />
            //< ComboBoxItem Content = "snake_case" />
            //< ComboBoxItem Content = "kebab-case" />
            //< ComboBoxItem Content = "SCREAM-KEBAB" />
            //< ComboBoxItem Content = "CONSTANTS_CASE" />
            if (cmbStringConvert.SelectedItem != null)
            {
                switch (cmbStringConvert.SelectedIndex)
                {
                    case 0:
                        ToLowerCase();
                        break;
                    case 1:
                        ToUpperCase();
                        break;
                    case 2:
                        ToCamelCase();
                        break;
                    case 3:
                        ToPascalCase();
                        break;
                    case 4:
                        ToSnakeCase();
                        break;
                    case 5:
                        ToKebabCase();
                        break;
                    case 6:
                        ToScreamKebab();
                        break;
                    case 7:
                        ToConstantsCase();
                        break;
                    default:
                        break;
                }
            }
        }

        private void ToLowerCase()
        {
            txtOutput.Text = input.ToLower();
        }

        private void ToUpperCase()
        {
            txtOutput.Text = input.ToUpper();
        }

        private void ToCamelCase()
        {
            string[] words = input.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            string camelCase = words[0].ToLower();
            for (int i = 1; i < words.Length; i++)
            {
                camelCase += char.ToUpper(words[i][0]) + words[i].Substring(1).ToLower();
            }
            txtOutput.Text = camelCase;
        }

        private void ToPascalCase()
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            txtOutput.Text = textInfo.ToTitleCase(txtInput.Text).Replace(" ", string.Empty);
        }

        private void ToSnakeCase()
        {
            string result = input.Replace(" ", "_").ToLower();
            txtOutput.Text = result;
        }

        private void ToKebabCase()
        {
            string result = input.Replace(" ", "-").ToLower();
            txtOutput.Text = result;
        }
        private void ToScreamKebab()
        {
            string result = input.Replace(" ", "-").ToUpper();
            txtOutput.Text = result;
        }

        private void ToConstantsCase()
        {
            string result = input.Replace(" ", "_").ToUpper();
            txtOutput.Text = result;
        }
    }
}
