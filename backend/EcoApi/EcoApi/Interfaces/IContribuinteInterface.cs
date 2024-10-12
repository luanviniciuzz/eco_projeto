using EcoApi.Models;

namespace EcoApi.Interfaces {
    public interface IContribuinteInterface {

        Task<ServiceResponse<List<ContribuinteModel>>> GetContribuinte();
        Task<ServiceResponse<ContribuinteModel>> GetContribuinteById(int id);
        Task<ServiceResponse<List<ContribuinteModel>>> CreateContribuinte(ContribuinteModel contribuinte);
    }
}
