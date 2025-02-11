using System.ComponentModel.DataAnnotations;

namespace ProjetoDealer.Domain
{
    public class Venda
    {
        [Display(Name = "C�digo")]
        public int idVenda { get; set; }

        [Display(Name = "C�digo cliente")]
        [Required(ErrorMessage = "{0} obrigat�rio")]
        public int idCliente { get; set; }
        public Cliente Clientes { get; set; }

        [Display(Name = "C�digo produto")]
        [Required(ErrorMessage = "{0} obrigat�rio")]
        public int idProduto { get; set; }
        public Produto Produtos { get; set; }

        [Display(Name = "Quantidade venda")]
        [Required(ErrorMessage = "{0} obrigat�ria")]
        [Range(1, 999, ErrorMessage = "{0} deve ser no m�nimo {1} e no m�ximo {2}")]
        public int qtdVenda { get; set; }
        public float vlrUnitarioVenda { get; set; }
        public DateTime dthVenda { get; set; } = DateTime.Now;
        public float vlrTotalVenda { get; set; }
    }
}