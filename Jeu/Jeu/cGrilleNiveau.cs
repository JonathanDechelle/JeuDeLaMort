using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jeu
{
    class cGrilleNiveau
    {
         private int Niveau;
         private bool MonterdeNiveau = false;
         static readonly public int[] TabledeNiveau = new int[10]
         {15,35,60,80,100,120,150,175,200,220};


         public cGrilleNiveau(int experience,int NiveauActuelle)
         {
             if (NiveauActuelle < 10)
             {
                 int i = 0;

                 //parcours le tableau dexperience
                 do
                 {
                     i++;
                 }

                 while (experience >= TabledeNiveau[i - 1]);

                 Niveau = i;

                 if (NiveauActuelle < Niveau)
                 {
                     MonterdeNiveau = true;
                 }
             }
         }

        public bool MonterNiv()
        {
            return MonterdeNiveau;
        }

       
    }
}
