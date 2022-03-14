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


        public AdventureContext(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_appSettings.DbConnectionString);
        }
    }
}
