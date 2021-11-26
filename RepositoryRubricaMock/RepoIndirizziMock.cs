using RubricaCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryRubricaMock
{
    public class RepoIndirizziMock:IRepoIndirizzo
    {
        public static List<Indirizzo> Indirizzi = new List<Indirizzo>()
        {
             new Indirizzo {IdIndirizzo=1, Tipologia="Domicilio", Via="Angelo Morettini 11", Città="Perugia", Provincia="PG", CAP=06128, Nazione="Italia"}
         };

        public Indirizzo Add(Indirizzo item)
        {
            if (Indirizzi.Count == 0)
            {
                item.IdIndirizzo = 1;
            }
            else //se la lista è piena trova l'id più alto e, dopo aver incrementato di 1, lo assegna ad item
            {
                int maxId = 1;
                foreach (var i in Indirizzi)
                {
                    if (i.IdIndirizzo > maxId)
                    {
                        maxId = i.IdIndirizzo;
                    }
                }
                item.IdIndirizzo = maxId + 1;
            }

            Indirizzi.Add(item);
            return item;
        }

    

        public List<Indirizzo> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
