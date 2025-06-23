//using e_Agenda.Dominio.ModuloTarefas;
//using e_Agenda.WebApp.Extensions;
//using e_Agenda.WebApp.Models;
//using Microsoft.AspNetCore.Mvc.ViewFeatures;

//namespace e_Agenda.WebApp.Models
//{
//    public abstract class FormularioTarefaViewModel
//    {
//        public string Titulo { get; set; }
//        public string Prioridade { get; set; }
//        public DateTime DataCriacao { get; set; }
//        public DateTime? DataConclusao { get; set; }
//        public int PercentualConcluido { get; set; }

//        public bool Concluida => PercentualConcluido == 100;
//    }


//    public class CadastrarTarefaViewModel : FormularioTarefaViewModel
//    {
//        public CadastrarTarefaViewModel() { }

//        public CadastrarTarefaViewModel(string titulo, string prioridade, DateTime dataCriacao, DateTime? dataConclusao, int percentualConcluido)
//        {
//            Titulo = titulo;
//            Prioridade = prioridade;
//            DataCriacao = dataCriacao;
//            DataConclusao = dataConclusao;
//            PercentualConcluido = percentualConcluido;
//        }
//    }


//    public class EditarTarefaViewModel : FormularioTarefaViewModel
//    {
//        public EditarTarefaViewModel() { }

//        public EditarTarefaViewModel(string titulo, string prioridade, DateTime dataCriacao, DateTime? dataConclusao, int percentualConcluido)
//        {
//            Titulo = titulo;
//            Prioridade = prioridade;
//            DataCriacao = dataCriacao;
//            DataConclusao = dataConclusao;
//            PercentualConcluido = percentualConcluido;
//        }
//    }


//    public class ExcluirTarefaViewModel
//    {
//        public string Titulo { get; set; }

//        public ExcluirTarefaViewModel() { }

//        public ExcluirTarefaViewModel(string titulo)
//        {
//            Titulo = titulo;
//        }
//    }


//    public class VisualizarTarefasViewModel
//    {
//        public List<DetalhesTarefaViewModel> Registros { get; }

//        public VisualizarTarefasViewModel(List<Tarefa> tarefas)
//        {
//            Registros = new List<DetalhesTarefaViewModel>();

//            foreach (var tarefa in tarefas)
//            {
//                var detalhesVM = tarefa.ParaDetalhesVM();
//                Registros.Add(detalhesVM);
//            }
//        }
//    }


//    public class DetalhesTarefaViewModel
//    {
//        public string Titulo { get; set; }
//        public string Prioridade { get; set; }
//        public DateTime DataCriacao { get; set; }
//        public DateTime? DataConclusao { get; set; }
//        public int PercentualConcluido { get; set; }

//        public bool Concluida => PercentualConcluido == 100;

//        public DetalhesTarefaViewModel() { }

//        public DetalhesTarefaViewModel(string titulo, string prioridade, DateTime dataCriacao, DateTime? dataConclusao, int percentualConcluido)
//        {
//            Titulo = titulo;
//            Prioridade = prioridade;
//            DataCriacao = dataCriacao;
//            DataConclusao = dataConclusao;
//            PercentualConcluido = percentualConcluido;
//        }
//    }

//}
