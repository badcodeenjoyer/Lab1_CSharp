using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Lab1_CSharp
{
    internal class Transaction
    {
        public Transaction(TransactionType transactionType, Users user, decimal amount) 
        {
            TransactionDateTime = DateTime.Now;
            TransactionType = transactionType;
            User = user;
            Amount = amount;
        }

        public DateTime TransactionDateTime { get; set; }
        public Users User { get; set; }
        public TransactionType TransactionType { get; set; }    
        public decimal Amount { get; set; }
        public static void CommitTransaction(SelfCheckoutClass selfCheckout, Transaction transaction)
        {
            selfCheckout.Transactions
                .Add($"Time : {transaction.TransactionDateTime} , User : {transaction.User}  Operation : {transaction.TransactionType} , Amount : {transaction.Amount}");
        }
        public override string ToString()
        {
            return $"Time : {TransactionDateTime} , User : {User}  Operation : {TransactionType} , Amount : {Amount}";
        }
    }

    public enum Users
    {
        System,
        Cashier
    }
    public enum TransactionType
    {
        WithdrawCash,
        BuyWithCard,
        BuyWithCash,
        CashTopUp,
        GiveChange,
        AddProduct
    }
}
