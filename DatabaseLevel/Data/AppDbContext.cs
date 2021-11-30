
using DatabaseLevel.EntityModels;
using Microsoft.EntityFrameworkCore;


namespace DatabaseLevel.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<PersonEntityModel> Persons { get; set; }

    }
}
