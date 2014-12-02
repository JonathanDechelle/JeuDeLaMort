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
    public partial class dMagasin : Form
    {
        #region Variable utilisés
        // Arme 
        public int []TabArme=new int[6];
        // Argent
        public int m_Argent;
        int ArgentArme;
        int NumeroArme;

        System.Media.SoundPlayer sp = new System.Media.SoundPlayer("Musique\\Magasinsong.wav");
        #endregion

        public dMagasin(int[] TArme, int ArgentAbase)
        {
            InitializeComponent();
            #region intitialisation son,tabarme,argent(et en texte)
            sp.PlayLooping();
            TabArme = TArme;
            m_Argent = ArgentAbase;
            lbArgent.Text = m_Argent.ToString();
            #endregion
            #region Affichage selon l'arme de depart
            if (TabArme[0] == 1)
            {
                pbArmePosses1.Image  = Image.FromFile("Arme\\Zat.jpg");
            }
         
                if (TabArme[1] == 1)
                {
                    pbArmePosses1.Image = Image.FromFile("Arme\\PlasmaGun.jpg"); 
                    
                }

            if (TabArme[2] == 1)
            {

                pbArmePosses2.Image = Image.FromFile("Arme\\Klarix.jpg");
                pbArme5.Visible = false;
                panArme5.Visible = false;
            }

            if (TabArme[3] == 1)
            {

                pbArmePosses3.Image = Image.FromFile("Arme\\Catagan.jpg");
                pbArme3.Visible = false;
                panArme3.Visible = false;
            }

            if (TabArme[4] == 1)
            {

                pbArmePosses4.Image = Image.FromFile("Arme\\TwisterGun.jpg");
                pbArme2.Visible = false;
                panArme2.Visible = false;
            }

            if (TabArme[5] == 1)
            {

                pbArmePosses5.Image = Image.FromFile("Arme\\Desintegrateur.jpg"); 
                pbArme4.Visible = false;
                panArme5.Visible = false;
            }
            if (TabArme[6] == 1)
            {
                pbArmePosses6.Image = Image.FromFile("Arme\\NUKE.jpg");
            }
            #endregion
        }

        private void btnRetour_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region different evenement associer a chaque picturebox
        #region Attrait du picturebox pbArme2
        private void pbArme2_MouseEnter(object sender, EventArgs e)
        {
            InitialisationForm();
            ArgentArme = 1250;
            lbArgentArme.Text = ArgentArme.ToString();
            panArme2.BackColor = Color.DarkGreen;
        }

        private void pbArme2_Click(object sender, EventArgs e)
        {
            //Twistergun
            NumeroArme = 4;
            ArmeAchat(pbArme2,panArme2);
        }
        #endregion
        #region Attrait du picturebox pbArme3
        private void pbArme3_MouseEnter(object sender, EventArgs e)
        {
            InitialisationForm();
            ArgentArme = 800;
            lbArgentArme.Text = ArgentArme.ToString();
            panArme3.BackColor = Color.DarkGreen;
        }

        private void pbArme3_Click(object sender, EventArgs e)
        {
            //Catagan
            NumeroArme = 3;
            ArmeAchat(pbArme3,panArme3);
        }
        #endregion
        #region Attrait du picturebox pbArme4
        private void pbArme4_MouseEnter(object sender, EventArgs e)
        {
            InitialisationForm();
            ArgentArme = 1800;
            lbArgentArme.Text = ArgentArme.ToString();
            panArme4.BackColor = Color.DarkGreen;
        }

        private void pbArme4_Click(object sender, EventArgs e)
        {
            //Desintegrateur
            NumeroArme = 5;
            ArmeAchat(pbArme4,panArme4);
        }
        #endregion
        #region Attrait du picturebox pbArme5
        private void pbArme5_MouseEnter(object sender, EventArgs e)
        {
            InitialisationForm();
            ArgentArme = 250;
            lbArgentArme.Text = ArgentArme.ToString();
            panArme5.BackColor = Color.DarkGreen;
            
        }
        private void pbArme5_Click(object sender, EventArgs e)
        {
            //KLARIX
            NumeroArme = 2;
            ArmeAchat(pbArme5,panArme5);
        }
        #endregion
        #endregion

        public void ArmeAchat(PictureBox Pb,Panel pan)
        {
            #region Arme Achetable ou non 
            if (m_Argent < ArgentArme)
            {
                MessageBox.Show("VOUS N'AVEZ PAS ASSEZ DARGENT");
                return;
            }
            else
            {
                Pb.Visible = false;
                pan.Visible = false;
                #region Image de linventaire Selon le numero de larme acheter
                switch (NumeroArme)
                {
                    case 2: pbArmePosses2.Image = Image.FromFile("Arme\\Klarix.jpg");
                        break;
                    case 3: pbArmePosses3.Image = Image.FromFile("Arme\\Catagan.jpg");
                        break;
                    case 4: pbArmePosses4.Image = Image.FromFile("Arme\\TwisterGun.jpg");
                        break;
                    case 5: pbArmePosses5.Image = Image.FromFile("Arme\\Desintegrateur.jpg");
                        break;

                }
                #endregion
                TabArme[NumeroArme] = 1;
                //argent soustrai
                m_Argent -= ArgentArme;
                lbArgent.Text = m_Argent.ToString();
            }
            #endregion
        }

        private void dMagasin_MouseMove(object sender, MouseEventArgs e)
        {
            //evite les bugs graphiques
            InitialisationForm();
        }

        private void InitialisationForm()
        {
            pbArme2.BorderStyle = BorderStyle.None;
            pbArme3.BorderStyle = BorderStyle.None;
            pbArme4.BorderStyle = BorderStyle.None;
            pbArme5.BorderStyle = BorderStyle.None;
            panArme2.BackColor = Color.Gray;
            panArme3.BackColor = Color.Gray;
            panArme4.BackColor = Color.Gray;
            panArme5.BackColor = Color.Gray;
            ArgentArme = 0;
            lbArgentArme.Text = ArgentArme.ToString();
            this.Cursor = Cursors.Default;
        }

       
    }
}
