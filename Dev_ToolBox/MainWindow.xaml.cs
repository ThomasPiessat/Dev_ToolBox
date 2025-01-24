using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Dev_ToolBox.Pages.Calculator;
using Dev_ToolBox.Pages.PercentageCalculator;
using Dev_ToolBox.Pages.RegexChecker;
using Dev_ToolBox.Pages.StringConverter;
using Dev_ToolBox.Pages.SortDedupeLine;
using Dev_ToolBox.Pages.TimeConverter;
using Dev_ToolBox.Pages.URLParser;
using Dev_ToolBox.Pages.ColorConverter;
using Dev_ToolBox.Pages.TemperatureConverter;
using Dev_ToolBox.Pages.SpeedConverter;
using Dev_ToolBox.Pages.JsonFormatterValidator;
using Dev_ToolBox.Pages.DuplicateFileFinder;
using Dev_ToolBox.Pages.PasswordGenerator;

namespace Dev_ToolBox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ToolSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem? selectedTool = lstTools.SelectedItem as ListBoxItem;

            if (selectedTool != null)
            {
                switch (selectedTool.Content.ToString())
                {
                    case "Simple":
                        mainFrame.Navigate(new CalculatorPage());
                        break;
                    case "Compound Interest Calculator":
                        mainFrame.Navigate(new CompoundInterestCalculatorPage());
                        break;
                    case "Percentage Calculator":
                        mainFrame.Navigate(new PercentageCalculatorPage());
                        break;
                    case "Diff Viewer":
                        mainFrame.Navigate(new DiffViewerPage());
                        break;
                    case "QR Code Generator":
                        mainFrame.Navigate(new QRCodeGeneratorPage());
                        break;
                    case "String Converter":
                        mainFrame.Navigate(new StringConverterPage());
                        break;                    
                    case "Sort Dedupe Line":
                        mainFrame.Navigate(new SortDedupeLinePage());
                        break;                    
                    case "Time Converter":
                        mainFrame.Navigate(new TimeConverterPage());
                        break;
                    case "Temperature Converter":
                        mainFrame.Navigate(new TemperatureConverterPage());
                        break;
                    case "Speed Converter":
                        mainFrame.Navigate(new SpeedConverterPage());
                        break;
                    case "Color Converter":
                        mainFrame.Navigate(new ColorConverterPage());
                        break;
                    case "Regex Checker":
                        mainFrame.Navigate(new RegexCheckerPage());
                        break;
                    case "JSON Formatter Validator":
                        mainFrame.Navigate(new JsonFormatterValidatorPage());
                        break;
                    case "URL Parser":
                        mainFrame.Navigate(new URLParserPage());
                        break;                    
                    case "Duplicate file finder":
                        mainFrame.Navigate(new DuplicateFileFinderPage());
                        break;                    
                    case "Password Generator":
                        mainFrame.Navigate(new PasswordGeneratorPage());
                        break;
                        // Add cases for other tools as needed
                }
            }
        }

        private void OpenSettings_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}