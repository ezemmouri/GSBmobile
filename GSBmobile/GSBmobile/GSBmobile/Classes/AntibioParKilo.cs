using System;
using System.Collections.Generic;
using System.Text;

namespace GSBmobile
{
    public class AntibioParKilo : Antibio
    {
        private int doseKilo;
        public AntibioParKilo(String pLibelle, String pUnite, Categorie pCategorie, int pDoseKilo, int pNombre) : base(pLibelle, pUnite, pCategorie, pNombre)
        {            
            this.doseKilo = pDoseKilo;
        }
        public int getDoseKilo()
        {
            return this.doseKilo;
        }
    }
}
