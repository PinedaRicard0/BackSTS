﻿using sts_models.DTO;
using sts_models.POCOS;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sts_i_services
{
    public interface IAuthService
    {
        Task<string> Register(UserP userP);
        Task<UserP> GetAndVerifyUser(string mail, string password);
        Task<bool> IsUserRegistered(string mail);
        string Login(UserP user);
        Task<List<UserMG>> GetAllMongoUsers();
    }
}
