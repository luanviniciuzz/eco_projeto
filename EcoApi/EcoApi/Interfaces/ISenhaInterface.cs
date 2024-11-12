using EcoApi.Models;

namespace EcoApi.Interfaces {
    public interface ISenhaInterface {

        string CriarToken(MensageiroModel mensageiro);
    }
}
