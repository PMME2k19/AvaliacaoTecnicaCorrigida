using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace AvaliacaoTecninca.Models
{
    public class Utilizador
    {
        public Guid Id { get; set; }
        [DisplayName("Nome de Utilizador")]
        [Required(ErrorMessage = "Este é um campo obrigatório")]
        public string Username { get; set; }   
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Este é um campo obrigatório")]
        public string Password { get; set; }
        public virtual Cliente Cliente { get; set; }
        public string ErrorMessage { get; set; }


       
    }

}