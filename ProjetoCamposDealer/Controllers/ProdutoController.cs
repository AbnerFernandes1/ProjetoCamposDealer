using Microsoft.AspNetCore.Mvc;
using ProjetoCamposDealer.Services.Interfaces;
using ProjetoDealer.Domain;

namespace ProjetoCamposDealer.Controllers
{
    [Route("produtos")]
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _service;

        public ProdutoController(IProdutoService service)
        {
            _service = service;
        }

        [Route("lista")]
        public async Task<ViewResult> Index(int page, string name)
        {
            ViewData["PageCount"] = await _service.GetCountProdutosAsync();

            var produto = await _service.GetByPageAndNameAsync(page, name);
            return View(produto);
        }

        [Route("novo")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("novo")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idProduto, dscProduto, vlrUnitario")] Produto produto)
        {
            ModelState.Remove("Vendas");

            if (ModelState.IsValid)
            {
                var produtoContext = await _service.AddAsync(produto);

                if (produtoContext is not null)
                {
                    return RedirectToAction(nameof(Index), new { page = 1, produto.idProduto });
                }
            }

            return View(produto);
        }

        [Route("detalhes/{id:int}")]
        public async Task<IActionResult> Details(int id)
        {
            var produto = await _service.GetByIdAsync(id);

            if (produto is null) return NotFound();

            return View(produto);
        }

        [Route("editar/{id:int}")]
        public async Task<IActionResult> Edit(int id)
        {
            var produto = await _service.GetByIdAsync(id);

            if (produto is null) return NotFound();

            return View(produto);
        }

        [HttpPost("editar/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idProduto, dscProduto, vlrUnitario")] Produto produto)
        {
            ModelState.Remove("Vendas");

            if (ModelState.IsValid)
            {
                var produtoContext = await _service.UpdateAsync(id, produto);

                if (produtoContext is null) return NotFound();

                return RedirectToAction(nameof(Index), new { page = 1, produto.idProduto });
            }

            return View(produto);
        }

        [Route("excluir/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var produto = await _service.GetByIdAsync(id);

            if (produto is null) return NotFound();

            return View(produto);
        }

        [HttpPost("excluir/{id:int}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produto = await _service.DeleteAsync(id);

            if (produto is false) return NotFound();

            return RedirectToAction(nameof(Index));
        }
    }
}
