﻿using System;
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
        int motATrouver = 2;
        string motCacher;

        public MainWindow()
        {
            InitializeComponent();
            listMot.Add("U T I L I S A T E U R");
            listMot.Add("S Y S T E M E");
            listMot.Add("B I N A I R E");
            motCacher = CacherMot(listMot[motATrouver]);
            labelMotATrouver.Content = motCacher;
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
                Trace.WriteLine(sb[i]);
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

                }
            }
            if (res == 0)
            {
                faussesLettres.Add(lettre);
                afficher_LettreFausses();
            }

            motCacher = sb.ToString();

            if (motCacher == listMot[motATrouver])
            {
                motATrouver++;
                if (motATrouver <= 2)
                {
                    motCacher = CacherMot(listMot[motATrouver]);
                }
                else
                {
                    labelMotATrouver.Content = motCacher;
                    Window1 newWin = new Window1();
                    newWin.ShowDialog();
                }
            }
            labelMotATrouver.Content = motCacher;
        }

        private void input_jeux_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return")
            {
                if (input_jeux.Text.Length <= 1)
                {
                    Traitement(Convert.ToChar(input_jeux.Text.ToUpper()));
                    input_jeux.Text = "";
                }
            }

        }

        private void TestBtn_Click(object sender, RoutedEventArgs e)
        {
            if (input_jeux.Text.Length <= 1)
            {
                Traitement(Convert.ToChar(input_jeux.Text.ToUpper()));
                input_jeux.Text = "";
            }
        }

        private void afficher_LettreFausses()
        {
            string lettre = "";

            for (int i = 0; i < faussesLettres.Count; i++)
            {
                lettre += faussesLettres[i].ToString();
            }
            labelLettresFausses.Content = lettre;
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