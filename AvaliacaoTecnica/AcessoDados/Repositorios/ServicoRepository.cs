using avaliacao_tecnica_V2.AcessoDados.Contract;
using avaliacao_tecnica_V2.AcessoDados.Samples;
using AvaliacaoTecninca.Data;
using AvaliacaoTecninca.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace avaliacao_tecnica_V2.AcessoDados.Repositorios
{
    public class ServicoRepository : IServicoRepository
    {
        private Mock<IRepository<Servico>> _Mock;
        public ServicoRepository()
        {
            ConfigurarMockRepositorio();
        }

        private void ConfigurarMockRepositorio()
        {
            _Mock = new Mock<IRepository<Servico>>();
            _Mock.Setup(x => x.Listar())
                .Returns(ServicoSample.GetAll());
        }

        public bool Actualizar(Servico objecto)
        {
            throw new NotImplementedException();
        }

        public Servico Buscar(Guid id)
        {
            _Mock.Setup(x => x.Buscar(id))
           .Returns(ServicoSample.Get(id));

            return _Mock.Object.Buscar(id);
        }

        public void Eliminar(Servico objecto)
        {
            throw new NotImplementedException();
        }

        public bool Inserir(Servico objecto)
        {
            throw new NotImplementedException();
        }

        public IList<Servico> Listar()
        {
            return _Mock.Object.Listar();
        }
    }
}