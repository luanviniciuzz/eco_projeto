using EcoApi.Models;

namespace EcoApi.Interfaces {
    public interface IMensageiroInterface {

        Task<ServiceResponse<List<MensageiroModel>>> GetMensageiro();

        Task<ServiceResponse<MensageiroModel>> GetMensageiroById(int id);
        Task<ServiceResponse<List<MensageiroModel>>> CreateMensageiro(MensageiroModel mensageiro);
    }
}
