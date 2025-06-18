

using e_Agenda.Dominio.ModuloContato;

namespace e_Agenda.WebApp.Extensions;

public static class ContatoExtensions
{
    public static Contato ParaEntidade(this FormularioContatoViewModel formularioVM)
    {
        return new Contato(formularioVM.Nome, formularioVM.);
    }

    public static DetalhesProdutoViewModel ParaDetalhesVM(this Produto produto)
    {
        return new DetalhesProdutoViewModel(
                produto.Id,
                produto.Nome,
                produto.Valor
        );
    }
}