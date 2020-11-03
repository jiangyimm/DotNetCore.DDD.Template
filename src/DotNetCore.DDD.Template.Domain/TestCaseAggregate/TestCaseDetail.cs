using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DotNetCore.DDD.Template.Infrastructure.Domain;

namespace DotNetCore.DDD.Template.Domain.TestCaseAggregate
{
    [Table("test_case_detail", Schema = "test_platform")]
    public class TestCaseDetail : Entity<long>
    {
        [ForeignKey(nameof(TargetTestCase))]
        public long TestCaseId { get; set; }
        public short Sort { get; set; }
        [MaxLength(16)]
        public string[] Params { get; set; }
        [MaxLength(16)]
        public string[] Variables { get; set; }
        [StringLength(32)]
        public string EditorName { get; set; }
        public string Result { get; set; }
        public bool IsCallBack { get; set; }
        public long? CallBackFormId { get; set; }
        [StringLength(16)]
        public string OperCode { get; set; }
        public DateTimeOffset OperTime { get; set; }
        public TestCase TargetTestCase { get; set; }
    }
}