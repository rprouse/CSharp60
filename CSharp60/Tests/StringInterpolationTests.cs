using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp60.Tests
{
    [TestFixture]
    class StringInterpolationTests
    {
        [Test]
        public void TestStringInterpolation()
        {
            var line = new OrderLine(new Product("Toy boat", 12.99m), 2);
            var msg = "You ordered \{line.Quantity} \{line.Product.Name}\{line.Quantity > 1 ? "s" : ""}";

            Assert.That(msg, Is.EqualTo("You ordered 2 Toy boats") );
        }
    }
}
