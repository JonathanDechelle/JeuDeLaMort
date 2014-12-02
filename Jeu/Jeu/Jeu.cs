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
    public partial class Jeu : Form
    {
        System.Media.SoundPlayer sp = new System.Media.SoundPlayer("ElecChansonDebut.wav");
        

        public Jeu()
        {
            InitializeComponent();
            sp.PlayLooping();
            
        }

        private void btnJouer_MouseEnter(object sender, EventArgs e)
        {
            panJeu.BackColor = Color.WhiteSmoke;
           
        }

        private void btnJouer_MouseLeave(object sender, EventArgs e)
        {
            panJeu.BackColor = Color.Gray;
        }

        private void btnQuitter_MouseEnter(object sender, EventArgs e)
        {
            PanQuitter.BackColor = Color.WhiteSmoke;
        }

        private void btnQuitter_MouseLeave(object sender, EventArgs e)
        {
            PanQuitter.BackColor = Color.Gray;
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnJouer_Click(object sender, EventArgs e)
        {
            MenuEntrée DebutJeu = new MenuEntrée();
            DebutJeu.ShowDialog();
           
        }
    }
}
