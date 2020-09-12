using Microsoft.EntityFrameworkCore;
using PersonWebAPI.Data.Maps;
using PersonWebAPI.Models;

namespace PersonWebAPI.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Person> People { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PersonMap());
        }
    }
}
