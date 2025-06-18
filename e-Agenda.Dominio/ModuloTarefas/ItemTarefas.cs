namespace e_Agenda.Dominio.ModuloTarefas;

public class ItemTarefas
{
    public string Titulo { get; set; }
    public bool Concluido { get; private set; }

    public ItemTarefas(string titulo)
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
