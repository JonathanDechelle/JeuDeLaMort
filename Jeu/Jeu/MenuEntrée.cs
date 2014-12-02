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
    public partial class MenuEntrée : Form
    {
        System.Media.SoundPlayer sp = new System.Media.SoundPlayer("ElecChansonDebut.wav");
        Cryptage Cripteur = new Cryptage("jhadkjhadkjhakjh");
        int ChoixPerso=-1;
        int m_Argent=0;
        //Tableau darme en possession(en style binaire 0 si la pas 1 si l'a)
        //1erpos=Zat 2ieme=PlasmaGun  3ieme=TwisterGun 4ieme=Catagan 5iem=Désintégrateur
        int []TabArme=new int[6]{0,0,0,0,0,0};
        public Univers m_Univers;
        bool Planete2;
        public MenuEntrée()
        {
            InitializeComponent();
            lbArgent.Text = m_Argent.ToString();
        }

        private void btnStats_Click(object sender, EventArgs e)
        {
            //Menu des Armes ouverture
            Setting StatsArmes = new Setting();
            StatsArmes.ShowDialog();
        }

        private void btnPerso_Click(object sender, EventArgs e)
        {
            //Menu des Perso
            Choix_du_personage Perso = new Choix_du_personage();
            Perso.ShowDialog();
            ChoixPerso = Perso.ChoixDuPerso();
            Affichage();
            btnPerso.Visible = false;
            btnSave.Enabled = true;

        }
        private void btnMagasin_Click(object sender, EventArgs e)
        {
            if (ChoixPerso == -1)
            {
                MessageBox.Show("Vous devez choisir un personnage avant de commencer", "IMPORTANT",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //Ouverture en fonction de larme de base et de largent
            
            Magasin Magasinage = new Magasin(TabArme,m_Argent);
            Magasinage.ShowDialog();
            sp.PlayLooping();
            m_Argent = Magasinage.m_Argent;
            lbArgent.Text = m_Argent.ToString();
        }


        private void btnJouer_Click(object sender, EventArgs e)
        {

            if (ChoixPerso == -1)
            {
                MessageBox.Show("Vous devez choisir un personnage avant de commencer", "IMPORTANT",
                                MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }

            
            m_Univers = new Univers(ChoixPerso,m_Argent,TabArme,Planete2);
            m_Univers.ShowDialog();
            //lorsque revenu au menu
            sp.PlayLooping();
            //Si pas ramassser dargent
            try
            {
                m_Argent = m_Univers.Argent;
            }

            catch
            {
                lbArgent.Text = m_Argent.ToString();
            }

            lbArgent.Text = m_Argent.ToString();
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            char[] InfoChar=new char[13];
            string InfoCharPourCryptage="";
            int i=0;
            string ArgentENstring=lbArgent.Text;
            FileStream fs = new FileStream("perso.txt", FileMode.Create, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(fs);

           #region Remplissage du tableau InfoChar avec differente info Joueur 

            InfoChar[0] = (char)ChoixPerso;
            //Largent doit etre lu carac par carac  la valeur ne sera jamais lu par l'écriture(valeur max 99999)
            //si millier et centaine non atteinte=0 pour eviter les erreurs dexception
           for (i = 0; i < 5; i++)
           {
               try
               {
                   InfoChar[i + 1] = ArgentENstring[i];
               }
               catch
               {
                   InfoChar[i + 1] = '\0';
               }
           }
           InfoChar[6] = (char)TabArme[0];
           InfoChar[7] = (char)TabArme[1];
           InfoChar[8] = (char)TabArme[2];
           InfoChar[9] = (char)TabArme[3];
           InfoChar[10] = (char)TabArme[4];
           InfoChar[11] = (char)TabArme[5];
           try
           {
               Planete2 = m_Univers.m_Niveau1.PLanete2Permise;
           }

           catch
           {
               Planete2 = false;
           }

           if (Planete2 == true)
               InfoChar[12] = (char)1;
           else
               InfoChar[12] = (char)0;
            #endregion

           #region Transfo char[] en string pour cryptage
           for (i = 0; i < InfoChar.Length; i++)
           {
               InfoCharPourCryptage += InfoChar[i];
           }
           #endregion 

          
           sw.Write(Cripteur.EncryptData(InfoCharPourCryptage.ToString()));
           sw.Close();
            fs.Close();
            MessageBox.Show("SAUVEGARDE ÉFFECTUÉE AVEC SUCCES");
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
           
            StreamReader sr = new StreamReader("perso.txt");
            int i = 0;
            string ArgentenString="";
            string texte = Cripteur.DecryptData(sr.ReadToEnd());

            #region analyse de la variable texte et transcription des information du joueur
            ChoixPerso = texte[0];
            for (i = 0; i < 5; i++)
            {
                ArgentenString += texte[i + 1];
            }
            m_Argent = Convert.ToInt32(ArgentenString);
            TabArme[0] = texte[6];
            TabArme[1] = texte[7];
            TabArme[2] = texte[8];
            TabArme[3] = texte[9];
            TabArme[4] = texte[10];
            TabArme[5] = texte[11];
            if (texte[12] == 1)
                Planete2 = true;
            else
                Planete2 = false;
            #endregion

            sr.Close();
            btnSave.Enabled = true;
            btnPerso.Visible = false;
            Affichage();
       }

        private void Affichage()
        {
            if (ChoixPerso == 0)
            {
                ImagePerso.Image = global::Jeu.Properties.Resources.AlienArmurelegerte;
                ImageArme.Image = global::Jeu.Properties.Resources.Zat;
                TabArme[0] = 1;//Larme zat (Tab[0]) est acheter(de base) c pour ca que la valeur est 1
            }
            else
                if (ChoixPerso == 1)
                {
                    ImagePerso.Image = global::Jeu.Properties.Resources.AlienHeavyWarrior;
                    ImageArme.Image = global::Jeu.Properties.Resources.PlasmaGun;
                    TabArme[1] = 1;//Larme plasma gun (Tab[1]) est acheter de base =1;
                }
                else
                    if (ChoixPerso == 2)
                    {
                        ImagePerso.Image = global::Jeu.Properties.Resources.AlienIngenieur;
                        ImageArme.Image = global::Jeu.Properties.Resources.PlasmaGun;
                        TabArme[1] = 1;
                    }
                    else

                        if (ChoixPerso == 3)
                        {
                            ImagePerso.Image = global::Jeu.Properties.Resources.AlienMedic;
                            ImageArme.Image = global::Jeu.Properties.Resources.Zat;
                            TabArme[0] = 1;
                        }
                        else
                            if (ChoixPerso == 4)
                            {
                                ImagePerso.Image = global::Jeu.Properties.Resources.AlienÉclaireur;
                                ImageArme.Image = global::Jeu.Properties.Resources.Zat;
                                TabArme[0] = 1;
                            }
                            else
                                if (ChoixPerso == 5)
                                {
                                    ImagePerso.Image = global::Jeu.Properties.Resources.AlienSamourai;
                                    ImageArme.Image = global::Jeu.Properties.Resources.Zat;
                                    TabArme[0] = 1;
                                }
            lbArgent.Text = m_Argent.ToString();
        }

        //Changement de couleur orange lorsque souris dessus bouton
        #region changementGraphique
        private void btnStats_MouseEnter(object sender, EventArgs e)
        {
            btnStats.ForeColor = Color.Orange;
        }

        private void btnStats_MouseLeave(object sender, EventArgs e)
        {
            btnStats.ForeColor = Color.White;
        }

        private void btnPerso_MouseEnter(object sender, EventArgs e)
        {
            btnPerso.ForeColor = Color.Orange;
        }

        private void btnPerso_MouseLeave(object sender, EventArgs e)
        {
            btnPerso.ForeColor = Color.White;
        }

        private void btnMagasin_MouseEnter(object sender, EventArgs e)
        {
            btnMagasin.ForeColor = Color.Orange;
        }

        private void btnMagasin_MouseLeave(object sender, EventArgs e)
        {
            btnMagasin.ForeColor = Color.White;
        }

        private void btnJouer_MouseEnter(object sender, EventArgs e)
        {
            btnJouer.ForeColor = Color.Orange;
        }

        private void btnJouer_MouseLeave(object sender, EventArgs e)
        {
            btnJouer.ForeColor = Color.White;

        }

        private void btnSave_MouseEnter(object sender, EventArgs e)
        {
            btnSave.ForeColor = Color.Blue;
        }

        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            btnSave.ForeColor = Color.Black;
        }

        private void btnLoad_MouseEnter(object sender, EventArgs e)
        {
            btnLoad.ForeColor = Color.Red;
        }

        private void btnLoad_MouseLeave(object sender, EventArgs e)
        {
            btnLoad.ForeColor = Color.Black;
        }
        #endregion

    }
}
