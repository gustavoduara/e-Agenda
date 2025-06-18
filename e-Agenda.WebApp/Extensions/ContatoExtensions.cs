

using e_Agenda.Dominio.ModuloContato;

namespace e_Agenda.WebApp.Extensions;

public static class ContatoExtensions
{
    public static Contato ParaEntidade(this FormularioContatoViewModel formularioVM)
    {
        return new Contato(formularioVM.Nome, formularioVM.);
    }

    public static DetalhesContatoViewModel ParaDetalhesVM(this Contato contato)
    {
        return new DetalhesContatoViewModel(
                contato.Id,
                contato.Nome,
                contato.Email,
                contato.Telefone,
                contato.Cargo,
                contato.Empresa
        );
    }
}