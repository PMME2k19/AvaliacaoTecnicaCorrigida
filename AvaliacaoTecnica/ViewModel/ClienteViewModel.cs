using AvaliacaoTecninca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AvaliacaoTecninca.ViewModel
{
    public class ClienteViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Celular { get; set; }
        public string Documento { get; set; }

        public UtilizadorViewModel Utilizador { get; set; }

    }
}