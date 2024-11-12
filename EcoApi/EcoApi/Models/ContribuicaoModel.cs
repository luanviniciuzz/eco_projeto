using EcoApi.Enums;

namespace EcoApi.Models {
    public class ContribuicaoModel {
        public int Id { get; set; }
        public string Recibo {  get; set; }
        public decimal Valor { get; set; }
        public DateTime? DataPrevista { get; set; }
        public int MensageiroId { get; set; }
        public PagamentoEnum IdTipoPagamento { get; set; }
        public string Status { get; set; }
        public int ContribuinteId { get; set; }
    }
}
