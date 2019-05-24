using AutoMapper;
using AvaliacaoTecninca.Data;
using AvaliacaoTecninca.Models;
using AvaliacaoTecninca.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AvaliacaoTecninca.Controllers
{
    public class ClienteController : Controller
    {
        readonly IClienteRepository _ClienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _ClienteRepository = clienteRepository;
        }

        // GET: Cliente
        public ActionResult Index()
        {
            var lista = _ClienteRepository.Listar();
            return View(lista);
        }

        // GET: Cliente/Details/5
        public ActionResult Details()
        {
            if (Guid.TryParse(Session["userID"].ToString(), out Guid id))
            {
                var cliente = _ClienteRepository.Listar().FirstOrDefault(x => x.Utilizador.Id == id);

                var clienteViewModel = Mapper.Map<ClienteViewModel>(cliente);

                return View(clienteViewModel);
            }

            return null; //Mensagem de Erro
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(ClienteViewModel clienteViewModel)
        {
    
            try
            {
                
                var cliente = Mapper.Map<Cliente>(clienteViewModel);
                cliente.Utilizador = Mapper.Map<Utilizador>(clienteViewModel.Utilizador);

                if (cliente.IsValid())
                {
                    _ClienteRepository.Inserir(cliente);
                }
           
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(Guid id)
        {
            var cliente = _ClienteRepository.Listar().FirstOrDefault(x => x.Id == id);
            return View(cliente);
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(Cliente cliente)
        {
            try
            {
                _ClienteRepository.Actualizar(cliente);

                return RedirectToAction("Index","Home");
            }
            catch
            {
                return View();
            }
        }

        
    }
}
