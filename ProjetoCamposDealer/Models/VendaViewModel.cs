using ProjetoDealer.Domain;

namespace ProjetoCamposDealer.Models
{
    public class VendaViewModel : Venda
    {
        public IEnumerable<Cliente> Clientes { get; set; }
        public IEnumerable<Produto> Produtos { get; set; }
    }
}
