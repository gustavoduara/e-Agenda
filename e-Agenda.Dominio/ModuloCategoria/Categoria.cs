using e_Agenda.Dominio.Compartilhado;
using e_Agenda.Dominio.ModuloDespesa;

namespace e_Agenda.Dominio.ModuloCategoria;

public class Categoria : EntidadeBase<Categoria>
{
    public string Titulo { get; set; }
    public List<Despesa> Despesas { get; set; }

    public Categoria()
    {
        Despesas = new List<Despesa>();
    }

    public Categoria(string titulo) : this()
    {
        Id = Guid.NewGuid();
        Titulo = titulo;
    }

    public void AdicionarDespesa(Despesa despesa)
    {
        if (!Despesas.Contains(despesa))
        {
            Despesas.Add(despesa);
            if (!despesa.Categorias.Contains(this))
            {
                despesa.Categorias.Add(this);
            }
        }
    }

    public void RemoverDespesa(Despesa despesa)
    {
        if (Despesas.Contains(despesa))
        {
            Despesas.Remove(despesa);
            if (despesa.Categorias.Contains(this))
            {
                despesa.Categorias.Remove(this);
            }
        }
    }

    public decimal CalcularValorTotalDespesas()
    {
        return Despesas.Sum(d => d.Valor);
    }

    public bool PodeSerExcluida()
    {
        return Despesas.Count == 0;
    }

    public override void AtualizarRegistro(Categoria registroAtualizado)
    {
        Titulo = registroAtualizado.Titulo;
    }

    public override string ToString()
    {
        return $"{Titulo} ({Despesas.Count} despesas)";
    }
}