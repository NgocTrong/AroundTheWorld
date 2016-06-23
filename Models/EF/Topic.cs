using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.EF
{
    [Table("Topic")]
    public partial class Topic
    {
        public int TopicId { get; set; }

        [StringLength(50)]
        public string TopicName { get; set; }

        public int? DisplayOrder { get; set; }

        public bool? Status { get; set; }
    }
}
