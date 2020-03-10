using sts_models.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace sts_i_daos
{
    public interface ID_Player
    {
        Task<string> SavePlayer(Player player);
        Task<List<Player>> GetTeamPlayers(int teamId);
        Task<string> UpdatePlayer(Player player);



    }
}
