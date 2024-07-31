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
            modelBuilder.Entity<UserRoles>().HasKey(x => new { x.UserId, x.RoleId});
            modelBuilder.Entity<User>().HasMany(x => x.Role).WithMany(x => x.User).UsingEntity<UserRoles>();


            modelBuilder.Entity<MovieActor>().HasKey(x => new { x.MovieId, x.ActorId });
            modelBuilder.Entity<Movie>().HasMany(x => x.MovieCrew).WithMany(x => x.Movies).UsingEntity<MovieActor>();
            modelBuilder.Entity<MovieDirector>().HasKey(x => new { x.MovieId, x.DirectorId });
            modelBuilder.Entity<Movie>().HasMany(x => x.MovieCrew).WithMany(x => x.Movies).UsingEntity<MovieDirector>();
            modelBuilder.Entity<MovieGenre>().HasKey(x => new { x.MovieId, x.GenreId });
            modelBuilder.Entity<Movie>().HasMany(x => x.Genres).WithMany(x => x.Movies).UsingEntity<MovieGenre>();

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Person> MovieCrew { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}
