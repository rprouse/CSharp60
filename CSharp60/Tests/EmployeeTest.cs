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

        [Test]
        public void EmployeeNameCannotBeNull()
        {
            Assert.That(() => new Employee(null, "Development", 12000), Throws.ArgumentException);
        }

        [Test]
        public void EmployeeNameCannotBeEmpty()
        {
            Assert.That(() => new Employee("", "Development", 12000), Throws.ArgumentException);
        }

        [Test]
        public void TestExplicitConstructor()
        {
            var employee = new Employee("Rob Prouse");
            Assert.That(employee.Name, Is.EqualTo("Rob Prouse"));
            Assert.That(employee.Department, Is.EqualTo("Intern"));
            Assert.That(employee.Salary, Is.EqualTo(10000));
        }
    }
}
