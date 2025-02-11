using System.ComponentModel.DataAnnotations;

namespace ProjetoDealer.Domain
{
    public class Venda
    {
        [Display(Name = "Código")]
        public int idVenda { get; set; }

        [Display(Name = "Código cliente")]
        [Required(ErrorMessage = "{0} obrigatório")]
        public int idCliente { get; set; }
        public Cliente Clientes { get; set; }

        [Display(Name = "Código produto")]
        [Required(ErrorMessage = "{0} obrigatório")]
        public int idProduto { get; set; }
        public Produto Produtos { get; set; }

        [Display(Name = "Quantidade venda")]
        [Required(ErrorMessage = "{0} obrigatória")]
        [Range(1, 999, ErrorMessage = "{0} deve ser no mínimo {1} e no máximo {2}")]
        public int qtdVenda { get; set; }
        public float vlrUnitarioVenda { get; set; }
        public DateTime dthVenda { get; set; } = DateTime.Now;
        public float vlrTotalVenda { get; set; }
    }
}