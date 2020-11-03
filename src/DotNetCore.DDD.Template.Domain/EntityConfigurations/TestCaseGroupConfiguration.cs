using DotNetCore.DDD.Template.Domain.TestCaseAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetCore.DDD.Template.Domain.EntityConfigurations
{
    public class TestCaseGroupConfiguration : IEntityTypeConfiguration<TestCaseGroup>
    {
        public void Configure(EntityTypeBuilder<TestCaseGroup> builder)
        {
            //builder.ToTable("test_case_group", "test_platform");
            //builder.HasMany<TestCase>(nameof(TestCaseGroup.TestCases));
        }
    }
}