using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Auction.DAL.Models;
using Auction.WebApi.Auth;
using Auction.WebApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Auction.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;

        public UsersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserViewModel userViewModel)
        {
            var result = await _userManager.CreateAsync
            (
                new ApplicationUser()
                {
                    UserName = userViewModel.Name,
                    Email = userViewModel.Email
                },
                userViewModel.Password
            );
            
            if (!result.Succeeded)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPost("token")]
        public async Task<IActionResult> GetToken([FromBody] LoginViewModel login)
        {
            var user = await _userManager.FindByEmailAsync(login.Email);
            if (user == null || !(await _userManager.CheckPasswordAsync(user, login.Password)))
            {
                return Unauthorized();
            }

            var claims = 
                new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
                };

            var signingKey = JwtAuthOptions.GetSymmetricSecurityKey();

            var token = new JwtSecurityToken
                (
                expires: DateTime.Now.AddMinutes(JwtAuthOptions.LIFETIME_MINUTES),
                claims: claims,
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
            );

            return Ok
            (
                new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                }
            );
        }
    }
}