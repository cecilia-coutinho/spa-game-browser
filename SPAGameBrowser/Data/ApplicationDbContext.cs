using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SPAGameBrowser.Models;

namespace SPAGameBrowser.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public DbSet<Word>? Words { get; set; }
        public DbSet<UserScore>? UserScores { get; set; }

        public DbSet<Letter>? Letters { get; set; }

        public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>()
                .HasIndex(u => u.Nickname)
                .IsUnique();

            modelBuilder.Entity<Word>()
                .HasIndex(u => u.WordName)
                .IsUnique();

            modelBuilder.Entity<Letter>()
                .HasIndex(u => u.Key)
                .IsUnique();

            modelBuilder.Entity<UserScore>()
            .HasOne(u => u.ApplicationUsers)
            .WithMany(a => a.UserScores)
            .HasForeignKey(u => u.FkUserId);

            modelBuilder.Entity<UserScore>()
                .HasOne(u => u.Words)
                .WithMany(a => a.UserScores)
                .HasForeignKey(u => u.FkWordId);

            modelBuilder.Seed();
        }
    }
}