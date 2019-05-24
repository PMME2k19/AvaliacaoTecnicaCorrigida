using AutoMapper;
using avaliacao_tecnica_V2.AcessoDados.Contract;
using avaliacao_tecnica_V2.ViewModel;
using AvaliacaoTecninca.Data;
using AvaliacaoTecninca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vereyon.Web;

namespace AvaliacaoTecninca.Controllers
{
    public class AgendaController : Controller
    {
        readonly IServicoRepository _ServicoRepository;
        readonly IClienteRepository _ClienteRepository;
        readonly IAgendaRepository _AgendaRepository;
        public AgendaController(IServicoRepository servicoRepository, IClienteRepository clienteRepository, IAgendaRepository agendaRepository)
        {
            _ServicoRepository = servicoRepository;
            _ClienteRepository = clienteRepository;
            _AgendaRepository = agendaRepository;
        }
        // GET: Agenda
        public ActionResult Index()
        {
            var lista = _AgendaRepository.Listar();
            return View(lista);
        }

        // GET: Agenda/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Agenda/Create
        public ActionResult Create()
        {
            Agenda ag = new Agenda();

            if (ag.IsInTime() == false)
            {
                FlashMessage.Danger("Esta fora do horario de marcação de agenda [08H00 - 16H00]");
                return RedirectToAction("Index","Home");
            }
            var servicos = _ServicoRepository.Listar();

            var agendaViewModel = new AgendaViewModel
            {
                dataAgenda = DateTime.Now,
                Servicos = servicos.Select( x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Nome
                })
            };

            return View(agendaViewModel);
        }

        // POST: Agenda/Create
        [HttpPost]
        public ActionResult Create(AgendaViewModel agendaViewModel)
        {
            try
            {
                // TODO: Add insert logic here
                var agenda = Mapper.Map<Agenda>(agendaViewModel);

                     if (Guid.TryParse(Session["userID"].ToString(), out Guid id))
                {
                    var cliente = _ClienteRepository.Listar().FirstOrDefault(x => x.Utilizador.Id == id);
                    var servico = _ServicoRepository.Buscar(agendaViewModel.ServicoSeleccionado);

                    agenda.Cliente = cliente;
                    agenda.Servico = servico;

                    _AgendaRepository.Inserir(agenda);
                 
                }
                FlashMessage.Confirmation("Agenda Criada Com Sucesso");
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Agenda/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Agenda/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Agenda/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Agenda/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
