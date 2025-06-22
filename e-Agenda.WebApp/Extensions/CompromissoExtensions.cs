using e_Agenda.ConsoleApp.Models;
using e_Agenda.Dominio.ModuloCompromisso;
using e_Agenda.Dominio.ModuloContato;
using e_Agenda.WebApp.Models;

namespace e_Agenda.WebApp.Extensions
{
    public static class CompromissoExtensions
    {
        public static Compromisso ParaEntidade(this FormularioCompromissoViewModel formularioVM, List<Contato> contatos)
        {
            Contato ContatoSelecionado = null;
            foreach (var f in contatos)
            {
                if (f.Id == formularioVM.ContatoId)
                {
                   ContatoSelecionado = f;
                }
            }
            return new Compromisso(formularioVM.Assunto, formularioVM.DataOcorrencia, formularioVM.HoraInicio, formularioVM.HoraTermino, formularioVM.TipoCompromisso,formularioVM.Local, formularioVM.Link, ContatoSelecionado);
        }
        public static DetalhesCompromissoViewModel ParaDetalheVM(this Compromisso compromisso)
        {
            return new DetalhesCompromissoViewModel(
                    compromisso.Id,
                    compromisso.Assunto,
                    compromisso.DataOcorrencia,
                    compromisso.HoraInicio,
                    compromisso.HoraTermino,
                    compromisso.TipoCompromisso,
                    compromisso.Local,
                    compromisso.Link,
                    compromisso.Contato.Id
            );
        }
    }
}
