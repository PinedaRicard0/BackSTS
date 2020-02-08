using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sts_i_daos;
using sts_models.DTO;

namespace sts_daos
{
    public class D_Category : ID_Category
    {
        private readonly DataContext _context;
        public D_Category(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            var categories = await _context.Categories.ToListAsync();
            return categories;
        }
    }
}
