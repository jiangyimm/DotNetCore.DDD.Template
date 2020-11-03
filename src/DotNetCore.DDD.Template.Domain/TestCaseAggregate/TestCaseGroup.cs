using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DotNetCore.DDD.Template.Infrastructure.Domain;

namespace DotNetCore.DDD.Template.Domain.TestCaseAggregate
{
    [Table("test_case_group", Schema = "test_platform")]
    public class TestCaseGroup : Entity<long>
    {
        [Required, StringLength(32)]
        public string Name { get; set; }
        public short Sort { get; set; }
        [StringLength(16)]
        public string OperCode { get; set; }
        public DateTimeOffset OperTime { get; set; }
        public List<TestCase> TestCases { get; set; }
    }
}