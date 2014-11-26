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
            var line = new OrderLine(new Product("Toy boat", 12.99m), 1);
            var msg = string.Format("You ordered {0} {1}{{s}}", line.Quantity, line.Product.Name);

            Assert.That(msg, Is.EqualTo("You ordered 1 Toy boat{s}") );
        }
    }
}
