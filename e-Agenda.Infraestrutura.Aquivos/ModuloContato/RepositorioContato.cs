using e_Agenda.Dominio.ModuloContato;
using e_Agenda.Infraestrura.Arquivos.Compartilhado;

namespace eAgenda.Infraestrutura.ModuloContato;
public class RepositorioContato : RepositorioBaseEmArquivo<Contato>, IRepositorioContato
{
    public RepositorioContato(ContextoDados contexto) : base(contexto) { }

    protected override List<Contato> ObterRegistros()
    {
        return contexto.Contatos;
    }
}