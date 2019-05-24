using avaliacao_tecnica_V2.AcessoDados.Contract;
using avaliacao_tecnica_V2.AcessoDados.Repositorios;
using AvaliacaoTecninca.AcessoDados.Repositorios;
using AvaliacaoTecninca.Controllers;
using AvaliacaoTecninca.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;

namespace AvaliacaoTecninca.App_Start
{
    public class InjeccaoDependenciaConfig
    {
        internal static void Inicializar()
        {
            var container = new UnityContainer();

            container.RegisterType<IClienteRepository, ClienteRepository>();
            container.RegisterType<IServicoRepository, ServicoRepository>();
            container.RegisterType<IAgendaRepository, AgendaRepository>();
           
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}