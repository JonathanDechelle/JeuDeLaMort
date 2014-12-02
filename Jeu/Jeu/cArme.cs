using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jeu
{
    public class cArme 
    {
         public string nom,TempsRecharge;
         public int DommageMin, DommageMax,Precision,Chargeur,Niveau;
         #region public static cArme[] Tabarme (définition de ses 6 armes)
         public static cArme[] Tabarme = new cArme[7]{
              new cArme("Zat",15, 35, 25, "Moyenne", 1),
              new cArme("PlasmaGun",25, 30, 25, "Moyenne", 1),
               new cArme("Klarix", 40, 55, 20, "Rapide", 1),
             new cArme("Catagan", 60, 70, 25, "Moyenne", 1),
            new cArme("TwisterGun", 80, 95, 0, "Aucun", 1),
         new cArme("Desintegrateur", 110, 30, 12, "Lent", 1),
         new cArme("BOMBE NUCLEAIRE",999,100,1,"Tres Lent",1)};
#endregion

         public cArme(string Name,int Dommax,int preci,int Charg, string TempsDeRecharge, int Level)
        {
            nom = Name;
            DommageMax = Dommax;
            Precision = preci;
            Chargeur = Charg;
            TempsRecharge = TempsDeRecharge;
            Niveau = Level;
        }

        public static void ResetTableau()
         {
             Tabarme = new cArme[7]{
              new cArme("Zat",15, 35, 25, "Moyenne", 1),
              new cArme("PlasmaGun",25, 30, 25, "Moyenne", 1),
               new cArme("Klarix", 40, 55, 20, "Rapide", 1),
             new cArme("Catagan", 60, 70, 25, "Moyenne", 1),
            new cArme("TwisterGun", 80, 95, 0, "Aucun", 1),
         new cArme("Desintegrateur", 110, 30, 12, "Lent", 1),
        new cArme("BOMBE NUCLEAIRE",999,100,1,"Extremement Lent",1)};
         }
        
    }
}
