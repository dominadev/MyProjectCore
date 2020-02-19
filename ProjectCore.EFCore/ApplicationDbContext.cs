using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectCore.Model.EntityModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectCore.EFCore
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string,
        ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin,
        ApplicationRoleClaim, ApplicationUserToken>
    {
        public virtual DbSet<SystemConfig> SystemConfigs { get; set; }
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DOMINA\DOMINA;Database=DBProjectCore;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>(b =>
            {
                // Each User can have many UserClaims
                b.HasMany(e => e.Claims)
                    .WithOne(e => e.User)
                    .HasForeignKey(uc => uc.UserId)
                    .IsRequired();

                // Each User can have many UserLogins
                b.HasMany(e => e.Logins)
                    .WithOne(e => e.User)
                    .HasForeignKey(ul => ul.UserId)
                    .IsRequired();

                // Each User can have many UserTokens
                b.HasMany(e => e.Tokens)
                    .WithOne(e => e.User)
                    .HasForeignKey(ut => ut.UserId)
                    .IsRequired();

                // Each User can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.User)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            builder.Entity<ApplicationRole>(b =>
            {
                // Each Role can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.Role)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                // Each Role can have many associated RoleClaims
                b.HasMany(e => e.RoleClaims)
                    .WithOne(e => e.Role)
                    .HasForeignKey(rc => rc.RoleId)
                    .IsRequired();
            });
            builder.Entity<ApplicationUser>(b =>
            {
                b.ToTable("ApplicationUsers");
            });

            builder.Entity<ApplicationUserClaim>(b =>
            {
                b.ToTable("ApplicationUserClaims");
            });

            builder.Entity<ApplicationUserLogin>(b =>
            {
                b.ToTable("ApplicationUserLogins");
            });

            builder.Entity<ApplicationUserToken>(b =>
            {
                b.ToTable("ApplicationUserTokens");
            });

            builder.Entity<ApplicationRole>(b =>
            {
                b.ToTable("ApplicationRoles");
            });

            builder.Entity<ApplicationRoleClaim>(b =>
            {
                b.ToTable("ApplicationRoleClaims");
            });

            builder.Entity<ApplicationUserRole>(b =>
            {
                b.ToTable("ApplicationUserRoles");
            });
        }
    }
}
