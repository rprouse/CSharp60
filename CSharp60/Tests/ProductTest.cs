using NUnit.Framework;

namespace CSharp60.Tests
{
    [TestFixture]
    public class ProductTest
    {
        [Test]
        public void TestDefaultValues()
        {
            var product = new Product();
            Assert.That(product.Name, Is.EqualTo("Toy Car"));
            Assert.That(product.Price, Is.EqualTo(9.99m));
        }
    }
}
