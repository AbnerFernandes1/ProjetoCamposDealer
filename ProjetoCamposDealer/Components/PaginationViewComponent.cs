using Microsoft.AspNetCore.Mvc;
using ProjetoDealer.Application.Constantes;

namespace ProjetoCamposDealer.Components
{
    public class PaginationViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int quantityItens)
        {
            return View(QuantityPage(quantityItens));
        }

        private int QuantityPage(int quantityItens)
        {
            if (quantityItens <= 0) return 1;

            int pages = quantityItens / Paginacao.LIMITE_PESQUISA_POR_PAGINA;

            if (quantityItens % Paginacao.LIMITE_PESQUISA_POR_PAGINA != 0)
            {
                pages++;
            }
            
            return Math.Max(pages, 0);
        }
    }
}