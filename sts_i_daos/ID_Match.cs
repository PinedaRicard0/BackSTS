using sts_models.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace sts_i_daos
{
    public interface ID_Match
    {
        Task CreateMatch(Match match);
        Task<List<Match>> GetPoolMatches(int poolId);
    }
}
