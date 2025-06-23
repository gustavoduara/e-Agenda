//using e_Agenda.Dominio.ModuloTarefas;
//using e_Agenda.WebApp.Models;
//using Microsoft.AspNetCore.Mvc;

//namespace e_Agenda.WebApp.Controllers


//{
//    [Route("Tarefas")]

//    public class TarefaController : Controller
//    {
//        private IRepositorioTarefa repositorioTarefa;
//        [HttpGet]
//        public IActionResult Index()
//        {
//            var registros = repositorioTarefa.SelecionarRegistros();

//            var visualizarVM = new VisualizarTarefasViewModel(registros);
            
//            return View();
//        }
//    }
//}
