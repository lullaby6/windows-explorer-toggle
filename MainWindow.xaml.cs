using System;
using System.Diagnostics;
using System.IO;
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

namespace Windows_Explorer_Toggle
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static class Globals
        {
            public static TextBlock toggleBTNtext = new TextBlock();
        }
        public MainWindow()
        {
            InitializeComponent();


            Grid mainGrid = new Grid();

            this.Content = mainGrid;

            Button toggleBTN = new Button();
            toggleBTN.Width = 175;
            toggleBTN.Height = 23;
            toggleBTN.Margin = new Thickness(0, -30, 0, 0);
            toggleBTN.Click += toggleBTNclick;
            WrapPanel toggleBTNwrap = new WrapPanel();
            Globals.toggleBTNtext.Text = "Disable Windows Explorer";
            toggleBTNwrap.Children.Add(Globals.toggleBTNtext);
            toggleBTN.Content = toggleBTNwrap;

            Button openBTN = new Button();
            openBTN.Width = 175;
            openBTN.Height = 23;
            openBTN.Margin = new Thickness(0, 20, 0, 0);
            openBTN.Click += openBTNclick;
            WrapPanel openBTNwrap = new WrapPanel();
            TextBlock openBTNtext = new TextBlock();
            openBTNtext.Text = "Open Folder";
            openBTNwrap.Children.Add(openBTNtext);
            openBTN.Content = openBTNwrap;

            mainGrid.Children.Add(toggleBTN);
            mainGrid.Children.Add(openBTN);

        }
        private void openBTNclick(object sender, RoutedEventArgs e)
        {
            Process.Start(Directory.GetCurrentDirectory());
        }

        private void toggleBTNclick(object sender, RoutedEventArgs e)
        {
            if (Globals.toggleBTNtext.Text == "Disable Windows Explorer")
            {
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/c TASKKILL /F /IM explorer.exe";
                process.StartInfo = startInfo;
                process.Start();
                Globals.toggleBTNtext.Text = "Enable Windows Explorer";
            }
            else{
                Process.Start(@"C:\Windows\explorer.exe");
                Globals.toggleBTNtext.Text = "Disable Windows Explorer";
            }

        }

    }
}