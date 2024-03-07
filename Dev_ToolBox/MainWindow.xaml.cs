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
                    case "Percentage Calculator":
                        mainFrame.Navigate(new PercentageCalculatorPage());
                        break;
                    case "QR Code Generator":
                        mainFrame.Navigate(new QRCodeGeneratorPage());
                        break;
                        // Add cases for other tools as needed
                }
            }
        }
    }
}