using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Media;
using System.Threading;

namespace Jeu
{
   

     public partial class dCredits: Form
    {
         FileStream fs = new FileStream("Credits.txt",FileMode.Open,FileAccess.Read);
         StreamReader sr;
         SoundPlayer sp = new System.Media.SoundPlayer("Musique\\CreditSong.wav");
         string Texte="";
         string Ligne = "";
         string[] TabAffiche;
         int indexTabAffiche = 0;
         int debut = 0;
         bool fin = false;

        public dCredits()
        {
            InitializeComponent();
            sr = new StreamReader(fs,Encoding.Default);
            sp.PlayLooping();
        }

        private void dCredits_Load(object sender, EventArgs e)
        {
            while (Ligne != null)
            {
                Ligne = sr.ReadLine();
                Texte += Ligne + "\n";
            }

            TabAffiche = Texte.Split('\n');
            
            TimerStart.Start();
            TimerDeplacementTexte.Start();
          
        }

        private void TimerDeplacementTexte_Tick(object sender, EventArgs e)
        {
            if (fin == true)
            {
                TimerDeplacementTexte.Stop();
            }

            Point Coordonnée = lbCredits1.Location;
            Point Coordonnée2 = lbCredits2.Location;
            #region deplacement planete2
            Coordonnée.Y += 1;
            Coordonnée2.Y += 1;
            lbCredits1.Location = Coordonnée;
            lbCredits2.Location = Coordonnée2;
            #endregion
            #region Si limite atteinte
            if (lbCredits1.Location.Y > ClientSize.Height)
            {
                Coordonnée = lbCredits1.Location;
                Coordonnée.Y = 0;
                lbCredits1.Location = Coordonnée;

            }
            if (lbCredits2.Location.Y > ClientSize.Height)
            {
                Coordonnée2 = lbCredits2.Location;
                Coordonnée2.Y = 0;
                lbCredits2.Location = Coordonnée2;

            }
            #endregion
        }

        private void btnCommencer_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void TimerStart_Tick(object sender, EventArgs e)
        {
            debut++;

            if (indexTabAffiche + 1 < 24)
            {
                lbCredits2.Text = TabAffiche[indexTabAffiche];
                lbCredits1.Text = TabAffiche[indexTabAffiche + 1];
                indexTabAffiche += 3;
            }
            else
            {
                fin = true;
                lbNuke.Visible = true;
                pbNuke.Visible = true;
            }

            if (fin)
            {
                pbImage.Visible = true;
                pbNuke.Visible = true;
            }

            if (debut == 10)
                btnCommencer_Click(sender, e);
        }
    }
}
