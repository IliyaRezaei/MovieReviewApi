using Microsoft.EntityFrameworkCore;
using MovieReviewApi.Models;
using MovieReviewApi.Models.Account;

namespace MovieReviewApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options)
        {
            
        }
        //I could merge actor and director and add a discriminator, but there is no term that cover them both 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountUserRoles>().HasKey(x => new { x.UserId, x.RoleId});
            modelBuilder.Entity<AccountUser>().HasMany(x => x.Role).WithMany(x => x.User).UsingEntity<AccountUserRoles>();

            modelBuilder.Entity<MovieActor>().HasKey(x => new { x.MovieId, x.ActorId });
            modelBuilder.Entity<Movie>().HasMany(x => x.Actors).WithMany(x => x.Movies).UsingEntity<MovieActor>();
            modelBuilder.Entity<MovieDirector>().HasKey(x => new { x.MovieId, x.DirectorId });
            modelBuilder.Entity<Movie>().HasMany(x => x.Directors).WithMany(x => x.Movies).UsingEntity<MovieDirector>();
            modelBuilder.Entity<MovieGenre>().HasKey(x => new { x.MovieId, x.GenreId });
            modelBuilder.Entity<Movie>().HasMany(x => x.Genres).WithMany(x => x.Movies).UsingEntity<MovieGenre>();

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<AccountUser> AccountUsers { get; set; }
        public DbSet<AccountRole> AccountRoles { get; set; }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}
