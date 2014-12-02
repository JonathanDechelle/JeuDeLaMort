using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
namespace Jeu
{
    public partial class dJeu : Form
    {
        SoundPlayer sp = new System.Media.SoundPlayer("Musique\\ElecChansonDebut.wav");
     
        public dJeu()
        {
            InitializeComponent();
            sp.PlayLooping(); 
        }

        #region Interaction graphique btnJouer,Quitter
        private void btnJouer_MouseEnter(object sender, EventArgs e)
        {
            panJeu.BackColor = Color.WhiteSmoke;
        }

        private void btnQuitter_MouseEnter(object sender, EventArgs e)
        {
            PanQuitter.BackColor = Color.WhiteSmoke;
        }

        private void dJeu_MouseMove(object sender, MouseEventArgs e)
        {
            PanQuitter.BackColor = Color.Gray;
            panJeu.BackColor = Color.Gray;
        }
        #endregion

        private void btnJouer_Click(object sender, EventArgs e)
        {
            dJeu.ActiveForm.Visible = false;
            dMenuEntrée DebutJeu = new dMenuEntrée();
            DebutJeu.ShowDialog();
        }

        //quitte l'application
        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    

       
    }
}
