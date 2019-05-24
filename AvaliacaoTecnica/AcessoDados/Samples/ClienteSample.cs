using AvaliacaoTecninca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AvaliacaoTecninca.Data.Samples
{
    public class ClienteSample
    {

        private static List<Cliente> Lista = new List<Cliente>();

        public static bool Add(Cliente cliente)
        {
            cliente.Id = Guid.NewGuid();
            Lista.Add(cliente);
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

        public static Cliente Get(Guid id)
        {
            return Lista.FirstOrDefault(x => x.Id == id);
        }

        public static bool Update(Cliente cliente)
        {
            var registado = Get(cliente.Id);
            if (registado != null)
            {
                registado.Nome = cliente.Nome;
                registado.SobreNome = cliente.SobreNome;
                registado.Documento = cliente.Documento;
                registado.Celular = cliente.Celular;
            }
            return true;
        }

        private static void GerarClientes()
        {
            var cliente1 = new Cliente()
            {
                Id = Guid.NewGuid(),
                Nome = "Paulino",
                SobreNome = "Esperança",
                Celular = "904907676",
                Documento = "001177629BA034",
                Utilizador = new Utilizador
                {
                    Id = new Guid(),
                    Username = "paulino.esperanca",
                    Password = "12345678"
                }
            };

            var cliente2 = new Cliente()
            {
                Id = Guid.NewGuid(),
                Nome = "Pedro Castelo",
                SobreNome = "Esperança",
                Celular = "924000676",
                Documento = "000077629LA034",
                Utilizador = new Utilizador
                {
                    Id = Guid.NewGuid(),
                    Username = "pedro.castelo",
                    Password = "12345678"
                }
            };

            var cliente3 = new Cliente()
            {
                Id = Guid.NewGuid(),
                Nome = "Maria",
                SobreNome = "Antónia",
                Celular = "924906666",
                Documento = "023377629LN034",
                Utilizador = new Utilizador
                {
                    Id = Guid.NewGuid(),
                    Username = "maria.antonia",
                    Password = "12345678"
                }
            };
            Lista.Add(cliente1);
            Lista.Add(cliente2);
            Lista.Add(cliente3);
        }
    public static IList<Cliente> GetAll()
        {
            if (Lista == null || Lista.Count == 0)
                GerarClientes();

            return Lista;
        }
    }
}