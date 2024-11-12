using EcoApi.Models;

namespace EcoApi.Interfaces {
    public interface IContribuicaoInterface {
        Task<ServiceResponse<List<ContribuicaoModel>>> GetContribuicao();
        Task<ServiceResponse<ContribuicaoModel>> GetContribuicaoById(int id);
        Task<ServiceResponse<List<ContribuicaoModel>>> CreateContribuicao(ContribuicaoModel contribuicao);
    }
}
