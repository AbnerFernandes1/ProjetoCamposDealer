using System.ComponentModel.DataAnnotations;

namespace ProjetoDealer.Domain
{
    public class Venda
    {
        [Display(Name = "ID venda")]
        public int idVenda { get; set; }

        [Display(Name = "Código cliente")]
        [Required(ErrorMessage = "{0} obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Deve ser informado um cliente.")]
        public int idCliente { get; set; }
        public Cliente Clientes { get; set; }

        [Display(Name = "Código produto")]
        [Required(ErrorMessage = "{0} obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Deve ser informado um produto.")]
        public int idProduto { get; set; }
        public Produto Produtos { get; set; }

        [Display(Name = "Quantidade venda")]
        [Required(ErrorMessage = "{0} obrigatória")]
        [Range(1, 999, ErrorMessage = "{0} deve ser no mínimo {1} e no máximo {2}")]
        public int qtdVenda { get; set; }

        [Display(Name = "Preço unitário venda")]
        public float vlrUnitarioVenda { get; set; }

        [Display(Name = "Data pedido")]
        public DateTime dthVenda { get; set; } = DateTime.Now;

        [Display(Name = "Valor venda")]
        public float vlrTotalVenda { get; set; }
    }
}