namespace e_Agenda.Dominio.ModuloTarefas;

public class ItemTarefa
{
    public string Titulo { get; set; }
    public bool Concluido { get; private set; }

    public ItemTarefa(string titulo)
    {
        Titulo = titulo;
        Concluido = false;
    }

    public void Concluir()
    {
        Concluido = true;
    }

    public void Reabrir()
    {
        Concluido = false;
    }
}
