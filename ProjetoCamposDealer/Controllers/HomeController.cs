using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProjetoCamposDealer.Models;
using ProjetoCamposDealer.Services.Interfaces;
using ProjetoDealer.Application.Data.Context;

namespace ProjetoCamposDealer.Controllers
{
    public class HomeController : Controller
    {
        private readonly IVendaEndpointsService _service;
        private readonly AppDbContext _context;

        public HomeController(IVendaEndpointsService service, AppDbContext context)
        {
            _service = service;
            _context = context;
        }

        public IActionResult Index()
        {
            try
            {
                if (_context.Produtos.ToArray().Length is 0)
                {
                    return View(true);
                }

                return View();
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [Route("carregar")]
        public async Task<IActionResult> Create()
        {
            await _service.AddVendasExternasAsync();

            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
