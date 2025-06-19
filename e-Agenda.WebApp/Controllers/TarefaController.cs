using e_Agenda.Dominio.ModuloTarefas;
using Microsoft.AspNetCore.Mvc;

namespace e_Agenda.WebApp.Controllers


{
    [Route("Tarefas")]
    public class HomeController2 : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
