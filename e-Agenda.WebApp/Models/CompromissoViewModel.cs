using System.Security.Cryptography.X509Certificates;
using e_Agenda.Dominio.ModuloCompromisso;
using e_Agenda.Dominio.ModuloContato;
using e_Agenda.WebApp.Extensions;

namespace e_Agenda.ConsoleApp.Models
{
    public abstract class FormularioCompromissoViewModel
    {
        public string Titulo { get; set; }
        public string Assunto { get; set; }
        public DateTime DataOcorrencia { get; set; }
        public string HoraInicio { get; set; }
        public string HoraTermino { get; set; }
        public string TipoCompromisso { get; set; }
        public string Local { get; set; }
        public string Link { get; set; }
        public Guid ContatoId { get; set; }

        public List<SelecionarContatoViewModel> ContatosDisponiveis { get; set; }

        protected FormularioCompromissoViewModel()
        {
            ContatosDisponiveis = new List<SelecionarContatoViewModel>();
        }
    }

    public class SelecionarContatoViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public SelecionarContatoViewModel(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
    public class CadastrarCompromissoViewModel : FormularioCompromissoViewModel
    {
        public CadastrarCompromissoViewModel()
        {

        }
        public CadastrarCompromissoViewModel(List<Contato> contatos) : this()
        {
            foreach (Contato contato in contatos)
            {
                var contatoVM = new SelecionarContatoViewModel(contato.Id, contato.Nome);
                ContatosDisponiveis.Add(contatoVM);
            }
        }
    }

    public class VisualizarCompromissosViewModel
    {
        public List<DetalhesCompromissoViewModel> Registros { get; set; }

        public VisualizarCompromissosViewModel(List<Compromisso> compromissos)
        {
            Registros = new List<DetalhesCompromissoViewModel>();

            foreach (Compromisso m in compromissos)
            {
                DetalhesCompromissoViewModel detalheVM = m.ParaDetalheVM();

                Registros.Add(detalheVM);
            }
        }
    }
    public class EditarCompromissoViewModel : FormularioCompromissoViewModel
    {
        public Guid Id { get; set; }
        public EditarCompromissoViewModel()
        {

        }
        public EditarCompromissoViewModel(Guid id, string titulo, string assunto,  DateTime dataOcorrencia, string horaInicio, string horaTermino, string tipoCompromisso, string local, string link, Guid contatoId)
        {
            Id = id;
            Titulo = titulo;
            Assunto = assunto;
            DataOcorrencia = dataOcorrencia;
            HoraInicio = horaInicio;
            HoraTermino = horaTermino;
            TipoCompromisso = tipoCompromisso;
            Local = local;
            Link = link;
            ContatoId = contatoId;
        }
    }

    public class ExcluirCompromissoViewModel
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }

        public ExcluirCompromissoViewModel(Guid id, string titulo)
        {
            Id = id;
            Titulo = titulo;
        }
    }

    public class DetalhesCompromissoViewModel
    {
            public Guid Id { get; set; }
            public string Titulo { get; set; }
            public string Assunto { get; set; }
            public DateTime DataOcorrencia { get; set; }
            public string HoraInicio { get; set; }
            public string HoraTermino { get; set; }
            public string TipoCompromisso { get; set; }
            public string Local { get; set; }
            public string Link { get; set; }
            public Guid ContatoId { get; set; }
            public string NomeContato { get; set; }

        public DetalhesCompromissoViewModel(Guid id, string titulo, string assunto, DateTime dataOcorrencia, string horaInicio, string horaTermino, string tipoCompromisso, string local, string link, Guid contatoId)
        {
            Id = id;
            Titulo = titulo;
            Assunto = assunto;
            DataOcorrencia = dataOcorrencia;
            HoraInicio = horaInicio;
            HoraTermino = horaTermino;
            TipoCompromisso = tipoCompromisso;
            Local = local;
            Link = link;
            ContatoId = contatoId;
        }

    }
}