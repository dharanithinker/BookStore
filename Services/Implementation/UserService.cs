using BookStore.Entities;
using BookStore.Helpers;
using BookStore.Services.Contracts;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Implementation
{
    public class UserService : IUserService
    {
        private List<User> _users = DBHelper.GetAllUsers();

        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public string Login(string username, string password)
        {
            var user = _users.SingleOrDefault(x => x.Username == username && x.Password == password);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            // remove password before returning
            // Have to save the token into db when login
            return user.Token;
        }

        public bool Logout(int userDetailsID)
        {
            bool isLoggedOut = false;
            // Have to delete/mark as invalid when user try to log out in DB
            var _loggedUserDetails = _users.Where(x => x.Id == userDetailsID).FirstOrDefault();
            _loggedUserDetails.Token = String.Empty;
            isLoggedOut = true;
            return isLoggedOut;
        }
    }
}
