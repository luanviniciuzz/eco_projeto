using EcoApi.Data;
using EcoApi.Enums;
using EcoApi.Interfaces;
using EcoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EcoApi.Services {
    public class MovimentoDiarioService : IMovimentoDiarioInterface {

        private readonly AppDbContext _context;

        public MovimentoDiarioService(AppDbContext context) {
            _context = context;
        }

        public async Task<ServiceResponse<List<MovimentoDiarioModel>>> GetMovimentoDiario() {

            ServiceResponse<List<MovimentoDiarioModel>> serviceResponse = new ServiceResponse<List<MovimentoDiarioModel>>();

            try {
                var movimentoDiario = await _context.MovimentoDiario.ToListAsync();
                serviceResponse.Dados = movimentoDiario;

                if (movimentoDiario.Count != 0) {
                    serviceResponse.Mensagem = "Todas as movimentação diárias foram encontradas.";
                    serviceResponse.Sucesso = true;
                } else {
                    serviceResponse.Mensagem = "Nenhuma movimentação diária cadastrada";
                    serviceResponse.Sucesso = true;
                }

            } catch (Exception ex) {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<MovimentoDiarioModel>> GetMovimentoDiarioById(int id) {
            ServiceResponse<MovimentoDiarioModel> serviceResponse = new ServiceResponse<MovimentoDiarioModel>();

            try {
                var movimentoDiario = await _context.MovimentoDiario.FirstOrDefaultAsync(e => e.Id == id);

                if (movimentoDiario == null) {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Nenhum Movimento Diario encontrado";
                    serviceResponse.Sucesso = true;
                } else {
                    serviceResponse.Dados = movimentoDiario;
                    serviceResponse.Mensagem = "Movimento Diario encontrado.";
                    serviceResponse.Sucesso = true;
                }

            } catch (Exception ex) {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }
        public async Task<ServiceResponse<List<MovimentoDiarioModel>>> CreateMovimentoDiario(MovimentoDiarioModel movimentoDiarioObjeto) {

            ServiceResponse<List<MovimentoDiarioModel>> serviceResponse = new ServiceResponse<List<MovimentoDiarioModel>>();

            try {

                var movimentoDiario = new MovimentoDiarioModel() {
                    DataMovimento = movimentoDiarioObjeto.DataMovimento,
                    Recibo = movimentoDiarioObjeto.Recibo,
                    MensageiroId = movimentoDiarioObjeto.MensageiroId,
                    IdTipoPagamento = movimentoDiarioObjeto.IdTipoPagamento,
                    Valor = movimentoDiarioObjeto.Valor,
                    DataPrevista = movimentoDiarioObjeto.DataPrevista,
                    Status = movimentoDiarioObjeto.Status,
                    DataRecebimento = movimentoDiarioObjeto.DataRecebimento
                };
  

                _context.Add(movimentoDiario);
                await _context.SaveChangesAsync(); ;

                serviceResponse.Dados = await _context.MovimentoDiario.ToListAsync();
                serviceResponse.Mensagem = "Nova movimentacao diaria adicionada com sucesso";
                serviceResponse.Sucesso = true;


            } catch (Exception ex) {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }
    }
}
