using EcoApi.Data;
using EcoApi.Interfaces;
using EcoApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EcoApi.Services {
    public class MensageiroService : IMensageiroInterface {

        private readonly AppDbContext _context;

        public MensageiroService(AppDbContext context) {
            _context = context;
        }

        public async Task<ServiceResponse<List<MensageiroModel>>> GetMensageiro() {

            ServiceResponse<List<MensageiroModel>> serviceResponse = new ServiceResponse<List<MensageiroModel>>();

            try {
                var mensageiros = await _context.Mensageiro.ToListAsync();
                serviceResponse.Dados = mensageiros;

                if (mensageiros.Count != 0) {
                    serviceResponse.Mensagem = "Todos os mensageiros foram encontrados.";
                    serviceResponse.Sucesso = true;
                } else {
                    serviceResponse.Mensagem = "Nenhum mensageiro cadastrado";
                    serviceResponse.Sucesso = true;
                }

            } catch(Exception ex) {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<MensageiroModel>> GetMensageiroById(int id) {

            ServiceResponse<MensageiroModel> serviceResponse = new ServiceResponse<MensageiroModel>();

            try {
                var mensageiro = await _context.Mensageiro.FirstOrDefaultAsync(e => e.Id == id);

                if(mensageiro == null) {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Nenhum mensageiro encontrado";
                    serviceResponse.Sucesso = true;
                } else {
                    serviceResponse.Dados = mensageiro;
                    serviceResponse.Mensagem = "Mensageiro encontrado.";
                    serviceResponse.Sucesso = true;
                }


            } catch(Exception ex) {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }
        public async Task<ServiceResponse<List<MensageiroModel>>> CreateMensageiro(MensageiroModel mensageiroObjeto) {

            ServiceResponse<List<MensageiroModel>> serviceResponse = new ServiceResponse<List<MensageiroModel>>();
            var passwordHash = new PasswordHasher<MensageiroModel>();

            try {

                var mensageiro = new MensageiroModel() {
                    Nome = mensageiroObjeto.Nome,
                    Senha = passwordHash.HashPassword(mensageiroObjeto, mensageiroObjeto.Senha)
                };
                _context.Add(mensageiro);
                await _context.SaveChangesAsync(); ;

                serviceResponse.Dados = await _context.Mensageiro.ToListAsync();
                serviceResponse.Mensagem = "Novo mensageiro adicionado com sucesso";
                serviceResponse.Sucesso = true;


            } catch (Exception ex) {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }
    }
}
