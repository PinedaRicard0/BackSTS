using AutoMapper;
using sts_i_daos;
using sts_i_services;
using sts_models;
using sts_models.POCOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace sts_services
{
    public class TournamentConfService : ITournamentConfService
    {
        private readonly IMapper _mapper; 
        private readonly ID_Category _DaoCategory;
        private readonly ID_Pool _DaoPool;
        private readonly ID_Team _DaoTeam;

        public TournamentConfService(IMapper mapper,ID_Category DaoCategory, ID_Pool DaoPool, ID_Team DaoTeam)
        {
            _mapper = mapper;
            _DaoCategory = DaoCategory;
            _DaoPool = DaoPool;
            _DaoTeam = DaoTeam;
        }
        public List<Category> AllCategories()
        {
            return _DaoCategory.GetAllCategories();
        }

        public List<TeamP> GetCategoryTeams(int categoryId) {
            List<Pool> pools = _DaoPool.GetPoolsByCategory(categoryId);
            if (pools.Count > 0) {
                List<Team> teamsList = _DaoTeam.GetPoolsTeams(pools);
                if (teamsList.Count > 0) {
                    var r = _mapper.Map<List<Team>, List<TeamP>>(teamsList);
                    return r;
                }
            }
            return null;
        }
    }
}
