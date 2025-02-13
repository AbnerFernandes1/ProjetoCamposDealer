using ProjetoDealer.Domain;

namespace ProjetoCamposDealer.ViewModel
{
    public class VendaViewModel : Venda
    {
        public IEnumerable<Cliente> ClientesLista { get; set; }
        public IEnumerable<Produto> ProdutosLista { get; set; }
    }
}
