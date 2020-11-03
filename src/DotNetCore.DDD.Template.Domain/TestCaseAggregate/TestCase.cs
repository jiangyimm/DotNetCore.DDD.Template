using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DotNetCore.DDD.Template.Infrastructure.Domain;

namespace DotNetCore.DDD.Template.Domain.TestCaseAggregate
{
    [Table("test_case", Schema = "test_platform")]
    public class TestCase : Entity<long>, IAggregationRoot
    {
        [ForeignKey(nameof(TargetTestCaseGroup))]
        public long TestCaseGroupId { get; set; }
        [Required]
        [StringLength(32)]
        public string Name { get; set; }
        public short Sort { get; set; }
        public string CodeContent { get; set; }
        [StringLength(16)]
        public string OperCode { get; set; }
        public DateTimeOffset OperTime { get; set; }
        public TestCaseGroup TargetTestCaseGroup { get; set; }
        public List<TestCaseDetail> TestCaseDetails { get; set; }
    }
}