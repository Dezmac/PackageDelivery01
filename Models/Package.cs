using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PackageDelivery01.Models
{
    public class Package(int customerID, decimal weight, string serviceType, string status)
    {
        [Key]
        public int PackageID { get; set; }

        [Required]
        public int CustomerID { get; set; } = customerID;

        [Required]
        public decimal Weight { get; set; } = weight;

        [Required]
        [StringLength(50)]
        public string ServiceType { get; set; } = serviceType;

        [Required]
        [StringLength(50)]
        public string Status { get; set; } = status;

        public Customer? Customer { get; set; }  // Nullable navigation property
        public ICollection<Tracking> Trackings { get; set; } = [];  // Collection initialization
    }
}
