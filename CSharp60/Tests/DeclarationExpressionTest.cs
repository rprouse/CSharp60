using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp60.Tests
{
    [TestFixture]
    public class DeclarationExpressionTest
    {
        [Test]
        [TestCase("12", 12)]
        [TestCase("121", 121)]
        [TestCase("42", 42)]
        public void TestTryParse(string value, int expected)
        {
            int i;
            if (Int32.TryParse(value, out i))
            {
                Assert.That(i, Is.EqualTo(expected));
            }
            else
            {
                Assert.Fail("Failed to parse {0}", value);
            }
        }
    }
}
