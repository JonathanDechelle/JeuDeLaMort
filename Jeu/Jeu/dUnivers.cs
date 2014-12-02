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
    public partial class dUnivers : Form
    {
        #region variable utilisés
        public int Perso, Argent,Experience,NiveauPerso=1,ArmeChoisi;
        public int Rune1, Rune2;
        public bool Planete2, Planete3,Planete4;
        public dMonde_1 m_Niveau1;
        public Monde_2 m_Niveau2;
        public dMonde_3 m_Niveau3;
        public dNiveauFinale m_Niveau4;
        private dChoixArmeCombat ArméCombat;
        private cGrilleNiveau GrilleRefNiveau;
        private SoundPlayer sp = new System.Media.SoundPlayer("Musique\\Electro.wav");
        object[] PersoComplet;
        public int[] ArmeNiveau;
       
        #endregion

       public dUnivers(object[] PComplet,bool AccesMonde2,bool AccesMonde3,bool AccesMonde4,int R1,int R2)
        {
           
            InitializeComponent();
            #region Initialisation + parution du monde 2 et 3
            PersoComplet = PComplet;
            Perso = (int)PComplet[0];
            Argent =(int)PComplet[6];
            Experience = (int)PComplet[7];
            NiveauPerso = (int)PComplet[9];
            ArmeNiveau = (int[])PComplet[10];
            Planete2 = AccesMonde2;
            Planete3 = AccesMonde3;
            Planete4 = AccesMonde4;
            //Planete4 = AccesMonde4;
            Rune1 = R1;
            Rune2 = R2;
            if (Planete2 == true)
                pbPlanete2.Visible = true;
            if (Planete3 == true)
                pbPlanete3.Visible = true;
            if (Planete4 == true)
            {
                pbPlanete1.Visible = false;
                pbPlanete2.Visible = false;
                pbPlanete3.Visible = false;
                RotationPlaneteFinale.Start();
            }
            GrilleRefNiveau= new cGrilleNiveau(Experience,NiveauPerso);
            #endregion
            DeplacementPlanete(true);
            sp.PlayLooping();
        }

        #region Label et Timer (interactions graphiques)
        #region Modification et comportement du label de sortie
        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.Font = new System.Drawing.Font("Pristina", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.Font = new System.Drawing.Font("Pristina", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }
        #endregion
        #region interaction label grille de reference level
        private void lbrefGrille_Click(object sender, EventArgs e)
        {
            string GrilleNivString = "";
            for (int i = 0; i < cGrilleNiveau.TabledeNiveau.Length; i++)
            {
                if (i == 0)
                    GrilleNivString += string.Format("NIVEAU 1         de {1} a {2}\n", i + 1, 0, cGrilleNiveau.TabledeNiveau[i]);
                else
                    GrilleNivString += string.Format("NIVEAU {0}        de {1} a {2}\n", i + 1, cGrilleNiveau.TabledeNiveau[i - 1], cGrilleNiveau.TabledeNiveau[i]);

            }
            MessageBox.Show(GrilleNivString,"EXPÉRIENCE POUR CHAQUE NIVEAU       ");
        }

        private void lbrefGrille_MouseEnter(object sender, EventArgs e)
        {
            lbrefGrille.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void lbrefGrille_MouseLeave(object sender, EventArgs e)
        {
            this.lbrefGrille.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }
        #endregion
        #region Timer de deplacement
        private void Rotation_Tick(object sender, EventArgs e)
        {
            Point Coordonnée = pbPlanete1.Location;
            #region deplacement planete 1
            Coordonnée.Y += 4;
            pbPlanete1.Location = Coordonnée;
            #endregion
            #region Si limite de fenetre atteinte
            if (pbPlanete1.Location.Y > ClientSize.Height)
            {
                Coordonnée = pbPlanete1.Location;
                Coordonnée.Y = 0;
                pbPlanete1.Location = Coordonnée;
            }
            #endregion
        }
        private void RotationP2_Tick(object sender, EventArgs e)
        {
            Point Coordonnée = pbPlanete2.Location;
            #region deplacement planete2
            Coordonnée.Y += 2;
            pbPlanete2.Location = Coordonnée;
#endregion
            #region Si limite atteinte
            if (pbPlanete2.Location.Y > ClientSize.Height)
            {
                Coordonnée = pbPlanete2.Location;
                Coordonnée.Y = 0;
                pbPlanete2.Location = Coordonnée;

            }
            #endregion
        }
        private void RotationP3_Tick(object sender, EventArgs e)
        {
            Point Coordonnée = pbPlanete3.Location;
            #region deplacement planete3
            Coordonnée.Y -= 3;
            pbPlanete3.Location = Coordonnée;
            #endregion
            #region Si limite atteinte
            if (pbPlanete3.Location.Y+pbPlanete3.Height < 0)
            {
                Coordonnée = pbPlanete3.Location;
                Coordonnée.Y = ClientSize.Height;
                pbPlanete3.Location = Coordonnée;

            }
            #endregion
        }
        private void RotationPlaneteFinale_Tick(object sender, EventArgs e)
        {
            Point Coordonnée = pbSoleil.Location;
            #region deplacement planete3
            Coordonnée.X += 3;
            pbSoleil.Location = Coordonnée;
            #endregion
            #region Si limite atteinte
            if (pbSoleil.Location.X  > ClientSize.Width)
            {
                Coordonnée = pbSoleil.Location;
                Coordonnée.X = 0;
                pbSoleil.Location = Coordonnée;

            }
            #endregion
        }
        #endregion 
        #endregion

        private void dUnivers_MouseMove(object sender, MouseEventArgs e)
        {
            lbPlanete.Text = "";
        }

        #region Attrait de planete 1

        private void IPlanete1_Click(object sender, EventArgs e)
        {
            DeplacementPlanete(false);
            ChoixArmeCombat();

            m_Niveau1 = new dMonde_1(PersoComplet, ArmeChoisi, Planete2, Rune1, Rune2);
            m_Niveau1.ShowDialog();

            #region Planete2Permise ? et Pour aller au menu direct ?
            if (m_Niveau1.PLanete2Permise == true)
            {
                pbPlanete2.Visible = true;
                Planete2 = true;
            }
            if (m_Niveau1.PourAllerAuMenuDirect() == true)
            {
                DeplacementPlanete(false);
                MiseEnPlace_Argent_Exp(1);
                VérificationGrilleNiveau();
                this.Close();
                return;
            }
            #endregion
            DeplacementPlanete(true);
            //Argent et expérience gagné
            MiseEnPlace_Argent_Exp(1);
            VérificationGrilleNiveau();
            sp.PlayLooping();
        }
        private void IPlanete1_MouseEnter(object sender, EventArgs e)
        {
            lbPlanete.Text = "Xakara";
        }

        #endregion
        #region attrait planete 2

        private void pbPlanete2_MouseEnter(object sender, EventArgs e)
        {
            lbPlanete.Text = "Nova Klam";
        }
        private void pbPlanete2_Click(object sender, EventArgs e)
        {
            DeplacementPlanete(false);
            ChoixArmeCombat();

            m_Niveau2 = new Monde_2(PersoComplet,ArmeChoisi,Planete3,Rune1,Rune2);
            m_Niveau2.ShowDialog();
         
            #region Planete 3 Permise ? et pour aller au menu direct ?
            if (m_Niveau2.PourAllerAuMenuDirect() == true)
            {
                DeplacementPlanete(false);
                MiseEnPlace_Argent_Exp(2);
                VérificationGrilleNiveau();
                this.Close();
                return;
            }
            if (m_Niveau2.PLanete3Permise == true)
            {
                pbPlanete3.Visible = true;
                Planete3 = true;
            }
            #endregion
            DeplacementPlanete(true);
            MiseEnPlace_Argent_Exp(2);
            VérificationGrilleNiveau();
            sp.PlayLooping();
        }

        #endregion
        #region attrait planete 3

        private void pbPlanete3_MouseEnter(object sender, EventArgs e)
        {
            lbPlanete.Text = "Nesda";
        }

        private void pbPlanete3_Click(object sender, EventArgs e)
        {
            DeplacementPlanete(false);
            ChoixArmeCombat();
            m_Niveau3 = new dMonde_3(PersoComplet,ArmeChoisi, Planete4, Rune1, Rune2);
            m_Niveau3.ShowDialog();

            #region Planete finale Permise ? et pour aller au menu direct ?
            if (m_Niveau3.PourAllerAuMenuDirect() == true)
            {
                DeplacementPlanete(false);
                MiseEnPlace_Argent_Exp(3);
                VérificationGrilleNiveau();
                this.Close();
                return;
            }

            if (m_Niveau3.PLanete4Permise == true)
            {
                Planete4 = true;
                RotationPlaneteFinale.Start();
                pbPlanete1.Visible = false;
                pbPlanete2.Visible = false;
                pbPlanete3.Visible = false;
            }
            #endregion
            DeplacementPlanete(true);
            MiseEnPlace_Argent_Exp(3);
            VérificationGrilleNiveau();
            sp.PlayLooping();
        }
        #endregion 
        #region attrait planete 4

        private void pbSoleil_MouseEnter(object sender, EventArgs e)
        {
            lbPlanete.Text = "AMADÉUS";
        }

        private void pbSoleil_Click(object sender, EventArgs e)
        {
            RotationPlaneteFinale.Stop();
            ChoixArmeCombat();
            m_Niveau4 = new dNiveauFinale(PersoComplet, ArmeChoisi, Rune1, Rune2);
            m_Niveau4.ShowDialog();

            #region Planete finale Permise ? et pour aller au menu direct ?
            if (m_Niveau4.PourAllerAuMenuDirect() == true)
            {
                DeplacementPlanete(false);
                MiseEnPlace_Argent_Exp(4);
                VérificationGrilleNiveau();
                this.Close();
                return;
            }
            if (m_Niveau4.FIN)
            {
                dUnivers.ActiveForm.Visible = false;
                dCredits Finale = new dCredits();
                Finale.ShowDialog();
            }
            #endregion
            RotationPlaneteFinale.Start();
            MiseEnPlace_Argent_Exp(4);
            VérificationGrilleNiveau();
            sp.PlayLooping();
        }
        #endregion 

        #region fonction
        private void ChoixArmeCombat()
        {
            //ouvre le dialogue de choix darme (retourneArmechoisi=Donne larme choisit)
            ArméCombat = new dChoixArmeCombat((int)PersoComplet[0], (Image)PersoComplet[3], (int[])PersoComplet[5]);
            ArméCombat.ShowDialog();
            ArmeChoisi = ArméCombat.RetourneArmeChoisi();
        }
        private void VérificationGrilleNiveau()
        {
            //regarde dans la grille de niveau
            GrilleRefNiveau = new cGrilleNiveau(Experience, NiveauPerso);
           
            if (GrilleRefNiveau.MonterNiv())
            {
                //choix perso , image de base arme, point de vie,tabArme envoyés en argument
                dLevelUp upgrade = new dLevelUp((int)PersoComplet[0],(Image)PersoComplet[3], (int)PersoComplet[4], (int[])PersoComplet[5]);
                upgrade.ShowDialog();
                
                NiveauPerso++;
                PersoComplet[4] = upgrade.UpgradeDeVie;
                ArmeNiveau = upgrade.UpgradeDeDegatArme();
            }
        }
        private void DeplacementPlanete(bool AcceptMove)
        {
            if (AcceptMove)
            {
                Rotation.Start();
                RotationP2.Start();
                RotationP3.Start();
            }
            else
            {
                Rotation.Stop();
                RotationP2.Stop();
                RotationP3.Stop();
            }

        }
        private void MiseEnPlace_Argent_Exp(int NiveauChoisi)
        {
            switch (NiveauChoisi)
            {
                case 1: Argent=m_Niveau1.m_Argent;
                    Experience = m_Niveau1.m_Experience;
                    break;
                case 2: Argent = m_Niveau2.m_Argent;
                    Experience = m_Niveau2.m_Experience;
                    break;
                case 3: Argent = m_Niveau3.m_Argent;
                    Experience = m_Niveau3.m_Experience;
                    break;
                case 4: Argent = m_Niveau4.m_Argent;
                    Experience = m_Niveau4.m_Experience;
                    break;
            }

            //mise dans le tableau 
            PersoComplet[6] = Argent;
            PersoComplet[7] = Experience;
        }
        #endregion

        

        

      

       

    }
}
