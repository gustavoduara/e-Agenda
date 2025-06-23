
using Microsoft.AspNetCore.Mvc;
using e_Agenda.Infraestrura.Arquivos.Compartilhado;
using e_Agenda.Dominio.ModuloCompromisso;
using e_Agenda.Infraestrutura.Aquivos.ModuloCompromisso;
using e_Agenda.Dominio.ModuloContato;
using e_Agenda.Infraestrura.Arquivos.ModuloContato;
using e_Agenda.ConsoleApp.Models;
using e_Agenda.WebApp.Extensions;
using e_Agenda.WebApp.Models;

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

            [HttpGet("cadastrar")]
            public IActionResult Cadastrar()
            {
                var contextoDados = new ContextoDados(true);

                var contatos = repositorioContato.SelecionarRegistros();
                var compromissos = repositorioCompromisso.SelecionarRegistros();

                CadastrarCompromissoViewModel cadastrarVM = new CadastrarCompromissoViewModel(contatos);

                return View(cadastrarVM);
            }

            [HttpPost("cadastrar")]
            public IActionResult Cadastrar(CadastrarCompromissoViewModel cadastrarVM)
            {
                var compromissos = repositorioCompromisso.SelecionarRegistros();
                var contatos = repositorioContato.SelecionarRegistros();

                Compromisso  compromisso = cadastrarVM.ParaEntidade(contatos);

                repositorioCompromisso.CadastrarRegistro(compromisso);
                return RedirectToAction(nameof(Index));

            }

        [HttpGet("editar/{Id:guid}")]
        public IActionResult Editar([FromRoute] Guid id)
        {

            var compromisso = repositorioCompromisso.SelecionarRegistroPorId(id);
            EditarCompromissoViewModel editarVM = compromisso.ParaEditarVM();

            var contatos = repositorioContato.SelecionarRegistros();
            editarVM.ContatosDisponiveis = contatos.ParaSelecionarContatoViewModel();
            return View(editarVM);
        }

        [HttpPost("editar/{Id:guid}")]
        public IActionResult EditarMedicamento([FromRoute] Guid id, EditarCompromissoViewModel editarVM)
        {

            var contextoDados = new ContextoDados(true);

            var contatos = repositorioContato.SelecionarRegistros();
            Compromisso compromisso = editarVM.ParaEntidade(repositorioContato.SelecionarRegistros());

            repositorioCompromisso.EditarRegistro(id, compromisso);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("detalhes/{id:guid}")]
        public ActionResult Detalhes(Guid id)
        {
            var registroSelecionado = repositorioCompromisso.SelecionarRegistroPorId(id);

            var detalhesVM = new DetalhesCompromissoViewModel(
                id,
                registroSelecionado.Titulo,
                registroSelecionado.Assunto,
                registroSelecionado.DataOcorrencia,
                registroSelecionado.HoraInicio,
                registroSelecionado.HoraTermino,
                registroSelecionado.TipoCompromisso,
                registroSelecionado.Local,
                registroSelecionado.Link,
                registroSelecionado.Contato.Id
            );

            detalhesVM.NomeContato = registroSelecionado.Contato.Nome;
            return View(detalhesVM);
        }
    }
}