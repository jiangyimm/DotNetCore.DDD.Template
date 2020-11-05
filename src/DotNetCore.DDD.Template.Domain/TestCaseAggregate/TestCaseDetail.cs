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
        public long TestCaseId { get; private set; }
        public short Sort { get; private set; }
        [MaxLength(16)]
        public string[] Params { get; private set; }
        [MaxLength(16)]
        public string[] Variables { get; private set; }
        [StringLength(32)]
        public string EditorName { get; private set; }
        public string Result { get; private set; }
        public bool IsCallBack { get; private set; }
        public long? CallBackFormId { get; private set; }
        [StringLength(16)]
        public string OperCode { get; private set; }
        public DateTimeOffset OperTime { get; private set; }
        public TestCase TargetTestCase { get; private set; }
    }
}