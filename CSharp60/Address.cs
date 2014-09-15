namespace CSharp60
{
    public class Address(string street, string city, string province, string postal_code)
    {
        public string Street { get; } = street;
        public string City { get; } = city;
        public string Province { get; } = province;
        public string PostalCode { get; } = postal_code;
    }
}
