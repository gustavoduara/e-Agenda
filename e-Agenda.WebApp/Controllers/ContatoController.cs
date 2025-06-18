
using Microsoft.AspNetCore.Mvc;
using e_Agenda.WebApp.Extensions;

namespace e_Agenda.WebApp.Controllers
{
    [Route("contatos")]
    public class ContatoController : Controller
    {
        private readonly ContextoDados contextoDados;
        private readonly IRepositorioContato repositorioContato;
        public ContatoController()
        {
            contextoDados = new ContextoDados(true);
            repositorioContato = new RepositorioContatoEmArquivo(contextoDados);
        }

        [HttpGet]
        public IActionResult Index()
        {
            var registros = repositorioProduto.SelecionarRegistros();

            var visualizarVM = new VisualizarProdutosViewModel(registros);

            return View(visualizarVM);
        }


        [HttpGet("cadastrar")]
        public IActionResult Cadastrar()
        {
            var cadastrarVM = new CadastrarProdutoViewModel();

            return View(cadastrarVM);
        }


        [HttpPost("cadastrar")]
        public IActionResult Cadastrar(CadastrarProdutoViewModel cadastrarVM)
        {
            var entidade = cadastrarVM.ParaEntidade();

            repositorioProduto.CadastrarRegistro(entidade);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("editar/{id:guid}")]
        public IActionResult Editar(Guid id)
        {
            var registroSelecionado = repositorioProduto.SelecionarRegistroPorId(id);
            var editarVM = new EditarProdutoViewModel(id, registroSelecionado.Nome, registroSelecionado.Preco);

            return View(editarVM);
        }


        [HttpPost("editar/{id:guid}")]
        public IActionResult Editar(Guid id, EditarProdutoViewModel editarVM)
        {
            var entidadeEditada = editarVM.ParaEntidade();

            repositorioProduto.EditarRegistro(id, entidadeEditada);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("excluir/{id:guid}")]
        public ActionResult Excluir(Guid id)
        {
            var registroSelecionado = repositorioProduto.SelecionarRegistroPorId(id);

            var excluirVM = new ExcluirProdutoViewModel(registroSelecionado.Id, registroSelecionado.Nome);

            return View(excluirVM);
        }

        [HttpPost("excluir/{id:guid}")]
        public ActionResult ExcluirConfirmado(Guid id)
        {
            repositorioProduto.ExcluirRegistro(id);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("detalhes/{id:guid}")]
        public ActionResult Detalhes(Guid id)
        {
            var registroSelecionado = repositorioProduto.SelecionarRegistroPorId(id);

            var detalhesVM = new DetalhesProdutoViewModel(
                id,
                registroSelecionado.Nome,
                registroSelecionado.Preco
            );

            return View(detalhesVM);
        }
    }
}

