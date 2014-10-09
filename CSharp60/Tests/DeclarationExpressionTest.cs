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
            int x = Int32.TryParse(value, out var i) ? i : -1;
            Assert.That(x, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("string")]
        public void TestCasting(object obj)
        {
            if ((string str = obj as string) != null )
            {
                Assert.Pass();
            }
            Assert.Fail();
        }
    }
}
