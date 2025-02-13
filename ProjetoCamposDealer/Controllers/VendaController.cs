using Microsoft.AspNetCore.Mvc;
using ProjetoCamposDealer.Services.Interfaces;
using ProjetoCamposDealer.ViewModel;

namespace ProjetoCamposDealer.Controllers
{
    [Route("vendas")]
    public class VendaController : Controller
    {
        private readonly IVendaService _service;

        public VendaController(IVendaService service)
        {
            _service = service;
        }

        [Route("lista")]
        public async Task<ViewResult> Index(int page, string name, string description)
        {
            ViewData["PageCount"] = await _service.GetCountVendasAsync();

            var venda = await _service.GetByPageAndNameAndDescriptionAsync(page, name, description);
            return View(venda);
        }

        [Route("detalhes/{id:int}")]
        public async Task<IActionResult> Details(int id)
        {
            var venda = await _service.GetByIdAsync(id);

            if (venda is null) return NotFound();

            return View(venda);
        }

        [Route("novo")]
        public async Task<IActionResult> Create()
        {
            var viewModel = await _service.GetViewModelVendaAsync();

            if (viewModel is null) return NotFound();

            return View(viewModel);
        }

        [HttpPost("novo")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idCliente, idProduto, qtdVenda")] VendaViewModel model)
        {
            ModelState.Remove("ClientesLista");
            ModelState.Remove("ProdutosLista");
            ModelState.Remove("Clientes");
            ModelState.Remove("Produtos");

            if (ModelState.IsValid)
            {
                var venda = await _service.AddAsync(model);

                if (venda is null) return NotFound();

                return RedirectToAction(nameof(Index), new { page = 1, name = "", description = "" });
            }

            var viewModel = await _service.GetViewModelVendaAsync();

            return View(viewModel);
        }

        [Route("editar/{id:int}")]
        public async Task<IActionResult> Edit(int id)
        {
            var viewModel = await _service.GetViewModelVendaAsync(id);

            if (viewModel is null) return NotFound();

            return View(viewModel);
        }

        [HttpPost("editar/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idVenda, idCliente, idProduto, qtdVenda")] VendaViewModel model)
        {
            ModelState.Remove("ClientesLista");
            ModelState.Remove("ProdutosLista");
            ModelState.Remove("Clientes");
            ModelState.Remove("Produtos");

            if (ModelState.IsValid)
            {
                var venda = await _service.UpdateAsync(id, model);

                if (venda is null) return NotFound();

                return RedirectToAction(nameof(Index), new { page = 1, name = "", description = "" });
            }

            var viewModel = await _service.GetViewModelVendaAsync();

            return View(viewModel);
        }

        [Route("excluir/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var venda = await _service.GetByIdAsync(id);

            if (venda is null) return NotFound();

            return View(venda);
        }

        [HttpPost("excluir/{id:int}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var venda = await _service.DeleteAsync(id);

            if (venda is false) return NotFound();

            return RedirectToAction(nameof(Index));
        }
    }
}
