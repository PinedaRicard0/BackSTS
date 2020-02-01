using sts_models;
using sts_models.POCOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace sts_i_services
{
    public interface ITournamentConfService
    {
        List<Category> AllCategories();
        List<TeamP> GetCategoryTeams(int categoryId);
    }
}
