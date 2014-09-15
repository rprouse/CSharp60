namespace CSharp60
{
    public class Product(string name, decimal price)
    {
        public string Name { get; } = name;
        public decimal Price { get; } = price;
    }
}
