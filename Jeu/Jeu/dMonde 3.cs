using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Threading;

namespace Jeu
{
    public partial class dMonde_3 : Form
    {
        #region variable utilisées

        /*Choix*/
        private int m_Nbchoisideja, m_NumeroMonstre, m_NumeroMonstre2,m_NumeroMonstre3, m_MonstreaAttaquer = 1;
        /*Vie*/
        private int m_VieMechant, m_VieMechant2,m_VieMechant3, m_ViePerso;
        /*Combat*/
        private int NumAction, NumActionMechant2, NumActionMechant3, Attack, 
                    ActionAttackmechant, ActionDefensemechant, 
                    ActionAttackmechant2, ActionDefensemechant2,
                    ActionAttackmechant3, ActionDefensemechant3;

        /*arme acquise*/
        private int ArmeChoisi;
        /*BOSS*/
        private int m_NbrestantMonstreBoss = 2;
        /* mort juste       */
        private bool MechantMort, MechantMort2,MechantMort3;
        /*regarder une fois */
        /*Rune*/
        private int Rune1, Rune2;
        /*compteur pr rune*/
        private int Paralysie = 3, Soin = 0;
        /* Soin ACtivée ?*/
        private bool SoinActif = false;
        /*Ennemi est paralyser*/
        private bool Monstre1paralyser, Monstre2Paralyser,Monstre3Paralyser;
        /*Pour gbarme*/
        private bool Ouvert = false;
        /*lorsquon clicke sur un image ? alors que le boss est pas la (boss)*/
        private int GoodSelection=-1;
        private bool BossActivate = false;
        /*ACCES 3iemePLanete*/
        public bool PLanete4Permise = false;
        /*ARGENT*/
        public int m_Argent;
        /*EXPERIENCE*/
        public int m_Experience;

        #region classe
        /*SONS*/
        private SoundPlayer sp = new System.Media.SoundPlayer("Musique\\Ice Jump.wav");
        /* mechant choisi 1*/
        private cMonstre m_monstreChoisi;
        /* mechant choisi 2*/
        private cMonstre m_monstreChoisi2;
        /* mechant choisi 3*/
        private cMonstre m_monstreChoisi3;
        /*Aleatoire*/
        private Random r = new Random();
        private Random b = new Random();
        #endregion
        #endregion
        #region tableaux utilisés
        //Different tableau
        public static object[] TabMonstre = new object[7];
        private cActionMechant[] TabActions = new cActionMechant[2];
        private cActionMechant[] TabActionsMechant2 = new cActionMechant[2];
        private cActionMechant[] TabActionsMechant3 = new cActionMechant[2];
        private object[] PersonnageComplet;
        #endregion

        public dMonde_3(object[] pComplet, int WeaponSelected, bool P4, int R1, int R2)
        {
            InitializeComponent();
            sp.PlayLooping();
            
            PersonnageComplet = pComplet;
            #region Initialisation Arme choix perso + Argent
            m_Argent = (int)pComplet[6];
            lbArgent.Text = m_Argent.ToString();
            #endregion
            #region Experience et Planete + Rune
            m_Experience = (int)pComplet[7];
            lbExperience.Text = m_Experience.ToString();
            PLanete4Permise = P4;
            Rune1 = R1;
            Rune2 = R2;
            #endregion
            #region Soin
            Soin = (int)PersonnageComplet[8];
            #endregion
            #region Initialisation globale Premier combat en ouvrant la forme
            //Choix du personnage;
            #region choixPerso
            pbPerso.Image = (Image)pComplet[2];
            ArmeChoisi = WeaponSelected;
            #endregion

            //Choix darmes (initialiser ak les armes acquises)
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
            m_ViePerso = (int)pComplet[4];
            BarreVie.Step = m_ViePerso;
            BarreVie.Maximum = m_ViePerso;
            BarreVie.PerformStep();
            lbViePerso.Text = pComplet[4].ToString() + "/" + pComplet[4].ToString();
            #endregion

            ///Choix mechant
            ///initialisateur
            #region ChoixMechant + InitialisateurvieMechant
            TabMonstre[0] = new cMonstre("Tibarn", 30, 40, 5, 40,Image.FromFile("Mechant.Marchand\\P3Mechant1.jpg"));
            TabMonstre[1] = new cMonstre("Tormod", 50, 20, 5, 30,Image.FromFile("Mechant.Marchand\\P3Mechant2.jpg"));
            TabMonstre[2] = new cMonstre("Zihark", 60, 15, 10, 20,Image.FromFile("Mechant.Marchand\\P3Mechant3.jpg"));
            TabMonstre[3] = new cMonstre("Haar", 40, 15, 5, 10,Image.FromFile("Mechant.Marchand\\P3Mechant4.jpg"));
            TabMonstre[4] = new cMonstre("Reyson", 70, 35, 10, 20,Image.FromFile("Mechant.Marchand\\P3Mechant5.jpg"));
            TabMonstre[5] = new cMonstre("Letharshnor (BOSS)", 100, 50, 10, 70, Image.FromFile("Mechant.Marchand\\P3MechantBoss.jpg"));//BOSS
            TabMonstre[6] = Image.FromFile("Mechant.Marchand\\P3BossSuprise.jpg");//BOSS
          //; Caineghis; Kurtnaga ... 

            m_NumeroMonstre = ChoisirHasardMechant(1);
            m_NumeroMonstre2 = ChoisirHasardMechant(2);
            m_NumeroMonstre3 = ChoisirHasardMechant(3);

            m_monstreChoisi = ((cMonstre)TabMonstre[m_NumeroMonstre]);
            m_monstreChoisi2 = ((cMonstre)TabMonstre[m_NumeroMonstre2]);
            m_monstreChoisi3 = ((cMonstre)TabMonstre[m_NumeroMonstre3]);
            #endregion

            //actions initialisateur 
            #region ActionMechantInitialisateur
            /*ATTACK*/
            TabActions[0] = new cActionMechant(m_monstreChoisi.m_Dommage, 0);
            /*DEFENSE*/
            TabActions[1] = new cActionMechant(0, m_monstreChoisi.m_defense);
            #endregion

            #region ActionMechantInitialisateur2
            /*ATTACK*/
            TabActionsMechant2[0] = new cActionMechant(m_monstreChoisi2.m_Dommage, 0);
            /*DEFENSE*/
            TabActionsMechant2[1] = new cActionMechant(0, m_monstreChoisi2.m_defense);
            #endregion

            #region ActionMechantInitialisateur3
            /*ATTACK*/
            TabActionsMechant3[0] = new cActionMechant(m_monstreChoisi3.m_Dommage, 0);
            /*DEFENSE*/
            TabActionsMechant3[1] = new cActionMechant(0, m_monstreChoisi3.m_defense);
            #endregion
            #endregion

        }



