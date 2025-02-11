using Microsoft.AspNetCore.Mvc;
using ProjetoDealer.Domain;
using ProjetoDealer.Services.Interfaces;

namespace ProjetoCamposDealer.Controllers
{
    [Route("clientes")]
    public class ClienteController : Controller
    {
        private readonly IClienteService _service;

        public ClienteController(IClienteService service)
        {
            _service = service;
        }

        [Route("lista")]
        public async Task<ViewResult> Index(int page, string name)
        {
            var cliente = await _service.GetByPageAndNameAsync(page, name);
            return View(cliente);
        }

        [Route("novo")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("novo")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idCliente, nmCliente, Cidade")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                var clienteContext = await _service.AddAsync(cliente);

                if (clienteContext is not null)
                {
                    return RedirectToAction(nameof(Index), new { page = 1, cliente.nmCliente });
                }
            }

            return View(cliente);
        }

        [Route("detalhes/{id:int}")]
        public async Task<IActionResult> Details(int id)
        {
            var cliente = await _service.GetByIdAsync(id);

            if (cliente is null) return NotFound();

            return View(cliente);
        }

        [Route("editar/{id:int}")]
        public async Task<IActionResult> Edit(int id)
        {
            var cliente = await _service.GetByIdAsync(id);

            if (cliente is null) return NotFound();

            return View(cliente);
        }

        [HttpPost("editar/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idCliente, nmCliente, Cidade")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                var clienteContext = await _service.UpdateAsync(id, cliente);

                if (clienteContext is null) return NotFound();

                return RedirectToAction(nameof(Index), new { page = 1, cliente.nmCliente });
            }

            return View(cliente);
        }

        [Route("excluir/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var cliente = await _service.GetByIdAsync(id);

            if (cliente is null) return NotFound();

            return View(cliente);
        }

        [HttpPost("excluir/{id:int}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = await _service.DeleteAsync(id);

            if (cliente is false) return NotFound();

            return RedirectToAction(nameof(Index));
        }
    }
}
