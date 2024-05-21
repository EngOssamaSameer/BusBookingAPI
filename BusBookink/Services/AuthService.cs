using BusBookink.Bl;
using BusBookink.Contexts;
using BusBookink.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BusBookink.Services
{
    public class AuthService : IAuthService
    {
        // Propertys
        public UserManager<IdentityUser> _userManager { get; }
        public AppDbContext _appDbContext { get; }
        public IConfiguration _configuration { get; }

        //Constractor to inialize USerManager and configration
        public AuthService(UserManager<IdentityUser> userManager, AppDbContext appDbContext, IConfiguration configuration)
        {
            this._userManager = userManager;
            this._appDbContext = appDbContext;
            this._configuration = configuration;
        }

        // funct take login model and generate token
        public string GenerateToken(LoginModel loginModel)
        {
            var user = _userManager.FindByNameAsync(loginModel.Emial);
            var role = GetRoleByUserEmail(loginModel.Emial);

            //Generate Claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, loginModel.Emial),
                new Claim(ClaimTypes.Role , role)
            };

            //Securty Key
            var SecurtyKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Key").Value));

            //SigningCard
            var SingingCred = new SigningCredentials(SecurtyKey, SecurityAlgorithms.HmacSha256);

            // generate Token
            var SecurityToken = new JwtSecurityToken(
                     claims: claims,
                     expires: DateTime.Now.AddMinutes(20),
                     signingCredentials: SingingCred,
                     issuer: _configuration.GetSection("Jwt:Issuer").Value,
                     audience: _configuration.GetSection("Jwt:Audience").Value
                );

            string TokenString = new JwtSecurityTokenHandler().WriteToken(SecurityToken);
            return TokenString;
        }

        // login  function return true if vlaid or flase if invalid
        public async Task<bool> Login(LoginModel loginModel)
        {
            var result = await _userManager.FindByEmailAsync(loginModel.Emial);
            if (result == null)
            {
                return false;
            }
            return await _userManager.CheckPasswordAsync(result, loginModel.Password);
        }
        // register  function return true if vlaid or flase if invalid
        public async Task<bool> Register(RegisterModel registerModel)
        {
            var user = new IdentityUser
            {
                UserName = registerModel.UserName,
                Email = registerModel.Email,
            };
            var result = await _userManager.CreateAsync(user, registerModel.Password);
            if (result.Succeeded == true)
            {
                AddUserRole(registerModel.Email);
                Traveler traveler = new Traveler();
                traveler.UserName = registerModel.UserName;
                traveler.Email = registerModel.Email;
                NewTraveler(traveler);
                return true;
            }
            return false;
        }



        /*
         Private Function 
         */

        //add new User Role 
        private void AddUserRole(string Email)
        {
            UserRole userRole = new UserRole();
            userRole.UserEmail = Email;
            userRole.Role = "User";

            _appDbContext.TbUserRoles.Add(userRole);
            _appDbContext.SaveChanges();
        }


        // function to get role by user email
        private string GetRoleByUserEmail(string Email)
        {
            var Role = _appDbContext.TbUserRoles
                        .Where(ur => ur.UserEmail == Email)
                        .Select(ur => ur.Role)
                        .FirstOrDefault();

            if (Role == null)
            {
                return "NaN";
            }
            return Role;
        }

        // function to create Traveler for ecach user when registeration process
        private void NewTraveler(Traveler traveler)
        {
            _appDbContext.TbTraveler.Add(traveler);
            _appDbContext.SaveChanges ();
        }
    }
}
