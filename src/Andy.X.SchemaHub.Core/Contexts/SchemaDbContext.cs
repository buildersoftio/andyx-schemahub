using Andy.X.SchemaHub.IO.Locations;
using Andy.X.SchemaHub.Model.Entities.Schemas;
using Microsoft.EntityFrameworkCore;

namespace Andy.X.SchemaHub.Core.Contexts
{
    public class SchemaDbContext : DbContext
    {
        public readonly string _schemmaDbLocation; 
        
        public SchemaDbContext()
        {
            _schemmaDbLocation = AppLocations.GetschemasStoreFile();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_schemmaDbLocation}");
        }

        public DbSet<Schema> Schemas { get; set; }
    }
}
