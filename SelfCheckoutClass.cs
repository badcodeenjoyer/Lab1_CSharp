using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_CSharp
{
    internal class SelfCheckoutClass
    {
        public SelfCheckoutClass(string name,string model, List<Product> products)
        {
            Name= name;
            Model= model; 
            Products = products;
            Transactions = new List<string>();
        }

        private List<Product> Products { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Model { get; set; }
        public decimal CashBalance { get; set; }
        public decimal CardBalance { get; set; }
        public List<string> Transactions { get; set; }


        public void AddProduct(Product productToAdd)
        {
            var result = Products.AddUnique(productToAdd);
            if (result)
            {
                Transaction.CommitTransaction(this, new(TransactionType.AddProduct, Users.Cashier, 1));
            }
           
        }
        public void WithdrawCash(decimal amount)
        {
            if (CashBalance<amount)
            {
                Console.WriteLine($"Unable to withdraw cash , not enougth balance");
                return;
            }
            CashBalance -= amount;
            Transaction.CommitTransaction(this, new(TransactionType.WithdrawCash, Users.Cashier, amount));
        }
        public decimal TotalReceiptSumm(List<Product> products)
        {
            decimal summ = 0;
            foreach (var product in products)
            {
                summ += product.Price;
            }
            return summ;
        }
        public void ProcessReceipt(List<Product> products, PaymentType paymentType, decimal insertedCash)
        {
            var summ = TotalReceiptSumm(products);

            switch (paymentType)
            {
                case PaymentType.Card:
                    CardBalance += summ;
                    Transaction.CommitTransaction(this, new(TransactionType.BuyWithCard, Users.System, summ));
                    break;
                case PaymentType.Cash:
                    CashBalance += summ;
                    Transaction.CommitTransaction(this, new(TransactionType.BuyWithCash, Users.System, summ));

                    if (insertedCash > summ)
                    {
                        CashBalance -= insertedCash - summ;
                        Transaction.CommitTransaction(this, new(TransactionType.GiveChange, Users.System, insertedCash - summ));
                    }
                    else
                    {
                        Console.WriteLine($"Insufficient cash.");
                    }                   
                    break;
                default:
                    break;
            }
        }
        public void TopUpCash(decimal amount)
        {
            CashBalance += amount;
            Transaction.CommitTransaction(this, new(TransactionType.CashTopUp, Users.Cashier, amount));
        }
        public void PrintTransactions() 
        {
            foreach(var transaction in Transactions)
            {
                Console.WriteLine(transaction.ToString());
            }
        }

    }
    public enum PaymentType
    {
        Card,
        Cash
    }
}
