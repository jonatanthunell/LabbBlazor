using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LabbClassLibrary
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
        [Display(Name = "Street")]
        [StringLength(50, MinimumLength = 2)]
        public string? AddressStreet { get; set; }

        [Required]
        [Display(Name = "City")]
        [StringLength(50, MinimumLength = 2)]
        public string? AddressCity { get; set; }

        [Required]
        [Display(Name = "Zip Code")]
        [StringLength(50, MinimumLength = 2)]
        public string? AddressZipCode { get; set; }

        [Required]
        [Display(Name = "Company Name")]
        [StringLength(50, MinimumLength = 2)]
        public string? CompanyName { get; set; }

        [Required]
        [Display(Name = "Company Catchphrase")]
        [StringLength(100, MinimumLength = 2)]
        public string? CompanyCatchPhrase { get; set; }

        public User GetValidatedUser()
        {
            User user = new User();
            //Vid ett riktigt scenario implementera logik för att ge ID ett värde av "numberOfCurrentUsers + 1"
            user.ID = 11;
            user.Name = Name;
            user.Email = Email;
            user.Address.Street = AddressStreet;
            user.Address.City = AddressCity;
            user.Address.ZipCode = AddressZipCode;
            user.Company.Name = CompanyName;
            user.Company.CatchPhrase = CompanyCatchPhrase;

            return user;
        }
    }
}
