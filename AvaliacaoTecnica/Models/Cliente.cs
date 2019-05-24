using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AvaliacaoTecninca.Models
{
    public class Cliente
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Celular { get; set; }
        public string Documento { get; set; }
        public virtual ICollection<Agenda> Agendas { get; set; }
        public virtual Utilizador Utilizador { get; set; }

        public bool IsValid()
        {
            //var agenda = DateTime.Now.Addd;

            //DateTime.Now.AddDays(-1).Date;

            if (string.IsNullOrEmpty(this.Nome))
            {
                throw new Exception("O campo nome é obrigatório");
            }
            if (string.IsNullOrEmpty(this.Documento))
            {
                throw new Exception("O campo Documento é obrigatório");
            }
            if (string.IsNullOrEmpty(this.Celular))
            {
                throw new Exception("O campo Celular é obrigatório");
            }

            return true;
        }

    }
}