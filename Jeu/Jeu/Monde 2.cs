using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Jeu
{
    public partial class Monde_2 : Form
    {
        #region variable utilisées
        /*SONS*/
        System.Media.SoundPlayer sp = new System.Media.SoundPlayer("Music_combat2.wav");
            /*Choix*/
            int m_choix, m_Nbchoisideja, m_NumeroMonstre,m_NumeroMonstre2,m_MonstreaAttaquer=1;
            /*Vie*/
            int m_VieMechant,m_VieMechant2, m_ViePerso;
            /*Combat*/
            int NumAction, NumActionMechant2, Attack, ActionAttackmechant, ActionDefensemechant, ActionAttackmechant2,ActionDefensemechant2;
            /*arme acquise*/
            int[] TabArmeenMain;
            int choixArme;
        
   /*ARGENT*/                public int m_Argent;
   /*BOSS*/                  int m_NbrestantMonstreBoss = 3;
   /*ACCES 3iemePLanete*/    public bool PLanete3Permise=false;
              
     /*perso choisi*/     cPersonnage m_persoChoisi;
     /* mechant choisi 1*/  cMonstre m_monstreChoisi;
     /* mechant choisi 2*/  cMonstre m_monstreChoisi2;
      /*Arme*/            cArme a=new cArme("",0,0,0,0,"",0);
 /*Aleatoire*/            Random r = new Random();
        #endregion
   
        //Different tableau
        object []TabMonstre=new object[5];
        object[] TabActions = new object[2];
        object[] TabActionsMechant2 = new object[2];
        object[] TabArmes = new object[5];
        //bool de mort juste regarder une fois 
        bool MechantMort, MechantMort2;

      public Monde_2(int ChoixPerso, int Money, int[] ArmeenMain)
        {
            InitializeComponent();
            sp.PlayLooping();

            #region Initialisation Arme choix perso + Argent
            m_Argent = Money;
            lbArgent.Text = m_Argent.ToString();
            m_choix = ChoixPerso;
            TabArmeenMain = ArmeenMain;
            TabArmes = (object[])a.TableauDarme();
            lbBoss.Text = "BOSS DANS " + m_NbrestantMonstreBoss + " VAGUES";
            #endregion
           #region Initialisation globale Premier combat en ouvrant la forme
            //Choix du personnage;
            #region choixPerso

            switch (m_choix)
            {
                case 0: pbPerso.Image = global::Jeu.Properties.Resources.AlienArmurelegerte;
                    pbArme1.Image = global::Jeu.Properties.Resources.Zat;
                    m_persoChoisi = new cPersonnage("Alien Armure legerte", 120);
                    choixArme = 0;

                    break;
                case 1: pbPerso.Image = global::Jeu.Properties.Resources.AlienHeavyWarrior;
                    pbArme1.Image = global::Jeu.Properties.Resources.PlasmaGun;
                    m_persoChoisi = new cPersonnage("Alien Armure lourde", 140);
                    choixArme = 1;

                    break;
                case 2: pbPerso.Image = global::Jeu.Properties.Resources.AlienIngenieur;
                    pbArme1.Image = global::Jeu.Properties.Resources.PlasmaGun;
                    m_persoChoisi = new cPersonnage("Alien Ingenieur", 130);
                    choixArme = 1;

                    break;
                case 3: pbPerso.Image = global::Jeu.Properties.Resources.AlienMedic;
                    pbArme1.Image = global::Jeu.Properties.Resources.Zat;
                    m_persoChoisi = new cPersonnage("Alien Medic", 120);
                    choixArme = 0;

                    break;
                case 4: pbPerso.Image = global::Jeu.Properties.Resources.AlienÉclaireur;
                    pbArme1.Image = global::Jeu.Properties.Resources.Zat;
                    m_persoChoisi = new cPersonnage("Alien eclaireur", 100);
                    choixArme = 0;

                    break;
                case 5: pbPerso.Image = global::Jeu.Properties.Resources.AlienSamourai;
                    pbArme1.Image = global::Jeu.Properties.Resources.Zat;
                    m_persoChoisi = new cPersonnage("Alien Samourai", 110);
                    choixArme = 0;
                    break;
            }
            #endregion

            //Choix darmes (initialiser ak les armes acquises)
            #region ChoixArme
            if (TabArmeenMain[2] == 1)
                pbArme2.Image = global::Jeu.Properties.Resources.klarix;
            if (TabArmeenMain[3] == 1)
                pbArme3.Image = global::Jeu.Properties.Resources.Catagan;
            if (TabArmeenMain[4] == 1)
                pbArme4.Image = global::Jeu.Properties.Resources.TwisterGun;
            if (TabArmeenMain[5] == 1)
                pbArme5.Image = global::Jeu.Properties.Resources.Desintregrateur;
            #endregion

            //initialisateur de vie perso
            #region InitialisateurviePerso
            m_ViePerso = m_persoChoisi.Vie;
            BarreVie.Step = m_ViePerso;
            BarreVie.Maximum = m_ViePerso;
            BarreVie.PerformStep();
            lbViePerso.Text = m_persoChoisi.Vie.ToString() + "/" + m_persoChoisi.Vie.ToString();
            #endregion

            ///Choix mechant
            ///initialisateur
            #region ChoixMechant + InitialisateurvieMechant
            TabMonstre[0] = new cMonstre("Akasha", 30, 40, 5, 40);//Vie- Attack++ defense- xp++
            TabMonstre[1] = new cMonstre("Malakai", 50, 20, 5, 30);//Vie+ Attack+ defense- xp+
            TabMonstre[2] = new cMonstre("Scythe", 60, 15, 10, 20);//Vie++ Attack defense xp
            TabMonstre[3] = new cMonstre("Nergal", 40, 15, 5, 10);// Vie Attack defense- xp-
            TabMonstre[4] = new cMonstre("Devdan", 100, 50, 10, 70);//BOSS
            
          
            //; Tibarn; Tormod;  Zihark; Haar; Lethe; Reyson; ; Caineghis; Kurthnaga ... 

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
    

        private void btnContinue_Click(object sender, EventArgs e)
        {

            #region Arrivée Du Boss /  Monstre aléatoire
            m_NbrestantMonstreBoss--;
            lbBoss.Text = "BOSS DANS " + m_NbrestantMonstreBoss + " VAGUES";

            if (m_NbrestantMonstreBoss == 0)
            {
                m_NumeroMonstre = 4;
                pbMechant.Image = global::Jeu.Properties.Resources.MagieVendeur;
                InitialisteurDeVieMechant(m_NumeroMonstre, 1);
                pbMechant2.Image = null; 
            }

            //Rotation des monstres
            else
            {
                m_NumeroMonstre = ChoisirHasardMechant(1);
                m_NumeroMonstre2 = ChoisirHasardMechant(2);
            }
                
            #endregion

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
            MechantMort2=false;
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

            btnContinue.Enabled = false;
        }

        private void btnAttack_Click(object sender, EventArgs e)
        {
            //Action aleatoire mechant
            #region Action Choisi 2 monstre
            if (!MechantMort)
                NumAction = ActionMechatHasard();
            else
                NumAction = -1;
            if (!MechantMort2)
                NumActionMechant2 = ActionMechatHasard();
            else
                NumActionMechant2 = -1;
            #endregion 

            //texte selon choix de ladversaire
            #region texte
            Thread.Sleep(800);
            #region Mechant1
            if (NumAction == 0)
            {
                lbActionMechant.Text = "Attack";
                lbActionMechant.ForeColor = Color.Red;
                lbActionMechant.Visible = true;
            }
            else
                if(NumAction==1)
            {
                lbActionMechant.Text = "Defense";
                lbActionMechant.ForeColor = Color.Cyan;
                lbActionMechant.Visible = true;
            }
            #endregion
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
            Thread.Sleep(1000);
            #endregion
            #endregion

            //Selon lactionchoisi
            #region Point dattack et de defense 2 monstre
            if (!MechantMort)
            {
                ActionAttackmechant = ((cActionMechant)TabActions[NumAction]).Domm;
                ActionDefensemechant = ((cActionMechant)TabActions[NumAction]).Protection;
            }
            if (!MechantMort2)
            {
                ActionAttackmechant2 = ((cActionMechant)TabActionsMechant2[NumActionMechant2]).Domm;
                ActionDefensemechant2 = ((cActionMechant)TabActionsMechant2[NumActionMechant2]).Protection;
            }
            #endregion
             
            //selon larme choisi du perso
            Attack = ((cArme)TabArmes[choixArme]).DommageMax;

            //Calcul ds letat de vie (mechant)
            #region Calcul etat de vie mechant
            if (!MechantMort)
            {
                #region Monstre 1
                if (m_MonstreaAttaquer == 1)
                {
                    BarreVieMechant.Step = -Attack + ActionDefensemechant;
                    m_VieMechant += BarreVieMechant.Step;
                    Thread.Sleep(500);
                }
                #endregion
            }
            if(!MechantMort2)
            {
                   #region Monstre 2
            if(m_MonstreaAttaquer==2)
            {
                BarreVieMechant2.Step = -Attack + ActionDefensemechant2;
                m_VieMechant2 += BarreVieMechant2.Step;
                Thread.Sleep(500);
            }
            #endregion
            }
            #endregion
             
            //changement graphique apres attack contre mechant
            #region changementGraphMechant
            #region Monstre 1
            if (m_MonstreaAttaquer == 1)
            {
                BarreVieMechant.PerformStep();
                lbDomMechant.Text = BarreVieMechant.Step.ToString();
            }
            #endregion
            #region Monstre 2
            else
            {
                BarreVieMechant2.PerformStep();
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
                    //AFFICHAGE DE Largent ACQUISE

                    #region si Boss Vaincu
                    if (m_NbrestantMonstreBoss == 0)//SI BOSS VAINCU
                    {
                        PLanete3Permise = true;
                        cs = String.Format("VOUS AVEZ VAINCU LE BOSS alias ({0}) \n \n {1}\n\n ARGENT RECU {2}", m_monstreChoisi.m_nom, m_persoChoisi.nom, m_monstreChoisi.m_ArgentRecu);
                        this.Close();
                    }

                    #endregion

                    else
                    {
                        cs = String.Format("{0}\n\n ARGENT RECU {1}", m_persoChoisi.nom, m_monstreChoisi.m_ArgentRecu);
                        MessageBox.Show(cs);
                    }
                }
#endregion
                #region si Monstre 2 battu
                if (m_VieMechant2 <= 0 && MechantMort2==false)
                {
                    MechantMort2 = true;
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
                    if(!MechantMort)
                    pbMechant_Click(sender, e);
                    #endregion
                    m_Argent += m_monstreChoisi2.m_ArgentRecu;
                    
                    //AFFICHAGE DE Largent ACQUISE
                    cs = String.Format("{0}\n\n ARGENT RECU {1}", m_persoChoisi.nom, m_monstreChoisi2.m_ArgentRecu);
                    MessageBox.Show(cs);
                }
                #endregion

                lbArgent.Text = m_Argent.ToString();

                #region Si les 2 monstres sont battus
                if (m_VieMechant <= 0 && m_VieMechant2 <= 0)
                {
                    //desactivation du bouton dattack
                    btnAttack.Enabled = false;
                    btnContinue.Enabled = true;
                    return;
                }
                #endregion
               
            
            #endregion

            //calcul de vie perso (attack des 2 monstre)
            
                if (MechantMort == true)
                    ActionAttackmechant = 0;
                if (MechantMort2 == true)
                    ActionAttackmechant2 = 0;
                BarreVie.Step = -(ActionAttackmechant + ActionAttackmechant2);
                m_ViePerso += BarreVie.Step;
            


            //Si la vie du perso tombe a zero
            #region SI Perso 0 HP+desactivation de lattack
            if (m_ViePerso <= 0)
            {
                m_ViePerso = 0;
                lbViePerso.Text = m_ViePerso + "/" + m_persoChoisi.Vie.ToString();
                lbDomPerso.Text = "0";
                BarreVie.Step = -400;
                BarreVie.PerformStep();

                //AFFICHAGE Du MESSAGE DE LA MORT
                cs = "";
                cs = String.Format("{0}\n\n VOUS ETES MORT ", m_persoChoisi.nom);
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

            lbViePerso.Text = m_ViePerso + "/" + m_persoChoisi.Vie.ToString();
            #endregion

        }

        //changement graphique quand on passe sur larme + quand on click dessus
        #region changement graphique
        private void pbArme1_MouseEnter(object sender, EventArgs e)
        {
            pbArme1.Size = new System.Drawing.Size(27, 24);
        }

        private void pbArme1_MouseLeave(object sender, EventArgs e)
        {
            pbArme1.Size = new System.Drawing.Size(24, 21);
        }

        private void pbArme1_Click(object sender, EventArgs e)
        {

            pbArme1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            pbArme2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            pbArme3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            pbArme4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            pbArme5.BorderStyle = System.Windows.Forms.BorderStyle.None;

            if (pbArme1.Image == global::Jeu.Properties.Resources.Zat)
                choixArme = 0;

            else
                choixArme = 1;

        }

        private void pbArme2_MouseEnter(object sender, EventArgs e)
        {
            pbArme2.Size = new System.Drawing.Size(27, 24);
        }

        private void pbArme2_MouseLeave(object sender, EventArgs e)
        {
            pbArme2.Size = new System.Drawing.Size(24, 21);
        }

        private void pbArme2_Click(object sender, EventArgs e)
        {
            pbArme1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            pbArme2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            pbArme3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            pbArme4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            pbArme5.BorderStyle = System.Windows.Forms.BorderStyle.None;

            choixArme = 2;
        }
        private void pbArme3_MouseEnter(object sender, EventArgs e)
        {
            pbArme3.Size = new System.Drawing.Size(27, 24);
        }

        private void pbArme3_MouseLeave(object sender, EventArgs e)
        {
            pbArme3.Size = new System.Drawing.Size(24, 21);
        }

        private void pbArme3_Click(object sender, EventArgs e)
        {
            pbArme1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            pbArme2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            pbArme3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            pbArme4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            pbArme5.BorderStyle = System.Windows.Forms.BorderStyle.None;

            choixArme = 3;
        }

        private void pbArme4_MouseEnter(object sender, EventArgs e)
        {
            pbArme4.Size = new System.Drawing.Size(27, 24);
        }

        private void pbArme4_MouseLeave(object sender, EventArgs e)
        {
            pbArme4.Size = new System.Drawing.Size(24, 21);
        }

        private void pbArme4_Click(object sender, EventArgs e)
        {
            pbArme1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            pbArme2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            pbArme3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            pbArme4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            pbArme5.BorderStyle = System.Windows.Forms.BorderStyle.None;

            choixArme = 4;
        }

        private void pbArme5_MouseEnter(object sender, EventArgs e)
        {
            pbArme5.Size = new System.Drawing.Size(27, 24);
        }

        private void pbArme5_MouseLeave(object sender, EventArgs e)
        {
            pbArme4.Size = new System.Drawing.Size(24, 21);
        }

        private void pbArme5_Click(object sender, EventArgs e)
        {
            pbArme1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            pbArme2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            pbArme3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            pbArme4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            pbArme5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            choixArme = 5;
        }
        #endregion

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

        //changement dennemi en clickant dessus
        #region Evenement click et ennemi
        private void pbMechant_Click(object sender, EventArgs e)
        {
            lbMechant.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            lbMechant2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lbMechant.ForeColor = Color.White;
            lbMechant2.ForeColor = Color.Cyan;
            m_MonstreaAttaquer = 1;
        }
        private void pbMechant2_Click(object sender, EventArgs e)
        {
            lbMechant.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lbMechant2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            lbMechant.ForeColor = Color.Cyan;
            lbMechant2.ForeColor = Color.White;
            m_MonstreaAttaquer = 2;
        }
        #endregion

        #region FONCTION

        public int ChoisirHasardMechant(int Mechant1ou2)
        {
            int nb = 0;
            Random r = new Random();
            nb = r.Next(0, 4);
            PictureBox pbMechantChoisi;

            //Affichement dun monstre different obligatoire
            if (nb == m_Nbchoisideja)
            {
                while (nb == m_Nbchoisideja)
                {
                    nb = r.Next(0, 4);
                }
            }
            m_Nbchoisideja = nb;

            if (Mechant1ou2 == 1)
                pbMechantChoisi = pbMechant;
            else
                pbMechantChoisi = pbMechant2;

            switch (nb)
            {
                case 0: pbMechantChoisi.Image = global::Jeu.Properties.Resources.P2Mechant1;
                    break;
                case 1: pbMechantChoisi.Image = global::Jeu.Properties.Resources.P2Mechant2;
                    break;
                case 2: pbMechantChoisi.Image = global::Jeu.Properties.Resources.P2Mechant3;
                    break;
                case 3: pbMechantChoisi.Image = global::Jeu.Properties.Resources.P2Mechant4;
                    break;
            }

            InitialisteurDeVieMechant(nb, Mechant1ou2);
            return nb;
        }

        public void InitialisteurDeVieMechant(int nb, int Monstre1ou2)
        {
            if (Monstre1ou2 == 1)
            {
                //initialisateur de vie mechant
                m_VieMechant = ((cMonstre)TabMonstre[nb]).m_Vie;
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
        #endregion

    
    }

}
