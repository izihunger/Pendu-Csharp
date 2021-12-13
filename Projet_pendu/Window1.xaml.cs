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
using System.Windows.Shapes;
using System.Net.Sockets;

namespace Projet_pendu
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        public void EnvoiTcpClient()
        {
            string message = "GAGNE:4";
            TcpClient client = new TcpClient();
            client.Connect("10.16.3.214", 53000);

            Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

            NetworkStream stream = client.GetStream();

            stream.Write(data, 0, data.Length);

            stream.Close();
            client.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.Text.ToUpper() == "USB")
            {
                EnvoiTcpClient();
                MessageBox.Show("Bravo COWBOY !!! Tu as terminé cette épreuve YEEEHAW !!!");
                this.Close();
            }
        }
    }
}
