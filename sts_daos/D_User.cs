using Microsoft.EntityFrameworkCore;
using sts_i_daos;
using sts_models.DTO;
using System;
using System.Threading.Tasks;

namespace sts_daos
{
    public class D_User : ID_User
    {
        private readonly DataContext _context;
        public D_User(DataContext context)
        {
            _context = context;
        }
        public async Task<User> GetUser(string userMail)
        {
            User user = await _context.Users.FirstOrDefaultAsync(u => u.Mail == userMail);
            return user;

        }

        public async Task<string> SaveUser(User user)
        {
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
            return "Created";
        }

        public async Task<bool> UserExist(string userMail)
        {
            return await _context.Users.AnyAsync(u => u.Mail == userMail);
        }
    }
}
