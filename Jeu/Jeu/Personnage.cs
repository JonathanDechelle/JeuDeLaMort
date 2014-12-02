using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jeu
{
    class Personnage
    {  
         public string nom;
         public int Vie;
        
        public Personnage(string Name, int Life)
        {
            nom = Name;
            Vie = Life;

        }
    }
}
