using System.ComponentModel.DataAnnotations;

namespace Models.ViewModel
{
    public class TouristDestinationViewModel
    {
        public long TouristDestinationId { get; set; }

        [StringLength(250)]
        public string TouristDestinationName { get; set; }

        [StringLength(250)]
        public string TDAvartar { get; set; }

        public bool? Status { get; set; }

        [StringLength(100)]
        public string ProvinceName { get; set; }

        public int? DisplayOrder { get; set; }
    }
}