        #region evenement des bouton lorsque clické

        private void btnContinue_Click(object sender, EventArgs e)
        {
            #region form remise a neuf
            btnAttack.Enabled = true;
            lbMechant.Enabled = true;
            lbMechant2.Enabled = true;
            lbMechant3.Enabled = true;
            pbMechant.Enabled = true;
            pbMechant2.Enabled = true;
            pbMechant3.Enabled = true;
            #endregion

            //remettre attack et action comme debut
            #region lbdommage remis a neuf des 4 personnages + mort=false +Paralysie=false
            lbActionMechant.Text = "";
            lbActionMechant2.Text = "";
            lbActionMechant3.Text = "";
            lbVieMechant.Text = "0/0";
            lbVieMechant2.Text = "0/0";
            lbVieMechant3.Text = "0/0";
            lbDomMechant.Text = "Dommage";
            lbDomMechant2.Text = "Dommage";
            lbDomMechant3.Text = "Dommage";
            lbDomPerso.Text = "Dommage";
            MechantMort = false;
            MechantMort2 = false;
            MechantMort3 = false;
            Monstre1paralyser = false;
            Monstre2Paralyser = false;
            Monstre3Paralyser = false;
            #endregion

            #region Arrivée Du Boss /  Monstre aléatoire
            pbMechant_Click(sender, e);
            m_NbrestantMonstreBoss--;
            if (m_NbrestantMonstreBoss == 0)
            {
                #region operation faite pour le boss
                Monstre1paralyser = false;
                m_NumeroMonstre = 5;
                InitialisteurDeVieMechant(m_NumeroMonstre, 1);
                GoodSelection = 1;
                lbMechant.Enabled = false;
                lbMechant2.Enabled = false;
                lbMechant3.Enabled = false;
                lbVieMechant.Visible = false;
                lbVieMechant2.Visible = false;
                lbVieMechant3.Visible = false;
                MechantMort2 = true;
                MechantMort3 = true;
                BossActivate = true;
                lbBOSSTEXTE.Visible = true;
                lbBossLife.Visible = true;
                lbActionBoss.Visible = true;
                lbBossLife.Text = (((cMonstre)TabMonstre[5]).m_Vie+"/"+ ((cMonstre)TabMonstre[5]).m_Vie).ToString();
                pbMechant2.Image = (Image)TabMonstre[6];
                pbMechant3.Image = (Image)TabMonstre[6];
                
                #endregion
            }

            //Rotation des monstres
            else
            {
                m_NumeroMonstre = ChoisirHasardMechant(1);
                m_NumeroMonstre2 = ChoisirHasardMechant(2);
                m_NumeroMonstre3 = ChoisirHasardMechant(3);
            }

            #endregion

            m_monstreChoisi = ((cMonstre)TabMonstre[m_NumeroMonstre]);
            if (!BossActivate)
            {
                m_monstreChoisi2 = ((cMonstre)TabMonstre[m_NumeroMonstre2]);
                m_monstreChoisi3 = ((cMonstre)TabMonstre[m_NumeroMonstre3]);
            }

            //actions initialisateur attack et defense
            #region ActionsInitialisateur
            #region Monstre 1
            /*ATTACK*/
            TabActions[0] = new cActionMechant(m_monstreChoisi.m_Dommage, 0);
            /*DEFENSE*/
            TabActions[1] = new cActionMechant(0, m_monstreChoisi.m_defense);
            #endregion
            #region Monstre 2
            /*ATTACK*/
            TabActionsMechant2[0] = new cActionMechant(m_monstreChoisi2.m_Dommage, 0);
            /*DEFENSE*/
            TabActionsMechant2[1] = new cActionMechant(0, m_monstreChoisi2.m_defense);
            #endregion
            #region Monstre 3
            /*ATTACK*/
            TabActionsMechant3[0] = new cActionMechant(m_monstreChoisi3.m_Dommage, 0);
            /*DEFENSE*/
            TabActionsMechant3[1] = new cActionMechant(0, m_monstreChoisi3.m_defense);
            #endregion
            #endregion

            btnAttack.Enabled = true;
            btnContinue.Enabled = false;
            #region traitement Soin et paralysie
            if (Soin <= 0)
                btnSoin.Enabled = true;

            if (Paralysie == 0)
            {
                EnnemiChoisiPourParalyser();
            }
            else
            {
                Monstre2Paralyser = false;
                Monstre3Paralyser = false;
                Monstre3Paralyser = false;
            }
            #endregion
        }

