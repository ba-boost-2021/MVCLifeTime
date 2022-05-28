using System.ComponentModel.DataAnnotations;

namespace BilgeAdam.Services.Contracts
{
    public class NewEmployeeDTO
    {
        [Required]
        [MaxLength(16)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(16)]
        public string LastName { get; set; }
        [MaxLength(16)]
        public string Country { get; set; }
        [MaxLength(16)]
        public string City { get; set; }
        [MaxLength(16)]
        public string Phone { get; set; }
    }
}
