

using e_Agenda.Dominio.Compartilhado;
using e_Agenda.Dominio.ModuloContato;

namespace e_Agenda.Dominio.ModuloCompromisso
{
    public class Compromisso : EntidadeBase<Compromisso>
    {
        public string Assunto { get; set; }
        public DateTime DataOcorrencia { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraTermino { get; set; }
        public string TipoCompromisso  { get; set; }
        public string Local { get; set; }
        public string Link { get; set; }

        public Contato Contato;

        public Compromisso() { }

        public Compromisso(string assunto, DateTime dataOcorrencia, DateTime horaInicio, DateTime horaTermino, string tipoCompromisso, string local, string link, Contato contato) : this()
        {
            Id = Guid.NewGuid();
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