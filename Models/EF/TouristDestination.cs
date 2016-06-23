using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.EF
{
    [Table("TouristDestination")]
    public partial class TouristDestination
    {
        public long TouristDestinationId { get; set; }

        [StringLength(250)]
        public string TouristDestinationName { get; set; }

        [StringLength(250)]
        public string TDAvartar { get; set; }

        public bool? Status { get; set; }

        public int? ProvinceId { get; set; }

        public int? DisplayOrder { get; set; }

    }
}
