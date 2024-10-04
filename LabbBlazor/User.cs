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
        [StringLength(50, MinimumLength = 2)]
        public string? ZipCode { get; set; }
    }
    public class Company
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string? Name { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string? CatchPhrase { get; set; }
    }
}
