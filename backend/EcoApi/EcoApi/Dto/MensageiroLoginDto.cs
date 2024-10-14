using System.ComponentModel.DataAnnotations;

namespace EcoApi.Dto {
    public class MensageiroLoginDto {


        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo senha é obrigatória")]
        public string Senha { get; set; }
    }
}
