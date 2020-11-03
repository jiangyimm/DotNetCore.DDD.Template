using DotNetCore.DDD.Template.Infrastructure.Core;
using DotNetCore.DDD.Template.Domain.TestCaseAggregate;
using System.Threading.Tasks;
using System.Threading;

namespace DotNetCore.DDD.Template.Domain.Repositories
{
    public interface ITestCaseRepository : IRepository<TestCase, long>
    {

    }

    public class TestCaseRepository : Repository<TestCase, long, PgDbContext>, ITestCaseRepository
    {
        public TestCaseRepository(PgDbContext dbContext) : base(dbContext)
        {
        }
    }
}