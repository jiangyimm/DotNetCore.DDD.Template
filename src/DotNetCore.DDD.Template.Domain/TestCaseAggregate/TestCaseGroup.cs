using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DotNetCore.DDD.Template.Infrastructure.Abstractions;

namespace DotNetCore.DDD.Template.Domain.TestCaseAggregate
{
    [Table("test_case_group", Schema = "test_platform")]
    public class TestCaseGroup : Entity<long>
    {
        [Required, StringLength(32)]
        public string Name { get; private set; }
        public short Sort { get; private set; }
        [StringLength(16)]
        public string OperCode { get; private set; }
        public DateTimeOffset OperTime { get; private set; }
        public List<TestCase> TestCases { get; private set; }

        protected TestCaseGroup() { }
        public TestCaseGroup(string name, short sort, string operCode, DateTimeOffset operTime)
        {
            this.Name = name;
            this.Sort = sort;
            this.OperCode = operCode;
            this.OperTime = operTime;
        }
    }
}