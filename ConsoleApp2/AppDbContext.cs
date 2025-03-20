using Microsoft.EntityFrameworkCore;
namespace ConsoleApp2
{
    public class AppDbContext : DbContext
    {
        private string connectionStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=University;Integrated Security=True;Connect Timeout=30;";

        public DbSet<Student> Students { get; set; }
        /*public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }*/
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionStr);
        }
    }
}
