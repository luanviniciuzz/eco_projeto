using EcoApi.Enums;

namespace EcoApi.Models {
    public class MovimentoDiarioModel {
        public int Id { get; set; }
        public DateTime DataMovimento { get; set; }
        public string Recibo { get; set; }
        public int MensageiroId { get; set; }
        public PagamentoEnum IdTipoPagamento { get; set; }
        public decimal Valor { get; set; }
        public DateTime? DataPrevista { get; set; }
        public string Status { get; set; }
        public DateTime DataRecebimento { get; set; }

    }
}
