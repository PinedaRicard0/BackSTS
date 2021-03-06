﻿using sts_models.DTO;
using sts_models.POCOS;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sts_i_services
{
    public interface ITournamentConfService
    {
        Task<List<Category>> AllCategories();
        Task<List<TeamP>> GetCategoryTeams(int categoryId);
        Task<List<Field>> AllFields();
        Task<string> CreateField(FieldP field);
        Task<string> UpdateField(FieldP field);
        Task<List<PoolP>> GetCategoryPools(int id);
        Task<string> CreateTeams(TeamP team);
        Task<TeamP> GetTeamById(int id);
        Task<string> UpdateTeam(TeamP team);
        Task<string> AddPlayerToTeam(PlayerP player);
        Task<List<PlayerP>> GetTeamPlayers(int teamId);
        Task<string> UpdatePlayer(PlayerP player);
        Task<List<PoolStatistics>> GetPoolsAndStatisticOfCategory(int categoryId);
        Task<bool> CanStartCategorie(int categoryId);
        Task<string> StartCategory(int categoryId);
        Task<List<MatchP>> GetCategoryMatches(int categoryId);

    }
}
