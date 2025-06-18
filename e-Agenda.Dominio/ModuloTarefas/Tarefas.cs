using ControleDeBar.Dominio.ModuloTarefa;
using e_Agenda.Dominio.Compartilhado;

namespace ControleDeBar.Dominio.ModuloMesa;

public class Tarefas : EntidadeBase<Tarefas>
{
    public enum PrioridadeTarefa
    {
        Baixa,
        Normal,
        Alta
    }

    public string Titulo { get; set; }
    public PrioridadeTarefa Prioridade { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime? DataConclusao { get; set; }
    public bool Concluida => PercentualConcluido == 100;
    public int PercentualConcluido { get; private set; }

    public List<ItemTarefas> Itens { get; set; }

    public Tarefas()
    {
        Itens = new List<ItemTarefas>();
        DataCriacao = DateTime.Now;
    }

    public Tarefas(string titulo, PrioridadeTarefa prioridade) : this()
    {
        Id = Guid.NewGuid();
        Titulo = titulo;
        Prioridade = prioridade;
    }

    public void AdicionarItem(ItemTarefas item)
    {
        Itens.Add(item);
        AtualizarPercentual();
    }

    public void RemoverItem(ItemTarefas item)
    {
        Itens.Remove(item);
        AtualizarPercentual();
    }

    public void AtualizarPercentual()
    {
        if (Itens.Count == 0)
        {
            PercentualConcluido = 0;
            return;
        }

        var totalConcluidos = Itens.Count(i => i.Concluido);
        PercentualConcluido = (int)((double)totalConcluidos / Itens.Count * 100);

        if (PercentualConcluido == 100)
            DataConclusao = DateTime.Now;
        else
            DataConclusao = null;
    }

    public override void AtualizarRegistro(Tarefas registroEditado)
    {
        Titulo = registroEditado.Titulo;
        Prioridade = registroEditado.Prioridade;
        AtualizarPercentual();
    }
}