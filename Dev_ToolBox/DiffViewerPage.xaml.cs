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

        private void CompareButton_Click(object sender, RoutedEventArgs e)
        {
            string leftText = txtLeftText.Text;
            string rightText = txtRightText.Text;

            string[] leftLines = leftText.Split('\n');
            string[] rightLines = rightText.Split('\n');

            StringBuilder diffResult = new StringBuilder();

            int minLength = Math.Min(leftLines.Length, rightLines.Length);

            for (int i = 0; i < minLength; i++)
            {
                if (leftLines[i] != rightLines[i])
                {
                    diffResult.AppendLine($"Line {i + 1}:");
                    diffResult.AppendLine($"- {leftLines[i].Trim()}");
                    diffResult.AppendLine($"+ {rightLines[i].Trim()}");
                }
            }

            txtDiffResult.Text = diffResult.ToString();
        }
    }
}
