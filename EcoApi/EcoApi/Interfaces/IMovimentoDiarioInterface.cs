using EcoApi.Models;

namespace EcoApi.Interfaces {
    public interface IMovimentoDiarioInterface {

        Task<ServiceResponse<List<MovimentoDiarioModel>>> GetMovimentoDiario();
        Task<ServiceResponse<MovimentoDiarioModel>> GetMovimentoDiarioById(int id);
        Task<ServiceResponse<List<MovimentoDiarioModel>>> CreateMovimentoDiario(MovimentoDiarioModel movimentoDiario);
    }
}
