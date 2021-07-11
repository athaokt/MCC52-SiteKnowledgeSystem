using MCC52_SiteKnowledgeSystem.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCC52_SiteKnowledgeSystem.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<RequestForm> RequestForms { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<AccountRole> AccountRoles { get; set; }
        public DbSet<Site> Sites { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(a => a.Account)
                .WithOne(e => e.Employee)
                .HasForeignKey<Account>(e => e.EmployeeId);

            modelBuilder.Entity<AccountRole>()
                .HasKey(ac => new { ac.EmployeeId, ac.RoleId });
            modelBuilder.Entity<AccountRole>()
                .HasOne(a => a.Account)
                .WithMany(ac => ac.AccountRoles)
                .HasForeignKey(a => a.EmployeeId);
            modelBuilder.Entity<AccountRole>()
                .HasOne(r => r.Role)
                .WithMany(ac => ac.AccountRoles)
                .HasForeignKey(r => r.RoleId);

            modelBuilder.Entity<Category>()
                .HasMany(a => a.Contents)
                .WithOne(b => b.Category);

            modelBuilder.Entity<Content>()
                .HasOne(e => e.Employee)
                .WithMany(c => c.Contents);

            modelBuilder.Entity<Message>()
                .HasOne(e => e.Content)
                .WithMany(c => c.Messages);

            modelBuilder.Entity<Message>()
                .HasOne(e => e.Employee)
                .WithMany(c => c.Messages);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Site)
                .WithMany(c => c.Employees);

            modelBuilder.Entity<RequestForm>()
                .HasOne(e => e.Employee)
                .WithMany(c => c.RequestForms);
        }
    }

    
}
