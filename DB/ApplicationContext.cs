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
        //private string _connection = "Data Source=DESKTOP-EB9TG1V;Database=myDataBase;User Id=myUsername;Password=myPassword;";
        //private readonly string _connection = "Server=localhost\\SQLEXPRESS;Initial Catalog=Sample;TrustServerCertificate=true";
        private readonly string _connection = "Data Source=DESKTOP-EB9TG1V;Database=Sample;Integrated Security = sspi; Encrypt=False;";
        public DbSet<User> Users { get; set; }
        public DbSet<StateRequest> StateRequests { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        
        public DbSet<TypeFault> TypeFaults{ get; set; }




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
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

    }
}
