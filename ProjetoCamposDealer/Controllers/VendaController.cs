using Microsoft.AspNetCore.Mvc;
using ProjetoCamposDealer.Models;
using ProjetoDealer.Application.Data.Context;
using ProjetoDealer.Domain;

namespace ProjetoCamposDealer.Controllers
{
    [Route("vendas")]
    public class VendaController : Controller
    {
        private readonly AppDbContext _context;

        public VendaController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new VendaViewModel
            {
                Clientes = _context.Clientes.ToList(),
                Produtos = _context.Produtos.ToList(),
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(VendaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var venda = new Venda
                {
                    idCliente = model.idCliente,
                    idProduto = model.idProduto,
                };

                _context.Vendas.Add(venda);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            model.Clientes = _context.Clientes.ToList();
            model.Produtos = _context.Produtos.ToList();
            return View(model);
        }

        [Route("novo")]
        public async Task<IActionResult> Create()
        {
            var viewModel = new VendaViewModel
            {
                Clientes = _context.Clientes.ToList(),
                Produtos = _context.Produtos.ToList(),
            };

            return View(viewModel);
        }

        [HttpPost("novo")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VendaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var venda = new Venda
                {
                    idCliente = model.idCliente,
                    idProduto = model.idProduto,
                };

                _context.Vendas.Add(venda);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            model.Clientes = _context.Clientes.ToList();
            model.Produtos = _context.Produtos.ToList();
            
            return View(model);
        }

    }
}
