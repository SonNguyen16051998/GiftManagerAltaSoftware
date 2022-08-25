using GiftCodeManager.Services;
using GiftCodeManager.Models.ViewModels;
using GiftCodeManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GiftCodeManager.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TokenController : Controller
    {
        public IConfiguration _config;
        public ICustomer _Customer;
        public IManager _manager;
        public TokenController(IConfiguration config, ICustomer customer,IManager manager)
        {
            _manager = manager;
            _config = config;
            _Customer = customer;
        }
        [HttpPost]
        [ActionName("customer")]
        public async Task<IActionResult> CusLogin([FromBody] ViewLogin login)
        {
            if (ModelState.IsValid)
            {
                Customer custom = new Customer();
                custom= await _Customer.Login(login);
                if (custom != null)
                {
                    var Claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub,_config["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),
                        new Claim("Id",custom.Customer_Id.ToString()),
                        new Claim("Name",custom.Customer_Name),
                        new Claim("Email",custom.email),
                        new Claim("PhoneNo",custom.PhoneNo),
                    };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                        _config["Jwt:Audience"], Claims, expires: DateTime.UtcNow.AddDays(1),
                        signingCredentials: signIn);
                    ViewToken viewToken = new ViewToken() { Token = new JwtSecurityTokenHandler().WriteToken(token), cus = custom };
                    return Ok(viewToken);
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            return BadRequest();
        }// đăng nhập cho khách hàng

        [HttpPost]
        [ActionName("user")]
        public async Task<IActionResult> UserLogin([FromBody] ViewLogin login)
        {
            if (ModelState.IsValid)
            {
                User user = new User();
                user = await _manager.Login(login);
                if (user != null)
                {
                    var Claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub,_config["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),
                        new Claim("Id",user.User_Id.ToString()),
                        new Claim("Name",user.User_Name),
                        new Claim("Email",user.Email),
                        new Claim("PhoneNo",user.PhoneNo),
                    };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                        _config["Jwt:Audience"], Claims, expires: DateTime.UtcNow.AddDays(1),
                        signingCredentials: signIn);
                    ViewTokenUser viewToken = new ViewTokenUser() { Token = new JwtSecurityTokenHandler().WriteToken(token), user = user };
                    return Ok(viewToken);
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            return BadRequest();
        }// đăng nhập cho quản lí
    }
}
