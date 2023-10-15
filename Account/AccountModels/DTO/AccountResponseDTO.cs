using AccountModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountModels.DTO
{
    public class AccountResponseDTO
    {
        public Customer customer { get; set; }
        public List<Account> account { get; set; }
    }
}
