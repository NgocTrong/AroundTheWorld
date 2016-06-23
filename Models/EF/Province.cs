using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.EF
{
    [Table("Province")]
    public partial class Province
    {
        public int ProvinceId { get; set; }

        [StringLength(100)]
        public string ProvinceName { get; set; }

        [StringLength(250)]
        public string ProvinceAvatar { get; set; }

        public int? DisplayOrder { get; set; }

        [StringLength(50)]
        public string Description { get; set; }
    }
}
