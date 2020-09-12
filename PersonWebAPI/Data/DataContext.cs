using Microsoft.EntityFrameworkCore;
using PersonWebAPI.Models;

namespace PersonWebAPI.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Person> People { get; set; }
    }
}
