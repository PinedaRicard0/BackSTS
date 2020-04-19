using System;
using System.Collections.Generic;
using System.Text;

namespace sts_models.POCOS
{
    public class PoolStatistics
    {
        public int poolId { get; set; }
        public string poolName { get; set; }
        public List<PoolTeamStatisctics> teamsStatistics { get; set; }
    }
}
