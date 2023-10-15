using AccountModels.Models;
using AccountRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountServices
{
    public class LookupsService : ILookupsService
    {
        private readonly ILookupsRepository _lookupsRepository;
        public LookupsService(ILookupsRepository lookupsRepository)
        {
            _lookupsRepository = lookupsRepository;

        }
        public IEnumerable<Lookup> GetLookupsByParantCode(string code)
        {
            return _lookupsRepository.GetLookupsByParantCode(code);
        }
       
        public Lookup GetLookupByCode(string code)
        {
            return _lookupsRepository.GetLookupByCode(code);
        }

        public Lookup GetLookupById(int id)
        {
            return _lookupsRepository.GetLookupById(id);

        }

    }
}
