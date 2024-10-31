namespace LabbClassLibrary
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
    }
    public class Address
    {
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? ZipCode { get; set; }
    }
    public class Company
    {
        public string? Name { get; set; }
        public string? CatchPhrase { get; set; }
    }
}
