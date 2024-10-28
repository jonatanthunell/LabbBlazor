using System.ComponentModel.DataAnnotations;

namespace LabbBlazor
{
    public class NewUserFormValidator
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string? Name { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string? AddressStreet { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string? AddressCity { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string? AddressZipCode { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string? CompanyName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string? CompanyCatchPhrase { get; set; }

        public User GetValidatedUser()
        {
            return new User(
                //Vid ett riktigt scenario implementera logik för att ge ID ett värde av "numberOfCurrentUsers + 1"
                ID = 11,
                Name ?? throw new NullReferenceException("Name field must contain a name"),
                Email ?? throw new NullReferenceException("Email field must contain an email address"),
                AddressStreet ?? throw new NullReferenceException("Street field must contain a street"),
                AddressCity ?? throw new NullReferenceException("City field must contain a city"),
                AddressZipCode ?? throw new NullReferenceException("ZipCode field must contain a zip code"),
                CompanyName ?? throw new NullReferenceException("Company name field must contain a name"),
                CompanyCatchPhrase ?? throw new NullReferenceException("Company catchphrase field must contain a phrase")
            );
        }
    }
}
