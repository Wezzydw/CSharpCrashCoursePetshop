using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CA_Petshop.Infrastructure.Data.SQL;

namespace UI.RestAPI.Data
{
    public interface IDBInit
    {
        void Init(PetshopContext psc);
    }
}
