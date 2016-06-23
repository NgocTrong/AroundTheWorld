using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.EF
{
    [Table("Gallery")]
    public partial class Gallery
    {
        public long Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Link { get; set; }

        [StringLength(50)]
        public string DesciptionTitle { get; set; }

        [StringLength(100)]
        public string Desciption { get; set; }

        public bool? Status { get; set; }
    }
}
