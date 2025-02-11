﻿using Microsoft.AspNetCore.Mvc;
using ProjetoCamposDealer.Models;
using ProjetoCamposDealer.Services.Interfaces;

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
            var venda = await _service.GetByPageAndNameAndDescriptionAsync(page, name, description);
            return View(venda);
        }

        [Route("novo")]
        public async Task<IActionResult> Create()
        {
            var viewModel = await _service.GetViewModelVendaAsync();
            return View(viewModel);
        }

        [HttpPost("novo")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VendaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var venda = await _service.AddAsync(model);

                if(venda is null)

                return RedirectToAction(nameof(Index));
            }
            
            return View(model);
        }
    }
}
