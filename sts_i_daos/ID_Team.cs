using sts_models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sts_i_daos
{
    public interface ID_Team
    {
        Task<List<Team>> GetPoolsTeams(List<Pool> pools);
        Task<string> SaveTeam(Team team);
        Task<Team> GetTeam(int id);
        Task<string> UpdateTeam(Team team, int id);
        Task<List<Team>> GetTeamsPool(int poolId);
    }
}
