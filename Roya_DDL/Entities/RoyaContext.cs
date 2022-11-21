using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Roya_DDL.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roya_DDL.Entities
{
    public class RoyaContext : IdentityDbContext<User>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Addreses> Addreses { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<FavoritList> FavoritLists { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public RoyaContext(DbContextOptions<RoyaContext> options):base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Comment>().HasKey("UserId", "ProductId");
            base.OnModelCreating(modelBuilder);
        }
    }
}
