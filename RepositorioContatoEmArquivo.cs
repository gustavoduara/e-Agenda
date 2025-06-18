using ControleDeBar.Infraestrura.Arquivos.Compartilhado;

namespace e_Agenda.Infraestrura.Arquivos.ModuloContato;

public class RepositorioContatoEmArquivo : RepositorioBaseEmArquivo<Contato>, IRepositorioContato
{
    public RepositorioContatoEmArquivo(ContextoDados contexto) : base(contexto) { }

    protected override List<Contato> ObterRegistros()
    {
        return contexto.Contatos;
    }
}