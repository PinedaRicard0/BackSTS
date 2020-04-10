using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using sts_i_daos;
using sts_i_services;
using sts_models.DTO;
using sts_models.POCOS;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace sts_services
{
    public class AuthService : IAuthService
    {
        private readonly ID_User _DaoUser;
        private readonly IConfiguration _config;

        public AuthService(ID_User DaoUser, IConfiguration config)
        {
            _DaoUser = DaoUser;
            _config = config;
        }
        public async Task<bool> IsUserRegistered(string mail)
        {
            return await _DaoUser.UserExist(mail);
        }

        public async Task<UserP> GetAndVerifyUser(string mail, string password)
        {
            User user = await _DaoUser.GetUser(mail);
            if (user == null) {
                return null;
            }
            if (!IsPasswordCorrect(password, user.PasswordHash, user.PasswordSalt)) {
                return null;
            }
            return new UserP { 
                Id = user.Id,
                Name = user.Name,
                Mail = user.Mail,
            };
            
        }

        public async Task<string> Register(UserP userP)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(userP.password, out passwordHash, out passwordSalt);
            User user = new User
            {
                Mail = userP.Mail,
                Name = userP.Name,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            await _DaoUser.SaveUser(user);
            return "Created";
        }

        public string Login(UserP user) {
            //Creating token - First creating claims
            var claims = new[] {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Mail)
            };

            //Getting the security key
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            //Generating the Signing credential for signing tokens
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                NotBefore = DateTime.Now,
                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt) {
            using (var hmac = new System.Security.Cryptography.HMACSHA512()) {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            };
        }

        private bool IsPasswordCorrect(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) { return false; }
                }
                return true;
            }
        }
    }
}
