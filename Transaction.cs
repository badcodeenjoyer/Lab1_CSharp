using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_CSharp
{
    internal class Transaction
    {
        public Transaction() 
        {

        }
        public DateTime TramsationDateTime { get; set; }
        public Users User { get; set; }
        public TransactionType TransactionType { get; set; }    
        public decimal Summ { get; set; }

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
        CashTopUp
    }
}
