namespace e_Agenda.Dominio.ModuloTarefas;

public class ItemTarefa
{
    public Guid Id { get; set; }
    public string Titulo { get; set; }
    public bool Concluido { get; set; }

    public ItemTarefa(string titulo)
    {
        Id = Guid.NewGuid();
        Titulo = titulo;
        Concluido = false;
    }

    public void Concluir()
    {
        Concluido = true;
    }

    public void MarcarPendente()
    {
        Concluido = false;
    }
}
