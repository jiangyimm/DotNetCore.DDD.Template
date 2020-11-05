using MediatR;
using DotNetCore.DDD.Template.Domain.TestCaseAggregate;
namespace DotNetCore.DDD.Template.Domain.Events
{
    public class TestCaseCreateDomainEvent : INotification
    {
        public TestCase TestCase { get; private set; }
        public TestCaseCreateDomainEvent(TestCase testCase)
        {
            TestCase = testCase;
        }
    }
}
