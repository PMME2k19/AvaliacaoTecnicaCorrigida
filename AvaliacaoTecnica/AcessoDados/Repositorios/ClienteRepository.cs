using System;
using System.Collections.Generic;
using System.Linq;
using AvaliacaoTecninca.Data.Samples;
using AvaliacaoTecninca.Models;
using Moq;

namespace AvaliacaoTecninca.Data
{
    public class ClienteRepository : IClienteRepository
    {

        private Mock<IRepository<Cliente>> _Mock;
        public ClienteRepository()
        {
            ConfigurarMockRepositorio();
        }

        private void ConfigurarMockRepositorio()
        {
            _Mock = new Mock<IRepository<Cliente>>();
            _Mock.Setup(x => x.Listar())
                .Returns(ClienteSample.GetAll());
        }

        public Utilizador Autenticar(string nome, string password)
        {
            var cliente = Listar().FirstOrDefault(x => x.Utilizador.Username == nome && x.Utilizador.Password == password);

            if (cliente != null)
            {
                return cliente.Utilizador;
            }
            return null;
        }

        public IList<Cliente> Listar()
        {
            return _Mock.Object.Listar();
        }

        public bool Inserir(Cliente cliente)
        {
           _Mock.Setup(x => x.Inserir(cliente))
           .Returns(ClienteSample.Add(cliente));

            _Mock.Object.Inserir(cliente);

            return true;
        }

        public void Eliminar(Cliente objecto)
        {
            throw new NotImplementedException();
        }

        public bool Actualizar(Cliente cliente)
        {
            _Mock.Setup(x => x.Actualizar(cliente))
           .Returns(ClienteSample.Update(cliente));

            _Mock.Object.Actualizar(cliente);

            return true;
        }

        public Cliente Buscar(Guid id)
        {
            _Mock.Setup(x => x.Buscar(id))
           .Returns(ClienteSample.Get(id));

            return _Mock.Object.Buscar(id);

        }

    }
}