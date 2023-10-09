using BussinessObject.DataAccess;
using DataAccess;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Repository
{
    public class LoginDAO : ILoginRepository
    {
        private readonly IConfiguration _iconfiguration;

        public LoginDAO(IConfiguration iconfiguration)
        {

            _iconfiguration = iconfiguration;
        }

        public Tokens Authenticate(Login users)
        {
            var context = new FUFlowerBouquetManagementContext();
            var role = "";
            var admin = context.getDefaultAccounts();
            var user = context.Customers.FirstOrDefault(x => x.Email == users.Email && x.Password == users.Password);
            if (user == null)
            {
                return null;
            }
            if (user != null)
            {
               
                role = "Customer";
            }
            else if (users.Email == admin.Email)
            {
                role = "Admin";
            }else if(users.Password != admin.Password && user == null)
            {
                string errorMessage = "Login failed";
                return new LoginResult { ErrorMessage = errorMessage };
            }
            // Generate JSON Web Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_iconfiguration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Email, users.Email),
                 new Claim(ClaimTypes.Role, role)
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Tokens { Token = tokenHandler.WriteToken(token) };
        }


    }
}
