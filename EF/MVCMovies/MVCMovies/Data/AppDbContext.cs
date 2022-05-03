using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCMovies.Entities;
using MVCMovies.Models;

namespace MVCMovies.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<UserRate> MovieRates { get; set; }
        public DbSet<UserRateActor> ActorRates { get; set; }
        public DbSet<MovieArticles> MovieArticles { get; set; }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);

        //    builder.Entity<UserRate>(rate =>
        //    {
        //        rate.HasKey(c => c.MovieId);
        //        rate.HasKey(c => c.UserId);
        //    });


        //}
    }
}
