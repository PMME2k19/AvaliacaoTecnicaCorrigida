using AvaliacaoTecninca.Data;
using AvaliacaoTecninca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AvaliacaoTecninca.Controllers
{
    public class LoginController : Controller
    {
        private IClienteRepository _ClienteRepository;

        public LoginController(IClienteRepository clienteRepository)
        {
            _ClienteRepository = clienteRepository;
        }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Autenticar(Utilizador utilizador)
        {
            var utilizadorLogado = _ClienteRepository.Autenticar(utilizador.Username, utilizador.Password);
            if (utilizadorLogado != null)
            {
                Session["username"] = utilizadorLogado.Username;
                Session["userID"] = utilizadorLogado.Id;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("ErrorMessage", "Username ou Password Incorrecto");
                return View("Index", utilizador);
            }
           
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

    }
}
