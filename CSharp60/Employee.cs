using System;

namespace CSharp60
{
    /// <summary>
    /// An example of using primary constructors.
    /// </summary>
    public class Employee(string name, string department, decimal salary)
    {
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("name cannot be null or empty");
        }

        public Employee(string name) : this(name, "Intern", 10000)
        {
        }

        public string Name { get; } = name;
        public string Department { get; } = department;
        public decimal Salary { get; } = salary;
    }
}
