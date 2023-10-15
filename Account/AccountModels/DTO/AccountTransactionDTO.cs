using AccountModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountModels.DTO
{
    public class AccountTransactionDTO
    {

        public long customerId { get; set; }

        public decimal? balance { get; set; }

        public int? type { get; set; }

        public long accountId { get; set; }
        public List<Transaction> transactions { get; set; }
    }
}
