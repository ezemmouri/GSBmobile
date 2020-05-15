using System;
using System.Collections.Generic;
using System.Text;

namespace GSBmobile
{
    public class Categorie
    {
        private String libelle;
        public Categorie(String pLibelle)
        {
            this.libelle = pLibelle;
        }
        public String getLibelle()
        {
            return this.libelle;
        }

        public override string ToString()
        {
            return libelle;
        }
    }

}
