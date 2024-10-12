using System.ComponentModel.DataAnnotations;

namespace EcoApi.Models {
    public class MensageiroModel {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Senha { get; set; }
    }
}