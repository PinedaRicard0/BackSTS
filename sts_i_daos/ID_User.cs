using sts_models.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace sts_i_daos
{
    public interface ID_User
    {
        Task<string> SaveUser(User user);
        Task<User> GetUser(string userMail);
        Task<bool> UserExist(string userMail);
    }
}
