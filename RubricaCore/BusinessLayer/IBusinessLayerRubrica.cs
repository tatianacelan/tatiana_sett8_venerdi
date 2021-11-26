using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubricaCore
{
  public  interface IBusinessLayerRubrica
    {
        public List<Contatto> GetAllContacts();
        public Esito AggiungiContatto(Contatto c);
        public Esito AggiungiIndirizzo(Indirizzo nuovoIndirizzo);

   



    }
}
