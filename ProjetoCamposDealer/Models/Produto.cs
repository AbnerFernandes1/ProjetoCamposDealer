using System.ComponentModel.DataAnnotations;

namespace ProjetoDealer.Domain
{
    public class Produto
    {
        [Display(Name = "C�digo")]
        public int idProduto { get; set; }

        [Display(Name = "Descri��o")]
        [Required(ErrorMessage = "{0} obrigat�ria")]
        [StringLength(40, MinimumLength = 5, ErrorMessage = "{0} deve conter entre {2} a {1} caracteres")]
        public string? dscProduto { get; set; }

        [Display(Name = "Pre�o unit�rio")]
        [Required(ErrorMessage = "{0} obrigat�rio")]
        [Range(0.01, 100000.00, ErrorMessage = "O pre�o deve estar entre 0,01 e 10.000,00.")]
        public float? vlrUnitario { get; set; }
    }
}