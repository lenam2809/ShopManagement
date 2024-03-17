using Application.Contracts;
using Application.DTOs.Auth;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repo
{
    public class UserRepo : IUser
    {
        private readonly AppDbContext context;
        private readonly IConfiguration configuration;

        public UserRepo(AppDbContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }
        public async Task<LoginResponse> LoginAsync(LoginDTO login)
        {
            var getUser = await FindUserByEmail(login.Email);
            if (getUser == null) return new LoginResponse(false, "User not found!");

            bool checkPassword = BCrypt.Net.BCrypt.Verify(login.Password, getUser.Password);
            if (checkPassword)
            {
                return new LoginResponse(true, "Login successfully!", GenerateJWTToken(getUser));
            }
            else
            {
                return new LoginResponse(false, "Login fail.");
            }
        }

        private string GenerateJWTToken(ApplicationUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Name!),
                new Claim(ClaimTypes.NameIdentifier, user.Email!)
            };



            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: userClaims,
                signingCredentials: credentials,
                expires: DateTime.Now.AddDays(1)
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<ApplicationUser> FindUserByEmail(string email) => await context.Users.FirstOrDefaultAsync(x => x.Email == email);
        public async Task<RegistrationResponse> RegisterAsync(RegisterDTO register)
        {
            var getUser = await FindUserByEmail(register.Email);
            if(getUser != null) { return new RegistrationResponse(false, "User already exist!"); }
            context.Users.Add(new ApplicationUser()
            {
                Name = register.Name,
                Email = register.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(register.Password)
            });
            await context.SaveChangesAsync();
            return new RegistrationResponse(true, "Register successFully!");
        }
    }
}
