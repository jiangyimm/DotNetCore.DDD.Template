using DotNetCore.DDD.Template.Domain.TestCaseAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetCore.DDD.Template.Domain.EntityConfigurations
{
    public class TestCaseConfiguration : IEntityTypeConfiguration<TestCase>
    {
        public void Configure(EntityTypeBuilder<TestCase> builder)
        {
            //builder.ToTable("test_case_group", "test_platform");
            //builder.HasMany<TestCase>(nameof(TestCaseGroup.TestCases));
            // builder.OwnsOne(o => o.TestCaseValueObject, a =>
            // {
            //     a.WithOwner();
            // });
        }
    }
}