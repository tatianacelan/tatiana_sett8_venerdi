using System;

namespace RubricaCore
{
    public class Indirizzo
    {
        private string t;
        private string p;
        private string n;
        private int id;

        public int IdIndirizzo { get; set; }
        public string Tipologia { get; set; }
        public string Via { get; set; }
        public string Città { get; set; }
        public int CAP { get; set; }
        public string Provincia { get; set; }
        public string Nazione { get; set; }
        public int IdContatto { get; set; } //FK 
        public Contatto Contatto { get; set;  }
        public Indirizzo()
        {

        }

        public Indirizzo(string t, string via, string città, string p, string n, int id)
        {
            Tipologia= t;
            Via = via;
            Città = città;
            Provincia = p;
            Nazione= n;
            IdContatto= id;
        }
        public Indirizzo( int idInd, string t, string via, string città, string p, string n, int id)
        {
            IdIndirizzo = idInd;
            Tipologia = t;
            Via = via;
            Città = città;
            Provincia = p;
            Nazione = n;
            IdContatto = id;
        }

        public override string ToString()
        {
            return $"Tipo:{Tipologia}, Via:{Via } , Città: {Città}, Nazione:{Nazione}";
        }

    }
}
