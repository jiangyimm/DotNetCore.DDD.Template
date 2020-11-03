using DotNetCore.DDD.Template.Domain.TestCaseAggregate;
using DotNetCore.DDD.Template.Domain.EntityConfigurations;
using DotNetCore.DDD.Template.Infrastructure.Core;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace DotNetCore.DDD.Template.Domain
{
    public class PgDbContext : EFContext
    {
        public PgDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<TestCaseGroup> TestCaseGroups { get; set; }
        public DbSet<TestCase> TestCases { get; set; }
        public DbSet<TestCaseDetail> TestCaseDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasDefaultSchema("test_platform");
            //modelBuilder.ApplyConfiguration(new TestCaseGroupConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}