using GlobalBlueHomework.Models;
using Microsoft.EntityFrameworkCore;

namespace GlobalBlueHomework.AppContext
{
    public class GlobalBlueContext : DbContext
    {
        /// <summary>
        /// Purchases DbSet
        /// </summary>
        private DbSet<Purchase> Purchases { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="options"></param>
        public GlobalBlueContext(DbContextOptions<GlobalBlueContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// On Model Creating:
        ///     - Map all Purchase subclasses in same SQL table
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Hierarchy configurations
            modelBuilder.Entity<Purchase>()
                .HasDiscriminator<int>("PurchaseType")
                .HasValue<NetPurchase>(0)
                .HasValue<GrossPurchase>(1)
                .HasValue<VatPurchase>(2);
        }
    }
}