using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PhoneBookCrud.Models
{
    public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? ContactId { get; set; }
        public string TypeContactId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string TextComments { get; set; } = string.Empty;
        public string LicenseNumber { get; set; } = string.Empty;
        public string LicenseStatus { get; set; } = string.Empty;
        public string CoverageArea { get; set; } = string.Empty;
        public string OpeningHours { get; set; } = string.Empty;
        public string VehiclePolicy { get; set; } = string.Empty;

    }
}
