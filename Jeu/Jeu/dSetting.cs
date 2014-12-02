using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Jeu
{
    public partial class dSetting : Form
    {
        bool FiniJeu;

        public dSetting(bool FinDuJeu)
        {
            InitializeComponent();
            FiniJeu = FinDuJeu;

            if (FiniJeu)
                cboChoixArmes.Items.Add("Bombe Nucleaire");

            cboChoixArmes.SelectedIndex = 0;

                lbDegat.Text = (cArme.Tabarme[0]).DommageMax.ToString();
                lbPrecision.Text = (cArme.Tabarme[0]).Precision.ToString() + "%";
                lbChargeur.Text = (cArme.Tabarme[0]).Chargeur.ToString();
                lbRecharge.Text = (cArme.Tabarme[0]).TempsRecharge;
                lbNomArme.Text = (cArme.Tabarme[0]).nom;
                lbNiveauArme.Text = (cArme.Tabarme[0]).Niveau.ToString();
            
        }

        private void cboChoixArmes_SelectedIndexChanged(object sender, EventArgs e)
        {
                //choix armes
            lbDegat.Text = (cArme.Tabarme[cboChoixArmes.SelectedIndex]).DommageMax.ToString();
            lbPrecision.Text = (cArme.Tabarme[cboChoixArmes.SelectedIndex]).Precision.ToString() + "%";
            lbChargeur.Text = (cArme.Tabarme[cboChoixArmes.SelectedIndex]).Chargeur.ToString();
            lbRecharge.Text = (cArme.Tabarme[cboChoixArmes.SelectedIndex]).TempsRecharge;
            lbNomArme.Text = (cArme.Tabarme[cboChoixArmes.SelectedIndex]).nom;
            lbNiveauArme.Text = (cArme.Tabarme[cboChoixArmes.SelectedIndex]).Niveau.ToString();

                switch (cboChoixArmes.SelectedIndex)
                {
                    case 0: BoiteImage.Image = Image.FromFile("Arme\\Zat.jpg");
                        break;
                    case 1: BoiteImage.Image = Image.FromFile("Arme\\PlasmaGun.jpg");
                        break;
                    case 2: BoiteImage.Image = Image.FromFile("Arme\\Klarix.jpg");
                        break;
                    case 3: BoiteImage.Image = Image.FromFile("Arme\\Catagan.jpg");
                        break;
                    case 4: BoiteImage.Image = Image.FromFile("Arme\\TwisterGun.jpg");
                        break;
                    case 5: BoiteImage.Image = Image.FromFile("Arme\\Desintegrateur.jpg");
                        break;
                    case 6:BoiteImage.Image=Image.FromFile("Arme\\NUKE.jpg");
                    break;
                }
            
        }

        private void btnRetour_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
