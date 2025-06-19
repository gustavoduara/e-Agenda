using e_Agenda.Dominio.Compartilhado;

namespace e_Agenda.Dominio.ModuloCategoria;

public interface IRepositorioCategoria : IRepositorioBase<Categoria>
{
    bool ExisteTituloCategoria(string titulo);
    bool ExisteTituloCategoria(string titulo, Guid idCategoriaParaIgnorar);
    List<Categoria> SelecionarCategoriasPorTitulo(string titulo);
} 