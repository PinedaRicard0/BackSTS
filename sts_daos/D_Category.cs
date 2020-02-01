using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sts_i_daos;
using sts_models;

namespace sts_daos
{
    public class D_Category : ID_Category
    {
        private readonly DataContext _context;
        public D_Category(DataContext context)
        {
            _context = context;
        }

        public List<Category> GetAllCategories()
        {
            var categories = _context.Categories.ToList();
            return categories;
        }
    }
}
