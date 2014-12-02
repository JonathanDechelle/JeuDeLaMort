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
    public partial class dMenuEntrée : Form
    {
        #region variable utilisées

        System.Media.SoundPlayer sp = new System.Media.SoundPlayer("Musique\\ElecChansonDebut.wav");
        cCryptage Cripteur = new cCryptage("jhadkjhadkjhakjh");
        dUnivers m_Univers;
        #region nom,Perso,Niveau,Argent,Exp,Rune,Vie,bool Planete ,Image
        string nom="Aucun Nom Défini";
        int ChoixPerso=-1;
        int Niveau=1;
        int m_Argent=0;
        int Experience = 0;
        int Rune1 = 0, Rune2 = 0;
        int NbCoupPrMagieVie = 0;
        int Vie=0;
        bool Planete2, Planete3,Planete4;
        Image ImagePersonnage = null, ImageArme = null;
        #endregion 
        #region tableaux
        //Tableau darme en possession(en style binaire 0 si la pas 1 si l'a)
        //1erpos=Zat 2ieme=PlasmaGun  3ieme=TwisterGun 4ieme=Catagan 5iem=Désintégrateur
        int[] TabArme = new int[7] { 0, 0, 0, 0, 0, 0,0 };
        int[] TabArmeNiveau = new int[6] { 1, 1, 1, 1, 1, 1 };
        object[] PersoComplet=new object[11];
        #endregion
        bool FiniJeu;
        #endregion

        public dMenuEntrée()
        {
            InitializeComponent();
            
            #region Initialisation Variable object PersoComplet
            PersoComplet[0] = ChoixPerso;
            PersoComplet[1] = nom;
            PersoComplet[2] = ImagePersonnage;
            PersoComplet[3] = ImageArme;
            PersoComplet[4] = Vie;
            PersoComplet[5] = TabArme;
            PersoComplet[6] = m_Argent;
            PersoComplet[7] = Experience;
            PersoComplet[8] = NbCoupPrMagieVie;
            PersoComplet[9] = Niveau;
            PersoComplet[10] = TabArmeNiveau;
            #endregion
            lbArgent.Text = m_Argent.ToString();
            lbNiveau.Text = Niveau.ToString();
        }        

        #region evenement avec les differents bouton
    
        private void btnStats_Click(object sender, EventArgs e)
        {
            
            //Menu des Armes ouverture
            dSetting StatsArmes = new dSetting(FiniJeu);
            StatsArmes.ShowDialog();
        }

        private void btnPerso_Click(object sender, EventArgs e)
        {
            //Menu des Perso
            Choix_du_personage Perso = new Choix_du_personage(ref PersoComplet);
            if (DialogResult.OK == Perso.ShowDialog())
            {
                Affichage();
                btnPerso.Visible = false;
                btnSave.Enabled = true;
                btnMagasinArtefacts.Visible = true;
            }
        }

        private void btnMagasin_Click(object sender, EventArgs e)
        {
            if ((int)PersoComplet[0] == -1)
            {
                MessageBox.Show("Vous devez choisir un personnage avant de commencer", "IMPORTANT",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //Ouverture en fonction de larme de base et de largent
            dMagasin Magasinage = new dMagasin(TabArme,m_Argent);
            Magasinage.ShowDialog();
            sp.PlayLooping();
            m_Argent = Magasinage.m_Argent;
            PersoComplet[6] = m_Argent;
            lbArgent.Text = m_Argent.ToString();
            }

        private void btnMagasinArtefacts_Click(object sender, EventArgs e)
        {
            //Boutique dartéfact
            if (Planete3 == true)
            {
                dMagasinRunes MagasinRune = new dMagasinRunes(m_Argent, Rune1, Rune2);
                MagasinRune.ShowDialog();
                #region si a rune1 ....rune1 = 1
                if (MagasinRune.Rune1Enpossesion == 1)
                {
                    pbRune1.Image = Image.FromFile("Runes\\Rune4.jpg");
                    Rune1 = 1;
                }
                #endregion
                #region  si a rune2 ....rune2 = 1
                if (MagasinRune.Rune2Enpossession == 1)
                {
                    pbRune2.Image = Image.FromFile("Runes\\Rune1.jpg"); 
                    Rune2 = 1;
                }
                #endregion
                m_Argent = MagasinRune.Argent;
                lbArgent.Text = m_Argent.ToString();
                PersoComplet[6] = m_Argent;
                sp.PlayLooping();
                }
            else
            {
                MessageBox.Show("Le Magasin d'artéfact n'ai que disponible si le 2ieme boss est battu",
                                "Désolé",
                                 MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void btnJouer_Click(object sender, EventArgs e)
        {
            if ((int)PersoComplet[0] == -1)
            {
                MessageBox.Show("Vous devez choisir un personnage avant de commencer", "IMPORTANT",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            m_Univers = new dUnivers(PersoComplet,Planete2, Planete3,Planete4,Rune1,Rune2);
            m_Univers.ShowDialog();
            //lorsque revenu au menu
            sp.PlayLooping();
            #region Erreur gerer Argent gagner et planete débloqué + experience + niveau
            #region Argent
            try
            {
                m_Argent =m_Univers.Argent;
            }

            catch
            {
                lbArgent.Text = m_Argent.ToString();
            }
            lbArgent.Text = m_Argent.ToString();
            #endregion
            #region Niveau
            try
            {
                Niveau = m_Univers.NiveauPerso;
            }

            catch
            {
                lbNiveau.Text = Niveau.ToString();
            }
            lbNiveau.Text = Niveau.ToString();
            #endregion
            #region planete2
            try
            {
                Planete2 = m_Univers.Planete2;
            }

            catch
            {
                Planete2 = false;
            }
            #endregion
            #region planete3
            try
            {
                Planete3=m_Univers.Planete3;
            }

            catch
            {
                Planete3=false;
            }
            #endregion
            #region planete4
            try
            {
                Planete4 = m_Univers.Planete4;
            }

            catch
            {
                Planete4 = false;
            }
            #endregion
            #region fin du jeu
            try
            {
                FiniJeu = m_Univers.m_Niveau4.FIN;
            }
            catch
            {
                FiniJeu = false;
            }
#endregion
            #endregion
            TabArmeNiveau = m_Univers.ArmeNiveau;
            PersoComplet[6] = m_Argent;
            PersoComplet[7] = m_Univers.Experience;
            PersoComplet[9] = Niveau;
            PersoComplet[10] = TabArmeNiveau;
         
            if (FiniJeu)
            {
                ((int[])PersoComplet[5])[6] = 1;
            }
            }

        private void btnSave_Click(object sender, EventArgs e)
        {
            #region variable de stokage et ecriture
            char[] InfoChar = new char[32];
            string InfoCharPourCryptage = "";
            int i = 0;
            string VieEnstring = PersoComplet[4].ToString();
            string ArgentENstring = lbArgent.Text;
            string ExperienceEnstring = PersoComplet[7].ToString();
            FileStream fs = new FileStream("perso.txt", FileMode.Create, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(fs);
            #endregion

            #region Remplissage du tableau InfoChar avec differente info Joueur
            InfoChar[0] = Convert.ToChar(PersoComplet[0]);
            #region traitement Argent
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
            #endregion
            #region tabarme
            InfoChar[6] = (char)TabArme[0];
            InfoChar[7] = (char)TabArme[1];
            InfoChar[8] = (char)TabArme[2];
            InfoChar[9] = (char)TabArme[3];
            InfoChar[10] = (char)TabArme[4];
            InfoChar[11] = (char)TabArme[5];
            #endregion
            #region deverouillement planete 2 et 3
            if (Planete2 == true)
                InfoChar[12] = (char)1;
            else
                InfoChar[12] = (char)0;

            if (Planete3 == true)
                InfoChar[13] = (char)1;
            else
                InfoChar[13] = (char)0;
            #endregion
            #region Traitement experience
            for (i = 14; i < 18; i++)
            {
                try
                {
                    InfoChar[i] = ExperienceEnstring[i - 14];
                }
                catch
                {
                    InfoChar[i] = '\0';
                }
            }

            #endregion
            #region Rune
            if (Rune1 == 1)
                InfoChar[18] = (char)1;
            else
                InfoChar[18] = (char)0;
            if (Rune2 == 1)
                InfoChar[19] = (char)1;
            else
                InfoChar[19] = (char)0;
            #endregion
            InfoChar[20] = Convert.ToChar(PersoComplet[9]);
            #region TabArmeNiveau
            InfoChar[21] = (char)TabArmeNiveau[0];
            InfoChar[22] = (char)TabArmeNiveau[1];
            InfoChar[23] = (char)TabArmeNiveau[2];
            InfoChar[24] = (char)TabArmeNiveau[3];
            InfoChar[25] = (char)TabArmeNiveau[4];
            InfoChar[26] = (char)TabArmeNiveau[5];
            #endregion
            #region Vie
            {
                for (i = 27; i < 30; i++)
                {
                    try
                    {
                        InfoChar[i] = VieEnstring[i-27];
                    }
                    catch
                    {
                        InfoChar[i] = '\0';
                    }
                }
            }
            #endregion
            #region deverouillement planete finale
            if (Planete4 == true)
                InfoChar[30] = (char)1;
            else
                InfoChar[30] = (char)0;
            #endregion
            #region NUKE
            InfoChar[31] = (char)TabArme[6];
            #endregion
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
            #region variable de lecture
            StreamReader sr = new StreamReader("perso.txt");
            int i = 0;
            string ArgentenString = "";
            string Experienceenstring = "";
            string VieenString = "";
            string texte = Cripteur.DecryptData(sr.ReadToEnd());
            if (texte == null)
                return;
            #endregion
             
            #region analyse de la variable texte et transcription des information du joueur
            PersoComplet[0] = Convert.ToInt32(texte[0]);
            #region Traitement Argent
            for (i = 0; i < 5; i++)
            {
                ArgentenString += texte[i + 1];
            }
            m_Argent = Convert.ToInt32(ArgentenString);
            #endregion
            #region tabarme
            TabArme[0] = texte[6];
            TabArme[1] = texte[7];
            TabArme[2] = texte[8];
            TabArme[3] = texte[9];
            TabArme[4] = texte[10];
            TabArme[5] = texte[11];
            #endregion
            #region Acces au planete 2 et 3
            if (texte[12] == 1)
                Planete2 = true;
            else
                Planete2 = false;
            if (texte[13] == 1)
                Planete3 = true;
            else
                Planete3 = false;
            #endregion
            #region Traitement experience
            for (i = 14; i < 18; i++)
            {
              Experienceenstring+=texte[i];  
            }
            Experience = Convert.ToInt32(Experienceenstring);
            #endregion
            #region Rune
            if (texte[18] == 1)
                Rune1 = 1;
            else
                Rune1 = 0;
            if (texte[19] == 1)
                Rune2 = 1;
            else
                Rune2 = 0;
            #endregion 
            Niveau = Convert.ToInt32(texte[20]);
            #region tabarme Niveau
            TabArmeNiveau[0] = texte[21];
            TabArmeNiveau[1] = texte[22];
            TabArmeNiveau[2] = texte[23];
            TabArmeNiveau[3] = texte[24];
            TabArmeNiveau[4] = texte[25];
            TabArmeNiveau[5] = texte[26];
            #endregion
            #region Traitement Vie
            for (i = 27; i < 30; i++)
            {
                VieenString += texte[i];
            }
            Vie = Convert.ToInt32(VieenString);
            #endregion
            #region Acces au planete 2 et 3
            if (texte[30] == 1)
                Planete4 = true;
            else
                Planete4= false;
            #endregion
            TabArme[6] = texte[31];
            if (TabArme[6] == 1)
            {
                FiniJeu = true;
            }
            #endregion

            sr.Close();
            btnSave.Enabled = true;
            btnPerso.Visible = false;
            btnMagasinArtefacts.Visible = true;
            Affichage();
        }

        private void btnOption_Click(object sender, EventArgs e)
        {
            btnStats.Visible = true;
            btnSave.Visible = true;
            btnLoad.Visible = true;
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
          
        }
            #endregion
   
       


         //Changement de couleur orange lorsque souris dessus bouton
         #region changementGraphique
         private void btnStats_MouseEnter(object sender, EventArgs e)
        {
            ReinitialisationForm();
            btnStats.ForeColor = Color.Orange;
        }

        private void btnPerso_MouseEnter(object sender, EventArgs e)
        {
            ReinitialisationForm();
            btnPerso.ForeColor = Color.Orange;
            SousBoutonOption(false);
        }


        private void btnMagasin_MouseEnter(object sender, EventArgs e)
        {
            ReinitialisationForm();
            btnMagasin.ForeColor = Color.Orange;
            SousBoutonOption(false);
        }

       

        private void btnJouer_MouseEnter(object sender, EventArgs e)
        {
            ReinitialisationForm();
            btnJouer.ForeColor = Color.Orange;
            SousBoutonOption(false);
        }

      
        private void btnSave_MouseEnter(object sender, EventArgs e)
        {
            ReinitialisationForm();
            btnSave.ForeColor = Color.Blue;
        }

        private void btnLoad_MouseEnter(object sender, EventArgs e)
        {
            ReinitialisationForm();
            btnLoad.ForeColor = Color.Red;
        }

   
        private void btnMagasinArtefacts_MouseEnter(object sender, EventArgs e)
        {
            ReinitialisationForm();
            btnMagasinArtefacts.ForeColor = Color.Orange;
            SousBoutonOption(false);
        }

       

        private void btnQuitter_MouseEnter(object sender, EventArgs e)
        {
            ReinitialisationForm();
            btnQuitter.ForeColor = Color.Red;
            SousBoutonOption(false);
        }

       
        private void btnOption_MouseEnter(object sender, EventArgs e)
        {
            ReinitialisationForm();
            btnOption.ForeColor = Color.Orange;
            SousBoutonOption(true);
        }

        private void dMenuEntrée_MouseMove(object sender, MouseEventArgs e)
        {
            ReinitialisationForm();
        }


         #endregion
         #region Fonction
        private void Affichage()
        {
            cPersonnage P = new cPersonnage((int)PersoComplet[0]);
            PersoComplet[0] = Convert.ToInt32(P.choixVoulu);
            PersoComplet[1] = P.nom;
            PersoComplet[2] = P.ImagePersonnage;
            PersoComplet[3] = P.ImageArme;
            if (Vie == 0)
                PersoComplet[4] = P.Vie;
            else
                PersoComplet[4] = Vie;
            pbImagePerso.Image = (Image)PersoComplet[2];
            pbImageArme.Image = (Image)PersoComplet[3];
            PersoComplet[5] = TabArme;
            PersoComplet[6] = m_Argent;
            PersoComplet[7] = Experience;
            PersoComplet[8] = P.NbCoupPourSoin;
            PersoComplet[9] = Niveau;
            PersoComplet[10] = TabArmeNiveau;
            lbArgent.Text = m_Argent.ToString();
            lbNiveau.Text = Niveau.ToString();

            #region affichageRune
            if (Rune1 == 1)
                pbRune1.Image = Image.FromFile("Runes\\Rune4.jpg");
            else
                pbRune1.Image = null;

            if (Rune2 == 1)
                pbRune2.Image = Image.FromFile("Runes\\Rune1.jpg");
            else
                pbRune2.Image = null;
            #endregion
            // reset du tableau d'arme
            cArme.ResetTableau();

            //changement reference arme pour degat niveau
            for (int i = 0; i < TabArmeNiveau.Length; i++)
            {
                
                cArme.Tabarme[i].Niveau = TabArmeNiveau[i];
                if (TabArmeNiveau[i] > 1)
                    cArme.Tabarme[i].DommageMax += (3 * (TabArmeNiveau[i] - 1));
            }
        }
        private void SousBoutonOption(bool Activate)
        {
            if (Activate)
            {
                btnStats.Visible = true;
                btnLoad.Visible = true;
                btnSave.Visible = true;
            }
            else
            {
                btnStats.Visible = false;
                btnLoad.Visible = false;
                btnSave.Visible = false;
            }
        }
        private void ReinitialisationForm()
        {
            btnStats.ForeColor = Color.White;
            btnPerso.ForeColor = Color.White;
            btnMagasin.ForeColor = Color.White;
            btnJouer.ForeColor = Color.White;
            btnMagasinArtefacts.ForeColor = Color.White;
            btnQuitter.ForeColor = Color.White;
            btnOption.ForeColor = Color.White;
            btnLoad.ForeColor = Color.Black;
            btnSave.ForeColor = Color.Black;

        }
        #endregion




    }
}
