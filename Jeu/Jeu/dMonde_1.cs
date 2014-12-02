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
    public partial class dMonde_1 : Form
    {
        #region variable utiliséés
        /*SONS*/
        System.Media.SoundPlayer sp = new System.Media.SoundPlayer("FFfight1.wav");
      /*Choix*/int m_choix, m_Nbchoisideja,m_NumeroMonstre;
      /*Vie*/  int m_VieMechant,m_ViePerso;
      /*Combat*/int NumAction, Attack, ActionAttackmechant, ActionDefensemechant;
      /*arme acquise*/ int []TabArmeenMain;
                        int choixArme;
   /*ARGENT*/  public int m_Argent;
    /*Experience*/  public int m_Experience;
   /*BOSS*/ int m_NbrestantMonstreBoss = 3;
   /*ACCES 2iemePLanete*/public bool PLanete2Permise;
   /*Rune*/ int Rune1, Rune2;
    /*compteur pr rune*/int Paralysie=3, Soin=0;
        #region classe
   /*perso choisi*/ cPersonnage m_persoChoisi;
     /* mechant choisi*/  cMonstre m_monstreChoisi;
      /*Arme*/ cArme a=new cArme("",0,0,0,0,"",0);
 /*Aleatoire*/ Random r = new Random();
   #endregion
        #endregion
        #region tableaux tuilisés
 //Different tableau
        object []TabMonstre=new object[5];
        object[] TabActions = new object[2];
        object[] TabArmes = new object[5];
 #endregion

        public dMonde_1(int ChoixPerso, int Money, int[] ArmeenMain,int Exp,bool P2,int R1,int R2)
        {
            InitializeComponent();
            sp.PlayLooping();

            #region Initialisation Arme choix perso + Argent
            m_Argent = Money;
            lbArgent.Text = m_Argent.ToString();
            m_choix = ChoixPerso;
            TabArmeenMain = ArmeenMain;
            TabArmes = (object[])a.TableauDarme();
            lbBoss.Text = "BOSS DANS " + m_NbrestantMonstreBoss + " MONSTRE";
            #endregion
            #region Experience et Planete + Rune
            m_Experience = Exp;
            PLanete2Permise = P2;
            Rune1 = R1;
            Rune2 = R2;
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

            //rune en main
            #region Rune
            if (Rune1 == 1)
                pbRune1.Image = global::Jeu.Properties.Resources.Rune4;
            if (Rune2 == 1)
                pbRune2.Image = global::Jeu.Properties.Resources.Rune1;
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
            TabMonstre[0] = new cMonstre("Alastor", 30, 40, 5, 40);//Vie- Attack++ defense- xp++
            TabMonstre[1] = new cMonstre("Scorn", 50, 20, 5, 30);//Vie+ Attack+ defense- xp+
            TabMonstre[2] = new cMonstre("Kragoth", 60, 15, 10, 20);//Vie++ Attack defense xp
            TabMonstre[3] = new cMonstre("Nasir", 40, 15, 5, 10);// Vie Attack defense- xp-
            TabMonstre[4] = new cMonstre("Ashnard", 100, 50, 10, 70);//BOSS
            
            //Nomfuture Sinon ^^ , Scythe, Malakai, Akasha, 
            // Nergal; Tibarn; Tormod; Devdan; Zihark; Haar; Lethe; Reyson; ; Caineghis; Kurthnaga ... 

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
            lbBoss.Text = "BOSS DANS " + m_NbrestantMonstreBoss + " MONSTRE";

            if (m_NbrestantMonstreBoss == 0)
            {
                m_NumeroMonstre = 4;
                pbMechant.Image = global::Jeu.Properties.Resources.Boss1;
                InitialisteurDeVieMechant(m_NumeroMonstre);
            }

            //Rotation des monstres
            else
                m_NumeroMonstre = ChoisirHasardMechant();
            #endregion

            btnAttack.Enabled = true;

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
                   lbDomMechant.Text = "ENNEMI \n PARALYSÉ";
               }
           }
           #endregion

           btnContinue.Enabled = false;
        }

        private void btnAttack_Click(object sender, EventArgs e)
        {
            //Action aleatoire mechant et si NON PARALYSÉ
            if (Paralysie != 0)
            {
                NumAction = ActionMechatHasard();
                //Selon lactionchoisi
                ActionAttackmechant = ((cActionMechant)TabActions[NumAction]).Domm;
                ActionDefensemechant = ((cActionMechant)TabActions[NumAction]).Protection;
            }
           //selon larme choisi
             Attack = ((cArme)TabArmes[choixArme]).DommageMax;
          

             //Calcul ds letat de vie (mechant)
             #region Calcul etat de vie mechant
           
                 BarreVieMechant.Step = -Attack + ActionDefensemechant;
                 m_VieMechant += BarreVieMechant.Step;
           
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
                    cs = String.Format("VOUS AVEZ VAINCU LE BOSS alias ({0}) \n \n {1}\n\n ARGENT RECU {2}\n\n Experience en main {3}", m_monstreChoisi.m_nom, m_persoChoisi.nom, m_monstreChoisi.m_ArgentRecu,m_Experience);
                    this.Close();
                }

                #endregion

                else
                    cs = String.Format("{0}\n\n ARGENT RECU {1}\n\n Experience en main {2}", m_persoChoisi.nom, m_monstreChoisi.m_ArgentRecu,m_Experience);

                MessageBox.Show(cs);

                lbArgent.Text = m_Argent.ToString();
                //desactivation du bouton dattack
                btnAttack.Enabled = false;
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
                lbViePerso.Text = m_ViePerso + "/" + m_persoChoisi.Vie.ToString();
                lbDomPerso.Text = "0";
                BarreVie.Step = -400;
                BarreVie.PerformStep();

                //AFFICHAGE Du MESSAGE DE LA MORT
                string cs = "";
                cs = String.Format("{0}\n\n VOUS ETES MORT ", m_persoChoisi.nom);
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

                lbViePerso.Text = m_ViePerso + "/" + m_persoChoisi.Vie.ToString();
            }
            #endregion

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
            choixArme=5;
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
            switch (nb)
            {
                case 0: pbMechant.Image = global::Jeu.Properties.Resources.Mechant1;
                    break;
                case 1: pbMechant.Image = global::Jeu.Properties.Resources.Mechant2;
                    break;
                case 2: pbMechant.Image = global::Jeu.Properties.Resources.Mechant3;
                    break;
                case 3: pbMechant.Image = global::Jeu.Properties.Resources.Mechant4;
                    break;
            }

            InitialisteurDeVieMechant(nb);
            return nb;
        }

        public void InitialisteurDeVieMechant(int nb)
        {
            //initialisateur de vie mechant
            m_VieMechant = ((cMonstre)TabMonstre[nb]).m_Vie;
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
#endregion

     
    }
}
