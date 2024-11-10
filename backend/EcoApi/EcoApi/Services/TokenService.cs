using Azure;
using EcoApi.Data;
using EcoApi.Dto;
using EcoApi.Interfaces;
using EcoApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace EcoApi.Services {
    public class TokenService : ITokenInteface {

        private readonly AppDbContext _context;
        private readonly ISenhaInterface _senhaInterface;
        public TokenService(AppDbContext context, ISenhaInterface senhaInterface) {
            _context = context;
            _senhaInterface = senhaInterface;
        }

        public async Task<ServiceResponse<string>> Login(MensageiroLoginDto mensageiroLogin) {
            ServiceResponse<string> serviceResponse = new ServiceResponse<string>();
            MensageiroModel mensageiro = new MensageiroModel();

            try {

                var usuario = await _context.Mensageiro.FirstOrDefaultAsync(userBanco => userBanco.Nome == mensageiroLogin.Nome);

                if (usuario == null) {
                    serviceResponse.Mensagem = "Credenciais inválidas!";
                    return serviceResponse;
                }
                
                var passwordHasher = new PasswordHasher<MensageiroModel>();
                var status = passwordHasher.VerifyHashedPassword(mensageiro, usuario.Senha, mensageiroLogin.Senha);

                switch (status)
                {
                    case PasswordVerificationResult.Failed:
                        serviceResponse.Mensagem = "Credenciais inválidas!";
                        serviceResponse.Sucesso = true;
                        break;

                    case PasswordVerificationResult.Success:
                        var token = _senhaInterface.CriarToken(usuario);
                        serviceResponse.Dados = token;
                        serviceResponse.Mensagem = "Usuário logado com sucesso!";
                        serviceResponse.Sucesso = true;
                        break;

                    default:
                        throw new InvalidOperationException();
                }


            } catch (Exception ex) {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = ex.Message;
            }


            return serviceResponse;
        }
    }
}
