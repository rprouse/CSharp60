using System.Collections.Generic;

namespace CSharp60
{
    public class Order
    {
        public IList<OrderLine> OrderLines { get; } = new List<OrderLine>();

        public decimal OrderTotal
        {
            get
            {
                decimal total = 0;
                foreach(var line in OrderLines)
                {
                    if (line != null && line.Product != null)
                    {
                        total += line.Product.Price * line.Quantity;
                    }
                }
                return total;
            }
        }
    }

    public class OrderLine(Product product, uint quantity)
    {
        public uint Quantity { get; } = quantity;
        public Product Product { get; } = product;
    }
}
