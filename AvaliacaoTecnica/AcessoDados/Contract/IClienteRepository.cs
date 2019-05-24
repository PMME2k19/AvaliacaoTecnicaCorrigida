using AvaliacaoTecninca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AvaliacaoTecninca.Data
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Utilizador Autenticar(string nome, string password);
    }
}