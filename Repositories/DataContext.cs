using Repositories.Models;
using System.Data.Entity;

namespace Repositories
{
    public class DataContext : DbContext
    {
        public DataContext() : base("Connection")
        {
        }

        public DataContext(string connection) : base(connection)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}
