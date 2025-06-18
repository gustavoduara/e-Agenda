namespace ControleDeBar.Dominio.ModuloTarefa;

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
