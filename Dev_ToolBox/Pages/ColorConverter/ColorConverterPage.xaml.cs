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

namespace Dev_ToolBox.Pages.ColorConverter
{
    /// <summary>
    /// Interaction logic for ColorConverterPage.xaml
    /// </summary>
    public partial class ColorConverterPage : Page
    {
        public ColorConverterPage()
        {
            InitializeComponent();
        }

        private void ConvertColorButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Clear any previous error message
                ErrorInput.Text = string.Empty;
                ErrorInput.Visibility = Visibility.Collapsed;

                // Clear the output preview and result message
                ColorPreview.Background = null;

                // Determine which input is provided and process accordingly
                if (!string.IsNullOrWhiteSpace(RgbInput.Text))
                {
                    // Convert from RGB
                    string[] rgbParts = RgbInput.Text.Split(',');
                    if (rgbParts.Length != 3 || !IsValidRGB(rgbParts))
                        throw new ArgumentException("Invalid RGB format. Use 'R,G,B' format.");

                    byte r = byte.Parse(rgbParts[0]);
                    byte g = byte.Parse(rgbParts[1]);
                    byte b = byte.Parse(rgbParts[2]);

                    // Convert to RGBA
                    string rgba = $"{r}, {g}, {b}, {(byte)255}";
                    RgbaInput.Text = rgba;

                    // Convert to HEX
                    string hex = $"#{r:X2}{g:X2}{b:X2}";
                    HexInput.Text = hex;

                    // Update the preview
                    ColorPreview.Background = new SolidColorBrush(Color.FromRgb(r, g, b));
                }
                else if (!string.IsNullOrWhiteSpace(RgbaInput.Text))
                {
                    // Convert from RGBA
                    string[] rgbaParts = RgbaInput.Text.Split(',');
                    if (rgbaParts.Length != 4 || !IsValidRGBA(rgbaParts))
                        throw new ArgumentException("Invalid RGBA format. Use 'R,G,B,A' format.");

                    byte r = byte.Parse(rgbaParts[0]);
                    byte g = byte.Parse(rgbaParts[1]);
                    byte b = byte.Parse(rgbaParts[2]);
                    byte a = byte.Parse(rgbaParts[3]);

                    // Convert to RGB
                    string rgb = $"{r}, {g}, {b}";
                    RgbInput.Text = rgb;

                    // Convert to HEX
                    string hex = $"#{r:X2}{g:X2}{b:X2}";
                    HexInput.Text = hex;

                    // Update the preview
                    ColorPreview.Background = new SolidColorBrush(Color.FromArgb(a, r, g, b));
                }
                else if (!string.IsNullOrWhiteSpace(HexInput.Text))
                {
                    // Convert from HEX
                    string hex = HexInput.Text.Trim('#');
                    if (!IsValidHex(hex))
                        throw new ArgumentException("Invalid HEX format. Use '#RRGGBB' or '#RRGGBBAA' format.");

                    byte r = Convert.ToByte(hex.Substring(0, 2), 16);
                    byte g = Convert.ToByte(hex.Substring(2, 2), 16);
                    byte b = Convert.ToByte(hex.Substring(4, 2), 16);
                    byte a = hex.Length == 8 ? Convert.ToByte(hex.Substring(6, 2), 16) : (byte)255;

                    // Convert to RGB
                    string rgb = $"{r}, {g}, {b}";
                    RgbInput.Text = rgb;

                    // Convert to RGBA
                    string rgba = $"{r}, {g}, {b}, {(byte)255}";
                    RgbaInput.Text = rgba;

                    // Update the preview
                    ColorPreview.Background = new SolidColorBrush(Color.FromArgb(a, r, g, b));
                }
                else
                {
                    throw new ArgumentException("Please provide a valid input in one of the fields.");
                }
            }
            catch (FormatException)
            {
                ErrorInput.Text = "Invalid color format. Please check your input.";
                ErrorInput.Visibility = Visibility.Visible;
            }
            catch (ArgumentException ex)
            {
                ErrorInput.Text = ex.Message;
                ErrorInput.Visibility = Visibility.Visible;
            }
            catch (Exception)
            {
                ErrorInput.Text = "An unexpected error occurred. Please try again.";
                ErrorInput.Visibility = Visibility.Visible;
            }
        }

        // Helper methods for validation
        private bool IsValidRGB(string[] rgbParts)
        {
            return rgbParts.All(part => byte.TryParse(part, out var value) && value >= 0 && value <= 255);
        }

        private bool IsValidRGBA(string[] rgbaParts)
        {
            return rgbaParts.All(part => byte.TryParse(part, out var value) && value >= 0 && value <= 255);
        }

        private bool IsValidHex(string hex)
        {
            return (hex.Length == 6 || hex.Length == 8) && int.TryParse(hex, System.Globalization.NumberStyles.HexNumber, null, out _);
        }

    }
}
