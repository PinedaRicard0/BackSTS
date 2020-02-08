using AutoMapper;
using sts_i_daos;
using sts_i_services;
using sts_models.DTO;
using sts_models.POCOS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace sts_services
{
    public class TournamentConfService : ITournamentConfService
    {
        private readonly IMapper _mapper; 
        private readonly ID_Category _DaoCategory;
        private readonly ID_Pool _DaoPool;
        private readonly ID_Team _DaoTeam;
        private readonly ID_Field _DaoField;

        public TournamentConfService(IMapper mapper,ID_Category DaoCategory, ID_Pool DaoPool,
                                    ID_Team DaoTeam, ID_Field DaoField)
        {
            _mapper = mapper;
            _DaoCategory = DaoCategory;
            _DaoPool = DaoPool;
            _DaoTeam = DaoTeam;
            _DaoField = DaoField;
        }
        public async Task<List<Category>> AllCategories()
        {
            return await _DaoCategory.GetAllCategories();
        }

        public async Task<List<Field>> AllFields()
        {
            return await _DaoField.GetAllFields();
        }

        public async Task<string> CreateField(FieldP field)
        {
            var f = _mapper.Map<FieldP, Field>(field);
            return await _DaoField.SaveField(f);
        }

        public async Task<List<TeamP>> GetCategoryTeams(int categoryId)
        {
            List<Pool> pools = await _DaoPool.GetPoolsByCategory(categoryId);
            if (pools.Count > 0)
            {
                List<Team> teamsList = _DaoTeam.GetPoolsTeams(pools);
                if (teamsList.Count > 0)
                {
                    var r = _mapper.Map<List<Team>, List<TeamP>>(teamsList);
                    return r;
                }
            }
            return null;
        }
    }
}
