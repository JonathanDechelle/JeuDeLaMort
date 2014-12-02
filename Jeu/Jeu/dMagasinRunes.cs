using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Jeu
{
    public partial class dMagasinRunes : Form
    {
        #region Variable utilisées
        bool Rune1Active,Rune2Active;
        int PrixRune1=400, PrixRune2=450;
        public int Rune1Enpossesion, Rune2Enpossession, Argent;
        System.Media.SoundPlayer sp = new System.Media.SoundPlayer("Musique\\2iemMagasin.wav");
        #endregion

        public dMagasinRunes(int Cash,int ARune1,int ARune2)
        {
            InitializeComponent();
            #region initialisation experience et texte
            Argent = Cash;
            lbExperience.Text += " " + Argent.ToString();
            #endregion
            #region Initialisation texte rune et chansons
            sp.PlayLooping();
            lbRune1.Text += " " + PrixRune1.ToString();
            lbRune2.Text += " " + PrixRune2.ToString();
            Rune1Enpossesion = ARune1;
            Rune2Enpossession = ARune2;
            #endregion
            #region Regarde rune en possession
            if (Rune1Enpossesion == 1)
                Rune1Acheter();
            if (Rune2Enpossession == 1)
                Rune2Acheter();
            #endregion
        }
         
        #region Different evenement avec les differentes runes

        #region pbRune1
        private void pbRune1_MouseEnter(object sender, EventArgs e)
        {
            pbAchat.Image = Image.FromFile("Runes\\Rune4.jpg");
            btnAcheter.Enabled = true;
        }

        private void pbRune1_MouseLeave(object sender, EventArgs e)
        {
            if (!Rune1Active)
            {
                pbAchat.Image = null;
                btnAcheter.Enabled = false;
                Rune2Active = false;
            }
        }
        
        private void pbRune1_Click(object sender, EventArgs e)
        {
            pbAchat.Image = Image.FromFile("Runes\\Rune4.jpg");
            Rune1Active = true;
            
        }
        #endregion
        #region pbRune2
        private void pbRune2_MouseEnter(object sender, EventArgs e)
        {
            pbAchat.Image = Image.FromFile("Runes\\Rune1.jpg");
            btnAcheter.Enabled = true;
        }

        private void pbRune2_MouseLeave(object sender, EventArgs e)
        {
            if (!Rune2Active)
            {
                pbAchat.Image = null;
                btnAcheter.Enabled = true;
                Rune1Active = false;
            }
        }

        private void pbRune2_Click(object sender, EventArgs e)
        {
            pbAchat.Image = Image.FromFile("Runes\\Rune1.jpg");
            Rune2Active = true;
        }
        #endregion

        private void btnRetour_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void btnAcheter_Click(object sender, EventArgs e)
        {
            #region Achat de rune 1
            if (Rune1Active == true)
            {
                if (Argent < PrixRune1)
                {
                    MessageBox.Show("Pas Assez d'argent");
                    return;
                }

                else
                {

                    Argent -= PrixRune1;
                    lbExperience.Text = "Argent : " + Argent.ToString();
                    Rune1Acheter();
                    Rune1Active = false;
                    pbAchat.Image = null;
                    btnAcheter.Enabled = false;
                }
            }
            #endregion
            #region Achat de rune 2
            if (Rune2Active == true)
            {
                if (Argent < PrixRune2)
                {
                    MessageBox.Show("Pas Assez d'argent");
                    return;
                }

                else
                {
                    Argent -= PrixRune2;
                    lbExperience.Text = "Argent : " + Argent.ToString();
                    Rune2Acheter();
                    Rune2Active = false;
                    pbAchat.Image = null;
                    btnAcheter.Enabled = false;
                }
            }
            #endregion
        }

        #region Fonctions
        void Rune1Acheter()
        {
            pbRune1.Image = null;
            pbRune1.Enabled = false;
            lbRune1.Text = "Rune De Soin    Prix : Achetée";
            Rune1Enpossesion = 1;
        }
        void Rune2Acheter()
        {
            pbRune2.Image = null;
            pbRune2.Enabled = false;
            lbRune2.Text = "Rune De Paralysie  Prix : Achetée";
            Rune2Enpossession = 1;
        }
        #endregion

      
    }
}
