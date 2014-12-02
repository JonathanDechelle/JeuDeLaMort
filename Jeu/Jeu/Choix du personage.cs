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
        int m_choix;

        public Choix_du_personage()
        {
            InitializeComponent();
        }

        private void cboPerso_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cboPerso.SelectedIndex == 0)
            {
                PersoBox.Image = global::Jeu.Properties.Resources.AlienArmurelegerte;
                m_choix = 0;
            }
            else
                if (cboPerso.SelectedIndex == 1)
                {
                    PersoBox.Image = global::Jeu.Properties.Resources.AlienHeavyWarrior;
                    m_choix = 1;
                }
                else
                    if (cboPerso.SelectedIndex == 2)
                    {
                        PersoBox.Image = global::Jeu.Properties.Resources.AlienIngenieur;
                        m_choix = 2;
                    }
                    else

                        if (cboPerso.SelectedIndex == 3)
                        {
                            PersoBox.Image = global::Jeu.Properties.Resources.AlienMedic;
                            m_choix = 3;
                        }
                        else
                            if (cboPerso.SelectedIndex == 4)
                            {
                                PersoBox.Image = global::Jeu.Properties.Resources.AlienÉclaireur;
                                m_choix = 4;
                            }
                            else
                                if (cboPerso.SelectedIndex == 5)
                                {
                                    PersoBox.Image = global::Jeu.Properties.Resources.AlienSamourai;
                                    m_choix = 5;
                                }
        }

        public int ChoixDuPerso()
        {
            return m_choix;
        }

     

        private void cboPerso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.Close();
            }
        }
    }
}
