﻿using ProjetoDealer.Domain;

namespace ProjetoDealer.Application.Data.Interfaces
{
    public interface IClienteContext
    {
        Task<int> GetCountClientesAsync();
        Task<Cliente[]> GetClientesAsync();
        Task<Cliente> GetClienteByIdAsync(int id);
        Task<Cliente[]> GetClientesAsync(int page, string name);
    }
}
