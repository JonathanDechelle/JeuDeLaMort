using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jeu
{
     class Arme
    {
         public string nom,TempsRecharge;
         public int DommageMin, DommageMax,Precision,Chargeur,Niveau;
        
        public Arme(string Name,int DomMin,int Dommax,int preci,int Charg, string TempsDeRecharge, int Level)
        {
            nom = Name;
            DommageMax = Dommax;
            DommageMin = DomMin;
            Precision = preci;
            Chargeur = Charg;
            TempsRecharge = TempsDeRecharge;
            Niveau = Level;
        }

      
        
    }
}
