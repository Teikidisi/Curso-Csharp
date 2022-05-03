using Microsoft.EntityFrameworkCore;
using Model.Configurations;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Migrations
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Carrito> Carrito { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Subdepartment> Subdepartments { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ProductosAComprar> ProductosCompra { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<PurchaseOrdr> PurchaseOrders { get; set; }

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
            options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=eSHOP; Integrated Security=True");

        }
    }
}
