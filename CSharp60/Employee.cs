namespace CSharp60
{
    /// <summary>
    /// An example of using primary constructors.
    /// </summary>
    public class Employee
    {
        private string _name;
        private string _department;
        private decimal _salary;

        public Employee(string name, string department, decimal salary)
        {
            _name = name;
            _department = department;
            _salary = salary;
        }

        public string Name { get { return _name; } }
        public string Department { get { return _department; } }
        public decimal Salary { get { return _salary; } }
    }
}
