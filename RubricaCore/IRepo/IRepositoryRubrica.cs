using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubricaCore
{
   public  interface IRepositoryRubrica<T>
    {
    
        public T Add(T item); 
     
    }
}
