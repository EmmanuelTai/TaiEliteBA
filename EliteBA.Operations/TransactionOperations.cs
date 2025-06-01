using EliteBA.DB;
using EliteBA.Models;
using EliteBA.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteBA.Operations
{
    public static class TransactionOperations
    {
        public static void RegisterTransaction(Transaction transaction)
        {
            Tables.transactions.Add(transaction);
        }
    }


    public static class DepositOperations
    {
        public static void RegisterDeposit(string accountNumber, decimal amount, string description)
        {
            
            var account = Tables.accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
            if (account == null)
            {
                Console.WriteLine("Account not found.");
                return;
            }

            
            account.Balance += (double)amount;

            
            var transaction = new Transaction
            {
                TransactionId = Generators.GenerateTransactionId(),
                AccountNumber = accountNumber,
                Amount = (double)amount,
                DateCreated = DateTime.Now,
                Narration = description,
                TransactionType = TransactionType.Deposit
            };

            
            TransactionOperations.RegisterTransaction(transaction);
        }
    }




}



