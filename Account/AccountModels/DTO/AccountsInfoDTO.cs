using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountModels.DTO
{
    public class AccountsInfoDTO
    {
        public long customerId { get; set; }
        public string name { get; set; }
        public List<AccountTransactionDTO> account { get; set; }
    }
}
