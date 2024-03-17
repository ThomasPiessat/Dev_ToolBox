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
using QRCoder;

namespace Dev_ToolBox
{
    /// <summary>
    /// Interaction logic for QRCodeGeneratorPage.xaml
    /// </summary>
    public partial class QRCodeGeneratorPage : Page
    {
        public QRCodeGeneratorPage()
        {
            InitializeComponent();
        }

        private void GenerateQRCodeButton_Click(object sender, RoutedEventArgs e)
        {
            string link = txtLink.Text.Trim();
            if (!string.IsNullOrEmpty(link))
            {
                GenerateQRCode(link);
            }
            else
            {
                MessageBox.Show("Please paste a link before generating the QR code.", "QR Code Generator", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void GenerateQRCode(string link)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(link, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            System.Drawing.Bitmap qrCodeImage = qrCode.GetGraphic(20);

            // Convert to WPF BitmapSource
            imgQRCode.Source = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                qrCodeImage.GetHbitmap(),
                IntPtr.Zero,
                Int32Rect.Empty,
                System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
        }
    }
}
