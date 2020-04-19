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
        private readonly ID_Player _DaoPlayer;

        public TournamentConfService(IMapper mapper,ID_Category DaoCategory, ID_Pool DaoPool,
                                    ID_Team DaoTeam, ID_Field DaoField, ID_Player DaoPlayer)
        {
            _mapper = mapper;
            _DaoCategory = DaoCategory;
            _DaoPool = DaoPool;
            _DaoTeam = DaoTeam;
            _DaoField = DaoField;
            _DaoPlayer = DaoPlayer;
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

        public async Task<string> UpdateField(FieldP field)
        {
            string r = await _DaoField.UpdateFieldById(field);
            return r;

        }

        public async Task<List<TeamP>> GetCategoryTeams(int categoryId)
        {
            List<Pool> pools = await _DaoPool.GetPoolsByCategory(categoryId);
            if (pools.Count > 0)
            {
                List<Team> teamsList = await _DaoTeam.GetPoolsTeams(pools);
                if (teamsList.Count > 0)
                {
                    var r = _mapper.Map<List<Team>, List<TeamP>>(teamsList);
                    return r;
                }
            }
            return null;
        }

        public async Task<List<PoolP>> GetCategoryPools(int id) {
            List<Pool> pools = await _DaoPool.GetPoolsByCategory(id);
            var r = _mapper.Map<List<Pool>, List<PoolP>>(pools);
            if (r.Count > 0) {
                return r;
            }
            return null;
        }

        public async Task<string> CreateTeams(TeamP team)
        {
            try
            {

                var t = _mapper.Map<TeamP, Team>(team);
                return await _DaoTeam.SaveTeam(t);
            }
            catch (Exception e) {
                return e.ToString();
            }
        }

        public async Task<TeamP> GetTeamById(int id) {
            var t = await _DaoTeam.GetTeam(id);
            TeamP res = _mapper.Map<Team, TeamP>(t);
            return res;
        }

        public async Task<string> UpdateTeam(TeamP team)
        {
            Team t = _mapper.Map<TeamP, Team>(team);
            string r = await _DaoTeam.UpdateTeam(t, team.id);
            return r;

        }

        public async Task<string> AddPlayerToTeam(PlayerP player) {
            var p = _mapper.Map<PlayerP, Player>(player);
            string r = await _DaoPlayer.SavePlayer(p);
            return r;
        }
        public async Task<List<PlayerP>> GetTeamPlayers(int teamId) {
            var players = await _DaoPlayer.GetTeamPlayers(teamId);
            var r = _mapper.Map<List<Player>, List<PlayerP>>(players);
            return r;
        }

        public async Task<string> UpdatePlayer(PlayerP player) {
            Player p = _mapper.Map<PlayerP, Player>(player);
            var r = await _DaoPlayer.UpdatePlayer(p);
            return r;
        }

        public async Task<List<PoolStatistics>> GetPoolsAndStatisticOfCategory(int categoryId)
        {
            List<Pool> categoryPools = await _DaoPool.GetPoolsByCategory(categoryId);
            List<PoolStatistics> response = new List<PoolStatistics>();
            foreach (var p in categoryPools) {
                PoolStatistics ps = new PoolStatistics();
                List<PoolTeamStatisctics> poolsStatistics = new List<PoolTeamStatisctics>();
                poolsStatistics = await _DaoPool.GetPoolTeamsAndStatistics(p.Id);
                ps.poolId = p.Id;
                ps.poolName = p.Name;
                List<int> teamsWithStatistics = new List<int>();
                if (poolsStatistics != null && poolsStatistics.Count > 0)
                { 
                    //ps.teamsStatistics = poolsStatistics;
                    foreach (var x in poolsStatistics) {
                        teamsWithStatistics.Add(x.teamId);
                    }
                }
                ps.teamsStatistics = poolsStatistics;

                //Filling the list with all the pool teams statisctis (Those teams that doesn´t have statistics already)
                List<Team> poolTeams = await _DaoTeam.GetTeamsPool(p.Id);
                if (poolTeams != null && poolTeams.Count > 0 && poolTeams.Count != teamsWithStatistics.Count) {
                    foreach (var t in poolTeams) {
                        if (!teamsWithStatistics.Contains(t.TeamId)) {
                            var tmp = new PoolTeamStatisctics()
                            {
                                poolId = p.Id,
                                teamId = t.TeamId,
                                teamName = t.Name,
                                played = 0,
                                won = 0,
                                lost = 0,
                                scored = 0,
                                against = 0,
                                goalDifference = 0
                            };
                            poolsStatistics.Add(tmp);
                        }
                    }
                }
                response.Add(ps);
            }
            return response;
        }
    }
}
