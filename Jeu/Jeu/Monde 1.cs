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
    public partial class Monde_1 : Form
    {
       /*SONS*/System.Media.SoundPlayer sp = new System.Media.SoundPlayer("FFfight1.wav");
      /*Choix*/int m_choix, m_Nbchoisideja,m_NumeroMonstre;
      /*Vie*/  int m_VieMechant,m_ViePerso;
    /*Combat*/ int NumAction, Attack, ActionAttackmechant, ActionDefensemechant;
              
     /*perso choisi*/ cPersonnage m_persoChoisi;
     /* mechant choisi*/  cMonstre m_monstreChoisi;
      /*Arme*/ cArme a=new cArme("",0,0,0,0,"",0);
 /*Aleatoire*/ Random r = new Random();

        //Different tableau
        object []TabMonstre=new object[4];
        object[] TabActions = new object[2];
        object[] TabArmes = new object[4];

       
        public Monde_1(int ChoixPerso)
        {
            InitializeComponent();
            sp.PlayLooping();
            m_choix = ChoixPerso;
            TabArmes = (object[])a.TableauDarme();
            switch (m_choix)
            {
                case 0: pbPerso.Image = global::Jeu.Properties.Resources.AlienArmurelegerte;
                        pbArme1.Image = global::Jeu.Properties.Resources.Zat;
                        m_persoChoisi = new cPersonnage("Alien Armure legerte", 120);
           
                break;
                case 1: pbPerso.Image = global::Jeu.Properties.Resources.AlienHeavyWarrior;
                       pbArme1.Image = global::Jeu.Properties.Resources.PlasmaGun;
                       m_persoChoisi = new cPersonnage("Alien Armure lourde", 140);
                    
                break;
                case 2: pbPerso.Image = global::Jeu.Properties.Resources.AlienIngenieur;
                        pbArme1.Image = global::Jeu.Properties.Resources.PlasmaGun;
                        m_persoChoisi = new cPersonnage("Alien Ingenieur", 130);
                  
                break;
                case 3: pbPerso.Image = global::Jeu.Properties.Resources.AlienMedic;
                        pbArme1.Image = global::Jeu.Properties.Resources.Zat;
                        m_persoChoisi = new cPersonnage("Alien Medic", 120);
                  
                break;
                case 4: pbPerso.Image = global::Jeu.Properties.Resources.AlienÉclaireur;
                        pbArme1.Image = global::Jeu.Properties.Resources.Zat;
                        m_persoChoisi = new cPersonnage("Alien eclaireur", 100);
                  
                break;
                case 5: pbPerso.Image = global::Jeu.Properties.Resources.AlienSamourai;
                        pbArme1.Image = global::Jeu.Properties.Resources.Zat;
                        m_persoChoisi = new cPersonnage("Alien Samourai", 110);
                    
                break;

            }

            //initialisateur de vie perso
            m_ViePerso = m_persoChoisi.Vie;
            BarreVie.Step = m_ViePerso;
            BarreVie.Maximum = m_ViePerso;
            BarreVie.PerformStep();
            lbViePerso.Text = m_persoChoisi.Vie.ToString() + "/" + m_persoChoisi.Vie.ToString();
            ///Choix mechant
            ///initialisateur
            TabMonstre[0] = new cMonstre("Alastor", 30, 40,5,40);//Vie- Attack++ defense- xp++
            TabMonstre[1] = new cMonstre("Scorn", 50, 20,5,30);//Vie+ Attack+ defense- xp+
            TabMonstre[2] = new cMonstre("Kragoth", 60, 15,10,20);//Vie++ Attack defense xp
            TabMonstre[3] = new cMonstre("Nasir", 40, 15,5,10);// Vie Attack defense- xp-
           //Sinon ^^ , Scythe, Scorn, Malakai, Akasha, 
           //Ashnard; Nergal; Tibarn; Tormod; Devdan; Zihark; Haar; Lethe; Reyson; ; Caineghis; Kurthnaga ... 
            
            m_NumeroMonstre=ChoisirHasardMechant();
            m_monstreChoisi = ((cMonstre)TabMonstre[m_NumeroMonstre]);
            //initialisateur de vie mechant
            m_VieMechant = m_monstreChoisi.m_Vie;
            BarreVieMechant.Step = m_VieMechant;
            BarreVieMechant.Maximum = m_VieMechant;
            BarreVieMechant.PerformStep();
            LbVieMechant.Text = m_VieMechant.ToString() + "/" + m_VieMechant.ToString();
            //actions initialisateur
            /*ATTACK*/
            TabActions[0] = new cActionMechant(m_monstreChoisi.m_Dommage, 0);
            /*DEFENSE*/
            TabActions[1] = new cActionMechant(0, m_monstreChoisi.m_defense);
                 
        }
    
        private void btnContinue_Click(object sender, EventArgs e)
        {
           //Rotation des monstres
           m_NumeroMonstre= ChoisirHasardMechant();
           btnAttack.Enabled = true;
            //remettre attack et action comme debut
           lbActionMechant.Text = "";
           lbDomMechant.Text = "Dommage";
           lbDomPerso.Text = "Dommage";
        }

        public int ChoisirHasardMechant()
        {  //choix au hasard du monstre
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

            //initialisateur de vie mechant
            m_VieMechant = ((cMonstre)TabMonstre[nb]).m_Vie;
            BarreVieMechant.Step = m_VieMechant;
            BarreVieMechant.Maximum = m_VieMechant;
            BarreVieMechant.PerformStep();
            LbVieMechant.Text = m_VieMechant.ToString() + "/" + m_VieMechant.ToString();
            LbMechant.Text = ((cMonstre)TabMonstre[nb]).m_nom;
            return nb;
        }
        public int ActionMechatHasard()
        {
            int nb = 0;
            Random r = new Random();
            nb = r.Next(0, 2);
            return nb;
        }

        private void btnAttack_Click(object sender, EventArgs e)
        {
            
            //Action aleatoire mechant
             NumAction = ActionMechatHasard();
           //selon larme choisi
             Attack = ((cArme)TabArmes[0]).DommageMax;
           //Selon lactionchoisi
             ActionAttackmechant = ((cActionMechant)TabActions[NumAction]).Domm;
             ActionDefensemechant = ((cActionMechant)TabActions[NumAction]).Protection;
            //Calcul ds letat de vie
            m_VieMechant -= Attack - ActionDefensemechant; 
            m_ViePerso -= ActionAttackmechant;
            BarreVieMechant.Step = -Attack +ActionDefensemechant;
            BarreVie.Step = -ActionAttackmechant;
            Thread.Sleep(500);
            //changement graphique mechant
            BarreVieMechant.PerformStep();
            lbDomMechant.Text = (-Attack + ActionDefensemechant).ToString();
            //texte vie mechant
            LbVieMechant.Text = m_VieMechant + "/" + m_monstreChoisi.m_Vie.ToString();
            //Si la vie du montre tombe a zero
            if (m_VieMechant <= 0)
            {
                m_VieMechant= 0;
                LbVieMechant.Text = m_VieMechant + "/" + ((cMonstre)TabMonstre[m_NumeroMonstre]).m_Vie.ToString();
                lbDomMechant.Text = "0";
                //AFFICHAGE DE LEXPERIENCE ACQUISE
                 string cs = "";
                 cs = String.Format("{0}\n\n EXPERIENCE ACQUISE {1}", m_persoChoisi.nom, m_monstreChoisi.m_xp);
                 MessageBox.Show(cs);
                //desactivation du bouton dattack
                 btnAttack.Enabled = false;
                return;
            }
            //texte selon choix de ladversaire
            Thread.Sleep(800);
            if (NumAction == 0)
            {
                lbActionMechant.Text =  "Attack";
                lbActionMechant.ForeColor = Color.Red;
                lbActionMechant.Visible = true;
            }
            else
            {
                lbActionMechant.Text = "Defense";
                lbActionMechant.ForeColor = Color.Blue;
                lbActionMechant.Visible = true;
            }
          
            Thread.Sleep(1000);
            //Changement graphique vie perso
            BarreVie.PerformStep();

            if (ActionAttackmechant == 0)
                lbDomPerso.Text = "0";
            else
                lbDomPerso.Text = (-ActionAttackmechant).ToString();
            
            lbViePerso.Text = m_ViePerso + "/" + m_persoChoisi.Vie.ToString();
           
        }

        //changement graphique quand on passe sur larme
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
        }

      

      

    }
}
