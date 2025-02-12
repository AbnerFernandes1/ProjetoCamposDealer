using System.ComponentModel.DataAnnotations;

namespace ProjetoDealer.Domain
{
    public class Produto
    {
        [Display(Name = "Código")]
        public int idProduto { get; set; }

        [Display(Name = "Descrição produto")]
        [Required(ErrorMessage = "{0} obrigatória")]
        [StringLength(40, MinimumLength = 5, ErrorMessage = "{0} deve conter entre {2} a {1} caracteres")]
        public string? dscProduto { get; set; }

        [Display(Name = "Preço unitário")]
        [Required(ErrorMessage = "{0} obrigatório")]
        [Range(0.01, 100000.00, ErrorMessage = "O preço deve estar entre 0,01 e 10.000,00.")]
        public float? vlrUnitario { get; set; }

        public IEnumerable<Venda> Vendas { get; set; }
    }
}