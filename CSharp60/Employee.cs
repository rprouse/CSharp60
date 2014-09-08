using System;

namespace CSharp60
{
    public class Person(string name)
    {
        public string Name { get; } = name;
    }

    public class Employee(string name, string department, decimal salary) : Person(name)
    {
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("name cannot be null or empty");
        }

        public Employee(string name) : this(name, "Intern", 10000)
        {
        }

        public string Department { get; } = department;
        public decimal Salary { get; } = salary;
    }
}
