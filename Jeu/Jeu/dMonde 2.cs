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
    public partial class Monde_2 : Form
    {
      #region variable utilisées
       
/*Choix*/                 private int m_Nbchoisideja, m_NumeroMonstre,m_NumeroMonstre2,m_MonstreaAttaquer=1;
/*Vie*/                   private int m_VieMechant,m_VieMechant2, m_ViePerso;
/*Combat*/                private int NumAction, NumActionMechant2, Attack, ActionAttackmechant, ActionDefensemechant, ActionAttackmechant2,ActionDefensemechant2;
/*arme acquise*/          private int ArmeChoisi;
/*BOSS*/                  private int m_NbrestantMonstreBoss = 2;
/* mort juste       */    private bool MechantMort, MechantMort2; 
/*regarder une fois */
/*Rune*/                  private int Rune1, Rune2;
/*compteur pr rune*/      private int Paralysie = 3, Soin = 0;
/* Soin ACtivée ?*/       private bool SoinActif = false;
/*Ennemi est paralyser*/  private bool Monstre1paralyser, Monstre2Paralyser;
/*Pour gbarme*/           private bool Ouvert = false;
/*ACCES 3iemePLanete*/    public bool PLanete3Permise = false;
/*ARGENT*/                public int m_Argent;
/*EXPERIENCE*/            public int m_Experience;
      #region classe
  /*SONS*/                private  SoundPlayer sp = new System.Media.SoundPlayer("Musique\\Music_combat2.wav");
  /* mechant choisi 1*/   private  cMonstre m_monstreChoisi;
  /* mechant choisi 2*/   private  cMonstre m_monstreChoisi2;
  /*Aleatoire*/           private  Random r = new Random();
   #endregion
        #endregion
      #region tableaux utilisés
 //Different tableau
       static public cMonstre[] TabMonstre = new cMonstre[5];
       private object[] TabActions = new object[2];
       private object[] TabActionsMechant2 = new object[2];
       private object[] PersonnageComplet;
 #endregion
    

      public Monde_2(object []pComplet,int WeaponSelected,bool P3,int R1,int R2)
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
            PLanete3Permise = P3;
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
            m_ViePerso =(int) pComplet[4];
            BarreVie.Step = m_ViePerso;
            BarreVie.Maximum = m_ViePerso;
            BarreVie.PerformStep();
            lbViePerso.Text = pComplet[4].ToString() + "/" + pComplet[4].ToString();
            #endregion

            ///Choix mechant
            ///initialisateur
            #region ChoixMechant + InitialisateurvieMechant
            TabMonstre[0] = new cMonstre("Akasha", 30, 40, 5, 40,Image.FromFile("Mechant.Marchand\\P2Mechant1.jpg"));
            TabMonstre[1] = new cMonstre("Malakai", 50, 20, 5, 30,Image.FromFile("Mechant.Marchand\\P2Mechant2.jpg"));
            TabMonstre[2] = new cMonstre("Scythe", 60, 15, 10, 20,Image.FromFile("Mechant.Marchand\\P2Mechant3.jpg"));
            TabMonstre[3] = new cMonstre("Nergal", 40, 15, 5, 10,Image.FromFile("Mechant.Marchand\\P2Mechant4.jpg"));
            TabMonstre[4] = new cMonstre("Devdan (BOSS)", 100, 50, 10, 70,Image.FromFile("Mechant.Marchand\\MagieVendeur.jpg"));
         
            m_NumeroMonstre = ChoisirHasardMechant(1);
            m_NumeroMonstre2 = ChoisirHasardMechant(2);
           
            m_monstreChoisi = ((cMonstre)TabMonstre[m_NumeroMonstre]);
            m_monstreChoisi2 = ((cMonstre)TabMonstre[m_NumeroMonstre2]);
      
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

             #endregion
          
        }

      #region evenement des bouton lorsque clické

      private void btnContinue_Click(object sender, EventArgs e)
        {
            #region form remise a neuf
            btnAttack.Enabled = true;
            lbMechant.Enabled = true;
            lbMechant2.Enabled = true;
            pbMechant.Enabled = true;
            pbMechant2.Enabled = true;
            #endregion

            //remettre attack et action comme debut
            #region lbdommage remis a neuf des 3 personnages + mort=false
            lbActionMechant.Text = "";
            lbActionMechant2.Text = "";
            lbDomMechant.Text = "Dommage";
            lbDomMechant2.Text = "Dommage";
            lbDomPerso.Text = "Dommage";
            MechantMort = false;
            MechantMort2 = false;
            #endregion

            #region Arrivée Du Boss /  Monstre aléatoire
            m_NbrestantMonstreBoss--;
            if (m_NbrestantMonstreBoss == 0)
            {
                Monstre1paralyser = false;
                m_NumeroMonstre = 4;
                InitialisteurDeVieMechant(m_NumeroMonstre, 1);
                pbMechant_Click(sender, e);
                lbMechant2.Enabled = false;
                pbMechant.Enabled = false;
                pbMechant2.Enabled = false;
                MechantMort2 = true;
            }

            //Rotation des monstres
            else
            {
                m_NumeroMonstre = ChoisirHasardMechant(1);
                m_NumeroMonstre2 = ChoisirHasardMechant(2);
            }
                
            #endregion
             
            m_monstreChoisi = ((cMonstre)TabMonstre[m_NumeroMonstre]);
            m_monstreChoisi2 = ((cMonstre)TabMonstre[m_NumeroMonstre2]);

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
            #endregion

            btnAttack.Enabled = true;
            btnContinue.Enabled = false;
            if (Soin <= 0)
                btnSoin.Enabled = true;
          //ennemi un Mis de base
            pbMechant_Click(sender, e);
        }

      private void btnAttack_Click(object sender, EventArgs e)
        {
            //decrementation variable Soin
            #region Rune de soin - Utilisation
            Soin--;
            if (Soin <= 0)
                btnSoin.Enabled = true;
            if (!SoinActif)
                lbSoin.Visible = false;
            #endregion

            //Action aleatoire mechant si NON PARALYSÉ
            #region Action Choisi par les 2 monstre
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
            #endregion

            //Selon lactionchoisi si NON PARALYSÉ ET VIVANT
            #region Point dattack et de defense 2 monstre
            if (Monstre1paralyser == false)
            {
                if (!MechantMort)
                {
                    ActionAttackmechant = ((cActionMechant)TabActions[NumAction]).Domm;
                    ActionDefensemechant = ((cActionMechant)TabActions[NumAction]).Protection;
                }
            }
            if (Monstre2Paralyser == false)
            {
                if (!MechantMort2)
                {
                    ActionAttackmechant2 = ((cActionMechant)TabActionsMechant2[NumActionMechant2]).Domm;
                    ActionDefensemechant2 = ((cActionMechant)TabActionsMechant2[NumActionMechant2]).Protection;
                }
            }
            #endregion

            //texte selon choix de ladversaire Si NON PARALYSÉ
            #region texte
            Thread.Sleep(500);
            #region Mechant1
            if (Monstre1paralyser == false)
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
            #endregion

            //selon larme choisi
            #region Attack si nest pas en mode Soin
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
            Thread.Sleep(500);
            #endregion
             
            //changement graphique apres attack contre mechant
            #region changementGraphMechant
            #region Monstre 1
            if (m_MonstreaAttaquer == 1)
            {
                BarreVieMechant.PerformStep();
                if(Monstre1paralyser==false)
                lbDomMechant.Text = BarreVieMechant.Step.ToString();
            }
            #endregion
            #region Monstre 2
            else
            {
                BarreVieMechant2.PerformStep();
                if(Monstre2Paralyser==false)
                lbDomMechant2.Text = BarreVieMechant2.Step.ToString();
            }
            #endregion

            //texte vie mechant
            lbVieMechant.Text = m_VieMechant + "/" + m_monstreChoisi.m_Vie.ToString();
            lbVieMechant2.Text = m_VieMechant2 + "/" + m_monstreChoisi2.m_Vie.ToString();
            #endregion

            //Si la vie du montre tombe a zero(et celle du boss)
            #region SI Monstre 0 HP + desactivation de lattack pour continuer
            string cs="";

           
                #region si Monstre 1 battu (boss inclus dedans)
                if (m_VieMechant <= 0 && MechantMort==false)
                {
                    MechantMort = true;
                    #region Compteur pour paralysie(si Rune 2 acquise)
                    if (Rune2 == 1)
                    {
                        Paralysie--;
                        if (Paralysie == 0)
                        {
                            lbDomMechant2.Text = "ENNEMI \n PARALYSÉ";
                            lbActionMechant2.Text = "";
                            ActionDefensemechant2 = 0;
                            Monstre2Paralyser=true;
                        }
                        else
                            Monstre2Paralyser=false;
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
                    #endregion
                    #region passe a lennemi 2
                    if (!MechantMort2)
                    pbMechant2_Click(sender, e);
                    #endregion
                    m_Argent += m_monstreChoisi.m_ArgentRecu;
                    m_Experience++;
                    //AFFICHAGE DE Largent ACQUISE

                    #region si Boss Vaincu
                    if (m_NbrestantMonstreBoss == 0)//SI BOSS VAINCU
                    {
                        PLanete3Permise = true;
                        m_Experience += 2;
                        cs = String.Format("VOUS AVEZ VAINCU LE BOSS {0} \n \n {1}\n\n ARGENT RECU {2}\n\n Experience en main {3} \n ***Magasin artefact débloqué***", m_monstreChoisi.m_nom, PersonnageComplet[1], m_monstreChoisi.m_ArgentRecu,m_Experience);
                        MessageBox.Show(cs); 
                        this.Close();
                    }

                    #endregion

                    else
                    {
                        cs = String.Format("{0}\n\n ARGENT RECU {1}\n\n Experience en main {2}",PersonnageComplet[1], m_monstreChoisi.m_ArgentRecu,m_Experience);
                        MessageBox.Show(cs);
                    }

                    if (Paralysie == 0)
                    {
                        cMonstre[] TabCMonstre = new cMonstre[1];
                        TabCMonstre[0] = m_monstreChoisi2;
                        dChoixEnnemiAParalyser ChoixEnnemi = new dChoixEnnemiAParalyser(TabCMonstre);
                        ChoixEnnemi.ShowDialog();

                    }
                }
#endregion
                #region si Monstre 2 battu
                if (m_VieMechant2 <= 0 && MechantMort2==false)
                {
                    MechantMort2 = true;
                    #region Compteur pour paralysie(si Rune 2 acquise)
                    if (Rune2 == 1)
                    {
                        Paralysie--;
                        if (Paralysie == 0)
                        {
                            lbDomMechant.Text = "ENNEMI \n PARALYSÉ";
                            Monstre1paralyser = true;
                            lbActionMechant.Text = "";
                            ActionDefensemechant = 0;
                        }
                        else
                            Monstre1paralyser = false;
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
#endregion
                    #region passe a l'ennemi 1
                    if (!MechantMort)
                        pbMechant_Click(sender, e);
                    #endregion
                    m_Argent += m_monstreChoisi2.m_ArgentRecu;
                    m_Experience++;
                    //AFFICHAGE DE Largent ACQUISE
                    cs = String.Format("{0}\n\n ARGENT RECU {1}\n\n Experience en main {2}", PersonnageComplet[1], m_monstreChoisi2.m_ArgentRecu,m_Experience);
                    MessageBox.Show(cs);
                    if (Paralysie == 0)
                    {
                        cMonstre[] TabCMonstre = new cMonstre[1];
                        TabCMonstre[0] = m_monstreChoisi;
                        dChoixEnnemiAParalyser ChoixEnnemi = new dChoixEnnemiAParalyser(TabCMonstre);
                        ChoixEnnemi.ShowDialog();

                    }
                }
                #endregion

                lbArgent.Text = m_Argent.ToString();
                lbExperience.Text = m_Experience.ToString();
                #region Si les 2 monstres sont battus
                if (m_VieMechant <= 0 && m_VieMechant2 <= 0)
                {
                    //desactivation du bouton dattack
                    btnAttack.Enabled = false;
                    btnSoin.Enabled = false;
                    btnContinue.Enabled = true;
                    panMechant1.BackColor = Color.DarkRed;
                    panMechant2.BackColor = Color.DarkRed ;
                    return;
                }
                #endregion
               
            
            #endregion

            //calcul de vie perso (attack des 2 monstre)
           #region calcul vie perso
                #region Si mechant 1 ou 2 mort
                if (MechantMort == true)
                    ActionAttackmechant = 0;
                if (MechantMort2 == true)
                    ActionAttackmechant2 = 0;
                #endregion
                #region Si Monstre 1 paralyse ou monstre 2 ou aucun
         
                if (Monstre1paralyser == true)
                    BarreVie.Step = -ActionAttackmechant2;
                else
                    if(Monstre2Paralyser==true)
                      BarreVie.Step=-ActionAttackmechant;
                    else
                        if(Monstre1paralyser==false && Monstre2Paralyser==false)
                         BarreVie.Step = -(ActionAttackmechant + ActionAttackmechant2);
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

            if (ActionAttackmechant == 0 && ActionAttackmechant2==0)
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
      #endregion

      //changement graphique quand on passe sur larme + quand on click dessus
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

        //changement dennemi en clickant dessus
      #region Evenement click et ennemi
        private void pbMechant_Click(object sender, EventArgs e)
        {
            lbMechant.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            lbMechant2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lbMechant.ForeColor = Color.White;
            lbMechant2.ForeColor = Color.Cyan;
            panMechant1.BackColor = Color.WhiteSmoke;
            panMechant2.BackColor = Color.DarkRed;
            m_MonstreaAttaquer = 1;
        }
        private void pbMechant2_Click(object sender, EventArgs e)
        {
            lbMechant.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lbMechant2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            lbMechant.ForeColor = Color.Cyan;
            lbMechant2.ForeColor = Color.White;
            panMechant1.BackColor = Color.DarkRed;
            panMechant2.BackColor = Color.WhiteSmoke;
            m_MonstreaAttaquer = 2;
        }
        #endregion

      #region FONCTION

        public int ChoisirHasardMechant(int Mechant1ou2)
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

            InitialisteurDeVieMechant(nb, Mechant1ou2);
            return nb;
        }

        public void InitialisteurDeVieMechant(int nb, int Monstre1ou2)
        {
            if (Monstre1ou2 == 1)
            {
                //initialisateur de vie mechant
                m_VieMechant = ((cMonstre)TabMonstre[nb]).m_Vie;
                pbMechant.Image = ((cMonstre)TabMonstre[nb]).m_ImageMonstre;
                BarreVieMechant.Step = m_VieMechant;
                BarreVieMechant.Maximum = m_VieMechant;
                BarreVieMechant.PerformStep();
                lbVieMechant.Text = m_VieMechant.ToString() + "/" + m_VieMechant.ToString();
                lbMechant.Text = ((cMonstre)TabMonstre[nb]).m_nom;
            }
            else
            {
                //initialisateur de vie mechant2
                m_VieMechant2 = ((cMonstre)TabMonstre[nb]).m_Vie;
                pbMechant2.Image = ((cMonstre)TabMonstre[nb]).m_ImageMonstre;
                BarreVieMechant2.Step = m_VieMechant2;
                BarreVieMechant2.Maximum = m_VieMechant2;
                BarreVieMechant2.PerformStep();
                lbVieMechant2.Text = m_VieMechant2.ToString() + "/" + m_VieMechant2.ToString();
                lbMechant2.Text = ((cMonstre)TabMonstre[nb]).m_nom;
            }
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

        static public cMonstre[] RetourneTabMonstre2()
        {
            cMonstre[] TabMonstre = new cMonstre[5];
            TabMonstre[0] = new cMonstre("Akasha", 35, 45, 10, 40, Image.FromFile("Mechant.Marchand\\P2Mechant1.jpg"));
            TabMonstre[1] = new cMonstre("Malakai", 55, 25, 10, 30, Image.FromFile("Mechant.Marchand\\P2Mechant2.jpg"));
            TabMonstre[2] = new cMonstre("Scythe", 65, 20, 15, 20, Image.FromFile("Mechant.Marchand\\P2Mechant3.jpg"));
            TabMonstre[3] = new cMonstre("Nergal", 45, 20, 10, 10, Image.FromFile("Mechant.Marchand\\P2Mechant4.jpg"));
            TabMonstre[4] = new cMonstre("Devdan (BOSS)", 105, 55, 15, 70, Image.FromFile("Mechant.Marchand\\MagieVendeur.jpg"));
            return TabMonstre;
        }
        #endregion

      

      
    }

}
