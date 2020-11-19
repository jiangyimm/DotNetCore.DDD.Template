using System.ComponentModel.DataAnnotations.Schema;
using DotNetCore.DDD.Template.Infrastructure.Abstractions;

namespace DotNetCore.DDD.Template.Domain.TestBlobAggregation
{
    [Table("test_blob", Schema = "test_platform")]
    public class TestBlob : Entity<long>, IAggregateRoot
    {
        public byte[] Content { get; private set; }
    }
}