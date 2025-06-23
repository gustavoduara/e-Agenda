

using e_Agenda.Dominio.Compartilhado;
using e_Agenda.Dominio.ModuloContato;

namespace e_Agenda.Dominio.ModuloCompromisso
{
    public class Compromisso : EntidadeBase<Compromisso>
    {
        public string Titulo { get; set; }
        public string Assunto { get; set; }
        public DateTime DataOcorrencia { get; set; }
        public string HoraInicio { get; set; }
        public string HoraTermino { get; set; }
        public string TipoCompromisso  { get; set; }
        public string Local { get; set; }
        public string Link { get; set; }
        public Contato Contato { get; set; }

        public Compromisso() { }

        public Compromisso(string titulo, string assunto, DateTime dataOcorrencia, string horaInicio, string horaTermino, string tipoCompromisso, string local, string link, Contato contato) : this()
        {
            Id = Guid.NewGuid();
            Titulo = titulo;
            Assunto = assunto;
            DataOcorrencia = dataOcorrencia;
            HoraInicio = horaInicio;
            HoraTermino = horaTermino;
            TipoCompromisso = tipoCompromisso;
            Local = local;
            Link = link;
            Contato = contato;
        }

        public override void AtualizarRegistro(Compromisso registroEditado)
        {
            Titulo = registroEditado.Titulo;
            Assunto = registroEditado.Assunto;
            DataOcorrencia = registroEditado.DataOcorrencia;
            HoraInicio = registroEditado.HoraInicio;
            HoraTermino = registroEditado.HoraTermino;
            TipoCompromisso = registroEditado.TipoCompromisso;
            Local = registroEditado.Local;
            Link = registroEditado.Link;
        }

    }
}