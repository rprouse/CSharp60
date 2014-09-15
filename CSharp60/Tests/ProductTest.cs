using NUnit.Framework;

namespace CSharp60.Tests
{
    [TestFixture]
    public class ProductTest
    {
        [Test]
        public void TestGetterOnlyAutoProperties()
        {
            var product = new Product("Toy Car", 9.99m);
            Assert.That(product.Name, Is.EqualTo("Toy Car"));
            Assert.That(product.Price, Is.EqualTo(9.99m));
        }
    }
}
