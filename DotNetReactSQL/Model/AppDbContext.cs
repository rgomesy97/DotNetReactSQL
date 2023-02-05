using Microsoft.EntityFrameworkCore;

namespace DotNetReactSQL.Model
{
    public class AppDbContext : DbContext
    {
        private IConfiguration _configuration;

        public AppDbContext(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        public DbSet<PhoneBook> PhoneBook { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string? connectionString = _configuration.GetConnectionString("WebApiDatabase");
            if (connectionString != null)
            {
                optionsBuilder.UseMySQL(connectionString);
            }
            else
            {
                throw new Exception("Connection does not exist");
            }
            
        }
    }
}
