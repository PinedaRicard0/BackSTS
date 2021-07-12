using Microsoft.Extensions.Options;
using MongoDB.Driver;
using sts_i_daos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace sts_daos
{
    public class UserMG : IUserMG
    {
        private readonly MongoDataContext _context = null;

        public UserMG(IOptions<MongoGeneralContext> mongoGeneralContext)
        {
            _context = new MongoDataContext(mongoGeneralContext);
        }


        public async Task<List<sts_models.DTO.UserMG>> GetAllMongoUser()
        {
            try {
                return await _context.Users
                    .Find(_ => true).ToListAsync();
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}
