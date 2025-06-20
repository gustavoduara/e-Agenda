
using e_Agenda.Dominio.ModuloTarefas;
using e_Agenda.WebApp.Models;

namespace e_Agenda.WebApp.Extensions
{
    public static class TarefaExtensions
    {
        public static DetalhesTarefaViewModel ParaDetalhesVM(this Tarefa tarefa)
        {
            return new DetalhesTarefaViewModel(
                tarefa.Titulo,
                tarefa.Prioridade,
                tarefa.DataCriacao,
                tarefa.DataConclusao,
                tarefa.PercentualConcluido
            );
        }
    }
}