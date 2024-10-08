using System.ComponentModel.DataAnnotations;

namespace LabbBlazor
{
    public class User
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string? Name { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public Address Address { get; set; }
        [Required]
        public Company Company { get; set; }
        public User()
        {
            Address = new Address();
            Company = new Company();
        }
        public User(int id, string name, string email, string streetAddress, string cityAddress, int zipcodeAddress, string nameCompany, string catchphraseCompany)
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
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string? Street { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string? City { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int ZipCode { get; set; }
        public Address()
        {
            
        }
        public Address(string street, string city, int zipcode)
        {
            Street = street;
            City = city;
            ZipCode = zipcode;
        }
    }
    public class Company
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string? Name { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2)]
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
