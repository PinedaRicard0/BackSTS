using System;
using System.Collections.Generic;
using System.Text;

namespace sts_models.POCOS
{
    public class PoolTeamStatisctics
    {
        public int teamId { get; set; }
        public string teamName { get; set; }
        public int teamStatiscticsId { get; set; }
        public int played { get; set; }
        public int won { get; set; }
        public int lost { get; set; }
        public int scored { get; set; }
        public int against { get; set; }
        public int goalDifference { get; set; }
    }
}
