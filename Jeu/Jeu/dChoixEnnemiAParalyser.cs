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
    public partial class dChoixEnnemiAParalyser : Form
    {
        private cMonstre m_Monstre1, m_Monstre2, m_Monstre3;
        bool UnSeulMonstre;
        private int m_MonstreChoisi = -1;
        object sender=new object();
        EventArgs e=new EventArgs();

        public dChoixEnnemiAParalyser(cMonstre[] TabMonstreAucombat)
        {
            InitializeComponent();
            if (TabMonstreAucombat.Length == 1)
            {
                UnSeulMonstre = true;
            }

            //initialisation des monstre
            #region intitialisation du tableau de monstre
            m_Monstre1 = TabMonstreAucombat[0];

            if (!UnSeulMonstre)
            {
                m_Monstre2 = TabMonstreAucombat[1];
                m_Monstre3 = TabMonstreAucombat[2];
            }
            #endregion
            #region Initialisation graphique
            if (!UnSeulMonstre)
            {
                lbDommMechant1.Text = m_Monstre1.m_Dommage.ToString();
                lbVieMechant1.Text = m_Monstre1.m_Vie.ToString();
                //////
                lbDommMechant2.Text = m_Monstre2.m_Dommage.ToString();
                lbVieMechant2.Text = m_Monstre2.m_Vie.ToString();
                /////
                lbDommMechant3.Text = m_Monstre3.m_Dommage.ToString();
                lbVieMechant3.Text = m_Monstre3.m_Vie.ToString();

                pbMechant1.BackgroundImage = m_Monstre1.m_ImageMonstre;
                pbMechant2.BackgroundImage = m_Monstre2.m_ImageMonstre;
                pbMechant3.BackgroundImage = m_Monstre3.m_ImageMonstre;
            }
            else
            {
                lbDommMechant2.Text = m_Monstre1.m_Dommage.ToString();
                lbVieMechant2.Text = m_Monstre1.m_Vie.ToString();
                pbMechant2.BackgroundImage = m_Monstre1.m_ImageMonstre;
                lbDommMechant1.Visible = false;
                lbVieMechant1.Visible = false;
                lbVieMechant3.Visible = false;
                lbDommMechant3.Visible = false;
                panMechant1.Visible = false;
                panMechant3.Visible = false;
                lbText.Text = m_Monstre1.m_nom + " est paralysé grâce à votre rune";
                pbMechant2_MouseClick(sender, e);
            }
            #endregion
        }

        #region evenement bouton lorsquon clicke dessus
      
        #region attrait pbMechant1
        private void pbMechant1_MouseClick(object sender, EventArgs e)
        {
            pbMechant2.Enabled = false;
            pbMechant2.Visible = false;
            pbMechant3.Enabled = false;
            pbMechant3.Visible = false;
            BtnOkEtAnnuler(true);
            m_MonstreChoisi = 1;
        }
        private void pbMechant1_MouseEnter(object sender, EventArgs e)
        {
            RemiseForm();
            panMechant1.BackColor = Color.Red;
        }
        #endregion
        #region attrait pbMechant2
        private void pbMechant2_MouseClick(object sender, EventArgs e)
        {
            pbMechant1.Enabled = false;
            pbMechant1.Visible = false;
            pbMechant3.Enabled = false;
            pbMechant3.Visible = false;
            BtnOkEtAnnuler(true);
            m_MonstreChoisi = 2;
        }
        private void pbMechant2_MouseEnter(object sender, EventArgs e)
        {
            RemiseForm();
            panMechant2.BackColor = Color.Red;
        }
        #endregion
        #region attrait pbMechant3 
        private void pbMechant3_MouseClick(object sender, EventArgs e)
        {
            pbMechant1.Enabled = false;
            pbMechant1.Visible = false;
            pbMechant2.Enabled = false;
            pbMechant2.Visible = false;
            BtnOkEtAnnuler(true);
            m_MonstreChoisi = 3;
        }
        private void pbMechant3_MouseEnter(object sender, EventArgs e)
        {
            RemiseForm();
            panMechant3.BackColor = Color.Red;
        }
        #endregion

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            
            RemiseImage();
            BtnOkEtAnnuler(false);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dChoixEnnemiAParalyser_MouseMove(object sender, MouseEventArgs e)
        {
            RemiseForm();
        }

        #endregion

        #region Fonction
        private void BtnOkEtAnnuler(bool Activé)
        {
            if (Activé)
            {
                btnOk.Visible = true;
                btnAnnuler.Visible = true;
            }
            else
            {
                btnOk.Visible = false;
                btnAnnuler.Visible = false;
            }
        }
        private void RemiseForm()
        {
                panMechant1.BackColor = Color.Gray;
                panMechant2.BackColor = Color.Gray;
                panMechant3.BackColor = Color.Gray;
        }
        private void RemiseImage()
        {
            pbMechant1.Enabled = true;
            pbMechant2.Enabled = true;
            pbMechant3.Enabled = true;
            pbMechant1.Visible = true;
            pbMechant2.Visible = true;
            pbMechant3.Visible = true;
        }
        public int retourneMonstreChoisi()
        {
            return m_MonstreChoisi;
        }
        #endregion

        

     

     
     

     

     


        

       
     
    }
}
