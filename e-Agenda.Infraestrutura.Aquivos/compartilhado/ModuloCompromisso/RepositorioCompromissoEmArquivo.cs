using e_Agenda.Dominio.ModuloCompromisso;
using e_Agenda.Infraestrura.Arquivos.Compartilhado;

namespace e_Agenda.Infraestrura.Arquivos.ModuloCategoria;

public class RepositorioCompromissoEmArquivo : RepositorioBaseEmArquivo<Compromisso>, IRepositorioCompromisso
{
    public RepositorioCompromissoEmArquivo(ContextoDados contexto) : base(contexto)
    {
    }

    protected override List<Compromisso> ObterRegistros()
    {
        return contexto.Categorias;
    }

    public bool ExisteTituloCategoria(string titulo)
    {
        return registros.Any(c => c.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));
    }

    public bool ExisteTituloCategoria(string titulo, Guid idCategoriaParaIgnorar)
    {
        return registros.Any(c =>
            !c.Id.Equals(idCategoriaParaIgnorar) &&
            c.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));
    }

    public List<Compromisso> SelecionarCategoriasPorTitulo(string titulo)
    {
        return registros.Where(c =>
            c.Titulo.Contains(titulo, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
}