using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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

namespace Dev_ToolBox.Pages.DuplicateFileFinder
{
    /// <summary>
    /// Interaction logic for URLParserPage.xaml
    /// </summary>
    public partial class DuplicateFileFinderPage : Page
    {

        public DuplicateFileFinderPage()
        {
            InitializeComponent();
        }

        private void BrowseDirectory_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DirectoryPathInput.Text = dialog.SelectedPath;
            }
        }

        private void StartScan_Click(object sender, RoutedEventArgs e)
        {
            string directoryPath = DirectoryPathInput.Text;

            if (string.IsNullOrWhiteSpace(directoryPath) || !Directory.Exists(directoryPath))
            {
                MessageBox.Show("Please enter a valid directory path.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Find duplicates
            try
            {
                ResultsList.Items.Clear();
                var duplicates = FindDuplicateFiles(directoryPath);

                if (duplicates.Count == 0)
                {
                    ResultsList.Items.Add("No duplicate files found.");
                }
                else
                {
                    foreach (var group in duplicates)
                    {
                        ResultsList.Items.Add($"Duplicates for: {group.First()}");
                        foreach (var file in group.Skip(1))
                        {
                            ResultsList.Items.Add($"  - {file}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during the scan: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private List<List<string>> FindDuplicateFiles(string directoryPath)
        {
            var fileHashes = new Dictionary<string, List<string>>();

            // Get all files in directory and subdirectories
            var files = Directory.GetFiles(directoryPath, "*.*", SearchOption.AllDirectories);

            foreach (var file in files)
            {
                try
                {
                    // Compute file hash
                    string hash = ComputeFileHash(file);

                    // Group files by hash
                    if (!fileHashes.ContainsKey(hash))
                        fileHashes[hash] = new List<string>();

                    fileHashes[hash].Add(file);
                }
                catch
                {
                    // Skip files that can't be read
                }
            }

            // Return groups of duplicates
            return fileHashes.Values.Where(group => group.Count > 1).ToList();
        }

        private string ComputeFileHash(string filePath)
        {
            using (var sha256 = SHA256.Create())
            using (var stream = File.OpenRead(filePath))
            {
                var hash = sha256.ComputeHash(stream);
                return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
            }
        }
    }
}