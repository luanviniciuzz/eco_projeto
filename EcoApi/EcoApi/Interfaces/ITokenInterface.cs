using EcoApi.Dto;
using EcoApi.Models;

namespace EcoApi.Interfaces {
    public interface ITokenInteface {

        Task<ServiceResponse<string>> Login(MensageiroLoginDto mensageiroLoginDto);
    }
}
