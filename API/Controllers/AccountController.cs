
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace API.Controllers
{
    public class AccountController:AuthApiController
    {

                private readonly DataContext _context;
        public AccountController(DataContext ctxt)
        {
                    _context = ctxt;
        }

        [HttpPost("register")]
        public async Task<ActionResult<string>> Register(RegisterDTO registerDto)
        {
            string email = registerDto.UserName;
            string pwd = registerDto.Password;

            if (await CheckUser(email))
            {
                return BadRequest("Username Already Taken");
            }

            using var hmac = new HMACSHA512();
            AppUser user = new AppUser
            {
                UserName = email.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(pwd)),
                PasswordSalt = hmac.Key
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("YourJwtSecretKeyHere"); // Replace with your own secret key
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(tokenString);
        }

 


        private async Task<bool> CheckUser(string username)
        {
            return await _context.Users.AnyAsync(user => user.UserName == username.ToLower());
        }


        [HttpPost("login")]
public async Task<ActionResult<string>> Login(LoginDTO loginDTO)
{
    var user = await _context.Users.SingleOrDefaultAsync(x => x.UserName == loginDTO.UserName);
    if (user == null)
    {
        return Unauthorized("Invalid username or password.");
    }

    using var hmac = new HMACSHA512(user.PasswordSalt);
    var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));
    for (int i = 0; i < computedHash.Length; i++)
    {
        if (computedHash[i] != user.PasswordHash[i])
        {
            return Unauthorized("Invalid username or password.");
        }
    }

    var tokenHandler = new JwtSecurityTokenHandler();
    var key = Encoding.ASCII.GetBytes("YourJwtSecretKeyHere"); // Replace with your own secret key
    var tokenDescriptor = new SecurityTokenDescriptor
    {
        Subject = new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.UserName)
        }),
        Expires = DateTime.UtcNow.AddDays(7),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
    };
    var token = tokenHandler.CreateToken(tokenDescriptor);
    var tokenString = tokenHandler.WriteToken(token);

    return Ok(tokenString);
}

        // [HttpPost("login")]
        // public async Task<ActionResult<AppUser>> Login(LoginDTO loginDTO){

        //     var user = await _context.Users.SingleOrDefaultAsync(x=> x.UserName == loginDTO.UserName);
        //     if (user == null)
        //     return Unauthorized();
        //     using var hmac = new HMACSHA512(user.PasswordSalt);

        //     var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));

        //     for(int i=0; i < computedHash.Length; i++)
        //     {
        //         if(computedHash[i] != user.PasswordHash[i])
        //         return Unauthorized("inavlid password");
        //     }
        //     return user;

        // }

    }
}