using DomainLayer.Entities.Concrete;
using Infrastructure.EntityTypeConfigurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class LibraryContext : IdentityDbContext<User,Role,int>
    {
        public LibraryContext()
        {
        }
        public LibraryContext(DbContextOptions options) : base(options)
        {
        }
         
        public DbSet<User> Users => Set<User>();
        public DbSet<Role> roles => Set<Role>();

        public DbSet<Book> Books => Set<Book>();

        public DbSet<Category> Categories => Set<Category>();

        public DbSet<Corner> Corners => Set<Corner>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Data source=SEDAT\\SQLEXPRESS;initial catalog=Read_BookDB; integrated security=true; TrustServerCertificate=true;");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new User_CFG());
            builder.ApplyConfiguration(new Role_CFG());
            builder.ApplyConfiguration(new Book_CFG());
            builder.ApplyConfiguration(new Category_CFG());
            builder.ApplyConfiguration(new Corner_CFG());
            //Admin Relation(1-1)

            builder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int> 
            {
                UserId = 1,
                RoleId = 1,
            });



        }
    }
}
