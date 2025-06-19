using e_Agenda.Dominio.ModuloCategoria;
using e_Agenda.WebApp.Models;

namespace e_Agenda.WebApp.Extensions;

public static class CategoriaExtensions
{
    public static Categoria ParaEntidade(this FormularioCategoriaViewModel formularioVM)
    {
        return new Categoria(formularioVM.Titulo);
    }

    public static DetalhesCategoriaViewModel ParaDetalhesVM(this Categoria categoria)
    {
        return new DetalhesCategoriaViewModel(
            categoria.Id,
            categoria.Titulo,
            categoria.Despesas.Count,
            categoria.CalcularValorTotalDespesas()
        );
    }

    public static SelecionarCategoriaViewModel ParaSelecionarVM(this Categoria categoria)
    {
        return new SelecionarCategoriaViewModel(categoria.Id, categoria.Titulo);
    }
} 