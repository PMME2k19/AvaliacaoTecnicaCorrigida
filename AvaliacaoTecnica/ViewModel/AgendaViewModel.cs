using AvaliacaoTecninca.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace avaliacao_tecnica_V2.ViewModel
{
    public class AgendaViewModel
    {
        public Guid Id { get; set; }
        [DisplayName("Descrição")]
        public string Descricao { get; set; }
        [DisplayName("Escolha uma Data")]
        public DateTime dataAgenda { get; set; }

        public Guid ServicoSeleccionado { get; set; }
        public  IEnumerable<SelectListItem> Servicos { get; set; }
    }
}