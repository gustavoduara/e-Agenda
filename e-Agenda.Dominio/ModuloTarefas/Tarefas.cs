using e_Agenda.Dominio.Compartilhado;

namespace ControleDeBar.Dominio.ModuloMesa;

public class Tarefas : EntidadeBase<Tarefas>
{
    public int Numero { get; set; }
    public int Capacidade { get; set; }
    public bool EstaOcupada { get; set; }

    public Tarefas() { }

    public Tarefas(int numero, int quantidadeDeAssentos) : this()
    {
        Id = Guid.NewGuid();
        Numero = numero;
        Capacidade = quantidadeDeAssentos;
        EstaOcupada = false;
    }

    public void Ocupar()
    {
        EstaOcupada = true;
    }

    public void Desocupar()
    {
        EstaOcupada = false;
    }

    public override void AtualizarRegistro(Tarefas registroEditado)
    {
        Numero = registroEditado.Numero;
        Capacidade = registroEditado.Capacidade;
    }
}
