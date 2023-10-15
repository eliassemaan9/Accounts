using AccountModels.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountRepository
{
    public class LookupsRepository : ILookupsRepository
    {
       

        private readonly AccountsContext MyDbContext;
        public LookupsRepository(AccountsContext context)
        {
            this.MyDbContext = context;
        }
        public IEnumerable<Lookup> GetLookupsByParantCode(string code)
        {
            var parentLookup = MyDbContext.Lookups.SingleOrDefault(m => m.LookupCode == code);
            return  MyDbContext.Lookups.Where(m => m.ParentId == parentLookup.Id).ToList();
        }
       
        public Lookup GetLookupByCode(string code)
        {
            return  MyDbContext.Lookups.Where(m => m.LookupCode == code).SingleOrDefault();
        }

        public  Lookup GetLookupById(int id)
        {
            return  MyDbContext.Lookups.Where(m => m.Id == id).SingleOrDefault();
        }

    }
}
