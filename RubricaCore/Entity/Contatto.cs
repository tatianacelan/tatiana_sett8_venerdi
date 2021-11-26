using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubricaCore
{
 public  class Contatto
    {
        public int IdContatto { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public int IdIndirizzo { get; set; }  //FK

        public List<Indirizzo> Indirizzi = new List<Indirizzo>();
        public Contatto()
        {

        }
        public Contatto(string cognome, string nome)
        {
            Cognome = cognome;
            Nome = nome;
         
        }
        public Contatto(int id,string cognome, string nome)
        {
            IdContatto = id;
            Cognome = cognome;
            Nome = nome;
        


        }
        public override string ToString()
        {
            return $" IdContatto: {IdContatto} \t {Nome}\t{Cognome}\t ";
        }
    }
}
