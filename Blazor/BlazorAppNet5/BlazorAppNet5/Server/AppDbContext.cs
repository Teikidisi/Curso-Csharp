using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace BlazorAppNet5.Server
{
    public class AppDbContext : DbContext
    {
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}
