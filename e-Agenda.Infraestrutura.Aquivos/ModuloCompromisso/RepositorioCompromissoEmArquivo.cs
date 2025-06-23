using e_Agenda.Dominio.ModuloCompromisso;
using e_Agenda.Infraestrura.Arquivos.Compartilhado;

namespace e_Agenda.Infraestrutura.Aquivos.ModuloCompromisso;

public class RepositorioCompromissoEmArquivo : RepositorioBaseEmArquivo<Compromisso>, IRepositorioCompromisso
{
    public RepositorioCompromissoEmArquivo(ContextoDados contexto) : base(contexto) { }

    protected override List<Compromisso> ObterRegistros()
    {
        return contexto.Compromissos;
    }
}