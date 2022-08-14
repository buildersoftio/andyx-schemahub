using Andy.X.SchemaHub.IO.Locations;
using Andy.X.SchemaHub.Model.Entities.Tenants;
using Microsoft.EntityFrameworkCore;

namespace Andy.X.SchemaHub.Core.Contexts
{
    public class TenantDbContext : DbContext
    {
        public readonly string _tenantDbLocation;

        public TenantDbContext()
        {
            _tenantDbLocation = AppLocations.GetTenantStoreFile();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_tenantDbLocation}");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Tenant>()
                .HasIndex(u => u.Name)
                .IsUnique();
        }


        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Tag> Tags { get; set; }

    }
}
