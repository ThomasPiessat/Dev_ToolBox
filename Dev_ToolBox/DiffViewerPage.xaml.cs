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
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DiffPlex.DiffBuilder;
using DiffPlex.DiffBuilder.Model;
using DiffPlex.Wpf;

namespace Dev_ToolBox
{
    /// <summary>
    /// Interaction logic for DiffViewerPage.xaml
    /// </summary>
    public partial class DiffViewerPage : Page
    {
        public DiffViewerPage()
        {
            InitializeComponent();
        }

        private void WindowButton_Click(object sender, RoutedEventArgs e)
        {
            var has = false;
            foreach (var w in Application.Current.Windows)
            {
                if (w is DiffWindow dw)
                {
                    dw.Activate();
                    has = true;
                    break;
                }
            }

            if (has) return;
            var win = new DiffWindow();
            win.OpenFileOnBoth();
            win.Show();
        }
    }
}
