using ProjetoDealer.Domain;
using System.ComponentModel.DataAnnotations;

namespace ProjetoCamposDealer.Models
{
    public class VendaViewModel
    {
        public int idVenda { get; set; }
        public int idCliente { get; set; }
        public IEnumerable<Cliente> Clientes { get; set; }
        public int idProduto { get; set; }
        public IEnumerable<Produto> Produtos { get; set; }
        public int qtdVenda { get; set; }
        public float vlrUnitarioVenda { get; set; }
        public float vlrTotalVenda { get; set; }
    }
}
