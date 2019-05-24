using avaliacao_tecnica_V2.AcessoDados.Contract;
using avaliacao_tecnica_V2.AcessoDados.Samples;
using AvaliacaoTecninca.Data;
using AvaliacaoTecninca.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AvaliacaoTecninca.AcessoDados.Repositorios
{
    public class AgendaRepository : IAgendaRepository

    {
        private Mock<IRepository<Agenda>> _Mock;

        public AgendaRepository()
        {
            ConfigurarMockRepositorio();
        }
        private void ConfigurarMockRepositorio()
        {
            _Mock = new Mock<IRepository<Agenda>>();
            _Mock.Setup(x => x.Listar())
                .Returns(AgendaSample.GetAll());
        }
        public bool Actualizar(Agenda objecto)
        {
            throw new NotImplementedException();
        }

        public Agenda Buscar(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(Agenda objecto)
        {
            throw new NotImplementedException();
        }

        public bool Inserir(Agenda agenda)
        {
            _Mock.Setup(x => x.Inserir(agenda))
            .Returns(AgendaSample.Add(agenda));

            _Mock.Object.Inserir(agenda);

            return true;
        }

        public IList<Agenda> Listar()
        {
            return _Mock.Object.Listar();
        }
    }
}