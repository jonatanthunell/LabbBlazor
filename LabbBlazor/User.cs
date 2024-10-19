namespace LabbBlazor
{
    public class User
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public Address Address { get; set; }
        public Company Company { get; set; }
        public User()
        {
            Address = new Address();
            Company = new Company();
        }
        public User(int id, string name, string email, string streetAddress, string cityAddress, string zipcodeAddress, string nameCompany, string catchphraseCompany)
        {
            ID = id;
            Name = name;
            Email = email;
            Address = new Address(streetAddress, cityAddress, zipcodeAddress);
            Company = new Company(nameCompany, catchphraseCompany);

        }
    }
    public class Address
    {
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? ZipCode { get; set; }
        public Address()
        {
            
        }
        public Address(string street, string city, string zipcode)
        {
            Street = street;
            City = city;
            ZipCode = zipcode;
        }
    }
    public class Company
    {
        public string? Name { get; set; }
        public string? CatchPhrase { get; set; }
        public Company()
        {
            
        }
        public Company(string name, string catchphrase)
        {
            Name = name;
            CatchPhrase = catchphrase;
        }
    }
}
