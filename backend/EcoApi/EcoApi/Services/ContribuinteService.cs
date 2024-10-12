using EcoApi.Data;
using EcoApi.Interfaces;
using EcoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EcoApi.Services {
    public class ContribuinteService : IContribuinteInterface {

        private readonly AppDbContext _context;

        public ContribuinteService(AppDbContext context) {
            _context = context;
        }

        public async Task<ServiceResponse<List<ContribuinteModel>>> GetContribuinte() {

            ServiceResponse<List<ContribuinteModel>> serviceResponse = new ServiceResponse<List<ContribuinteModel>>();

            try {
                var contribuinte = await _context.Contribuinte.ToListAsync();
                serviceResponse.Dados = contribuinte;

                if(contribuinte.Count != 0) {
                    serviceResponse.Mensagem = "Todos os contribuintes foram encontrados.";
                    serviceResponse.Sucesso = true;
                } else {
                    serviceResponse.Mensagem = "Nenhum contribuinte cadastrado";
                    serviceResponse.Sucesso = true;
                }

            } catch (Exception ex) {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;

        }

        public async Task<ServiceResponse<ContribuinteModel>> GetContribuinteById(int id) {
            ServiceResponse<ContribuinteModel> serviceResponse = new ServiceResponse<ContribuinteModel>();

            try {
                var contribuinte = await _context.Contribuinte.FirstOrDefaultAsync(e => e.Id == id);

                if (contribuinte == null) {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Nenhum contribuinte encontrado";
                    serviceResponse.Sucesso = true;
                } else {
                    serviceResponse.Dados = contribuinte;
                    serviceResponse.Mensagem = "Contribuinte encontrado.";
                    serviceResponse.Sucesso = true;
                }



            } catch (Exception ex) {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ContribuinteModel>>> CreateContribuinte(ContribuinteModel contribuinteObjeto) {

            ServiceResponse<List<ContribuinteModel>> serviceResponse = new ServiceResponse<List<ContribuinteModel>>();

            try {

                var contribuinte = new ContribuinteModel() {
                    Nome = contribuinteObjeto.Nome,
                    Endereco = contribuinteObjeto.Endereco,
                    Telefone = contribuinteObjeto.Telefone
                };
                _context.Add(contribuinte);
                await _context.SaveChangesAsync(); ;

                serviceResponse.Dados = await _context.Contribuinte.ToListAsync();
                serviceResponse.Mensagem = "Novo contribuinte adicionado com sucesso";
                serviceResponse.Sucesso = true;


            } catch (Exception ex) {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        
    }
}
