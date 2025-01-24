using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dev_ToolBox.Pages.PasswordGenerator
{
    /// <summary>
    /// Interaction logic for PasswordGeneratorPage.xaml
    /// </summary>
    public partial class PasswordGeneratorPage : Page
    {
        public PasswordGeneratorPage()
        {
            InitializeComponent();
        }

        private void GeneratePassword_Click(object sender, RoutedEventArgs e)
        {
            int length = (int)LengthSlider.Value;
            bool includeUppercase = IncludeUppercase.IsChecked ?? false;
            bool includeLowercase = IncludeLowercase.IsChecked ?? false;
            bool includeNumbers = IncludeNumbers.IsChecked ?? false;
            bool includeSpecial = IncludeSpecial.IsChecked ?? false;

            // Validate options
            if (!includeUppercase && !includeLowercase && !includeNumbers && !includeSpecial)
            {
                MessageBox.Show("Please select at least one character type.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Generate password
            string password = GeneratePassword(length, includeUppercase, includeLowercase, includeNumbers, includeSpecial);
            GeneratedPassword.Text = password;
        }

        private string GeneratePassword(int length, bool includeUppercase, bool includeLowercase, bool includeNumbers, bool includeSpecial)
        {
            const string uppercaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string lowercaseChars = "abcdefghijklmnopqrstuvwxyz";
            const string numberChars = "0123456789";
            const string specialChars = "!@#$%^&*()-_=+[]{}|;:'\",.<>?/";

            StringBuilder characterPool = new StringBuilder();

            if (includeUppercase) characterPool.Append(uppercaseChars);
            if (includeLowercase) characterPool.Append(lowercaseChars);
            if (includeNumbers) characterPool.Append(numberChars);
            if (includeSpecial) characterPool.Append(specialChars);

            if (characterPool.Length == 0) throw new ArgumentException("Character pool is empty.");

            Random random = new Random();
            return new string(Enumerable.Repeat(characterPool.ToString(), length)
                                        .Select(s => s[random.Next(s.Length)])
                                        .ToArray());
        }
    }
}