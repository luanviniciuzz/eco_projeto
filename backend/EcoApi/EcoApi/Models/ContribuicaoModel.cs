using EcoApi.Enums;

namespace EcoApi.Models {
    public class ContribuicaoModel {
        public int Id { get; set; }
        public string Recibo {  get; set; }
        public decimal Valor { get; set; }
        public DateTime? DataPrevista { get; set; }
        public MensageiroModel Mensageiro { get; set; }
        public PagamentoEnum IdTipoPagamento { get; set; }
        public string Status { get; set; }
        public ContribuinteModel Contribuinte { get; set; }
    }
}
