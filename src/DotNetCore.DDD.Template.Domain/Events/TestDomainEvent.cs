using MediatR;

namespace DotNetCore.DDD.Template.Domain.Events
{
    public class TestDomainEvent : INotification
    {
        public TestDomainEvent(string name, string sex)
        {
            this.Name = name;
            this.Sex = sex;
        }

        public string Name { get; }
        public string Sex { get; }

    }
}
