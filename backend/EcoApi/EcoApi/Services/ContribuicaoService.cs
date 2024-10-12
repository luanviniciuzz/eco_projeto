using EcoApi.Data;
using EcoApi.Interfaces;
using EcoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EcoApi.Services {
    public class ContribuicaoService : IContribuicaoInterface {

        private readonly AppDbContext _context;

        public ContribuicaoService(AppDbContext context) {
            _context = context;
        }
        public async Task<ServiceResponse<List<ContribuicaoModel>>> GetContribuicao() {
            ServiceResponse<List<ContribuicaoModel>> serviceResponse = new ServiceResponse<List<ContribuicaoModel>>();

            try {
                var contribuicao = await _context.Contribuicao.ToListAsync();
                serviceResponse.Dados = contribuicao;

                if (contribuicao.Count != 0) {
                    serviceResponse.Mensagem = "Todas as contribuições foram encontradas.";
                    serviceResponse.Sucesso = true;
                } else {
                    serviceResponse.Mensagem = "Nenhuma contribuição cadastrada";
                    serviceResponse.Sucesso = true;
                }

            } catch (Exception ex) {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<ContribuicaoModel>> GetContribuicaoById(int id) {
            ServiceResponse<ContribuicaoModel> serviceResponse = new ServiceResponse<ContribuicaoModel>();

            try {
                var contribuicao = await _context.Contribuicao.FirstOrDefaultAsync(e => e.Id == id);

                if (contribuicao == null) {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Nenhuma contribuiçao cadastrada.";
                    serviceResponse.Sucesso = true;
                } else {
                    serviceResponse.Dados = contribuicao;
                    serviceResponse.Mensagem = "Contribuição encontrada.";
                    serviceResponse.Sucesso = true;
                }



            } catch (Exception ex) {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ContribuicaoModel>>> CreateContribuicao(ContribuicaoModel contribuicaoObjeto) {

            ServiceResponse<List<ContribuicaoModel>> serviceResponse = new ServiceResponse<List<ContribuicaoModel>>();

            try {

                var contribuicao = new ContribuicaoModel() {
                    Recibo = contribuicaoObjeto.Recibo,
                    Valor = contribuicaoObjeto.Valor,
                    Status = contribuicaoObjeto.Status,
                    DataPrevista = contribuicaoObjeto.DataPrevista,
                    MensageiroId = contribuicaoObjeto.MensageiroId,
                    IdTipoPagamento = contribuicaoObjeto.IdTipoPagamento,
                    ContribuinteId = contribuicaoObjeto.ContribuinteId, 
                };

                _context.Add(contribuicao);
                await _context.SaveChangesAsync(); ;

                serviceResponse.Dados = await _context.Contribuicao.ToListAsync();
                serviceResponse.Mensagem = "Nova contribuicao adicionada com sucesso";
                serviceResponse.Sucesso = true;


            } catch (Exception ex) {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }
    }
    
}
