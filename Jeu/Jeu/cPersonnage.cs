using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Jeu
{
    public class cPersonnage
    {  
         public string nom;
         public int Vie;
         public int choixVoulu;
         public int ArmedeBase;
         public int NbCoupPourSoin;
   
         public Image ImagePersonnage, ImageArme;

        public cPersonnage(int choix)
        {
            switch (choix)
            {
                case 0:
                    choixVoulu = 0;
                    nom = "Alien Armure legerte";
                    ImagePersonnage = Image.FromFile("Perso Image\\AlienArmurelegerte.jpg");
                    ImageArme = Image.FromFile("Arme\\Zat.jpg");
                    ArmedeBase = 0;
                    Vie=120;
                    NbCoupPourSoin = 4;
                  
                    break;
                case 1:
                    choixVoulu = 1;
                    nom = "Alien Armure lourde";
                    ImagePersonnage = Image.FromFile("Perso Image\\AlienHeavyWarrior.jpg");
                    ImageArme = Image.FromFile("Arme\\PlasmaGun.jpg");
                    ArmedeBase = 1;
                    Vie=140;
                    NbCoupPourSoin = 5;
                    break;
                case 2:
                    choixVoulu = 2;
                    nom= "Alien Ingenieur";
                    ImagePersonnage = Image.FromFile("Perso Image\\AlienIngenieur.jpg");
                    ImageArme = Image.FromFile("Arme\\PlasmaGun.jpg");
                    ArmedeBase = 1;
                    Vie= 130;
                    NbCoupPourSoin = 5;
                  
                    break;
                case 3:
                    choixVoulu = 3;
                    nom= "Alien Medic";
                    ImagePersonnage = Image.FromFile("Perso Image\\AlienMedic.jpg");
                    ImageArme = Image.FromFile("Arme\\Zat.jpg");
                    ArmedeBase = 0;
                    Vie= 120;
                    NbCoupPourSoin = 2;

                    break;
                case 4:
                    choixVoulu = 4;
                    nom= "Alien eclaireur";
                    ImagePersonnage = Image.FromFile("Perso Image\\AlienÉclaireur.jpg");
                    ImageArme = Image.FromFile("Arme\\Zat.jpg");
                    ArmedeBase = 0;
                    Vie=100 ;
                    NbCoupPourSoin = 3;
                   
                    break;
                case 5:
                    choixVoulu = 5;
                    nom="Alien Samourai";
                    ImagePersonnage = Image.FromFile("Perso Image\\AlienSamourai.jpg");
                    ImageArme = Image.FromFile("Arme\\Zat.jpg");
                    ArmedeBase = 0;
                    Vie=110;
                    NbCoupPourSoin = 4;
                   
                    break;
            }
        }

        
    }
}
