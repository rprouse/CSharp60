using NUnit.Framework;

namespace CSharp60.Tests
{
    public class EmployeeTest
    {
        [Test]
        public void TestConstructor()
        {
            var employee = new Employee("Rob Prouse", "Development", 12000);
            Assert.That(employee.Name, Is.EqualTo("Rob Prouse"));
            Assert.That(employee.Department, Is.EqualTo("Development"));
            Assert.That(employee.Salary, Is.EqualTo(12000));
        }
    }
}
