using sts_models;
using System;
using System.Collections.Generic;
using System.Text;

namespace sts_i_daos
{
    public interface ID_Category
    {
        List<Category> GetAllCategories();
    }
}
