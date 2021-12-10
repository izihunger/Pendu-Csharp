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
        /*
         public bool Comparer_lettre(string motATrouver, char lettre)
        {
            for (size_t i = 0; i <= motATrouver.size(); i++)
            {
                char lettreMot = motATrouver[i];
                if (lettre == lettreMot)
                {
                    return true;
                }
            }
            return false;
        }
        
        public string CacherMot(string motACacher)
        {
            for (size_t i = 0; i <= motACacher.size(); i++)
            {
                motACacher[i] = '*';
            }
            return motACacher;
        }
        
        public void Traitement()
        {
            string mot1 = "utilisateur", mot2 = "systeme", mot3 = "binaire", motCacher, lettreFausses;
            char lettre;
            int res = 0;

            motCacher = CacherMot(mot1);

            while (motCacher != mot1)
            {
                system("cls");
                res = 0;
                std::cout << motCacher << std::endl;
                std::cout << "Lettre fausses : " << lettreFausses << std::endl; //changer entrée/sortie pour c#
                std::cout << "Entrez une lettre" << std::endl;
                std::cin >> lettre;
                if (Comparer_lettre(mot1, lettre))
                {
                    for (size_t i = 0; i <= mot1.size(); i++) // changer type et methode
                    {
                        if (mot1[i] == lettre)
                        {
                            motCacher[i] = lettre;
                            res = 1;
                        }

                    }
                }
                if (res == 0)
                {
                    lettreFausses.push_back(lettre);
                }
            }
        }*/

        private void input_jeux_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return")
            {
                label.Content = input_jeux.Text;
            }
            
        }
    }
}

/*
 A FAIRE !!!

    Changer les entrées sorties par les évenements
    Changer le type "size_t"
    Changer la méthode string.size() par une methode compatible en c#
    Changer la méthode string.push_back() par une methode compatible en c
    Ajouter methode gagner() 
     */
