using Microsoft.EntityFrameworkCore;
using sts_i_daos;
using sts_models.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sts_daos
{
    public class D_Team : ID_Team
    {
        private readonly DataContext _context;

        public D_Team(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Team>> GetPoolsTeams(List<Pool> pools)
        {
            List<Team> responseList = new List<Team>();
            foreach (var item in pools)
            {
                 responseList.AddRange(await _context.Teams.Where(t => t.PoolId == item.Id).ToListAsync());
            }
            return responseList;
        }

        public async Task<string> SaveTeam(Team team) {
            team.Pool = null;
            await _context.Teams.AddAsync(team);
            await _context.SaveChangesAsync();
            return "created";
        }

        public async Task<Team> GetTeam(int id) {
            return await _context.Teams.Include(t=>t.Pool).Where(t => t.TeamId == id).FirstOrDefaultAsync();
        }

        public async Task<string> UpdateTeam(Team team, int id) {
            Team res = await _context.Teams.Where(t => t.TeamId == id).FirstOrDefaultAsync();
            res.Name = team.Name;
            res.City = team.City;
            res.PoolId = team.PoolId;
            await _context.SaveChangesAsync();
            return "updated";
        }

        public async Task<List<Team>> GetTeamsPool(int poolId) {
            var response = await _context.Teams.Where(t => t.PoolId == poolId).OrderBy(t => t.Name).ToListAsync();
            return response;
        }

        public async Task<object> GetPlayersTeamBreadScrumb(int teamId)
        {
            var entries = await (from t in _context.Teams
                           join p in _context.Pools on t.PoolId equals p.Id
                           join c in _context.Categories on p.CategoryId equals c.Id
                           where t.TeamId == teamId
                           select new
                           {
                               teamName = t.Name,
                               teamId,
                               categoryName = c.Name,
                               categoryId = c.Id
                           }).FirstOrDefaultAsync();
            return entries;
                           
        }
    }
}
