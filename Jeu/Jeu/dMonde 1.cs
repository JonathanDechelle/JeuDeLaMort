using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace Jeu
{
    public partial class dMonde_1 : Form
    {
        #region variable utiliséés
      /*Choix*/       private int m_Nbchoisideja,m_NumeroMonstre;
      /*Vie*/         private int m_VieMechant,m_ViePerso;
      /*Combat*/      private int NumAction, Attack, ActionAttackmechant, ActionDefensemechant;
    /*arme acquise*/  private int ArmeChoisi;
      /*BOSS*/        private int m_NbrestantMonstreBoss = 3;
      /*Rune*/        private int Rune1, Rune2;
/*Compteur pr rune*/  private int Paralysie = 3, Soin = 0;
  /* Soin Activée*/   private bool SoinActif = false;
/*   Pour GbArme */   private bool Ouvert = false;
   /*ARGENT*/         public int m_Argent;
    /*Experience*/    public int m_Experience;
  /*   ACCES    */    public bool PLanete2Permise;
  /*2iemePLanete*/

        #region classe
  /*SONS*/            private SoundPlayer sp = new System.Media.SoundPlayer("Musique\\FFfight1.wav");
/* mechant choisi*/   private cMonstre m_monstreChoisi;
/*Aleatoire*/         private Random r = new Random();
   #endregion
        #endregion
        #region tableaux tuilisés
        //Different tableau
        private cMonstre []TabMonstre=new cMonstre[5];
        private object[] TabActions = new object[2];
        private object[] PersonnageComplet;
        #endregion
      

        public dMonde_1()
        {
            InitializeComponent();
        }

        public dMonde_1(object []Pcomplet,int WeaponSelected,bool P2,int R1,int R2):this()
        {
            sp.PlayLooping();
            PersonnageComplet = Pcomplet;
            #region Initialisation Arme choix perso + Argent 
            m_Argent = (int)Pcomplet[6];
            lbArgent.Text = m_Argent.ToString();
            ArmeChoisi = WeaponSelected;
            #endregion
            #region Experience et Planete + Rune
            m_Experience = (int)Pcomplet[7];
            lbExperience.Text = m_Experience.ToString();
            PLanete2Permise = P2;
            Rune1 = R1;
            Rune2 = R2;
            #endregion
            #region Soin
            Soin = (int)PersonnageComplet[8];
            #endregion
            #region Initialisation globale Premier combat en ouvrant la forme
            //Choix du personnage;
            #region choixPerso
            pbPerso.Image = (Image)Pcomplet[2];
            #endregion

            //Choix darmes (avec l'arme Choisi)
            #region ChoixArme
            switch (ArmeChoisi)
            {
                case 0:
                    pbArme1.Image = Image.FromFile("Arme\\Zat.jpg");
                    lbArmeEncours.Text = "ZAT";
                    lbDommageArmeEncours.Text = (cArme.Tabarme[0]).DommageMax.ToString();
                    break;
                case 1:
                    pbArme1.Image = Image.FromFile("Arme\\PlasmaGun.jpg");
                    lbArmeEncours.Text = "PLASMA GUN";
                    lbDommageArmeEncours.Text = (cArme.Tabarme[1]).DommageMax.ToString();
                    break;
                case 2:
                    pbArme1.Image = Image.FromFile("Arme\\Klarix.jpg");
                    lbArmeEncours.Text = "Klarix";
                    lbDommageArmeEncours.Text = (cArme.Tabarme[2]).DommageMax.ToString();

                    break;
                case 3:
                    pbArme1.Image = Image.FromFile("Arme\\Catagan.jpg");
                    lbArmeEncours.Text = "Catagan";
                    lbDommageArmeEncours.Text = (cArme.Tabarme[3]).DommageMax.ToString();
                    break;
                case 4:
                    pbArme1.Image = Image.FromFile("Arme\\TwisterGun.jpg");
                    lbArmeEncours.Text = "Twister Gun";
                    lbDommageArmeEncours.Text = (cArme.Tabarme[4]).DommageMax.ToString();
                    break;
                case 5:
                    pbArme1.Image = Image.FromFile("Arme\\Desintegrateur.jpg");
                    lbArmeEncours.Text = "Désintégrateur";
                    lbDommageArmeEncours.Text = (cArme.Tabarme[5]).DommageMax.ToString();
                    break;
                case 6:
                    pbArme1.Image = Image.FromFile("Arme\\NUKE.jpg");
                    lbArmeEncours.Text = "Bombe";
                    lbDommageArmeEncours.Text = (cArme.Tabarme[6]).DommageMax.ToString();
                    break;

            }
          
            #endregion

            //rune en main et bouton magie
            #region Rune/Initialisation Bouton Magie
            if (Rune1 == 1)
            {
                pbRune1.Image = Image.FromFile("Runes\\Rune4.jpg");
                pbRune1.Visible = true;
                btnSoin.Visible = true;
            }
            if (Rune2 == 1)
            {
                pbRune2.Image = Image.FromFile("Runes\\Rune1.jpg");
                pbRune2.Visible = true;
            }
            #endregion

            //initialisateur de vie perso
            #region InitialisateurviePerso
            m_ViePerso = (int)Pcomplet[4];
            BarreVie.Step = m_ViePerso;
            BarreVie.Maximum = m_ViePerso;
            BarreVie.PerformStep();
            lbViePerso.Text = ((int)Pcomplet[4]).ToString() + "/" + ((int)Pcomplet[4]).ToString();
            #endregion

            ///Choix mechant
            ///initialisateur
            #region ChoixMechant + InitialisateurvieMechant
            TabMonstre[0] = new cMonstre("Alastor", 30, 40, 5, 40, Image.FromFile("Mechant.Marchand\\Mechant1.jpg"));
            TabMonstre[1] = new cMonstre("Scorn", 50, 20, 5, 30,Image.FromFile("Mechant.Marchand\\Mechant2.jpg"));
            TabMonstre[2] = new cMonstre("Kragoth", 60, 15, 10, 20,Image.FromFile("Mechant.Marchand\\Mechant3.jpg"));
            TabMonstre[3] = new cMonstre("Nasir", 40, 15, 5, 10, Image.FromFile("Mechant.Marchand\\Mechant4.jpg"));// Vie Attack defense- xp-
            TabMonstre[4] = new cMonstre("Ashnard (BOSS)", 100, 50, 10, 70, Image.FromFile("Mechant.Marchand\\Boss1.jpg"));//BOSS
            
            m_NumeroMonstre = ChoisirHasardMechant();
            m_monstreChoisi = ((cMonstre)TabMonstre[m_NumeroMonstre]);
           
            #endregion

            //actions initialisateur 
            #region ActionMechantInitialisateur
            /*ATTACK*/
            TabActions[0] = new cActionMechant(m_monstreChoisi.m_Dommage, 0);
            /*DEFENSE*/
            TabActions[1] = new cActionMechant(0, m_monstreChoisi.m_defense);
            #endregion
            #endregion
        }

        #region evenement losrque quon clicke sur les boutons
        private void btnContinue_Click(object sender, EventArgs e)
        {
          
            #region Arrivée Du Boss /  Monstre aléatoire
            m_NbrestantMonstreBoss--;
            
            if (m_NbrestantMonstreBoss == 0)
            {
                m_NumeroMonstre = 4;
                InitialisteurDeVieMechant(m_NumeroMonstre);
            }

            //Rotation des monstres
            else
                m_NumeroMonstre = ChoisirHasardMechant();
            #endregion

            btnAttack.Enabled = true;
            if (Soin <= 0)
                btnSoin.Enabled = true;

           //remettre attack et action comme debut
           #region lbdommage remis a neuf des 2 personnages
           lbActionMechant.Text = "";
           lbDomMechant.Text = "Dommage";
           lbDomPerso.Text = "Dommage";
           #endregion

           m_monstreChoisi = ((cMonstre)TabMonstre[m_NumeroMonstre]);

           //actions initialisateur
           #region ActionMechantInitialisateur
           /*ATTACK*/
           TabActions[0] = new cActionMechant(m_monstreChoisi.m_Dommage, 0);
           /*DEFENSE*/
           TabActions[1] = new cActionMechant(0, m_monstreChoisi.m_defense);
           #endregion

           #region Compteur pour paralysie(si Rune 2 acquise)
           if (Rune2 == 1)
           {
               Paralysie--;
               if (Paralysie == 0)
               {
                   cMonstre[] TabCMonstre = new cMonstre[1];
                   TabCMonstre[0] = m_monstreChoisi;
                   dChoixEnnemiAParalyser ChoixEnnemi = new dChoixEnnemiAParalyser(TabCMonstre);
                   ChoixEnnemi.ShowDialog();
                   lbDomMechant.Text = "ENNEMI \n PARALYSÉ";
               }
           }
           #endregion

           btnContinue.Enabled = false;
        }

        private void btnAttack_Click(object sender, EventArgs e)
        {
            //decrementation variable Soin
            #region Rune de soin - Utilisation
            Soin--;
            if (!SoinActif)
            {
                lbSoin.Visible = false;
                lbSoin.Enabled = false;
            }
            if (Soin <= 0 )
                btnSoin.Enabled = true;
         
#endregion

            //Action aleatoire mechant et si NON PARALYSÉ
            #region Action si non paralysé avec dommage dattack et point def mechant
            if (Paralysie != 0)
            {
                NumAction = ActionMechatHasard();
                //Selon lactionchoisi
                ActionAttackmechant = ((cActionMechant)TabActions[NumAction]).Domm;
                ActionDefensemechant = ((cActionMechant)TabActions[NumAction]).Protection;
            }
            #endregion

            //selon larme choisi
            #region Attack du joueur si nest pas en mode Soin
            if (!SoinActif)
                Attack = (cArme.Tabarme[ArmeChoisi]).DommageMax;
            else
                Attack = 0;
            #endregion

            //Calcul ds letat de vie (mechant)
            #region Calcul etat de vie mechant si nest pas en Mode soin
            if (!SoinActif)
            {
                BarreVieMechant.Step = -Attack + ActionDefensemechant;
                m_VieMechant += BarreVieMechant.Step;
            }
            else
                BarreVieMechant.Step = 0;

            Thread.Sleep(500);
             #endregion

            //changement graphique mechant
            #region changementGraphMechant
            BarreVieMechant.PerformStep();

            if(Paralysie!=0)/*si Non Paralysé*/
            lbDomMechant.Text = BarreVieMechant.Step.ToString();

            //texte vie mechant
            LbVieMechant.Text = m_VieMechant + "/" + m_monstreChoisi.m_Vie.ToString();
            #endregion

            //Si la vie du montre tombe a zero(et celle du boss)
            #region SI Monstre 0 HP + desactivation de lattack pour continuer

            if (m_VieMechant <= 0)
            {
                m_VieMechant = 0;
                LbVieMechant.Text = m_VieMechant + "/" + ((cMonstre)TabMonstre[m_NumeroMonstre]).m_Vie.ToString();
                lbDomMechant.Text = "0";
                m_Argent += m_monstreChoisi.m_ArgentRecu;
                m_Experience++;
                //AFFICHAGE DE Largent ACQUISE

                #region si Boss Vaincu
                string cs = "";
                if (m_NbrestantMonstreBoss == 0)//SI BOSS VAINCU
                {
                    PLanete2Permise = true;
                    m_Experience += 2;
                    cs = String.Format("VOUS AVEZ VAINCU {0} \n \n {1}\n\n ARGENT RECU {2}\n\n Experience en main {3}\n\n***PLANETE 2 Débloquée***", m_monstreChoisi.m_nom, PersonnageComplet[1], m_monstreChoisi.m_ArgentRecu,m_Experience);
                    this.Close();
                }

                #endregion

                else
                    cs = String.Format("{0}\n\n ARGENT RECU {1}\n\n Experience en main {2}", PersonnageComplet[1], m_monstreChoisi.m_ArgentRecu,m_Experience);

                MessageBox.Show(cs);

                lbArgent.Text = m_Argent.ToString();
                lbExperience.Text = m_Experience.ToString();
                //desactivation du bouton dattack
                btnAttack.Enabled = false;
                btnSoin.Enabled = false;
                btnContinue.Enabled = true;
                return;
            }
#endregion

            //calcul de vie perso si ENNEMI NON PARALYSÉ
            #region calcul vie perso
            else
                if (Paralysie != 0)
                {
                    m_ViePerso -= ActionAttackmechant;
                    BarreVie.Step = -ActionAttackmechant;
                }
            #endregion

            //Si la vie du perso tombe a zero
            #region SI Perso 0 HP+desactivation de lattack
            if (m_ViePerso <= 0)
            {
                m_ViePerso = 0;
                lbViePerso.Text = m_ViePerso + "/" + PersonnageComplet[4].ToString();
                lbDomPerso.Text = "0";
                BarreVie.Step = -400;
                BarreVie.PerformStep();

                //AFFICHAGE Du MESSAGE DE LA MORT
                string cs = "";
                cs = String.Format("{0}\n\n VOUS ETES MORT ", PersonnageComplet[1]);
                this.Close();
                MessageBox.Show(cs);
               
                //desactivation du bouton dattack
                btnAttack.Enabled = false;
                return;
            }
            #endregion

            //texte selon choix de ladversaire si ENNEMI NON PARALYSÉ
            #region texte
            if (Paralysie != 0)
            {
                if (NumAction == 0)
                {
                    lbActionMechant.Text = "Attack";
                    lbActionMechant.ForeColor = Color.Red;
                    lbActionMechant.Visible = true;
                }
                else
                {
                    lbActionMechant.Text = "Defense";
                    lbActionMechant.ForeColor = Color.Blue;
                    lbActionMechant.Visible = true;
                }
            }
            Thread.Sleep(1000);
            #endregion

            //Changement graphique vie perso si ENNEMI NON PARALYSÉ
            #region changementGraphPerso
            if (Paralysie != 0)
            {
                BarreVie.PerformStep();

                if (ActionAttackmechant == 0)
                    lbDomPerso.Text = "0";
                else
                    lbDomPerso.Text = (-ActionAttackmechant).ToString();

                lbViePerso.Text = m_ViePerso + "/" + PersonnageComplet[4].ToString();
            }
            #endregion

        }

        private void btnSoin_Click(object sender, EventArgs e)
        {
            SoinActif = true;
            //Nb point de vie guérison
            m_ViePerso += (int)PersonnageComplet[4] / 4;
            //Depacement vie
            #region depacement de capacité
            if (m_ViePerso > (int)PersonnageComplet[4])
                m_ViePerso = (int)PersonnageComplet[4];
            #endregion
            //Affichage
            #region Affichage
            BarreVie.Step = (int)PersonnageComplet[4] / 4;
            BarreVie.PerformStep();
            lbViePerso.Text = m_ViePerso.ToString() + "/" + PersonnageComplet[4].ToString();
            lbSoin.Visible = true;
            lbSoin.Text = "+" + ((int)PersonnageComplet[4] / 4).ToString();
            #endregion

            btnAttack_Click(sender, e);
            //remise a neuf de la variable soin pour faire disparaitre bouton
            Soin = (int)PersonnageComplet[8];
            #region changement graphique
            btnSoin.Enabled = false;
            #endregion
            SoinActif = false;
          
        }

        //combobox de retour(ferme la forme dans les 2 cas) 
        private void cbRetour_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbRetour.SelectedIndex == 0)
            {
                this.Close();
            }
            else
            {
                this.Close();
            }
        }
         
       private void btnArmement_Click(object sender, EventArgs e)
        {
            if (Ouvert == true)
            {
                gbArme.Visible = false;
                Ouvert = false;
            }

            else
            {
                gbArme.Visible = true;
                Ouvert = true;
            }
        }
        #endregion

       #region FONCTION

       public int ChoisirHasardMechant()
        {  
            int nb = 0;
            Random r = new Random();
            nb = r.Next(0, 4);
            //Affichement dun monstre different obligatoire
            if (nb == m_Nbchoisideja)
            {
                while (nb == m_Nbchoisideja)
                {
                    nb = r.Next(0, 4);
                }
            }
            m_Nbchoisideja = nb;
            InitialisteurDeVieMechant(nb);
            return nb;
        }

        public void InitialisteurDeVieMechant(int nb)
        {
            //initialisateur de vie mechant + graphique
            m_VieMechant = ((cMonstre)TabMonstre[nb]).m_Vie;
            pbMechant.Image = ((cMonstre)TabMonstre[nb]).m_ImageMonstre;
            BarreVieMechant.Step = m_VieMechant;
            BarreVieMechant.Maximum = m_VieMechant;
            BarreVieMechant.PerformStep();
            LbVieMechant.Text = m_VieMechant.ToString() + "/" + m_VieMechant.ToString();
            LbMechant.Text = ((cMonstre)TabMonstre[nb]).m_nom;
        }

        public int ActionMechatHasard()
        {
            int nb = 0;
            Random r = new Random();
            nb = r.Next(0, 2);
            return nb;
        }

        public bool PourAllerAuMenuDirect()
        {
            if (cbRetour.SelectedIndex == 1)
                return true;
            else
                return false;
        }

        static public cMonstre [] RetourneTabMonstre1()
        {
            cMonstre []TabMonstre=new cMonstre[5];
            TabMonstre[0] = new cMonstre("Alastor", 30, 40, 5, 40, Image.FromFile("Mechant.Marchand\\Mechant1.jpg"));
            TabMonstre[1] = new cMonstre("Scorn", 50, 20, 5, 30, Image.FromFile("Mechant.Marchand\\Mechant2.jpg"));
            TabMonstre[2] = new cMonstre("Kragoth", 60, 15, 10, 20, Image.FromFile("Mechant.Marchand\\Mechant3.jpg"));
            TabMonstre[3] = new cMonstre("Nasir", 40, 15, 5, 10, Image.FromFile("Mechant.Marchand\\Mechant4.jpg"));// Vie Attack defense- xp-
            TabMonstre[4] = new cMonstre("Ashnard (BOSS)", 100, 50, 10, 70, Image.FromFile("Mechant.Marchand\\Boss1.jpg"));//BOSS
            return TabMonstre;
        }
#endregion

      

      
     
    }
}
