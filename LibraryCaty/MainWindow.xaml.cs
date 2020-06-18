using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.IO;
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

namespace LibraryCaty
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void BPMButton_Click(object sender, RoutedEventArgs e)
        {
            string path = "V:/IanPRTZMusicLibary/EDM";

            if (Directory.Exists(path))
            {
                Methods.BPMCaty(path, lcStatus);
            }
        }

        private void NewSongsButton_Click(object sender, RoutedEventArgs e)
        {
            string path = "V:/IanPRTZMusicLibary/NewDownloads";

            if (Directory.Exists(path))
            {
                Methods.NewSongsCaty(path, lcStatus);
            }
        }
    }
}
