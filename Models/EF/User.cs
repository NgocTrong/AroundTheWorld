using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.EF
{
    [Table("User")]
    public partial class User
    {
        public int UserId { get; set; }

        [StringLength(50)]
        [Required]
        public string UserName { get; set; }

        [StringLength(50)]
        [Required]
        public string PassWord { get; set; }

        public bool? Status { get; set; }
    }
}
