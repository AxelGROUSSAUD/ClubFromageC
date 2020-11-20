using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer.Business
{
    class FamilleFromage
    {
        private int _id;
        private string _nom;
        private List<Fromage> _uneListeFromage ;

        public FamilleFromage()
        {
            _id = 0;
            _nom = "";
            _uneListeFromage = new List<Fromage>();
        }
    }
}
