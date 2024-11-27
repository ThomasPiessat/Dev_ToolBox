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
using Dev_ToolBox.Pages.StringConverter;
using Dev_ToolBox.Pages.URLParser;

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
            ListBoxItem selectedTool = lstTools.SelectedItem as ListBoxItem;

            if (selectedTool != null)
            {
                switch (selectedTool.Content.ToString())
                {
                    case "Calculator":
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
                    case "URL Parser":
                        mainFrame.Navigate(new URLParserPage());
                        break;
                        // Add cases for other tools as needed
                }
            }
        }
    }
}