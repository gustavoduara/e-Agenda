using e_Agenda.Dominio.Compartilhado;
using e_Agenda.Dominio.ModuloCategoria;

namespace e_Agenda.Dominio.ModuloDespesa;

public class Despesa : EntidadeBase<Despesa>
{
    public string Descricao { get; set; }
    public DateTime DataOcorrencia { get; set; }
    public decimal Valor { get; set; }
    public FormaPagamentoEnum FormaPagamento { get; set; }
    public List<Categoria> Categorias { get; set; }

    public Despesa()
    {
        Categorias = new List<Categoria>();
        DataOcorrencia = DateTime.Now; // Data de cadastro por padrão
    }

    public Despesa(string descricao, decimal valor, FormaPagamentoEnum formaPagamento) : this()
    {
        Id = Guid.NewGuid();
        Descricao = descricao;
        Valor = valor;
        FormaPagamento = formaPagamento;
    }

    public Despesa(string descricao, DateTime dataOcorrencia, decimal valor, FormaPagamentoEnum formaPagamento) : this(descricao, valor, formaPagamento)
    {
        DataOcorrencia = dataOcorrencia;
    }

    public void AdicionarCategoria(Categoria categoria)
    {
        if (!Categorias.Contains(categoria))
        {
            Categorias.Add(categoria);
            if (!categoria.Despesas.Contains(this))
            {
                categoria.Despesas.Add(this);
            }
        }
    }

    public void RemoverCategoria(Categoria categoria)
    {
        if (Categorias.Contains(categoria))
        {
            Categorias.Remove(categoria);
            if (categoria.Despesas.Contains(this))
            {
                categoria.Despesas.Remove(this);
            }
        }
    }

    public override void AtualizarRegistro(Despesa registroEditado)
    {
        foreach (var categoria in Categorias.ToList())
        {
            RemoverCategoria(categoria);
        }

        Descricao = registroEditado.Descricao;
        DataOcorrencia = registroEditado.DataOcorrencia;
        Valor = registroEditado.Valor;
        FormaPagamento = registroEditado.FormaPagamento;

        foreach (var categoria in registroEditado.Categorias)
        {
            AdicionarCategoria(categoria);
        }
    }

    public override string ToString()
    {
        return $"{Descricao} - R$ {Valor:F2} - {FormaPagamento} - {DataOcorrencia:dd/MM/yyyy}";
    }
} 