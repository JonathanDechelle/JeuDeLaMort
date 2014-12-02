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
    public partial class Magasin : Form
    {
        // Arme de base
        public int []TabArme=new int[6];
        // Argent
        public int m_Argent;
        int ArgentArme;
        int NumeroArme;

        System.Media.SoundPlayer sp = new System.Media.SoundPlayer("Magasinsong.wav");



        public Magasin(int[] TArme, int ArgentAbase)
        {
            InitializeComponent();
            sp.PlayLooping();
            TabArme = TArme;
            m_Argent = ArgentAbase;
            //Affichage de l'argent
            lbArgent.Text = m_Argent.ToString();

            //Affichage selon larme de depart
            if (TabArme[0] == 1)
            {
                pbArmePosses1.Image = global::Jeu.Properties.Resources.Zat;
            }
         
                if (TabArme[1] == 1)
                {
                    pbArmePosses1.Image = global::Jeu.Properties.Resources.PlasmaGun;
                    
                }

            if (TabArme[2] == 1)
            {

                pbArmePosses2.Image = global::Jeu.Properties.Resources.klarix;
                pbArme5.Visible = false;
            }

            if (TabArme[3] == 1)
            {

                pbArmePosses3.Image = global::Jeu.Properties.Resources.Catagan;
                pbArme3.Visible = false;
            }

            if (TabArme[4] == 1)
            {

                pbArmePosses4.Image = global::Jeu.Properties.Resources.TwisterGun;
                pbArme2.Visible = false;
            }

            if (TabArme[5] == 1)
            {

                pbArmePosses5.Image = global::Jeu.Properties.Resources.Desintregrateur;
                pbArme4.Visible = false;
            }
        }

        private void btnRetour_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

        private void pbArme2_MouseEnter(object sender, EventArgs e)
        {
            pbArme2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            ArgentArme = 2000;
            lbArgentArme.Text = ArgentArme.ToString();
            this.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        private void pbArme2_MouseLeave(object sender, EventArgs e)
        {
            pbArme2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            ArgentArme = 0;
            lbArgentArme.Text = ArgentArme.ToString();
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void pbArme2_Click(object sender, EventArgs e)
        {
            //Twistergun
            NumeroArme = 4;
            ArmeAchat(pbArme2);
        }

        private void pbArme3_MouseEnter(object sender, EventArgs e)
        {
            pbArme3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            ArgentArme = 1000;
            lbArgentArme.Text = ArgentArme.ToString();
            this.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        private void pbArme3_MouseLeave(object sender, EventArgs e)
        {
            pbArme3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            ArgentArme = 0;
            lbArgentArme.Text=ArgentArme.ToString();
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }

     
        private void pbArme3_Click(object sender, EventArgs e)
        {
            //Catagan
            NumeroArme = 3;
            ArmeAchat(pbArme3);
        }


        private void pbArme4_MouseEnter(object sender, EventArgs e)
        {
            pbArme4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            ArgentArme = 3000;
            lbArgentArme.Text = ArgentArme.ToString();
            this.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        private void pbArme4_MouseLeave(object sender, EventArgs e)
        {
            pbArme4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            ArgentArme = 0;
            lbArgentArme.Text = ArgentArme.ToString();
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void pbArme4_Click(object sender, EventArgs e)
        {
            //Desintegrateur
            NumeroArme = 5;
            ArmeAchat(pbArme4);
        }

        private void pbArme5_MouseEnter(object sender, EventArgs e)
        {
            pbArme5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            ArgentArme = 300;
            lbArgentArme.Text = ArgentArme.ToString();
            this.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        private void pbArme5_MouseLeave(object sender, EventArgs e)
        {
            pbArme5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            ArgentArme = 0;
            lbArgentArme.Text = ArgentArme.ToString();
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void pbArme5_Click(object sender, EventArgs e)
        {
            //KLARIX
            NumeroArme = 2;
            ArmeAchat(pbArme5);
        }
       


        public void ArmeAchat(PictureBox Pb)
        {
            if (m_Argent < ArgentArme)
            {
                MessageBox.Show("VOUS N'AVEZ PAS ASSEZ DARGENT");
                return;
            }
            else
            {
                Pb.Visible = false;

                switch (NumeroArme)
                {
                    case 2: pbArmePosses2.Image = global::Jeu.Properties.Resources.klarix;
                        break;
                    case 3: pbArmePosses3.Image = global::Jeu.Properties.Resources.Catagan;
                        break;
                    case 4: pbArmePosses4.Image = global::Jeu.Properties.Resources.TwisterGun;
                        break;
                    case 5: pbArmePosses5.Image = global::Jeu.Properties.Resources.Desintregrateur;
                        break;

                }
                TabArme[NumeroArme] = 1;
                //argent soustrai
                m_Argent -= ArgentArme;
                lbArgent.Text = m_Argent.ToString();
            }

        }

    }
}
