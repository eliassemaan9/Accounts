using AccountModels.DTO;
using AccountModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountServices
{
    public interface IAccountService
    {
        MessageDTO addAccount(Account account);
        List<Customer> getCustomers();
        AccountResponseDTO GetCustomersAccounts(long customerId);
        List<Transaction> GetAccountTransaction(long accountId);
    }
}
