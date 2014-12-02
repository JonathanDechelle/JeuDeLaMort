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
    public partial class dNiveauFinale : Form
    {
        #region variable utiliséés
      /*Choix*/       private int m_NumeroMonstre,m_MonstreaAttaquer=1;
      /*Vie*/         private int m_VieMechant,m_VieMechant2,m_VieMechant3,m_ViePerso;
      /*Combat*/      private int NumAction, NumActionMechant2, NumActionMechant3, Attack,
                                  ActionAttackmechant, ActionDefensemechant,
                                  ActionAttackmechant2, ActionDefensemechant2,
                                  ActionAttackmechant3, ActionDefensemechant3;
      /* mort juste       */    
                      private bool MechantMort, MechantMort2, MechantMort3;
      /*regarder une fois */
                      private bool MonstreParalysé;
    /*arme acquise*/  private int ArmeChoisi;
  /* Si Boss Activé*/ private bool BossActivate;
      /*Rune*/        private int Rune1, Rune2;
/*Compteur pr rune*/  private int Paralysie = 3, Soin = 0;
  /* Soin Activée*/   private bool SoinActif = false;
/*   Pour GbArme */   private bool Ouvert = false;
/*AvancementTabMonstre*/private int IndiceTabMonstre=0;

   /*ARGENT*/         public int m_Argent;
    /*Experience*/    public int m_Experience;
                      public bool FIN;
 
          
        #region classe
  /*SONS*/            private SoundPlayer sp = new System.Media.SoundPlayer("Musique\\Svidden.wav");
/* mechant choisi*/   private cMonstre m_monstreChoisi;
/*Aleatoire*/         private Random r = new Random();
   #endregion
        #endregion
        #region tableaux tuilisés
        //Different tableau
        private cMonstre []TabMonstre=new cMonstre[17];
        private int[] TabOrdreDesMonstre = new int[17]{3,2,1,0,4,8,7,6,5,9,13,12,11,14,10,15,16};
        private cActionMechant[] TabActions = new cActionMechant[2];
        private cActionMechant[] TabActionsMechant2 = new cActionMechant[2];
        private cActionMechant[] TabActionsMechant3 = new cActionMechant[2];
        private object[] PersonnageComplet;
        #endregion
      

       public dNiveauFinale()
        {
            InitializeComponent();
        }

        public dNiveauFinale(object []Pcomplet,int WeaponSelected,int R1,int R2):this()
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
            
            for (int i = 0; i < 5; i++)
            {
                TabMonstre[i] = dMonde_1.RetourneTabMonstre1()[i];
                TabMonstre[i + 5] = Monde_2.RetourneTabMonstre2()[i];
                TabMonstre[i + 10] = dMonde_3.RetourneTabMonstre3()[i];
            }

            TabMonstre[15] = dMonde_3.RetourneTabMonstre3()[5];
            TabMonstre[16] = new cMonstre("Blutbad BOSS FINAL", 200, 20, 5, 80, Image.FromFile("Mechant.Marchand\\P4MechantBoss.jpg"));//BOSS
            m_NumeroMonstre = TabOrdreDesMonstre[IndiceTabMonstre];
            InitialisteurDeVieMechant(m_NumeroMonstre,1);
            m_monstreChoisi = ((cMonstre)TabMonstre[m_NumeroMonstre]);
           
            #endregion

            #region NextEnnemi
            pbNextEnnemi.Image=(Image)(TabMonstre[TabOrdreDesMonstre[IndiceTabMonstre+1]].m_ImageMonstre);
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
            TabActionsMechant2[0] = new cActionMechant(((cMonstre)TabMonstre[16]).m_Dommage, 0);
            /*DEFENSE*/
            TabActionsMechant2[1] = new cActionMechant(0, ((cMonstre)TabMonstre[16]).m_defense);
            #endregion

            #region ActionMechantInitialisateur3
            /*ATTACK*/
            TabActionsMechant3[0] = new cActionMechant(((cMonstre)TabMonstre[16]).m_Dommage, 0);
            /*DEFENSE*/
            TabActionsMechant3[1] = new cActionMechant(0, ((cMonstre)TabMonstre[16]).m_defense);
            #endregion
            #endregion
        }

        #region evenement losrque quon clicke sur les boutons
        private void btnContinue_Click(object sender, EventArgs e)
        {
            IndiceTabMonstre++;
            m_NumeroMonstre = TabOrdreDesMonstre[IndiceTabMonstre]; 
           
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
           InitialisteurDeVieMechant(m_NumeroMonstre,1);
           MechantMort = false;
           pbMechant.Enabled = true;
           LbVieMechant.Enabled = true;

           #region NextEnnemi
           if (IndiceTabMonstre + 1 < TabMonstre.Length)
               pbNextEnnemi.Image = (Image)(TabMonstre[TabOrdreDesMonstre[IndiceTabMonstre + 1]].m_ImageMonstre);
           else
           {
               #region Si BOSS ACTIVATE (form)
               BossActivate = true;
               BarreVieMechant2.Visible = true;
               BarreVieMechant3.Visible = true;
               lbDomMechant2.Visible = true;
               lbDomMechant3.Visible = true;
               lbViemechant2.Visible = true;
               lbVieMechant3.Visible = true;
               lbMiniboss3.Visible = true;
               pbMiniBoss3.Visible = true;
               #endregion

               m_monstreChoisi = ((cMonstre)TabMonstre[16]);
               InitialisteurDeVieMechant(m_NumeroMonstre,2);
               InitialisteurDeVieMechant(m_NumeroMonstre, 3);
           }
           #endregion

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
               if (Paralysie == 2)
                   MonstreParalysé = false;

               if (Paralysie == 0)
               {
                   MonstreParalysé = true;
                   Paralysie = 3;
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

            //Action aleatoire mechant si NON PARALYSÉ
            #region Action Choisi par les 3 monstre
            #region si monstre 1 est pas paralysée et pas mort
         
                if (!MechantMort && !MonstreParalysé)
                    NumAction = ActionMechatHasard();
                else
                    NumAction = -1;
        
            #endregion
                if (BossActivate)
                {
                    #region si monstre 2 est pas paralysé et pas mort

                    if (!MechantMort2)
                        NumActionMechant2 = ActionMechatHasard();
                    else
                        NumActionMechant2 = -1;

                    #endregion
                    #region si monstre 3 est pas paralysé et pas mort
                    if (!MechantMort3)
                        NumActionMechant3 = ActionMechatHasard();
                    else
                        NumActionMechant3 = -1;

                    #endregion
                }
            #endregion

            #region Point dattack et de defense 3 monstre
                #region Monstre 1
                    if (!MechantMort&&!MonstreParalysé)
                    {
                        ActionAttackmechant = ((cActionMechant)TabActions[NumAction]).Domm;
                        ActionDefensemechant = ((cActionMechant)TabActions[NumAction]).Protection;
                    }
               
                #endregion

                    if (BossActivate)
                    {
                        #region Monstre 2
                        if (!MechantMort2)
                        {
                            ActionAttackmechant2 = ((cActionMechant)TabActionsMechant2[NumActionMechant2]).Domm;
                            ActionDefensemechant2 = ((cActionMechant)TabActionsMechant2[NumActionMechant2]).Protection;
                        }

                        #endregion
                        #region Monstre 3
                        if (!MechantMort3)
                        {
                            ActionAttackmechant3 = ((cActionMechant)TabActionsMechant3[NumActionMechant3]).Domm;
                            ActionDefensemechant3 = ((cActionMechant)TabActionsMechant3[NumActionMechant3]).Protection;
                        }

                        #endregion
                    }
                #endregion

           //Texte selon Lattaque du monstre
            #region texte
                    Thread.Sleep(500);
                    #region Mechant1
                   
                        
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
                       
                      
                    #endregion
                            if (BossActivate)
                            {
                                #region Mechant2

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

                                #endregion
                                #region Mechant3
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


                                #endregion
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


            if (BossActivate)
            {
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
            }
            Thread.Sleep(500);
            #endregion



            //changement graphique apres attack contre mechant
            #region changementGraphMechant
          
                if (m_MonstreaAttaquer == 1)
                {
                    #region Monstre 1
                    BarreVieMechant.PerformStep();
                    if(!MonstreParalysé)
                    lbDomMechant.Text = BarreVieMechant.Step.ToString();
                    LbVieMechant.Text = m_VieMechant.ToString() + "/" + (TabMonstre[m_NumeroMonstre].m_Vie).ToString();
                    #endregion
                }
            
            if (BossActivate)
            {
                if (m_MonstreaAttaquer == 2)
                {
                    #region Monstre 2
                    BarreVieMechant2.PerformStep();
                    lbDomMechant2.Text = BarreVieMechant2.Step.ToString();
                    lbViemechant2.Text = m_VieMechant2.ToString() + "/" + (TabMonstre[16].m_Vie).ToString();
                    #endregion
                }
                else
                {
                    #region Monstre 3
                    BarreVieMechant3.PerformStep();
                    lbDomMechant3.Text = BarreVieMechant3.Step.ToString();
                    lbVieMechant3.Text = m_VieMechant3.ToString() + "/" + (TabMonstre[16].m_Vie).ToString();
                    #endregion
                }
            }
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
                LbVieMechant.Text= m_VieMechant + "/" + ((cMonstre)TabMonstre[m_NumeroMonstre]).m_Vie.ToString();
                lbDomMechant.Text = "0";
                lbActionMechant.Text = "";
                LbMechant.Text += " (MORT)";
                pbMechant.Enabled = false;
                LbVieMechant.Enabled = false;
                pbMechant.Image = null;

                #endregion
                #region passe a lennemi 2 ou 3 tout dependant s'il est mort
                if (BossActivate)
                {
                    if (!MechantMort2)
                        pbNextEnnemi_Click(sender, e);
                    else
                        if (!MechantMort3)
                            pbMiniBoss3_Click(sender, e);
                }
                #endregion
                m_Argent += m_monstreChoisi.m_ArgentRecu;
                m_Experience++;
                lbArgent.Text = m_Argent.ToString();
                lbExperience.Text = m_Experience.ToString();
                //AFFICHAGE DE Largent ACQUISE

                    cs = String.Format("{0}\n\n ARGENT RECU {1}\n\n Experience en main {2}", PersonnageComplet[1], m_monstreChoisi.m_ArgentRecu, m_Experience);
                    MessageBox.Show(cs);
              
            }
            #endregion

            if (BossActivate)
            {
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
                    pbNextEnnemi.Enabled = false;
                    pbNextEnnemi.Image = null;
                    pbNextEnnemi.Enabled = false;
                    lbNextEnnemi.Text += " (MORT)";
                    m_VieMechant2 = 0;
                    lbViemechant2.Text = m_VieMechant2 + "/" + ((cMonstre)TabMonstre[16]).m_Vie.ToString();
                    lbDomMechant2.Text = "0";
                    lbActionMechant2.Text = "";
                    //  panMechant2.BackColor = Color.Black;
                    #endregion
                    #region passe a l'ennemi 1 ou 3
                    if (!MechantMort)
                        pbMechant_Click(sender, e);
                    else
                        if (!MechantMort3)
                            pbMiniBoss3_Click(sender, e);
                    #endregion
                    m_Argent += ((cMonstre)TabMonstre[16]).m_ArgentRecu;
                    m_Experience++;
                    lbArgent.Text = m_Argent.ToString();
                    lbExperience.Text = m_Experience.ToString();
                    //AFFICHAGE DE Largent ACQUISE
                    cs = String.Format("{0}\n\n ARGENT RECU {1}\n\n Experience en main {2}", PersonnageComplet[1], ((cMonstre)TabMonstre[16]).m_ArgentRecu, m_Experience);
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
                    pbMiniBoss3.Enabled = false;
                    pbMiniBoss3.Image = null;
                    pbMiniBoss3.Enabled = false;
                    lbMiniboss3.Text += " (MORT)";
                    m_VieMechant3 = 0;
                    lbVieMechant3.Text = m_VieMechant3 + "/" + ((cMonstre)TabMonstre[16]).m_Vie.ToString();
                    lbDomMechant3.Text = "0";
                    lbActionMechant3.Text = "";
                    // panMechant3.BackColor = Color.Black;
                    #endregion
                    #region passe a l'ennemi 1 ou 2
                    if (!MechantMort)
                        pbMechant_Click(sender, e);
                    else
                        if (!MechantMort2)
                            pbMiniBoss3_Click(sender, e);
                    #endregion
                    m_Argent += ((cMonstre)TabMonstre[16]).m_ArgentRecu;
                    m_Experience++;
                    lbArgent.Text = m_Argent.ToString();
                    lbExperience.Text = m_Experience.ToString();
                    //AFFICHAGE DE Largent ACQUISE
                    cs = String.Format("{0}\n\n ARGENT RECU {1}\n\n Experience en main {2}", PersonnageComplet[1], ((cMonstre)TabMonstre[16]).m_ArgentRecu, m_Experience);
                    MessageBox.Show(cs);
                }
                #endregion
            }

            #region Si les 3 monstres sont battus
            if (BossActivate)
            {
                if (m_VieMechant <= 0 && m_VieMechant2 <= 0 && m_VieMechant3 <= 0)
                {
                    #region si Boss Vaincu
                    FIN = true;
                    MessageBox.Show("VOUS AVEZ VAINCU LE  DERNIER ET ULTIME BOSS BRAVO", "fin du jeu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                    #endregion
                }
            }
            else
                if (!BossActivate && m_VieMechant <= 0)
                {
                    //desactivation du bouton dattack
                    btnAttack.Enabled = false;
                    btnSoin.Enabled = false;
                    btnContinue.Enabled = true;
                    return;
                }
            #endregion



            #endregion

            //calcul de vie perso (attack des 3 monstre)
            #region calcul vie perso
            #region Si mechant 1 ou 2 ou 3 mort
            if (MechantMort == true || MonstreParalysé)
                ActionAttackmechant = 0;
            if (BossActivate)
            {
                if (MechantMort2 == true)
                    ActionAttackmechant2 = 0;
                if (MechantMort3 == true)
                    ActionAttackmechant3 = 0;

                BarreVie.Step = -(ActionAttackmechant + ActionAttackmechant2 + ActionAttackmechant3);
            }
            else
                BarreVie.Step = -ActionAttackmechant;
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

            if (BossActivate)
            {
                if (ActionAttackmechant == 0 && ActionAttackmechant2 == 0 && ActionAttackmechant3 == 0)
                    lbDomPerso.Text = "0";
                else
                    lbDomPerso.Text = BarreVie.Step.ToString();
            }
            else
            {
                if (ActionAttackmechant == 0 )
                    lbDomPerso.Text = "0";
                else
                    lbDomPerso.Text = BarreVie.Step.ToString();
            
            }
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

       #region ennemi Click
       private void pbMechant_Click(object sender, EventArgs e)
       {
           
               RemiseForm();
               LbMechant.BackColor = Color.DarkRed;
               LbMechant.ForeColor = Color.White;
               m_MonstreaAttaquer = 1;
           
       }

       private void pbNextEnnemi_Click(object sender, EventArgs e)
       {
           if (BossActivate)
           {
               RemiseForm();
               lbNextEnnemi.BackColor = Color.DarkRed;
               lbNextEnnemi.ForeColor = Color.White;
               m_MonstreaAttaquer = 2;
           }
           else
           {
               MessageBox.Show("Vous Devez Attaquer l'ennemi principale","ALLER COMBATTRE!!!",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
           }
       }

       private void pbMiniBoss3_Click(object sender, EventArgs e)
       {
           if (BossActivate)
           {
               RemiseForm();
               lbMiniboss3.BackColor = Color.DarkRed;
               lbMiniboss3.ForeColor = Color.White;
               m_MonstreaAttaquer = 3;
           }
           else
           {
               MessageBox.Show("Vous Devez Attaquer l'ennemi principale", "ALLER COMBATTRE!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
           }
       }

       private void RemiseForm()
       {
           LbMechant.BackColor = Color.White;
           LbMechant.ForeColor = Color.Black;
           lbNextEnnemi.BackColor = Color.White;
           lbNextEnnemi.ForeColor = Color.Black;
           lbMiniboss3.BackColor = Color.White;
           lbMiniboss3.ForeColor = Color.Black;
       }
       #endregion
       #region NextEnnemiInfo
        private void pbNextEnnemi_MouseMove(object sender, MouseEventArgs e)
        {
             string Description = "";
             cMonstre New;
            rtNextEnnemi.Visible = true;

            if (BossActivate)
            {
                New = TabMonstre[16];
            }
            else
                New = TabMonstre[TabOrdreDesMonstre[IndiceTabMonstre + 1]];
            Description = String.Format("NOM: {0}\nVIE= {1}\nDEFENSE= {2}\nATTACK= {3}\nARGENT= {3}", New.m_nom, New.m_Vie, New.m_defense, New.m_Dommage, New.m_ArgentRecu);
            rtNextEnnemi.Text = Description;
        }

        private void dNiveauFinale_MouseMove(object sender, MouseEventArgs e)
        {
            rtNextEnnemi.Visible = false;
        }
       #endregion
        #region FONCTION

        public void InitialisteurDeVieMechant(int nb, int Numennemi)
        {
            switch (Numennemi)
            {
                case 1:
                    //initialisateur de vie mechant + graphique
                    m_VieMechant = ((cMonstre)TabMonstre[nb]).m_Vie;
                    pbMechant.Image = ((cMonstre)TabMonstre[nb]).m_ImageMonstre;
                    BarreVieMechant.Step = m_VieMechant;
                    BarreVieMechant.Maximum = m_VieMechant;
                    BarreVieMechant.PerformStep();
                    LbVieMechant.Text = m_VieMechant.ToString() + "/" + m_VieMechant.ToString();
                    LbMechant.Text = ((cMonstre)TabMonstre[nb]).m_nom;
                    break;
                case 2: m_VieMechant2 = ((cMonstre)TabMonstre[nb]).m_Vie;
                    pbNextEnnemi.Image = ((cMonstre)TabMonstre[nb]).m_ImageMonstre;
                    BarreVieMechant2.Step = m_VieMechant;
                    BarreVieMechant2.Maximum = m_VieMechant;
                    BarreVieMechant2.PerformStep();
                    lbViemechant2.Text = m_VieMechant.ToString() + "/" + m_VieMechant.ToString();
                    lbNextEnnemi.Text = ((cMonstre)TabMonstre[nb]).m_nom + " (mini)";
                    break;
                case 3: m_VieMechant3 = ((cMonstre)TabMonstre[nb]).m_Vie;
                    pbMiniBoss3.Image = ((cMonstre)TabMonstre[nb]).m_ImageMonstre;
                    BarreVieMechant3.Step = m_VieMechant;
                    BarreVieMechant3.Maximum = m_VieMechant;
                    BarreVieMechant3.PerformStep();
                    lbVieMechant3.Text = m_VieMechant.ToString() + "/" + m_VieMechant.ToString();
                    lbMiniboss3.Text = ((cMonstre)TabMonstre[nb]).m_nom + " (mini)";
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
        #endregion
    }
}
