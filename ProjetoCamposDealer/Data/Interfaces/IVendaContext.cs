﻿using ProjetoDealer.Domain;

namespace ProjetoDealer.Application.Data.Interfaces
{
    public interface IVendaContext
    {
        Task<int> GetCountVendasAsync();
        Task<Venda> GetVendaByIdAsync(int id);
        Task<Venda[]> GetVendasByPageByNamesAsync(int page, string nameCliente, string descriptionProduto);
    }
}
