using AvaliacaoTecninca.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AvaliacaoTecninca.ViewModel
{
    public class UtilizadorViewModel
    {
        [Required(ErrorMessage = "Este é um campo obrigatório")]
        public string Username { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Este é um campo obrigatório")]
        public string Password { get; set; }
        [DisplayName("Confirmar Password")]
        [DataType(DataType.Password)]
        public string RetryPassword { get; set; }
    }
}