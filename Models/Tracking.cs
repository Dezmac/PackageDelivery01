using System;
using System.ComponentModel.DataAnnotations;

namespace PackageDelivery01.Models
{
    public class Tracking(int packageID, string location, string status, DateTime timestamp)
    {
        [Key]
        public int TrackingID { get; set; }

        [Required]
        public int PackageID { get; set; } = packageID;

        [Required]
        [StringLength(255)]
        public string Location { get; set; } = location;

        [Required]
        [StringLength(50)]
        public string Status { get; set; } = status;

        [Required]
        public DateTime? Timestamp { get; set; } = timestamp;

        public Package? Package { get; set; }  // Nullable navigation property
    }
}
