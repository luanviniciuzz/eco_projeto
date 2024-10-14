using EcoApi.Interfaces;
using EcoApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace EcoApi.Services {
    public class SenhaService : ISenhaInterface {

        private readonly IConfiguration _config;

        public SenhaService(IConfiguration config) {
            _config = config;
        }

        public string CriarToken(MensageiroModel mensageiro) {
            List<Claim> claims = new List<Claim>()
           {
                new Claim("Nome", mensageiro.Nome),
                new Claim("Senha", mensageiro.Senha),
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: cred
                );


            var jwt = new JwtSecurityTokenHandler().WriteToken(token);


            return jwt;
        }
    }
}
