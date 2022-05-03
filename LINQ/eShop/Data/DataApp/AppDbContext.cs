using Data.Configurations;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.DataApp
{
    public class AppDbContext : DbContext
    {
        //public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        //{

        //}


        public DbSet<Department> Departments { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Subdepartment> Subdepartments { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<Product> Productos { get; set; }
        public DbSet<Carrito> Carritos { get; set; }
        public DbSet<ProductosAComprar> ProductosCompra { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new DepartmentConfiguration());
            builder.ApplyConfiguration(new SubdepartmentConfiguration());
            builder.ApplyConfiguration(new ProviderConfiguration());

            //builder.Entity<Enrollment>().HasOne(e => e.Course).WithMany(e => e.Enrollments).OnDelete(DeleteBehavior.NoAction);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=eShopWEB; Integrated Security=True");

        }

    }
}
