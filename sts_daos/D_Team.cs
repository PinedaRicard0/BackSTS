using sts_i_daos;
using sts_models.DTO;
using System.Collections.Generic;
using System.Linq;

namespace sts_daos
{
    public class D_Team : ID_Team
    {
        private readonly DataContext _context;

        public D_Team(DataContext context)
        {
            _context = context;
        }
        public List<Team> GetPoolsTeams(List<Pool> pools)
        {
            List<Team> responseList = new List<Team>();
            foreach (var item in pools)
            {
                responseList.AddRange( _context.Teams.Where(t => t.PoolId == item.Id).ToList());
            }
            return responseList;
        }
    }
}
