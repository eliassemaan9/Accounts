using AccountModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountRepository
{
    public interface ILookupsRepository
    {
        IEnumerable<Lookup> GetLookupsByParantCode(string code);
        Lookup GetLookupByCode(string code);
        Lookup GetLookupById(int id);

    }
}
