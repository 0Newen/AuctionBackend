using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FeeType>().HasData(
                new FeeType { Id = 1, Name = "Basic" },
                new FeeType { Id = 2, Name = "Special" },
                new FeeType { Id = 3, Name = "Association" },
                new FeeType { Id = 4, Name = "Storage" }
                );

            modelBuilder.Entity<VehicleType>().HasData(
                new VehicleType { Id = 1, Name = "Common" },
                new VehicleType { Id = 2, Name = "Luxury" }
                );

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<FeeType> FeeType { get; set; }
        public DbSet<VehicleType> VehicleType { get; set; }

    }
}
