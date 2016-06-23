using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.EF
{
    [Table("Contact")]
    public partial class Contact
    {
        public long ContactId { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Name is Requirde")]
        public string Name { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Phone is Requirde")]
        public string Phone { get; set; }

        [StringLength(50)]
        [Required]
        [Display(Name = "Email address")]
        [RegularExpression(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-‌​]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$", ErrorMessage = "Email is not valid")]
        public string Email { get; set; }

        
        [Required(ErrorMessage = "Address is Requirde")]
        [StringLength(250)]
        public string Address { get; set; }

        
        public long TourId { get; set; }


        [Required]
        [Range(1, 100, ErrorMessage = "Sorry, you must be between 1 and 100 to register.")]
        public int Quantity { get; set; }
    }
}
