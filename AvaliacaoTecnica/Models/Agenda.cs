using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AvaliacaoTecninca.Models
{
    public class Agenda
    {
        public Guid Id { get; set; }
        public DateTime dataAgenda { get; set; }
        public bool estado { get; set; }
        public string Descricao { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Servico Servico { get; set; }

        public bool IsInTime()
        {
            var dataActual = DateTime.Now;
            var dataInicio = DateTime.Now;
            var dataFim = DateTime.Now;

            // Hora de inicio de criação de agenda
            TimeSpan horaInicio = new TimeSpan(8,0,0);

            // Hora de fim de criação de agenda
            TimeSpan horaFim = new TimeSpan(16,0,0);

            dataInicio = dataInicio.Date + horaInicio;
            dataFim = dataFim.Date + horaFim;

            if(DateTime.Compare(dataActual, dataInicio) > 0 && DateTime.Compare(dataActual, dataFim) < 0)
            {
                return true;
            }

            return false;
        }

    }
}