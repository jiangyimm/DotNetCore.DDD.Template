using System.Collections.Generic;
using DotNetCore.DDD.Template.Infrastructure.Core;
using DotNetCore.DDD.Template.Domain.TestCaseAggregate;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DotNetCore.DDD.Template.Domain.Repositories
{
    public interface ITestCaseRepository : IRepository<TestCase, long>
    {
        Task<List<TestCase>> Query(string searchKey);
    }

    public class TestCaseRepository : Repository<TestCase, long, PgDbContext>, ITestCaseRepository
    {
        public TestCaseRepository(PgDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<TestCase>> Query(string searchKey)
        {
            return await DbContext.TestCases.ToListAsync();
        }
    }
}