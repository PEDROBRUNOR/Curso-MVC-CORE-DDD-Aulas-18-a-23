using Microsoft.AspNetCore.Mvc;
using Projeto.Curso.Core.Application.Pedido.Interfaces;

namespace Projeto.Curso.Core.Site.Areas.Cadastros.Controllers
{
    [Area("Cadastros")]
    public class ClientesController : Controller
    {
        private readonly IApplicationClientes appclientes;

        public ClientesController(IApplicationClientes _appclientes)
        {
            appclientes = _appclientes;
        }
        public IActionResult Index()
        {
            var model = appclientes.ObterTodos();
            return View(model);
        }
    }
}