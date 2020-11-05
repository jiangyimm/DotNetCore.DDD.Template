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
        Task<TestCase> GetAggregationAsync(long id);
        Task<List<TestCase>> QueryAsync(string searchKey);
    }

    public class TestCaseRepository : Repository<TestCase, long, PgDbContext>, ITestCaseRepository
    {
        public TestCaseRepository(PgDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<TestCase> GetAggregationAsync(long id)
        {
            return await DbContext.TestCases
                    .Include(p => p.TargetTestCaseGroup)
                    .Include(p => p.TestCaseDetails)
                    .FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<List<TestCase>> QueryAsync(string searchKey)
        {
            return await DbContext.TestCases.ToListAsync();
        }
    }
}