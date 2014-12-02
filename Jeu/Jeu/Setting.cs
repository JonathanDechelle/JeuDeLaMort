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
    public partial class Setting : Form
    {

        cArme TabclasseArme = new cArme("", 0, 0, 0, 0, "", 0);
        public object[] TableauArme = new object[6];
     
        public Setting()
        {
            InitializeComponent();

            TableauArme=(object[])TabclasseArme.TableauDarme();
            cboChoixArmes.SelectedIndex = 0;

            if (cboChoixArmes.SelectedIndex == 0)
            {
                lbDegat.Text = ((cArme)TableauArme[0]).DommageMin + "-" + ((cArme)TableauArme[cboChoixArmes.SelectedIndex]).DommageMax;
                lbPrecision.Text = ((cArme)TableauArme[0]).Precision.ToString() + "%";
                lbChargeur.Text = ((cArme)TableauArme[0]).Chargeur.ToString();
                lbRecharge.Text = ((cArme)TableauArme[0]).TempsRecharge;
                lbNomArme.Text = ((cArme)TableauArme[0]).nom;
                lbNiveauArme.Text = ((cArme)TableauArme[0]).Niveau.ToString();
                
            }

            

           
        }

        private void cboChoixArmes_SelectedIndexChanged(object sender, EventArgs e)
        {
            
          
                //choix armes
            lbDegat.Text = ((cArme)TableauArme[cboChoixArmes.SelectedIndex]).DommageMin + "-" + ((cArme)TableauArme[cboChoixArmes.SelectedIndex]).DommageMax;
            lbPrecision.Text = ((cArme)TableauArme[cboChoixArmes.SelectedIndex]).Precision.ToString() + "%";
            lbChargeur.Text = ((cArme)TableauArme[cboChoixArmes.SelectedIndex]).Chargeur.ToString();
            lbRecharge.Text = ((cArme)TableauArme[cboChoixArmes.SelectedIndex]).TempsRecharge;
            lbNomArme.Text = ((cArme)TableauArme[cboChoixArmes.SelectedIndex]).nom;
            lbNiveauArme.Text = ((cArme)TableauArme[cboChoixArmes.SelectedIndex]).Niveau.ToString();

                switch (cboChoixArmes.SelectedIndex)
                {
                    case 0: BoiteImage.Image = global::Jeu.Properties.Resources.Zat;
                        break;
                    case 1: BoiteImage.Image = global::Jeu.Properties.Resources.PlasmaGun;
                        break;
                    case 2: BoiteImage.Image = global::Jeu.Properties.Resources.klarix;
                        break;
                    case 3: BoiteImage.Image = global::Jeu.Properties.Resources.Catagan;
                        break;
                    case 4: BoiteImage.Image = global::Jeu.Properties.Resources.TwisterGun;
                        break;
                    case 5: BoiteImage.Image = global::Jeu.Properties.Resources.Desintregrateur;
                        break;
                   
                }
            
        }

        private void btnRetour_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
