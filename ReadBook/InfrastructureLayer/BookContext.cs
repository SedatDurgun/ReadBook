using DomainLayer.Entities.Concrete;
using InfrastructureLayer.EntityTypeConfigurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace InfrastructureLayer
{
    public class BookContext : IdentityDbContext<User,Role,int>
    {
        public BookContext()
        {
            
        }

       

        public BookContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<Book> Books => Set<Book>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Corner> Corners => Set<Corner>();


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Data source=SEDAT\\SQLEXPRESS;initial catalog=ReadABookDB;integrated security=true;TrustServerCertificate=true");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            

            builder.ApplyConfiguration(new User_CFG());
            builder.ApplyConfiguration(new Role_CFG());
            builder.ApplyConfiguration(new Book_CFG());
            builder.ApplyConfiguration(new Category_CFG());
            builder.ApplyConfiguration(new Corner_CFG());

            //SuperUser-Admin İlişkisi(1-1)
            builder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>
            {
                UserId = 1,
                RoleId = 1,
            });

        }

    }
}
