using KonusarakOgrenProje.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
namespace KonusarakOgrenProje.Data
{

    public class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions options)
        {

        }
        public DbSet<Exams> Exams { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "KonusarakOgren.db" };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);

            optionsBuilder.UseSqlite(connection);
        }
    }
}
