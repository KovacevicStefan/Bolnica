using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using arhitektura_projekat.Models;
using Microsoft.AspNetCore.Identity;

namespace arhitektura_projekat.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Bolnica> Bolnice { get; set; }
        public DbSet<Dijagnoza> Dijagnoze { get; set; }
        public DbSet<Odeljenje> Odeljenja { get; set; }
        public DbSet<Pacijent> Pacijenti { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Koristite svoje definicije User i Role umesto generičkih klasa
            builder.Entity<User>().ToTable("AspNetUsers", "identity");
            builder.Entity<Role>().ToTable("AspNetRoles", "identity");
            builder.Entity<IdentityUserClaim<string>>().ToTable("AspNetUserClaims", "identity");
            builder.Entity<IdentityUserLogin<string>>().ToTable("AspNetUserLogins", "identity");
            builder.Entity<IdentityUserToken<string>>().ToTable("AspNetUserTokens", "identity");
            builder.Entity<IdentityUserRole<string>>().ToTable("AspNetUserRoles", "identity");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("AspNetRoleClaims", "identity");

            // Konfiguracija dodatnih svojstava
            builder.Entity<User>().Property(u => u.FirstName).HasMaxLength(100);
            builder.Entity<User>().Property(u => u.LastName).HasMaxLength(100);

            // Tabele za druge modele
            builder.Entity<Bolnica>().ToTable("Bolnica", "public");
            builder.Entity<Dijagnoza>().ToTable("Dijagnoza", "public");
            builder.Entity<Odeljenje>().ToTable("Odeljenje", "public");
            builder.Entity<Pacijent>().ToTable("Pacijent", "public");
        }
    }
}
