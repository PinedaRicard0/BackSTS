using sts_i_daos;
using sts_models.DTO;
using System;
using System.Collections.Generic;
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
    }
}
