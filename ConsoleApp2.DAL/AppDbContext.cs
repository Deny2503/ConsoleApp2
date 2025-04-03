using ConsoleApp2.DAL.Entities;
using ConsoleApp2.DAL.NewFolder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace ConsoleApp2.DAL
{
    public class AppDbContext : DbContext
    {
        //private string connectionStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=University;Integrated Security=True;Connect Timeout=30;";


        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        /*public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }*/
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionStr = connection.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionStr);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
