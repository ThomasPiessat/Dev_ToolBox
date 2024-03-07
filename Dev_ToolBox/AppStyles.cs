using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Dev_ToolBox
{
    public static class AppStyles
    {
        public static SolidColorBrush SidebarBackgroundColor { get; } = new SolidColorBrush(Color.FromRgb(44, 62, 80));
        public static SolidColorBrush ButtonForegroundColor { get; } = Brushes.White;
        // Add more style properties as needed
    }
}
