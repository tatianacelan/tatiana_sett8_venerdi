using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubricaCore
{
    public interface IRepoContatti : IRepositoryRubrica<Contatto>
    {
        List<Contatto> GetAll();
        Contatto GetById(int idContatto);
    }
}
