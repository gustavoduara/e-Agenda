using e_Agenda.Dominio.ModuloTarefas;
using e_Agenda.Infraestrura.Arquivos.Compartilhado;

namespace ControleDeBar.Infraestrura.Arquivos.ModuloMesa;

public class RepositorioMesaEmArquivo : RepositorioBaseEmArquivo<Tarefas>, IRepositorioTarefas
{
    public RepositorioMesaEmArquivo(ContextoDados contexto) : base(contexto) { }

    protected override List<Tarefas> ObterRegistros()
    {
        return contexto.Tarefas;
    }
}
