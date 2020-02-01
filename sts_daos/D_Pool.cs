using sts_i_daos;
using sts_models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sts_daos
{
    public class D_Pool : ID_Pool
    {
        private readonly DataContext _context;

        public D_Pool(DataContext context)
        {
            _context = context;
        }
        public List<Pool> GetPoolsByCategory(int categoryId)
        {
            var response = _context.Pools.Where(p => p.CategoryId == categoryId).ToList();
            return response;
        }
    }
}
