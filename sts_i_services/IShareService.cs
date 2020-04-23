using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace sts_i_services
{
    public interface IShareService
    {
        Task<string> GetBreadCrumbData(string id, string view);
    }
}
