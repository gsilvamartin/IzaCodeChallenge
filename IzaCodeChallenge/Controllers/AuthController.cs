using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using IzaCodeChallenge.Model;
using IzaCodeChallenge.Model.Auth;
using IzaCodeChallenge.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace IzaCodeChallenge.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IClienteService _clienteService;

        public AuthController(IClienteService clienteService)
        {
            this._clienteService = clienteService;
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            try
            {
                var userValid = _clienteService.IsUserValid(email, password, out string id);

                if (userValid)
                {
                    return Ok(new APIResponse
                    {
                        Data = GenerateToken(email, id),
                        Success = true,
                        Message = "Token gerado com sucesso"
                    });
                }
                else
                {
                    return BadRequest(new APIResponse
                    {
                        Success = false,
                        Message = "Usuário ou senha incorretos"
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new APIResponse
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }

        private string GenerateToken(string email, string userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("IZASECRETJWTTOKEN2022");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, email),
                    new Claim("Id", userId)
                }),
                Expires = DateTime.UtcNow.AddHours(4),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}

