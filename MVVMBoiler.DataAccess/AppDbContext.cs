using Microsoft.EntityFrameworkCore;
using MVVMBoiler.Models;

namespace MVVMBoiler.DataAccess
{
    /// <summary>
    /// DBContext for films.
    /// </summary>
    public class AppDbContext : DbContext
    {
        public DbSet<Customer> Customer { get; set; }

        public AppDbContext() : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //options.UseSqlServer(ConfigurationManager.ConnectionStrings["MVVMBoilerDb"].ConnectionString);
            //Remigration
            options.UseSqlServer(@"Server = (LocalDB)\MSSQLLocalDB; Database=MVVMBoilerDb; Trusted_Connection=True; Integrated Security = True");
        }


        /// <summary>
        /// Seeding data
        /// </summary>
        /// <param FirstName="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
            new Customer { Id = 1, FirstName = "Amendus", LastName = "Jackie" },
            new Customer { Id = 2, FirstName = "Sonate", LastName = "Hummel" },
            new Customer { Id = 3, FirstName = "Tokyo Drift", LastName = "Wannie" },
            new Customer { Id = 4, FirstName = "Ringer", LastName = "Emmy" });
            base.OnModelCreating(modelBuilder);
        }
    }
}
