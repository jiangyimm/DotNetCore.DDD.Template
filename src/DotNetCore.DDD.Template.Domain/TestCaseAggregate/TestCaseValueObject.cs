using System.Collections.Generic;
using DotNetCore.DDD.Template.Infrastructure.Abstractions;

namespace DotNetCore.DDD.Template.Domain.TestCaseAggregate
{

    public class TestCaseValueObject : ValueObject
    {
        public TestCaseValueObject() { }
        public TestCaseValueObject(string feild1, bool feild2)
        {
            this.Feild1 = feild1;
            this.Feild2 = feild2;

        }
        public string Feild1 { get; private set; }
        public bool Feild2 { get; private set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            // Using a yield return statement to return each element one at a time
            yield return Feild1;
            yield return Feild2;
        }
    }
}