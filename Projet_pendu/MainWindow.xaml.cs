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
using System.Net.Sockets;

namespace Projet_pendu
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitTcpClient();
        }

        public bool InitTcpClient()
        {
            bool EtatConnexion;
            string message = "GAGNE:4";
            TcpClient client = new TcpClient();
            client.Connect("10.16.3.214", 53000);
            if (client.Connected) { EtatConnexion = true; }
            else { EtatConnexion = false; };

            Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
            //bouton.Content = message;

            // Get a client stream for reading and writing.
            //Stream stream = client.GetStream();

            NetworkStream stream = client.GetStream();

            // Send the message to the connected TcpServer.
            stream.Write(data, 0, data.Length);

            stream.Close();
            client.Close();
            return EtatConnexion;

            /*System.IO.StreamWriter writer = new System.IO.StreamWriter(client.GetStream());
            writer.Write(message);
            writer.Flush();

            // Close Connection
            writer.Close();
            client.Close();*/
        }
    }
}
