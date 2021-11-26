using RepositoryRubricaAdo;
using RepositoryRubricaMock;
using RubricaCore;
using System;
using System.Collections.Generic;

namespace tatiana
{
    class Program
    {
        
        //  private static readonly IBusinessLayerRubrica bl=new MainBLRubrica(new RepoContattiAdo(), new RepoIndirizziADO());

       private static readonly IBusinessLayerRubrica bl = new MainBLRubrica(new RepositoryContattiMock(), new RepoIndirizziMock());
        static void Main(string[] args)
        {
            Console.WriteLine("Nuova rubrica!");

            bool continua = true;
            while (continua)
            {
                int scelta = SchermoMenu();
                continua = AnalizzaScelta(scelta);
            }

        }
        private static bool AnalizzaScelta(int scelta)
        {
            switch (scelta)
            {
                case 1:
                    VisualizzaContatti();
                    break;
                case 2:
                    AggiungiContatto();
                    break;
                case 3:
                    AggiungiIndirizzo();
                    break;
                case 4:
                    EliminaContattoSenzaNessunIndirizzo(); 
                    break; 
                case 0:
                    return false;
                default:
                    Console.WriteLine("Scelta errata. Riprova");
                    break;

            
             }
               return true;
        }

        private static void EliminaContattoSenzaNessunIndirizzo()
        {
          
        }

        private static void AggiungiIndirizzo()
        {
            Console.Write(" Inserisci tipologia tra residenza o domicilio: ");
            string t= Console.ReadLine();
            Console.Write(" Inserisci via:");
            string via = Console.ReadLine();
            Console.Write(" Città:");
            string città = Console.ReadLine();   
            Console.Write(" Provincia:");
            string p = Console.ReadLine();
            Console.Write(" Inserisci la nazione:");
            string n = Console.ReadLine();
            Console.WriteLine("_____________________________________________________");
            Console.WriteLine();
            
            Console.WriteLine("Questa e la lista dei tuoi contatti:");
            Console.WriteLine();
            VisualizzaContatti();
            Console.Write("Inserisci Id della persona a cui vuoi assegnare l'indirizzo:");
            int id  =int.Parse(Console.ReadLine());
            Console.WriteLine();

            Indirizzo nuovoIndirizzo = new Indirizzo(t, via, città, p, n, id);
            Esito esito = bl.AggiungiIndirizzo(nuovoIndirizzo);
            Console.WriteLine(esito.Messaggio);
            Console.WriteLine();
            Console.WriteLine("_____________________________________________________");



        }

        private static void AggiungiContatto()
        {
            Console.WriteLine("Inserisci il cognome:");
            string cognome = Console.ReadLine();
            Console.WriteLine("Inserisci il nome:");
            string nome = Console.ReadLine();

            Contatto nuovoContatto = new Contatto(cognome, nome);
            Esito e = bl.AggiungiContatto(nuovoContatto);
            Console.WriteLine(e.Messaggio);


        }

        private static void VisualizzaContatti()
        {
            List <Contatto> contatti = bl.GetAllContacts();
            if (contatti.Count == 0)
            {
                Console.WriteLine("Nessun Contatto");
            }
            else
            {

                foreach (var item in contatti)
                {
                    Console.WriteLine(item);
                }
            }

        }

        private static int SchermoMenu()
        {
            Console.WriteLine("*************************Menu***************************");
            // funzionalita che riguardano i corsi 
            Console.WriteLine();
            Console.WriteLine("      1. Visualizza  tutti i Contatti.");
            Console.WriteLine("      2. Aggiungi un nuovo Contatto.");
            Console.WriteLine("      3. Aggiungere un Indirizzo associandolo ad un contatto.");
            Console.WriteLine("      4. Eliminare un Contatto se NON ha un indirizzo associato.");
            Console.WriteLine("      0. Exit");
            Console.WriteLine("*********************************************************");

            int scelta;
            Console.WriteLine("Inserisci la tua scelta: ");
            while (!(int.TryParse(Console.ReadLine(), out scelta) && scelta >= 0 && scelta <= 4))
            {
                Console.WriteLine("scelta errata. Inserisci scelta: ");
            }
            return scelta;

        }
    }
}
