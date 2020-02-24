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
            await _context.Teams.AddAsync(team);
            await _context.SaveChangesAsync();
            return "created";
        }
    }
}
