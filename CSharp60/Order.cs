using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CSharp60
{
    public class Order
    {
        public event EventHandler OrderChanged;

        public ObservableCollection<OrderLine> OrderLines { get; } = new ObservableCollection<OrderLine>();

        public Order()
        {
            OrderLines.CollectionChanged += OrderLines_CollectionChanged;
        }

        private void OrderLines_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            OrderChanged?.Invoke(this, EventArgs.Empty);
        }

        public decimal OrderTotal
        {
            get
            {
                decimal total = 0;
                foreach(var line in OrderLines)
                {
                    total += line?.Product?.Price ?? 0 * line?.Quantity ?? 0;
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
