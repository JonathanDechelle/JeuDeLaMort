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
    public partial class Univers : Form
    {
        public int Perso, Argent;
        int[] ArmeenMain;
        public Monde_1 m_Niveau1;
        public Monde_2 m_Niveau2;
        public bool Planete2;
        System.Media.SoundPlayer sp = new System.Media.SoundPlayer("Electro.wav");

        public Univers(int choixduPerso, int Money,int[]TabArme,bool AccesMonde2)
        {
            InitializeComponent();

            #region Initialisation + parution du monde 2
            Perso = choixduPerso;
            Argent = Money;
            ArmeenMain = TabArme;
            Planete2 = AccesMonde2;
            if (Planete2 == true)
                pbPlanete2.Visible = true;
            #endregion

            sp.PlayLooping();
        }

        #region Modification et comportement du label de sortie
        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.Font = new System.Drawing.Font("Pristina", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.Font = new System.Drawing.Font("Pristina", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }
        #endregion

        private void Univers_Load(object sender, EventArgs e)
        {
            Rotation.Start();
            RotationP2.Start();
            
        }

        private void Rotation_Tick(object sender, EventArgs e)
        {
            #region deplacement planete1
            Point Coordonnée = IPlanete1.Location;
            //deplacement en ellipse
            Coordonnée.Y += 4;
            IPlanete1.Location = Coordonnée;
        
            if (IPlanete1.Location.Y > ClientSize.Height)
            {
                Coordonnée = IPlanete1.Location;
                Coordonnée.Y = 0;
                IPlanete1.Location = Coordonnée;

            }
            #endregion
        }

        #region Attrait de planete 1
        private void IPlanete1_Click(object sender, EventArgs e)
        {
            m_Niveau1 = new Monde_1(Perso, Argent, ArmeenMain);
            Rotation.Stop();
            RotationP2.Stop();
            m_Niveau1.ShowDialog();
            if (m_Niveau1.PLanete2Permise == true)
            {
                pbPlanete2.Visible = true;
                Planete2 = true;
            }
            if (m_Niveau1.PourAllerAuMenuDirect() == true)
            {
                Argent = m_Niveau1.m_Argent;
                this.Close();
                return;
            }
            Argent = m_Niveau1.m_Argent;
            Rotation.Start();
            RotationP2.Start();
            sp.PlayLooping();
        }

        private void IPlanete1_MouseEnter(object sender, EventArgs e)
        {
            lbPlanete.Text = "Xakara";
        }

        private void IPlanete1_MouseLeave(object sender, EventArgs e)
        {
            lbPlanete.Text = "";
        }

#endregion

        private void RotationP2_Tick(object sender, EventArgs e)
        {
            #region deplacement planete2
            Point Coordonnée = pbPlanete2.Location;
            Coordonnée.Y += 2;
            pbPlanete2.Location = Coordonnée;

            if (pbPlanete2.Location.Y > ClientSize.Height)
            {
                Coordonnée = pbPlanete2.Location;
                Coordonnée.Y = 0;
                pbPlanete2.Location = Coordonnée;

            }
            #endregion
        }

        #region attrait planete 2
        private void pbPlanete2_MouseEnter(object sender, EventArgs e)
        {
            lbPlanete.Text = "Nova Klam";
        }

        private void pbPlanete2_MouseLeave(object sender, EventArgs e)
        {
            lbPlanete.Text = "";
        }

        private void pbPlanete2_Click(object sender, EventArgs e)
        {
            m_Niveau2 = new Monde_2(Perso, Argent, ArmeenMain);
            Rotation.Stop();
            RotationP2.Stop();
            m_Niveau2.ShowDialog();
            if (m_Niveau2.PourAllerAuMenuDirect() == true)
            {
                Argent = m_Niveau2.m_Argent;
                this.Close();
                return;
            }
            Argent = m_Niveau2.m_Argent;
            Rotation.Start();
            RotationP2.Start();
            sp.PlayLooping();
        }
        #endregion
         
    }
}
