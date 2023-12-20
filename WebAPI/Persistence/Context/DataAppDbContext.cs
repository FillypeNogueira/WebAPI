using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Persistence.Context
{
    public class DataAppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DataAppDbContext(DbContextOptions<DataAppDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql(_configuration["ConnectionStrings:DefaultConnection"]);
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Category>().ToTable("Category");
            builder.Entity<Category>().HasKey(p => p.CategoryId);
            builder.Entity<Category>().Property(p => p.CategoryId).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Category>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Category>().Property(p => p.Status).IsRequired().HasDefaultValue(false);

            builder.Entity<Product>().ToTable("Product");
            builder.Entity<Product>().HasKey(p => p.ProductId);
            builder.Entity<Product>().Property(p => p.ProductId).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(70);
            builder.Entity<Product>().Property(p => p.Status).IsRequired().HasDefaultValue(false);
            builder.Entity<Product>().HasOne<Category>(p => p.Category).WithMany(p => p.Products).HasForeignKey(p => p.CategoryId);
            builder.Entity<Product>().Property(p => p.Description).HasMaxLength(150);
            builder.Entity<Product>().Property(p => p.Price).IsRequired().HasDefaultValue(0.00);

        }
    }
}
