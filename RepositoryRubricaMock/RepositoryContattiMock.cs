using RubricaCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryRubricaMock
{
    public class RepositoryContattiMock : IRepoContatti
    {
        public static List<Contatto> Contatti = new List<Contatto>()
        {
            new Contatto{ IdContatto=1,  Cognome="Celan",Nome="Tatiana", IdIndirizzo=1},
            new Contatto{ IdContatto=2,  Cognome="Celan", Nome="Roman",  IdIndirizzo=2 },
        };

        public Contatto Add(Contatto item)
        {
            if (Contatti.Count == 0)
            {
                item.IdContatto = 1;
            }
            else 
            {
                int maxId = 1;
                foreach (var c in Contatti)
                {
                    if (c.IdContatto > maxId)
                    {
                        maxId = c.IdContatto;
                    }
                }
                item.IdContatto = maxId + 1;
            }

            Contatti.Add(item);
            return item;
        }

        public bool Delete(Contatto item)
        {
            throw new NotImplementedException();
        }

        public List<Contatto> GetAll()
        {
            return Contatti;
        }

        public Contatto GetById(int idContatto)
        {
            foreach (var item in Contatti)
            {
                if (item.IdContatto == idContatto)
                {
                    return item;
                }

            }
            return null;
        }
    }
}