        private void btnAttack_Click(object sender, EventArgs e)
        {

          #region si le boss est là debut de l'operation mise en place graphique
            //choix du boss (deplacement)
            if (BossActivate)
            {
                GoodSelection = b.Next(1, 4);
                RemiseFormDurantBoss();
                switch (GoodSelection)
                {
                    case 1: pbMechant.Image = ((cMonstre)TabMonstre[5]).m_ImageMonstre; 
                            pbMechant2.Image = (Image)TabMonstre[6];
                            pbMechant3.Image = (Image)TabMonstre[6];
                            BarreVieMechant.Value = m_VieMechant;
                        break;
                    case 2: pbMechant.Image = (Image)TabMonstre[6];
                            pbMechant2.Image = ((cMonstre)TabMonstre[5]).m_ImageMonstre;
                            pbMechant3.Image = (Image)TabMonstre[6];
                            BarreVieMechant2.Value = m_VieMechant;
                        break;
                    case 3: pbMechant.Image = (Image)TabMonstre[6];
                            pbMechant2.Image = (Image)TabMonstre[6];
                            pbMechant3.Image = ((cMonstre)TabMonstre[5]).m_ImageMonstre;
                            BarreVieMechant3.Value = m_VieMechant;
                        break;
                }
            }
#endregion

            //decrementation variable Soin
            #region Rune de soin - Utilisation
            Soin--;
            if (Soin <= 0)
                btnSoin.Enabled = true;
            if (!SoinActif)
                lbSoin.Visible = false;
            #endregion

            //Action aleatoire mechant si NON PARALYSÉ
            #region Action Choisi par les 3 monstre
            #region si monstre 1 est pas paralysée et pas mort
            if (Monstre1paralyser == false)
            {
                if (!MechantMort)
                    NumAction = ActionMechatHasard();
                else
                    NumAction = -1;
            }
            #endregion
            #region si monstre 2 est pas paralysé et pas mort
            if (Monstre2Paralyser == false)
            {
                if (!MechantMort2)
                    NumActionMechant2 = ActionMechatHasard();
                else
                    NumActionMechant2 = -1;
            }
            #endregion
            #region si monstre 3 est pas paralysé et pas mort
            if (Monstre3Paralyser == false)
            {
                if (!MechantMort3)
                    NumActionMechant3 = ActionMechatHasard();
                else
                    NumActionMechant3 = -1;
            }
            #endregion
            #endregion

            //Selon lactionchoisi si NON PARALYSÉ ET VIVANT
            #region Point dattack et de defense 3 monstre
            #region Monstre 1
            if (Monstre1paralyser == false)
            {
                if (!MechantMort)
                {
                    ActionAttackmechant = ((cActionMechant)TabActions[NumAction]).Domm;
                    ActionDefensemechant = ((cActionMechant)TabActions[NumAction]).Protection;
                }
            }
            #endregion
            #region Monstre 2
            if (Monstre2Paralyser == false)
            {
                if (!MechantMort2)
                {
                    ActionAttackmechant2 = ((cActionMechant)TabActionsMechant2[NumActionMechant2]).Domm;
                    ActionDefensemechant2 = ((cActionMechant)TabActionsMechant2[NumActionMechant2]).Protection;
                }
            }
            #endregion
            #region Monstre 3
            if (Monstre3Paralyser == false)
            {
                if (!MechantMort3)
                {
                    ActionAttackmechant3 = ((cActionMechant)TabActionsMechant3[NumActionMechant3]).Domm;
                    ActionDefensemechant3 = ((cActionMechant)TabActionsMechant3[NumActionMechant3]).Protection;
                }
            }
            #endregion
            #endregion

            //texte selon choix de ladversaire Si NON PARALYSÉ
            #region texte
            Thread.Sleep(500);
            #region Mechant1
            if (Monstre1paralyser == false)
            {
                if (!BossActivate)
                {
                    if (NumAction == 0)
                    {
                        lbActionMechant.Text = "Attack";
                        lbActionMechant.ForeColor = Color.Red;
                        lbActionMechant.Visible = true;
                    }
                    else
                        if (NumAction == 1)
                        {
                            lbActionMechant.Text = "Defense";
                            lbActionMechant.ForeColor = Color.Cyan;
                            lbActionMechant.Visible = true;

                        }
                }
                else
                {
                    if (NumAction == 0)
                    {
                        lbActionBoss.Text = "Attack";
                        lbActionBoss.ForeColor = Color.Red;
                    }
                    else
                        if (NumAction == 1)
                        {
                            lbActionBoss.Text = "Defense";
                            lbActionBoss.ForeColor = Color.Cyan;
                        }
                }
            }
            #endregion
            #region Mechant2
            if (Monstre2Paralyser == false)
            {
                if (NumActionMechant2 == 0)
                {
                    lbActionMechant2.Text = "Attack";
                    lbActionMechant2.ForeColor = Color.Red;
                    lbActionMechant2.Visible = true;
                }
                else
                    if (NumActionMechant2 == 1)
                    {
                        lbActionMechant2.Text = "Defense";
                        lbActionMechant2.ForeColor = Color.Cyan;
                        lbActionMechant2.Visible = true;
                    }
            }

            #endregion
            #region Mechant3
            if (Monstre3Paralyser == false)
            {
                if (NumActionMechant3 == 0)
                {
                    lbActionMechant3.Text = "Attack";
                    lbActionMechant3.ForeColor = Color.Red;
                    lbActionMechant3.Visible = true;
                }
                else
                    if (NumActionMechant3 == 1)
                    {
                        lbActionMechant3.Text = "Defense";
                        lbActionMechant3.ForeColor = Color.Cyan;
                        lbActionMechant3.Visible = true;
                    }
            }

            #endregion
            #endregion

            //selon larme choisi
            #region Attack si nest pas en mode Soin
            if (!SoinActif)
                Attack = (cArme.Tabarme[ArmeChoisi]).DommageMax;
            else
                Attack = 0;
            #endregion

           // Calcul ds letat de vie (mechant)
            if(!BossActivate)
            {
                #region Calcul etat de vie mechant
            if (!MechantMort)
            {
                #region Monstre 1
                if (m_MonstreaAttaquer == 1)
                {
                    if (!SoinActif)
                    {
                        BarreVieMechant.Step = -Attack + ActionDefensemechant;
                        m_VieMechant += BarreVieMechant.Step;
                    }
                    else
                        BarreVieMechant.Step = 0;

                }
                #endregion
            }
            if (!MechantMort2)
            {
                #region Monstre 2
                if (m_MonstreaAttaquer == 2)
                {
                    if (!SoinActif)
                    {
                        BarreVieMechant2.Step = -Attack + ActionDefensemechant2;
                        m_VieMechant2 += BarreVieMechant2.Step;
                    }
                    else
                        BarreVieMechant2.Step = 0;

                }
                #endregion
            }

            if (!MechantMort3)
            {
                #region Monstre 3
                if (m_MonstreaAttaquer == 3)
                {
                    if (!SoinActif)
                    {
                        BarreVieMechant3.Step = -Attack + ActionDefensemechant3;
                        m_VieMechant3 += BarreVieMechant3.Step;
                    }
                    else
                        BarreVieMechant3.Step = 0;

                }
                #endregion
            }
            Thread.Sleep(500);
            #endregion
            }
           //Calcul de vie boss
            else
            {
                  #region bossLifeCalcul
                
                #region GoodSelection1
                if (m_MonstreaAttaquer == 1 && GoodSelection==1)
                {
                    if (!SoinActif)
                    {
                        BarreVieMechant.Step = -Attack + ActionDefensemechant;
                            m_VieMechant += BarreVieMechant.Step;
                    }
                    else
                        BarreVieMechant.Step = 0;
                }
                #endregion
                else
                #region GoodSelection 2
                if (m_MonstreaAttaquer == 2 && GoodSelection==2)
                {
                    if (!SoinActif)
                    {
                        BarreVieMechant2.Step = -Attack + ActionDefensemechant2;
                        m_VieMechant += BarreVieMechant2.Step;
                    }
                    else
                        BarreVieMechant2.Step = 0;

                }
                    #endregion
                else
                #region GoodSelection 3
                  if (m_MonstreaAttaquer == 3 && GoodSelection==3)
                {
                    if (!SoinActif)
                    {
                        BarreVieMechant3.Step = -Attack + ActionDefensemechant3;
                        m_VieMechant3 += BarreVieMechant3.Step;
                        if (GoodSelection == 3)
                            m_VieMechant += BarreVieMechant3.Step;
                    }
                    else
                        BarreVieMechant3.Step = 0;

                }
                #endregion
                  #endregion
            }
            Thread.Sleep(500);
           


            //changement graphique apres attack contre mechant
            #region changementGraphMechant  
          
            if (m_MonstreaAttaquer == 1)
            {
                #region Monstre 1
                BarreVieMechant.PerformStep();
                if (Monstre1paralyser == false)
                    lbDomMechant.Text = BarreVieMechant.Step.ToString();

                if (GoodSelection != 1 && GoodSelection != -1)
                    lbDomMechant.Text = "Manqué";
                   
                #endregion
            }
            else
                if (m_MonstreaAttaquer == 2)
                {
                    #region Monstre 2
                    BarreVieMechant2.PerformStep();
                    if (Monstre2Paralyser == false)
                        lbDomMechant2.Text = BarreVieMechant2.Step.ToString();

                    if (GoodSelection != 2 && GoodSelection != -1)
                        lbDomMechant2.Text = "Manqué";
                       
                    
                    #endregion
                }
                else
                {
                    #region Monstre 3
                    BarreVieMechant3.PerformStep();
                    if (Monstre3Paralyser == false)
                        lbDomMechant3.Text = BarreVieMechant3.Step.ToString();

                    if (GoodSelection != 3 && GoodSelection != -1)
              
                        lbDomMechant3.Text = "Manqué";
           
                    #endregion
                }
         
            

            //texte vie mechant(scene du boss incluse)
            if (GoodSelection == -1)
            {
                lbVieMechant.Text = m_VieMechant + "/" + m_monstreChoisi.m_Vie.ToString();
                lbVieMechant2.Text = m_VieMechant2 + "/" + m_monstreChoisi2.m_Vie.ToString();
                lbVieMechant3.Text = m_VieMechant3 + "/" + m_monstreChoisi3.m_Vie.ToString();
            }
            else
                lbBossLife.Text = m_VieMechant + "/" + m_monstreChoisi.m_Vie.ToString();
            #endregion
           

            //Si la vie du montre tombe a zero(et celle du boss)
            #region SI Monstre 0 HP + desactivation de lattack pour continuer
            string cs = "";
 
            #region si Monstre 1 battu (boss inclus dedans)
            if (m_VieMechant <= 0 && MechantMort == false)
            {
                MechantMort = true;
                #region Compteur pour paralysie(si Rune 2 acquise)
                if (Rune2 == 1)
                {
                    Paralysie--;
                }
                #endregion
                #region Mise a zero du monstre 1
                m_VieMechant = 0;
                lbVieMechant.Text = m_VieMechant + "/" + ((cMonstre)TabMonstre[m_NumeroMonstre]).m_Vie.ToString();
                lbDomMechant.Text = "0";
                lbActionMechant.Text = "";
                pbMechant.Enabled = false;
                lbMechant.Enabled = false;
                pbMechant.Image = null;
                panMechant1.BackColor = Color.Black;
                #endregion
                #region passe a lennemi 2 ou 3 tout dependant s'il est mort
                if (!MechantMort2)
                    pbMechant2_Click(sender, e);
                else
                    if(!MechantMort3)
                    pbMechant3_Click(sender, e);
                 
                #endregion
                m_Argent += m_monstreChoisi.m_ArgentRecu;
                m_Experience++;
                lbArgent.Text = m_Argent.ToString();
                lbExperience.Text = m_Experience.ToString();
                //AFFICHAGE DE Largent ACQUISE

                #region si Boss Vaincu
                if (m_NbrestantMonstreBoss == 0)//SI BOSS VAINCU
                {
                    PLanete4Permise = true;
                    pbMechant2.Image = null;
                    pbMechant3.Image = null;
                    m_Experience += 2;
                    m_Argent += m_monstreChoisi.m_ArgentRecu;
                    cs = String.Format("VOUS AVEZ VAINCU LE BOSS {0} \n \n {1}\n\n ARGENT RECU {2}\n\n Experience en main {3} \n ***Derniere planète débloqué***", m_monstreChoisi.m_nom, PersonnageComplet[1], m_monstreChoisi.m_ArgentRecu, m_Experience);
                    MessageBox.Show(cs);
                    this.Close();
                }

                #endregion

                else
                {
                    cs = String.Format("{0}\n\n ARGENT RECU {1}\n\n Experience en main {2}", PersonnageComplet[1], m_monstreChoisi.m_ArgentRecu, m_Experience);
                    MessageBox.Show(cs);
                }
            }
            #endregion
            #region si Monstre 2 battu
            if (m_VieMechant2 <= 0 && MechantMort2 == false)
            {
                MechantMort2 = true;
                #region Compteur pour paralysie(si Rune 2 acquise)
                if (Rune2 == 1)
                {
                    Paralysie--;
                }
                #endregion
                #region mise a zero du monstre 2
                pbMechant2.Enabled = false;
                pbMechant2.Image = null;
                lbMechant2.Enabled = false;
                m_VieMechant2 = 0;
                lbVieMechant2.Text = m_VieMechant2 + "/" + ((cMonstre)TabMonstre[m_NumeroMonstre2]).m_Vie.ToString();
                lbDomMechant2.Text = "0";
                lbActionMechant2.Text = "";
                panMechant2.BackColor = Color.Black;
                #endregion
                #region passe a l'ennemi 1 ou 3
                if (!MechantMort)
                    pbMechant_Click(sender, e);
                else
                    if(!MechantMort3)
                    pbMechant3_Click(sender, e);
                #endregion
                m_Argent += m_monstreChoisi2.m_ArgentRecu;
                m_Experience++;
                lbArgent.Text = m_Argent.ToString();
                lbExperience.Text = m_Experience.ToString();
                //AFFICHAGE DE Largent ACQUISE
                cs = String.Format("{0}\n\n ARGENT RECU {1}\n\n Experience en main {2}", PersonnageComplet[1], m_monstreChoisi2.m_ArgentRecu, m_Experience);
                MessageBox.Show(cs);
            }
            #endregion
            #region si Monstre 3 battu
            if (m_VieMechant3 <= 0 && MechantMort3 == false)
            {
                MechantMort3 = true;
                #region Compteur pour paralysie(si Rune 2 acquise)
                if (Rune2 == 1)
                {
                    Paralysie--;
                }
                #endregion
                #region mise a zero du monstre 3
                pbMechant3.Enabled = false;
                pbMechant3.Image = null;
                lbMechant3.Enabled = false;
                m_VieMechant3 = 0;
                lbVieMechant3.Text = m_VieMechant3 + "/" + ((cMonstre)TabMonstre[m_NumeroMonstre3]).m_Vie.ToString();
                lbDomMechant3.Text = "0";
                lbActionMechant3.Text = "";
                panMechant3.BackColor = Color.Black;
                #endregion
                #region passe a l'ennemi 1 ou 2
                if (!MechantMort)
                    pbMechant_Click(sender, e);
                else
                    if (!MechantMort2) 
                    pbMechant2_Click(sender, e);
                #endregion
                m_Argent += m_monstreChoisi3.m_ArgentRecu;
                m_Experience++;
                lbArgent.Text = m_Argent.ToString();
                lbExperience.Text = m_Experience.ToString();
                //AFFICHAGE DE Largent ACQUISE
                cs = String.Format("{0}\n\n ARGENT RECU {1}\n\n Experience en main {2}", PersonnageComplet[1], m_monstreChoisi3.m_ArgentRecu, m_Experience);
                MessageBox.Show(cs);
            }
            #endregion

            #region Si les 3 monstres sont battus
            if (m_VieMechant <= 0 && m_VieMechant2 <= 0 && m_VieMechant3 <= 0)
            {
                //desactivation du bouton dattack
                btnAttack.Enabled = false;
                btnSoin.Enabled = false;
                btnContinue.Enabled = true;
                panMechant1.BackColor = Color.Black;
                panMechant2.BackColor = Color.Black;
                panMechant3.BackColor = Color.Black;
                return;
            }
                #endregion


           
            #endregion

                //calcul de vie perso (attack des 3 monstre)
                #region calcul vie perso
                #region Si mechant 1 ou 2 ou 3 mort
                if (MechantMort == true)
                    ActionAttackmechant = 0;
                if (MechantMort2 == true)
                    ActionAttackmechant2 = 0;
                if (MechantMort3 == true)
                    ActionAttackmechant3 = 0;
                #endregion
            #region Si Monstre 1 paralyse ou monstre 2 ou 3  ou aucun

            if (Monstre1paralyser == true)
                BarreVie.Step = -(ActionAttackmechant2 + ActionAttackmechant3);
            else
                if (Monstre2Paralyser == true)
                    BarreVie.Step = -(ActionAttackmechant + ActionAttackmechant3);
                else
                    if (Monstre3Paralyser == true)
                        BarreVie.Step = -(ActionAttackmechant + ActionAttackmechant2);
                    else
                        if (Monstre1paralyser == false && Monstre2Paralyser == false && Monstre3Paralyser == false)
                            BarreVie.Step = -(ActionAttackmechant + ActionAttackmechant2 + ActionAttackmechant3);
            #endregion
                m_ViePerso += BarreVie.Step;
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
                    cs = "";
                    cs = String.Format("{0}\n\n VOUS ETES MORT ", PersonnageComplet[1]);
                    this.Close();
                    MessageBox.Show(cs);

                    //desactivation du bouton dattack
                    btnAttack.Enabled = false;
                    return;
                }
                #endregion


