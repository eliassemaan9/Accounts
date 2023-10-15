using AccountModels.DTO;
using AccountModels.Models;
using AccountRepository.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AccountRepository
{
    public class AccountsRepository :IAccountRepository
    {
        private readonly AccountsContext _context;
        private readonly IHelper _helper;
        public AccountsRepository(AccountsContext context, IHelper helper)
        {
            _context = context;
            _helper = helper;

        }
        public List<Customer> getCustomers()
        {
            var customers = _context.Customers.ToList();
            return customers;
        }
        public MessageDTO addAccount(Account account)
        {
            try
            {
                MessageDTO messageDTO = new MessageDTO();
                var accounts = _context.Accounts.Where(c => c.CustomerId == account.CustomerId && c.Type == account.Type).FirstOrDefault();
                if (accounts != null)
                {
                   
                    messageDTO.message = "Account already Exists";
                    return messageDTO;
                }
                else
                {
                    _context.Accounts.Add(account);
                    _context.SaveChanges();
                    if (account.InitialCred > 0)
                    {
                        Transaction transaction = new Transaction();
                        transaction.AccountId = account.AccountId;
                        transaction.CreatedDate = DateTime.Now;
                        transaction.TransactionAmout = account.InitialCred;
                        _context.Transactions.Add(transaction);

                        account.Balance = transaction.TransactionAmout;
                        _context.Accounts.Update(account);
                        _context.SaveChanges();
                        
                    }

                }
                messageDTO.message = "Account added successfully";
                return messageDTO;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public AccountResponseDTO GetCustomersAccounts(long customerId)
        {
            try
            {
                var customer = _context.Customers.Where(c => c.CustomerId == customerId).FirstOrDefault();
                var accounts = _context.Accounts.Where(c => c.CustomerId == customerId).ToList();

                AccountResponseDTO accountResponseDTO = new AccountResponseDTO();
                accountResponseDTO.customer = customer;
                accountResponseDTO.account = accounts;
                return accountResponseDTO;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
          
        }

        public List<Transaction> GetAccountTransaction(long accountId)
        {
            try
            {
                var transactions = _context.Transactions.Where(c => c.AccountId == accountId).ToList();
                return transactions;
            }
           catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
