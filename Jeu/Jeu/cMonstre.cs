using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Jeu
{
    public class cMonstre
    {
        public string m_nom;
        public int m_Vie;
        public int m_Dommage;
        public int m_defense;
        public int m_ArgentRecu;
        public Image m_ImageMonstre;

         public cMonstre(string Name, int Life,int Damage,int Defense,int Argent, Image ImageMonstre)
        {
            m_nom = Name;
            m_Vie = Life;
            m_Dommage = Damage;
            m_defense = Defense;
            m_ArgentRecu = Argent;
            m_ImageMonstre=ImageMonstre;
        }
      
        
      

       
        
    }
}
