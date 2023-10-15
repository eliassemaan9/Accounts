using AccountModels.DTO;
using AccountModels.Models;
using AccountRepository.Helper;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore.Query.Internal;
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
        public object getAccountDetails(long customerId)
        {
            try
            {
               List<AccountTransactionDTO> accountTransactionDTO = new List<AccountTransactionDTO>();
                List<Transaction> transactionDTO = new List<Transaction>();

                var details = (from C in _context.Customers
                               join A in _context.Accounts on C.CustomerId equals A.CustomerId
                               join T in _context.Transactions on A.AccountId equals T.AccountId
                               where C.CustomerId == customerId
                               select new
                               {
                                customerId =C.CustomerId,
                                name = C.FirstName +" "+ C.LastName,
                                accountId =A.AccountId,
                                accountBalance = A.Balance,
                                accountType = A.Type,
                                transactionAmount = T.TransactionAmout,
                                createdDate = T.CreatedDate,
                                transactionId = T.TransactionId

                               }).ToList();
                AccountsInfoDTO accountsInfoDTO = new AccountsInfoDTO();
                accountsInfoDTO.customerId = details[0].customerId;
                accountsInfoDTO.name = details[0].name;
                foreach (var item in details)
                {
                    Transaction transaction = new Transaction();
                    transaction.TransactionAmout = item.transactionAmount;
                    transaction.CreatedDate = item.createdDate;
                    transaction.AccountId = item.accountId;
                    transaction.TransactionId = item.transactionId;
                    transactionDTO.Add(transaction);

                    AccountTransactionDTO accountTransaction = new AccountTransactionDTO();
                    accountTransaction.customerId = item.customerId;
                    accountTransaction.balance = item.accountBalance;
                    accountTransaction.type = item.accountType;
                    accountTransaction.accountId = item.accountId;
                    accountTransaction.transactions = transactionDTO;
                    accountTransactionDTO.Add(accountTransaction);

                    
                }

                accountsInfoDTO.account = accountTransactionDTO;
                return accountsInfoDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
