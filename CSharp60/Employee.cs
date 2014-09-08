namespace CSharp60
{
    /// <summary>
    /// An example of using primary constructors.
    /// </summary>
    public class Employee(string name, string department, decimal salary)
    {
        public string Name { get; } = name;
        public string Department { get; } = department;
        public decimal Salary { get; } = salary;
    }
}
