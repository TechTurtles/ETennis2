using System;
using System.Collections.Generic;
using System.Text;
using ETennis2.Model;
using ETennis2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ETennis2.Data
{
    public class ApplicationDbContext: IdentityDbContext<TennisUser, TennisRole, int,
        TennisUserClaim, TennisUserRole, TennisUserLogin,TennisRoleClaim,TennisUserToken>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<TennisUser> TennisUser { get; set; }
        public virtual DbSet<TennisRole> TennisRole { get; set; }
        public virtual DbSet<TennisUserRole> TennisUserRole { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<Schedule> Schedule { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Schedule>()
            //    .HasKey(s => new { s.EventId, s.UserId });

            //modelBuilder.Entity<Schedule>()
            //    .HasOne(s => s.Event)
            //    .WithMany(b => b.Schedules)
            //    .HasForeignKey(s => s.EventId);

            //modelBuilder.Entity<Schedule>()
            //    .HasOne(s => s.TennisUser)
            //    .WithMany(b => b.Schedules)
            //    .HasForeignKey(s => s.UserId);

            modelBuilder.Entity<TennisUser>(b =>
            {
                // Each User can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.User)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            modelBuilder.Entity<TennisRole>(b =>
            {
                // Each Role can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.Role)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();
            });
        }
    }
}
