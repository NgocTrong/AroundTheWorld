using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.ViewModel
{
    public class TourViewModel
    {
        public long TourId { get; set; }

        [StringLength(100)]
        public string TourName { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        [StringLength(250)]
        public string TDAvartar { get; set; }

        [StringLength(100)]
        public string DepartureTime { get; set;}

        [StringLength(50)]
        public string TourTime { get; set; }

        [StringLength(100)]
        public string StartingPoint { get; set; }

        [StringLength(100)]
        public string ArrivalPoint { get; set; }

        [StringLength(50)]
        public string Transport { get; set; }

        public decimal? Price { get; set; }

        [Column(TypeName = "ntext")]
        public string TimeTable { get; set; }

        public int? DisplayOrder { get; set; }

        public bool? Status { get; set; }

        [StringLength(250)]
        public string TouristDestinationName { get; set; }

        
        
    }
}
