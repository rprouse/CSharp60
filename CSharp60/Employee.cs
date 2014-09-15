using System;

namespace CSharp60
{
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
        public Address Address { get; set; }

        public static bool MailPayStub(Employee employee)
        {
            if(employee != null && employee.Address != null)
            {
                MailPayStub(employee.Name, employee.Address);
                return true;
            }
            return false;
        }

        public static void MailPayStub(string name, Address address)
        {
            Console.WriteLine("{0}{1}{2}{1}{3}, {4} {5}",
                name,
                Environment.NewLine,
                address.Street,
                address.City,
                address.Province,
                address.PostalCode);
        }
    }
}
