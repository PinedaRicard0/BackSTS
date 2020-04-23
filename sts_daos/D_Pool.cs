using Microsoft.EntityFrameworkCore;
using sts_i_daos;
using sts_models.DTO;
using sts_models.POCOS;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sts_daos
{
    public class D_Pool : ID_Pool
    {
        private readonly DataContext _context;

        public D_Pool(DataContext context)
        {
            _context = context;
        }

        public Task<List<PoolTeamStatisctics>> GetPoolTeamsAndStatistics(int poolId)
        {
            var entries = (from t in _context.Teams
                           join ts in _context.TeamsStatistics on t.TeamId equals ts.TeamId
                           join p in _context.Pools on t.PoolId equals p.Id
                           where p.Id == poolId
                           orderby p.Id, ts.Won descending, ts.Scored descending, ts.GoalDifference descending
                           select new PoolTeamStatisctics
                           { 
                               teamId = t.TeamId,
                               teamName = t.Name,
                               teamStatiscticsId = ts.Id,
                               played = ts.Played,
                               won = ts.Won,
                               lost = ts.Lost,
                               scored = ts.Scored,
                               against = ts.Against,
                               goalDifference = ts.GoalDifference
                           }).ToListAsync();
            return entries;
        }

        public async Task<List<Pool>> GetPoolsByCategory(int categoryId)
        {
            var response = await _context.Pools.Where(p => p.CategoryId == categoryId).OrderBy(p => p.Name).ToListAsync();
            return response;
        }
    }
}
