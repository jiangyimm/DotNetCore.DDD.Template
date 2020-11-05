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
        public long TestCaseGroupId { get; private set; }
        [Required]
        [StringLength(32)]
        public string Name { get; private set; }
        public short Sort { get; private set; }
        public string CodeContent { get; private set; }
        [StringLength(16)]
        public string OperCode { get; private set; }
        public DateTimeOffset OperTime { get; private set; }
        public TestCaseGroup TargetTestCaseGroup { get; private set; }
        public List<TestCaseDetail> TestCaseDetails { get; private set; }

        public TestCase(string name, short sort, string codeContent, string operCode, DateTimeOffset operTime
        //TestCaseGroup targetTestCaseGroup,
        //List<TestCaseDetail> testCaseDetails = null
        )
        {
            this.Name = name;
            this.Sort = sort;
            this.CodeContent = codeContent;
            this.OperCode = operCode;
            this.OperTime = operTime;
            //this.TargetTestCaseGroup = targetTestCaseGroup;
            //this.TestCaseDetails = testCaseDetails;
        }

        public void AddTargetTestCaseGroup(TestCaseGroup testCaseGroup)
        {
            this.TargetTestCaseGroup = testCaseGroup;
        }
    }
}