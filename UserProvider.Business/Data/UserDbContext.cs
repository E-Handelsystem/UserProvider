using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using UserProvider.Business.Models;


namespace UserProvider.Business.Data
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }


        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("TestDb");
            }
        }
    }
}
