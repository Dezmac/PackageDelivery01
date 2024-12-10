using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PackageDelivery01.Models
{
    public class Customer(string name, string address)
    {
        [Key]
        public int CustomerID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = name;

        [Required]
        [StringLength(255)]
        public string Address { get; set; } = address;

        public ICollection<Package> Packages { get; set; } = [];  // Collection initialization
    }
}

