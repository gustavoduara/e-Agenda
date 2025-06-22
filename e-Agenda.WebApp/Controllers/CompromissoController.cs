
using Microsoft.AspNetCore.Mvc;
using e_Agenda.Infraestrura.Arquivos.Compartilhado;
using e_Agenda.Dominio.ModuloCompromisso;
using e_Agenda.Infraestrutura.Aquivos.ModuloCompromisso;
using e_Agenda.Dominio.ModuloContato;
using e_Agenda.Infraestrura.Arquivos.ModuloContato;
using e_Agenda.ConsoleApp.Models;
using e_Agenda.WebApp.Extensions;

namespace e_Agenda.WebApp.Controllers
{
    [Route("compromissos")]
    public class CompromissoController : Controller
    {
        private readonly ContextoDados contextoDados;
        private readonly IRepositorioCompromisso repositorioCompromisso;
        private readonly IRepositorioContato repositorioContato;

            public CompromissoController()
            {
                contextoDados = new ContextoDados(true);
                repositorioCompromisso = new RepositorioCompromissoEmArquivo(contextoDados);
                repositorioContato = new RepositorioContatoEmArquivo(contextoDados);
            }   


            [HttpGet()]
            public IActionResult Index()
            {
                var compromissos = repositorioCompromisso.SelecionarRegistros();
                var visualizarVM = new VisualizarCompromissosViewModel(compromissos);
                return View(visualizarVM);
             }

            [HttpGet("Cadastrar")]
            public IActionResult Cadastrar()
            {
                var contextoDados = new ContextoDados(true);

                var contatos = repositorioContato.SelecionarRegistros();
                var compromissos = repositorioCompromisso.SelecionarRegistros();

                CadastrarCompromissoViewModel cadastrarVM = new CadastrarCompromissoViewModel(contatos);

                return View(cadastrarVM);
            }

            [HttpPost("Cadastrar")]
            public IActionResult Cadastrar(CadastrarCompromissoViewModel cadastrarVM)
            {
                var compromissos = repositorioCompromisso.SelecionarRegistros();
                var contatos = repositorioContato.SelecionarRegistros();

                Compromisso  compromisso = cadastrarVM.ParaEntidade(contatos);

                repositorioCompromisso.CadastrarRegistro(compromisso);
                return RedirectToAction(nameof(Index));

            }
    }
}