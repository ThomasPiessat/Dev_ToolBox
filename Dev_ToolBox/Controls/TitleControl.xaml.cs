using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Dev_ToolBox.Controls
{
    /// <summary>
    /// Interaction logic for TitleControl.xaml
    /// </summary>
    public partial class TitleControl : UserControl
    {
        public string ToolName
        {
            get { return txtTitle.Text; }
            set { txtTitle.Text = value; }
        }

        public TitleControl()
        {
            InitializeComponent();
        }
    }
}