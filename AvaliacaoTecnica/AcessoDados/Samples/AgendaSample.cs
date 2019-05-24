using AvaliacaoTecninca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace avaliacao_tecnica_V2.AcessoDados.Samples
{
    public class AgendaSample
    {
        private static List<Agenda> Lista = new List<Agenda>();

        public static bool Add(Agenda agenda)
        {
            agenda.Id = Guid.NewGuid();
            Lista.Add(agenda);
            return true;
        }
        public static void Delete(Guid id)
        {
            Lista.RemoveAll(c => c.Id == id);
        }

        public static void Delete(Cliente cliente)
        {
            Lista.RemoveAll(c => c.Id == cliente.Id);
        }

        public static Agenda Get(Guid id)
        {
            return Lista.FirstOrDefault(x => x.Id == id);
        }

        public static bool Update(Agenda agenda)
        {
            var registado = Get(agenda.Id);
            if (registado != null)
            {
                registado.Descricao = agenda.Descricao;
                registado.dataAgenda = agenda.dataAgenda;
                registado.Servico = agenda.Servico;
            }
            return true;
        }

        public static IList<Agenda> GetAll()
        {
         
            return Lista;
        }
    }
}