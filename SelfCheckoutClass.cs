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
            Transactions = new List<Transaction>();
        }

        private List<Product> Products { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Model { get; set; }
        public decimal CashBalance { get; set; }
        public decimal CardBalance { get; set; }
        public List<Transaction> Transactions { get; set; }

        public void AddProduct(Product productToAdd, SelfCheckoutClass selfCheckout)
        {
            selfCheckout.Products.AddUnique(productToAdd);
        }
    }
}
