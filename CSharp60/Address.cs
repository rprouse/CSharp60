namespace CSharp60
{
    public class Address
    {
        public Address(string street, string city, string province, string postal_code)
        {
            Street = street;
            City = city;
            Province = province;
            PostalCode = postal_code;
        }

        public string Street { get; }
        public string City { get; }
        public string Province { get; }
        public string PostalCode { get; }
    }
}
