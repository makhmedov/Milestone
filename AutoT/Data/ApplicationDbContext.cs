using System;
using System.Collections.Generic;
using System.Text;
using AutoT.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AutoT.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<UsersRolesMap> UserRolesMap { get; set; }
        public DbSet<ServiceBook> ServiceBook { get; set; }
        public DbSet<ServiceBookContent> ServiceBookContent { get; set; }
        public DbSet<ServiceMaintance> ServiceMaintance { get; set; }
        public DbSet<Rating> Rating { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
