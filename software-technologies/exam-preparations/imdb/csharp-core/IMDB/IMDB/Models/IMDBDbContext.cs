using Microsoft.EntityFrameworkCore;
using MySQL.Data.EntityFrameworkCore.Extensions;
using MySql.Data.MySqlClient;

namespace IMDB.Models
{
    public class IMDBDbContext : DbContext
    {
        public virtual DbSet<Film> Films { get; set; }

        public IMDBDbContext() : base()
        {
        }

        public MySqlConnection connection = new MySqlConnection("server=127.0.0.1;user id=mysqltest;password=test;port=3306;database=IMDB");
        
        /// <summary>
        /// Factory class for EmployeesContext
        /// </summary>
        public static class IMDBContextFactory
        {
            public static IMDBDbContext Create(string connectionString)
            {
                var optionsBuilder = new DbContextOptionsBuilder<IMDBDbContext>();
                optionsBuilder.UseMySQL(connectionString);

                //Ensure database creation
                var context = new IMDBDbContext();
                context.Database.EnsureCreated();

                return context;
            }
        }
    }
}