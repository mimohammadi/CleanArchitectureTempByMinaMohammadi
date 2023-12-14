namespace Core.Entities.Product
{
    public class Product:BaseEntity,IAggregateRoot
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        protected Product()
        {
        }

        public Product(string name, decimal price)
        {
            GuardAgainstIfPriceIsZeroOrLess(price);
            Name = name;
            Price = price;
        }

        public void Update(string name, decimal price)
        {
            GuardAgainstIfPriceIsZeroOrLess(price);
            Name = name;
            Price = price;
        }

        private static void GuardAgainstIfPriceIsZeroOrLess(decimal price)
        {
            if (price <= 0)
                throw new ArgumentOutOfRangeException("قیمت باید بزرگتر از 0 باشد");
        }
    }
}
