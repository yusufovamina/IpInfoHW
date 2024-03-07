using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace IPInfoHW
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string url = urlTextBox.Text;
           
            try
            {
                Uri uri = new Uri(url);

                // Получение IP-адресов для данного домена
                IPAddress[] ipAddresses = Dns.GetHostAddresses(uri.Host);

                // Вывод информации
                resultTextBox.Text = $"URL: {url}\r\n";
                resultTextBox.Text += $"IP Addresses:\r\n";

                foreach (IPAddress ipAddress in ipAddresses)
                {
                    resultTextBox.Text += $"{ipAddress}\r\n";
                }

                resultTextBox.Text += $"Hostname: {uri.Host}\r\n";
                resultTextBox.Text += $"Path: {uri.AbsolutePath}\r\n";
                resultTextBox.Text += $"Port: {uri.Port}\r\n";
                resultTextBox.Text += $"Is File: {uri.IsFile}\r\n";
            }
            catch (UriFormatException ex)
            {
                resultTextBox.Text = $"Error: {ex.Message}";
            }
        }

     
    }
}
