using Microsoft.EntityFrameworkCore;
using PersonWebAPI.Models;

namespace PersonWebAPI.Data
{
    public class DataContex : DbContext
    {
        public DbSet<Person> People { get; set; }
    }
}