                //Changement graphique vie perso
                #region changementGraphPerso
                BarreVie.PerformStep();

                if (ActionAttackmechant == 0 && ActionAttackmechant2 == 0 && ActionAttackmechant3 == 0)
                    lbDomPerso.Text = "0";
                else
                    lbDomPerso.Text = BarreVie.Step.ToString();

                lbViePerso.Text = m_ViePerso + "/" + PersonnageComplet[4].ToString();
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

        //GbArme
        #region changement graphique

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

        #endregion

        //changement dennemi en clickant dessus
        #region Evenement click et ennemi
        private void pbMechant_Click(object sender, EventArgs e)
        {
            lbMechant.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            lbMechant2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lbMechant3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lbMechant.ForeColor = Color.White;
            lbMechant2.ForeColor = Color.Cyan;
            lbMechant3.ForeColor = Color.Cyan;
            panMechant1.BackColor = Color.DodgerBlue;
            panMechant2.BackColor = Color.Black;
            panMechant3.BackColor = Color.Black;
            m_MonstreaAttaquer = 1;
        }
        private void pbMechant2_Click(object sender, EventArgs e)
        {
            lbMechant.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lbMechant2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            lbMechant3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lbMechant.ForeColor = Color.Cyan;
            lbMechant2.ForeColor = Color.White;
            lbMechant3.ForeColor = Color.Cyan;
            panMechant1.BackColor = Color.Black;
            panMechant2.BackColor = Color.DodgerBlue;
            panMechant3.BackColor = Color.Black;
            m_MonstreaAttaquer = 2;
        }

