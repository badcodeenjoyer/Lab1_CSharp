namespace Lab1_CSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>()
            {
                new Product ("Tomato","0001",16.99m),
                new Product ("Potato","0002",15.97m),
                new Product ("Milk","0003",33.15m),
                new Product ("Bread","0004",11.99m),
                new Product ("Banana","0005",55m),
                new Product ("Cucumber","0006",34.99m),
                new Product ("Beans","0007",15.99m),
                new Product ("Orange","0008",22m),
                new Product ("Bear","0009",99.99m),
                new Product ("Cheese","0010",14.88m),
                new Product ("Chocolate","0011",1.01m),

            };

            var Checkout1 = new SelfCheckoutClass("Checkout1", "XEA-123", products);
            var Checkout2 = new SelfCheckoutClass("Checkout2", "XEA-123", products);
            var Checkout3 = new SelfCheckoutClass("Checkout3", "XEA-228", products);

            Checkout2.WithdrawCash(300);
            Checkout2.TopUpCash(300);
            Checkout2.WithdrawCash(200);

            try
            {
                Checkout1.AddProduct(new Product("Ketchup", "0001", 13.33m));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Checkout1.AddProduct(new Product("Mayo", "0012", 44.44m));

            List<Product> recieptProducts = new List<Product>()
            {
                new Product ("Tomato","0001",16.99m),
                new Product ("Potato","0002",15.97m),
                new Product ("Milk","0003",33.15m),
                new Product ("Bread","0004",11.99m),
                new Product ("Banana","0005",55m),               

            };

            Checkout2.ProcessReceipt(recieptProducts, PaymentType.Cash, 200);
            Checkout3.ProcessReceipt(recieptProducts, PaymentType.Card, 200);

            Checkout1.PrintTransactions();
            Checkout2.PrintTransactions();
            Checkout3.PrintTransactions();
        }
    }
}