using e_Agenda.Dominio.Compartilhado;
using e_Agenda.Dominio.ModuloTarefas;

namespace e_Agenda.Dominio.ModuloTarefas;

public class Tarefa : EntidadeBase<Tarefa>
{
    public string Titulo { get; set; }
    public string Prioridade { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime? DataConclusao { get; set; }
    public bool Concluida => PercentualConcluido == 100;
    public int PercentualConcluido { get; private set; }

    public List<ItemTarefa> Itens { get; set; }

    public Tarefa()
    {
        Itens = new List<ItemTarefa>();
        DataCriacao = DateTime.Now;
    }

    public Tarefa(string titulo, string prioridade) : this()
    {
        Id = Guid.NewGuid();
        Titulo = titulo;
        Prioridade = prioridade;
    }

    public void AdicionarItem(ItemTarefa item)
    {
        Itens.Add(item);
        AtualizarPercentual();
    }

    public void RemoverItem(ItemTarefa item)
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

    public override void AtualizarRegistro(Tarefa registroEditado)
    {
        Titulo = registroEditado.Titulo;
        Prioridade = registroEditado.Prioridade;
        AtualizarPercentual();
    }
}