        private void pbMechant3_Click(object sender, EventArgs e)
        {
            lbMechant.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lbMechant2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lbMechant3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            lbMechant.ForeColor = Color.Cyan;
            lbMechant2.ForeColor = Color.Cyan;
            lbMechant3.ForeColor = Color.White;
            panMechant1.BackColor = Color.Black;
            panMechant2.BackColor = Color.Black;
            panMechant3.BackColor = Color.DodgerBlue;
            m_MonstreaAttaquer = 3;
        }
        #endregion

        #region FONCTION

        public int ChoisirHasardMechant(int Mechant1ou2ou3)
        {
            int nb = 0;
            
            nb = r.Next(0, 10);
            if (nb == m_NumeroMonstre)
                nb = r.Next(0,10);
            #region permet plus de hasard
            // permet encore plus de hasard
            switch (nb)
            {
                case 5: nb = 2;
                    break;
                case 6: nb = 1;
                    break;
                case 7: nb = 3;
                    break;
                case 8: nb = 4;
                    break;
                case 9: nb = 2;
                    break;
            }
            #endregion
            //Affichement dun monstre different obligatoire
            if (nb == m_Nbchoisideja)
            {
                while (nb == m_Nbchoisideja)
                {
                    nb = r.Next(0, 10);
                    #region permet plus de hasard
                    switch (nb)
                    {
                        case 5: nb = 3;
                            break;
                        case 6: nb = 2;
                            break;
                        case 7: nb = 1;
                            break;
                        case 8: nb = 2;
                            break;
                        case 9: nb = 4;
                            break;
                    }
                    #endregion
                }
            }
            m_Nbchoisideja = nb;
            InitialisteurDeVieMechant(nb, Mechant1ou2ou3);
            return nb;
        }

