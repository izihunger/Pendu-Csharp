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
using System.Diagnostics;

namespace Projet_pendu
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> listMot = new List<string>();
        List<char> faussesLettres = new List<char>();
        List<Image> pendu = new List<Image>();
        int motATrouver = 0;
        string motCacher;

        public MainWindow()
        {
            InitializeComponent();
            pendu.Add(erreur1);
            pendu.Add(erreur2);
            pendu.Add(erreur3);
            pendu.Add(erreur4);
            pendu.Add(erreur5);
            pendu.Add(erreur6);
            pendu.Add(erreur7);
            pendu.Add(erreur8);
            pendu.Add(erreur9);
            listMot.Add("U T I L I S A T E U R");
            listMot.Add("S Y S T E M E");
            listMot.Add("B I N A I R E");
            motCacher = CacherMot(listMot[motATrouver]);
            labelMot.Content = motCacher;
        }

        private void setDefaultWindow()
        {
            for(int i = 0; i<pendu.Count(); i++)
            {
                pendu[i].SetValue(Panel.ZIndexProperty, 0);
            }
            for (int i = faussesLettres.Count() - 1; i >= 0; i--)
            {
                faussesLettres.RemoveAt(i);
            }
            motATrouver = 0;
            motCacher = CacherMot(listMot[motATrouver]);
            labelLettresFausses.Content = "";
        }

        public bool Comparer_lettre(string motATrouver, char lettre)
        {
            for (int i = 0; i < motATrouver.Length; i++)
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
            StringBuilder sb = new StringBuilder(motACacher);
            for (int i = 0; i < motACacher.Length; i++)
            {
                if (sb[i] != ' ')
                {
                    sb[i] = '-';
                }
            }
            return sb.ToString();
        }

        public void Traitement(char lettre)
        {
            int res = 0;

            StringBuilder sb = new StringBuilder(motCacher);

            if (Comparer_lettre(listMot[motATrouver], lettre))
            {
                for (int i = 0; i < listMot[motATrouver].Length; i++)
                {
                    if (listMot[motATrouver][i] == lettre)
                    {
                        sb[i] = lettre;
                        res = 1;
                    }
                    motCacher = sb.ToString();
                }
            }
            if (res == 0)
            {
                bool dejaEssayer = false;
                for(int i = 0; i < faussesLettres.Count(); i++)
                {
                    if(lettre == faussesLettres[i])
                    {
                        dejaEssayer = true;
                    }
                }
                if(!dejaEssayer)
                {
                    faussesLettres.Add(lettre);
                    afficher_LettreFausses();
                    afficher_pendu(faussesLettres.Count());
                    if(faussesLettres.Count() == 9)
                    {                        
                        MessageBox.Show("Vous avez perdu ! Appuyez sur OK pour recommencer");
                        setDefaultWindow();
                    }
                }
            }
            if (motCacher == listMot[motATrouver])
            {
                motATrouver++;
                if (motATrouver <= 2)
                {
                    motCacher = CacherMot(listMot[motATrouver]);
                    for(int i = faussesLettres.Count()-1; i >= 0; i--)
                    {
                        faussesLettres.RemoveAt(i);
                    }
                    for (int i = 0; i < pendu.Count(); i++)
                    {
                        pendu[i].SetValue(Panel.ZIndexProperty, 0);
                    }
                    labelLettresFausses.Content = "";
                }
                else
                {
                    labelMot.Content = motCacher;
                    Window1 newWin = new Window1();
                    newWin.ShowDialog();
                    setDefaultWindow();
                }
            }
            labelMot.Content = motCacher;
        }

        private void afficher_pendu(int nb_erreur)
        {
            pendu[nb_erreur-1].SetValue(Panel.ZIndexProperty, 3);
        }

        private void input_jeux_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return")
            {
                if (input_jeux.Text.Length == 1)
                {
                    Traitement(Convert.ToChar(input_jeux.Text.ToUpper()));
                }
                input_jeux.Text = "";
            }
        }

        private void TestBtn_Click(object sender, RoutedEventArgs e)
        {
            if (input_jeux.Text.Length == 1)
            {
                Traitement(Convert.ToChar(input_jeux.Text.ToUpper()));
            }
            input_jeux.Text = "";
        }

        private void afficher_LettreFausses()
        {
            string lettre = "";

            for (int i = 0; i < faussesLettres.Count; i++)
            {
                lettre += faussesLettres[i].ToString() + " ";
            }
            labelLettresFausses.Content = lettre;
        }
    }
}