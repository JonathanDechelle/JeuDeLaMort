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
    public partial class Choix_du_personage : Form
    {
        
        object[] Perso;
     
        public Choix_du_personage( ref object [] P)
        {
            InitializeComponent();
            Perso = P;
        }

        private void cboPerso_SelectedIndexChanged(object sender, EventArgs e)
        {
            ImageParRapportAuchoix(cboPerso.SelectedIndex);
        }

        void ImageParRapportAuchoix(int choix)
        {
            cPersonnage NouveauPerso=new cPersonnage(choix);
            PersoBox.Image = NouveauPerso.ImagePersonnage;
            Perso[0] = NouveauPerso.choixVoulu;
            Perso[1] = NouveauPerso.nom;
            Perso[2] = PersoBox.Image;
            Perso[3] = NouveauPerso.ImageArme;
            Perso[4] = NouveauPerso.Vie;
            if (NouveauPerso.ArmedeBase == 0)
            ((int[])Perso[5])[0] = 1;
            else
                ((int[])Perso[5])[1] = 1;
        }
 
        
     

        private void cboPerso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