        public void InitialisteurDeVieMechant(int nb, int Monstre1ou2ou3)
        {
            //+graphique dans pbImageMonstre
            switch (Monstre1ou2ou3)
            {
                case 1:
                #region initialisateur de vie mechant
                m_VieMechant = ((cMonstre)TabMonstre[nb]).m_Vie;
                pbMechant.Image = ((cMonstre)TabMonstre[nb]).m_ImageMonstre;
                BarreVieMechant.Step = m_VieMechant;
                BarreVieMechant.Maximum = m_VieMechant;
                BarreVieMechant.PerformStep();
                lbVieMechant.Text = m_VieMechant.ToString() + "/" + m_VieMechant.ToString();
                lbMechant.Text = ((cMonstre)TabMonstre[nb]).m_nom;
#endregion
                break;
                case 2:
                #region initialisateur de vie mechant2
                m_VieMechant2 = ((cMonstre)TabMonstre[nb]).m_Vie;
                pbMechant2.Image = ((cMonstre)TabMonstre[nb]).m_ImageMonstre;
                BarreVieMechant2.Step = m_VieMechant2;
                BarreVieMechant2.Maximum = m_VieMechant2;
                BarreVieMechant2.PerformStep();
                lbVieMechant2.Text = m_VieMechant2.ToString() + "/" + m_VieMechant2.ToString();
                lbMechant2.Text = ((cMonstre)TabMonstre[nb]).m_nom;
#endregion
                break;
                case 3:
                #region initialisateur de vie mechant3
                m_VieMechant3 = ((cMonstre)TabMonstre[nb]).m_Vie;
                pbMechant3.Image = ((cMonstre)TabMonstre[nb]).m_ImageMonstre;
                BarreVieMechant3.Step = m_VieMechant3;
                BarreVieMechant3.Maximum = m_VieMechant3;
                BarreVieMechant3.PerformStep();
                lbVieMechant3.Text = m_VieMechant3.ToString() + "/" + m_VieMechant3.ToString();
                lbMechant3.Text = ((cMonstre)TabMonstre[nb]).m_nom;
#endregion 
                break;
                
            }
        }

