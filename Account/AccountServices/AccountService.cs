using AccountModels.DTO;
using AccountModels.Models;
using AccountRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountServices
{
    public class AccountService :IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public MessageDTO addAccount(Account account)
        {
            return _accountRepository.addAccount(account);
        }
        public List<Customer> getCustomers()
        {
            return _accountRepository.getCustomers();
        }
        public AccountResponseDTO GetCustomersAccounts(long customerId)
        {
            return _accountRepository.GetCustomersAccounts(customerId);
        }
        public List<Transaction> GetAccountTransaction(long accountId)
        {
            return _accountRepository.GetAccountTransaction(accountId);
        }
        public object getAccountDetails(long customerId)
        {
            return _accountRepository.getAccountDetails(customerId);
        }
}
}
