using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.EF
{
    [Table("Blog")]
    public partial class Blog
    {
        public long BlogId { get; set; }

        [StringLength(100)]
        public string BlogName { get; set; }

        [Column(TypeName = "ntext")]
        public string Content { get; set; }

        public int? DisplayOrder { get; set; }

        public bool? Status { get; set; }

        public int? TopicId { get; set; }

        public int? ProvinceId { get; set; }
    }
}
