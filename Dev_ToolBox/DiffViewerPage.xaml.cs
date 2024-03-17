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
using DiffPlex;
using DiffPlex.DiffBuilder;
using DiffPlex.DiffBuilder.Model;

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
            string InputText = txtInput.Text;
            string OutputText = txtOutput.Text;

            SideBySideDiffModel diffModel = GenerateDiff(InputText, OutputText);

            //Display the differences
            DisplayDiff(diffModel);
        }

        private SideBySideDiffModel GenerateDiff(string inputText, string outputText)
        {
            var differ = new Differ();
            var builder = new SideBySideDiffBuilder(differ);
            var diffModel = builder.BuildDiffModel(inputText, outputText);

            return diffModel;
        }

        private void DisplayDiff(SideBySideDiffModel diffModel)
        {
            txtInput.Clear();
            txtOutput.Clear();

            foreach (var line in diffModel.OldText.Lines)
            {
                //    if(line.Type == ChangeType.Deleted)
                //    {
                //        txtInput.AppendText(line.Text + "\r\n");
                //        txtInput.Background = System.Windows.Media.Brushes.LightSalmon;
                //    }
                //    txtInput.AppendText(line.Text + "\r\n");
                //}

                //foreach(var line in diffModel.NewText.Lines)
                //{
                //    if( line.Type == ChangeType.Inserted) 
                //    {
                //        txtOutput.AppendText(line.Text + "\r\n");
                //        txtOutput.Background = System.Windows.Media.Brushes.LightGreen;
                //    }
                //    txtOutput.AppendText(line.Text + "\r\n");
                //}
                if (line.Type == ChangeType.Deleted)
                {
                    txtInput.AppendText(line.Text + "\r\n");
                    txtInput.Background = System.Windows.Media.Brushes.LightSalmon;
                }
                else if (line.Type == ChangeType.Inserted)
                {
                    txtOutput.AppendText(line.Text + "\r\n");
                    txtOutput.Background = System.Windows.Media.Brushes.LightGreen;
                }
                else
                {
                    txtInput.AppendText(line.Text + "\r\n");
                    txtOutput.AppendText(line.Text + "\r\n");
                }

            }
        }
    }
}
