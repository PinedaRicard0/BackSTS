using Microsoft.EntityFrameworkCore;
using sts_i_daos;
using sts_models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sts_daos
{
    public class D_Match : ID_Match
    {
        private readonly DataContext _context;

        public D_Match(DataContext dataContext)
        {
            _context = dataContext;
        }

        public async Task CreateMatch(Match match)
        {
            await _context.Matches.AddAsync(match);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Match>> GetPoolMatches(int poolId)
        {
            var res = await _context.Matches.Include(m => m.TeamOne).
                Include(m => m.TeamTwo).
                Include(m => m.Field).
                Include(m => m.Pool).
                Where(m => m.PoolId == poolId).ToListAsync();
            return res;
        }
    }
}
