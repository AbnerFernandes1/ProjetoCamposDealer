using System.ComponentModel.DataAnnotations;

namespace ProjetoDealer.Domain
{
    public class Cliente
    {
        [Display(Name = "C�digo")]
        public int idCliente { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "{0} obrigat�rio")]
        [StringLength(60, ErrorMessage = "{0} deve conter at� {1} caracteres")]
        public string? nmCliente { get; set; }

        [Required(ErrorMessage = "{0} obrigat�ria")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "{0} deve conter entre {2} a {1} caracteres")]
        public string? Cidade { get; set; }  
    }
}