using sts_models.DTO;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace sts_i_daos
{
    public interface ID_Category
    {
        Task<List<Category>>GetAllCategories();
        Task UpdateCategoryStatus(int categoryId, string Status);
    }
}
