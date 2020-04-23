using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using sts_i_daos;
using sts_i_services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace sts_services
{
    public class ShareService : IShareService
    {
        private readonly ID_Team _DaoTeam;

        public ShareService(ID_Team DaoTeam)
        {
            _DaoTeam = DaoTeam;
        }

        public async Task<string> GetBreadCrumbData(string id, string view)
        {
            string res = "";
            if (view.Equals("players")) {
                var r = await _DaoTeam.GetPlayersTeamBreadScrumb(Int32.Parse(id));
                res = JsonConvert.SerializeObject(r);
            }
            return res;
            
        }
    }
}
