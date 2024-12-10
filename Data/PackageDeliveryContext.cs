using Microsoft.EntityFrameworkCore;
using PackageDelivery01.Models;

namespace PackageDelivery01.Data
{
    public class PackageDeliveryContext(DbContextOptions<PackageDeliveryContext> options) : DbContext(options)
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Tracking> Trackings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Package>()
                .HasOne(p => p.Customer)
                .WithMany(c => c.Packages)
                .HasForeignKey(p => p.CustomerID);

            modelBuilder.Entity<Tracking>()
                .HasOne(t => t.Package)
                .WithMany(p => p.Trackings)
                .HasForeignKey(t => t.PackageID);
        }
    }
}
