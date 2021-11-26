using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubricaCore
{
    public class MainBLRubrica : IBusinessLayerRubrica
    {
        private readonly IRepoContatti contattiRepo;
        private readonly IRepoIndirizzo indirizziRepo;


        public MainBLRubrica(IRepoContatti contatti, IRepoIndirizzo indirizzi)
        {
            contattiRepo = contatti;
            indirizziRepo = indirizzi;
        }

        public Esito AggiungiContatto(Contatto c)
        {
            //TODO verifica unicità
                contattiRepo.Add(c);
                return  new Esito { Messaggio = $"Contatto aggiunto corretamente", IsOk = true };

        }

        public Esito AggiungiIndirizzo(Indirizzo i)
        {
            Contatto contattoEsistente = contattiRepo.GetById(i.IdContatto);
            if (contattoEsistente== null)
            {
                return new Esito { Messaggio = "Codice corso errato", IsOk = false };
            }

            indirizziRepo.Add(i);
            return new Esito { Messaggio = $"Indirizzo inserito e stato assegnato a: {contattoEsistente.Cognome}  {contattoEsistente.Nome}", IsOk = true };
        }

        public List<Contatto> GetAllContacts()
        {
            return contattiRepo.GetAll();
        }
    }
}
