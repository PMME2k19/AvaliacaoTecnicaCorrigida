using AvaliacaoTecninca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace avaliacao_tecnica_V2.AcessoDados.Samples
{
    public class ServicoSample
    {
        private static List<Servico> Lista = new List<Servico>();

        public static Servico Get(Guid id)
        {
            return Lista.FirstOrDefault(x => x.Id == id);
        }

        private static void GerarServico()
        {
            var servico1 = new Servico()
            {
                Id = Guid.NewGuid(),
                Nome = "Massagem"          
            };

            var servico2 = new Servico()
            {
                Id = Guid.NewGuid(),
                Nome = "Outros"
            };

            Lista.Add(servico1);
            Lista.Add(servico2);
        }
        public static IList<Servico> GetAll()
        {
            if (Lista == null || Lista.Count == 0)
                GerarServico();

            return Lista;
        }
    }
}