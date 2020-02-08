using Microsoft.EntityFrameworkCore;
using sts_i_daos;
using sts_models.DTO;
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
        public async Task<List<Pool>> GetPoolsByCategory(int categoryId)
        {
            var response = await _context.Pools.Where(p => p.CategoryId == categoryId).ToListAsync();
            return response;
        }
    }
}
