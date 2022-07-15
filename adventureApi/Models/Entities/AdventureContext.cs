using System;
using adventureApi.Models.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace adventureApi.Models.Entities
{
    public class AdventureContext : DbContext
    {
        private AppSettings _appSettings;

        public DbSet<User> Users { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Adventure> Adventures { get; set; }
        public DbSet<AdventureMember> AdventureMembers { get; set; }
        public DbSet<AdventureImage> AdventureImages { get; set; }


        public AdventureContext(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_appSettings.DbConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>().Property(l => l.Latitude).HasPrecision(8, 6);
            modelBuilder.Entity<Location>().Property(l => l.Longitude).HasPrecision(9, 6);
            base.OnModelCreating(modelBuilder);
        }
    }
}