        public int ActionMechatHasard()
        {
            int nb;
         
            nb = r.Next(0, 5);
            // permet encore plus de hasard
            #region Hasard ++
            switch (nb)
            {
                case 2: nb = 0;
                    break;
                case 3: nb = 1;
                    break;
                case 4: nb = 1;
                    break;
                case 5: nb = 0;
                    break;
            }
            #endregion
            return nb;
        }

        public bool PourAllerAuMenuDirect()
        {
            if (cbRetour.SelectedIndex == 1)
                return true;
            else
                return false;
        }

        public void EnnemiChoisiPourParalyser()
        { 
            //Donne la possibilité au joueur de décider quel monstre il veut paralyse
            cMonstre[] TabMonstreAuCombat = new cMonstre[3]
            {
                 m_monstreChoisi,
                 m_monstreChoisi2,
                 m_monstreChoisi3,
            };

            dChoixEnnemiAParalyser ChoixEnnemi = new dChoixEnnemiAParalyser(TabMonstreAuCombat);
            ChoixEnnemi.ShowDialog();
            TextePourChoixEnnemiParalysé(ChoixEnnemi.retourneMonstreChoisi());

        }

        private void TextePourChoixEnnemiParalysé(int MonstrePossibleChoisi)
        {
            switch (MonstrePossibleChoisi)
            {
                case 1: lbDomMechant.Text = "ENNEMI \n PARALYSÉ";
                    lbActionMechant.Text = "";
                    ActionDefensemechant = 0;
                    Monstre1paralyser = true;
                    break;
                case 2: lbDomMechant2.Text = "ENNEMI \n PARALYSÉ";
                    lbActionMechant2.Text = "";
                    ActionDefensemechant2 = 0;
                    Monstre2Paralyser = true;
                    break;
                case 3: lbDomMechant3.Text = "ENNEMI \n PARALYSÉ";
                    lbActionMechant3.Text = "";
                    ActionDefensemechant3 = 0;
                    Monstre3Paralyser = true;
                    break;
            }

        }

