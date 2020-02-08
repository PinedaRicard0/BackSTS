using sts_models.DTO;
using System.Collections.Generic;

namespace sts_i_daos
{
    public interface ID_Team
    {
        List<Team> GetPoolsTeams(List<Pool> pools);
    }
}
