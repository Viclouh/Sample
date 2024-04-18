using Microsoft.EntityFrameworkCore;
using Sample.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.DB
{
    public class ApplicationContext : DbContext
    {
        //private string _connection = "Data Source=DESKTOP-61G5QRE;Database=myDataBase;User Id=myUsername;Password=myPassword;";
        private readonly string _connection = "Server=localhost\\SQLEXPRESS;Database=Sample;Trusted_Connection=True;TrustServerCertificate=true";

        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connection);
        }
        public ApplicationContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

    }
}
