using AutoMapper;
using avaliacao_tecnica_V2.ViewModel;
using AvaliacaoTecninca.Models;
using AvaliacaoTecninca.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace avaliacao_tecnica_V2.App_Start
{
    public class MapperConfig
    {
        internal static void Inicializar()
        {

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<UtilizadorViewModel, Utilizador>();
                cfg.CreateMap<Utilizador, UtilizadorViewModel>();

                cfg.CreateMap<ClienteViewModel, Cliente>();
                cfg.CreateMap<Cliente, ClienteViewModel>();

                cfg.CreateMap<AgendaViewModel, Agenda>();
                cfg.CreateMap<Agenda, AgendaViewModel>();

            });
        }
    }
}