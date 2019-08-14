using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace egrihakarya
{
    public interface IUserService
    {
        Users Authenticate(string username, string password);
        IEnumerable<Users> GetAll();
        Users GetById(int id);
    }
    public class UserService : IUserService
    {
        private readonly ClassroomContext _context;
        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings, ClassroomContext context)
        {
            _appSettings = appSettings.Value;
            _context = context;
        }
        public Users Authenticate(string email, string password)
        {
            Users user = _context.Users.FromSql($"EXECUTE dbo.GetUserByEmailAndPassword @Email = {email}, @Password = {password}").FirstOrDefault();
            if (user == null)
                return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                            new Claim(ClaimTypes.Name, user.Id.ToString()),
                            new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            user.Password = null;

            return user;
        }

        public IEnumerable<Users> GetAll()
        {
            
            return _context.Users.ToList().Select(x =>
            {
                x.Password = null;
                return x;
            });
        }

        public Users GetById(int id)
        {
            var user = _context.Users.Find(id);

            if (user != null)
                user.Password = null;
            return user;
        }
    }
}