        private void RemiseFormDurantBoss()
        {
            pbMechant.Image = null;
            pbMechant2.Image = null;
            pbMechant3.Image = null;
            BarreVieMechant.Value = 0;
            BarreVieMechant2.Value = 0;
            BarreVieMechant3.Value = 0;
            BarreVieMechant.Step = 0;
            BarreVieMechant2.Step = 0;
            BarreVieMechant3.Step = 0;
            BarreVieMechant2.Maximum = 100;
            BarreVieMechant3.Maximum = 100;
            lbVieMechant.Text = "0/0";
            lbVieMechant2.Text = "0/0";
            lbVieMechant3.Text = "0/0";
            lbDomMechant.Text = "";
            lbDomMechant2.Text = "";
            lbDomMechant3.Text = "";
            m_VieMechant2 = 0;
            m_VieMechant3 = 0;
           
        }


        static public cMonstre[] RetourneTabMonstre3()
        {
            cMonstre[] TabMonstre = new cMonstre[6];
            TabMonstre[0] = new cMonstre("Tibarn", 40, 50, 15, 40, Image.FromFile("Mechant.Marchand\\P3Mechant1.jpg"));
            TabMonstre[1] = new cMonstre("Tormod", 60, 30, 15, 30, Image.FromFile("Mechant.Marchand\\P3Mechant2.jpg"));
            TabMonstre[2] = new cMonstre("Zihark", 70, 25, 20, 20, Image.FromFile("Mechant.Marchand\\P3Mechant3.jpg"));
            TabMonstre[3] = new cMonstre("Haar", 50, 25, 15, 10, Image.FromFile("Mechant.Marchand\\P3Mechant4.jpg"));
            TabMonstre[4] = new cMonstre("Reyson", 80, 45, 20, 20, Image.FromFile("Mechant.Marchand\\P3Mechant5.jpg"));
            TabMonstre[5] = new cMonstre("Letharshnor (BOSS)", 110, 60, 20, 70, Image.FromFile("Mechant.Marchand\\P3MechantBoss.jpg"));//BOSS
            return TabMonstre;
        }
        #endregion

    }
}
