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

namespace Dev_ToolBox.Pages.URLParser
{
    /// <summary>
    /// Interaction logic for URLParserPage.xaml
    /// </summary>
    public partial class URLParserPage : Page
    {

        public URLParserPage()
        {
            InitializeComponent();
        }
        private void BtnParseUrl_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string url = txtUrlInput.Text;
                var uri = new Uri(url);

                txtScheme.Text = uri.Scheme;
                txtHost.Text = uri.Host;
                txtPort.Text = uri.IsDefaultPort ? "Default" : uri.Port.ToString();
                txtPath.Text = uri.AbsolutePath;
                txtQuery.Text = HttpUtility.UrlDecode(uri.Query.TrimStart('?'));
                txtFragment.Text = uri.Fragment.TrimStart('#');
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Invalid URL. Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
