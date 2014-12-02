using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Jeu
{
    public partial class dLevelUp : Form
    {
        #region Variables utilisées
        private int m_ChoixPerso;
        private int m_Vie;
        private int m_ChoixArme;
        private int m_DegatTempon;
        private int[] m_TabArme;
        #endregion

        public dLevelUp(int ChoixPerso,Image ArmeBase, int Vie,int []TabArmeenMain)
        {
            InitializeComponent();
            m_TabArme = TabArmeenMain;
            m_ChoixPerso = ChoixPerso;
            m_Vie = Vie;
            //mise en place des images avec le tableau darme et du texte de vie
            #region Initialisation graphique

            lbVieUpgrade.Text += " " + Vie.ToString() + " -> " + (Vie += (int)(Vie * 0.05)).ToString();
            pbArme1.Image = ArmeBase;
            #region Si Arme2
            if (TabArmeenMain[2] == 1)
            {
                pbArme2.Image = Image.FromFile("Arme\\Klarix.jpg");
                pbArme2.Cursor = Cursors.Hand;
                pbArme2.Enabled = true;
                pbArme2.Visible = true;
            }
            #endregion
            #region si Arme3
            if (TabArmeenMain[3] == 1)
            {
                pbArme3.Image = Image.FromFile("Arme\\Catagan.jpg");
                pbArme3.Cursor = Cursors.Hand;
                pbArme3.Enabled = true;
                pbArme3.Visible = true;
            }
            #endregion
            #region si Arme4
            if (TabArmeenMain[4] == 1)
            {
                pbArme4.Image = Image.FromFile("Arme\\TwisterGun.jpg");
                pbArme4.Cursor = Cursors.Hand;
                pbArme4.Enabled = true;
                pbArme4.Visible = true;
            }
            #endregion
            #region si Arme5
            if (TabArmeenMain[5] == 1)
            {
                pbArme5.Image = Image.FromFile("Arme\\Desintegrateur.jpg");
                pbArme5.Cursor = Cursors.Hand;
                pbArme5.Enabled = true;
                pbArme5.Visible = true;
            }
            #endregion
            #region si Arme6
            if(m_TabArme[6] == 1)
            {
                pbArme6.Image = Image.FromFile("Arme\\NUKE.jpg");
                pbArme6.Cursor = Cursors.Hand;
                pbArme6.Enabled = true;
                pbArme6.Visible = true;
            }
            #endregion
            #endregion
        }

        #region pbArme 1,2,3,4,5,6 Évenement Click
        private void pbArme1_Click(object sender, EventArgs e)
        {
            if (m_ChoixPerso == 1 || m_ChoixPerso == 2)
                m_ChoixArme = 1;
            else
                m_ChoixArme = 0;

            AfficheDegatArme();

            ModificationArme();
        }
        private void pbArme2_Click(object sender, EventArgs e)
        {
            m_ChoixArme = 2;
            AfficheDegatArme();
            ModificationArme();
        }
        private void pbArme3_Click(object sender, EventArgs e)
        {
            m_ChoixArme = 3;
            AfficheDegatArme();
            ModificationArme();
        }
        private void pbArme4_Click(object sender, EventArgs e)
        {
            m_ChoixArme = 4;
            AfficheDegatArme();
            ModificationArme();
        }
        private void pbArme5_Click(object sender, EventArgs e)
        {
            m_ChoixArme = 5;
            AfficheDegatArme();
            ModificationArme();
        }
        private void pbArme6_Click(object sender, EventArgs e)
        {
            m_ChoixArme = 6;
            AfficheDegatArme();
            ModificationArme();
        }
        #endregion

        #region Fonction
        private bool Confirmation()
        {
            DialogResult Confirmation;
            Confirmation = MessageBox.Show("Etes-vous sur???", "Confirmation",
                                       MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Confirmation == DialogResult.Yes)
                return true;
            else
                return false;
        }
        private void ModificationArme()
        {
            #region modifie le tableau d'arme dans la classe cArme si oui a CONFIRMATION
            if (Confirmation())
            {
                cArme.Tabarme[m_ChoixArme].DommageMax += 3;
                cArme.Tabarme[m_ChoixArme].Niveau++;
                Thread.Sleep(500);
                this.Close();
                Thread.Sleep(500);
            }
            else
            {
                lbDegatUpgrade.Text = "DÉGATS ARME";
                return;
            }
            #endregion
        }
        private void AfficheDegatArme()
        {
            #region Affichage graphique de lupgrade des degats de larme

            lbDegatUpgrade.Text += "  " + cArme.Tabarme[m_ChoixArme].DommageMax.ToString() + " -> ";

            m_DegatTempon = cArme.Tabarme[m_ChoixArme].DommageMax;
            m_DegatTempon += 3;

            Thread.Sleep(500);
            lbDegatUpgrade.Text += m_DegatTempon.ToString();

            #endregion
        }
        public int UpgradeDeVie
        {
            //retourne m_vie en lecture seule
            get
            {
                return m_Vie += (int)(m_Vie * 0.05);
            }
        }
        public int[] UpgradeDeDegatArme()
        {
            //crée un nouveau tableau de grandeur égale au taleau darme
            // et replace les niveaux augmenté dedans 
            int[] TabNiveauArme = new int[m_TabArme.Length];
            for (int i = 0; i < m_TabArme.Length; i++)
            {
                TabNiveauArme[i] = cArme.Tabarme[i].Niveau;
            }
            return TabNiveauArme;
        }
        #endregion


    }
}
