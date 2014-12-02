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
    public partial class dChoixArmeCombat : Form
    {
        private int m_ChoixPerso = -1;
        private int m_ChoixArme = -1;
        bool ArmeChoisi = false;
      
        public dChoixArmeCombat(int ChoixPerso, Image ArmeBase, int[] TabArmeenMain)
        {
            InitializeComponent();
            m_ChoixPerso = ChoixPerso;
            pbArme1.Image = ArmeBase;
            #region Si Arme2
            if (TabArmeenMain[2] == 1)
            {
                pbArme2.Image = Image.FromFile("Arme\\Klarix.jpg");
                pbArme2.Enabled = true;
                pbArme2.Visible = true;
            }
            #endregion
            #region si Arme3
            if (TabArmeenMain[3] == 1)
            {
                pbArme3.Image = Image.FromFile("Arme\\Catagan.jpg");
                pbArme3.Enabled = true;
                pbArme3.Visible = true;
            }
            #endregion
            #region si Arme4
            if (TabArmeenMain[4] == 1)
            {
                pbArme4.Image = Image.FromFile("Arme\\TwisterGun.jpg");
                pbArme4.Enabled = true;
                pbArme4.Visible = true;
            }
            #endregion
            #region si Arme5
            if (TabArmeenMain[5] == 1)
            {
                pbArme5.Image = Image.FromFile("Arme\\Desintegrateur.jpg");
                pbArme5.Enabled = true;
                pbArme5.Visible = true;
            }
            #endregion
            #region si Arme6
            if (TabArmeenMain[6] == 1)
            {
                pbArme6.Image = Image.FromFile("Arme\\NUKE.jpg");
                pbArme6.Enabled = true;
                pbArme6.Visible = true;
            }
            #endregion
        }

        #region Évenement avec les picturebox
        #region attrait pbArme1
        private void pbArme1_MouseEnter(object sender, EventArgs e)
        {
            Reinitialisation();

            if (m_ChoixPerso == 1 || m_ChoixPerso == 2)
            {
                lbNom.Text += cArme.Tabarme[1].nom;
                lbDegatUpgrade.Text += cArme.Tabarme[1].DommageMax.ToString();
            }
            else
            {
                lbNom.Text += cArme.Tabarme[0].nom;
                lbDegatUpgrade.Text += cArme.Tabarme[0].DommageMax.ToString();

            }

            
        }
        private void pbArme1_Click(object sender, EventArgs e)
        {
            if (m_ChoixPerso == 1 || m_ChoixPerso == 2)
                m_ChoixArme = 1;
            else
                m_ChoixArme = 0;
            ArmeChoisi = true;
            this.Close();
        }
        #endregion
        #region attrait pbArme2
        private void pbArme2_MouseEnter(object sender, EventArgs e)
        {
            Reinitialisation();
            lbNom.Text += cArme.Tabarme[2].nom;
            lbDegatUpgrade.Text += cArme.Tabarme[2].DommageMax.ToString();
        }
        private void pbArme2_Click(object sender, EventArgs e)
        {
            m_ChoixArme = 2;
            ArmeChoisi = true;
            this.Close();
        }
        #endregion
        #region attrait pbArme3
        private void pbArme3_MouseEnter(object sender, EventArgs e)
        {
            Reinitialisation();
            lbNom.Text += cArme.Tabarme[3].nom;
            lbDegatUpgrade.Text += cArme.Tabarme[3].DommageMax.ToString();
        }
        private void pbArme3_Click(object sender, EventArgs e)
        {
            m_ChoixArme = 3;
            ArmeChoisi = true;
            this.Close();
        }
        #endregion
        #region attrait pbArme4
        private void pbArme4_MouseEnter(object sender, EventArgs e)
        {
            Reinitialisation();
            lbNom.Text += cArme.Tabarme[4].nom;
            lbDegatUpgrade.Text += cArme.Tabarme[4].DommageMax.ToString();
        }
        private void pbArme4_Click(object sender, EventArgs e)
        {
            m_ChoixArme = 4;
            ArmeChoisi = true;
            this.Close();
        }
        #endregion 
        #region attrait pbArme5
        private void pbArme5_MouseEnter(object sender, EventArgs e)
        {
            Reinitialisation();
            lbNom.Text += cArme.Tabarme[5].nom;
            lbDegatUpgrade.Text += cArme.Tabarme[5].DommageMax.ToString();
        }
        private void pbArme5_Click(object sender, EventArgs e)
        {
            m_ChoixArme = 5;
            ArmeChoisi = true;
            this.Close();
        }
        #endregion
        #region attrait pbArme6
        private void pbArme6_MouseEnter(object sender, EventArgs e)
        {
            Reinitialisation();
            lbNom.Text += cArme.Tabarme[6].nom;
            lbDegatUpgrade.Text += cArme.Tabarme[6].DommageMax.ToString();
        }
        private void pbArme6_Click(object sender, EventArgs e)
        {
            m_ChoixArme = 6;
            ArmeChoisi = true;
            this.Close();
        }
        #endregion
        #endregion
        #region Évenement Avec la form dChoixArmeCombat
        private void dChoixArmeCombat_MouseMove(object sender, MouseEventArgs e)
        {
            //Évite que lorsquon passe trop vite sur 2 images que les nom se chevauche
            Reinitialisation();
        }
        private void dChoixArmeCombat_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ArmeChoisi == false)
            {
                MessageBox.Show("Voulez devez choisir une arme !!!!", "PRÉPARATION AU COMBAT OBLIGATOIRE     ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
            }
        }
        #endregion

        //fonction de retour
        public int RetourneArmeChoisi()
        {
            return m_ChoixArme;
        }
        private void Reinitialisation()
        {
            lbNom.Text = "NOM : ";
            lbDegatUpgrade.Text = "DÉGATS ARME : ";
        }

       
    }
}
