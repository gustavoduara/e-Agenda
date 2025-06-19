using e_Agenda.Dominio.ModuloDespesa;
using e_Agenda.Dominio.ModuloCategoria;
using e_Agenda.Infraestrura.Arquivos.Compartilhado;

namespace e_Agenda.Infraestrura.Arquivos.ModuloDespesa;

public class RepositorioDespesaEmArquivo : RepositorioBaseEmArquivo<Despesa>, IRepositorioDespesa
{
    public RepositorioDespesaEmArquivo(ContextoDados contexto) : base(contexto)
    {
    }

    protected override List<Despesa> ObterRegistros()
    {
        return contexto.Despesas;
    }

    public List<Despesa> SelecionarDespesasPorCategoria(Categoria categoria)
    {
        return registros.Where(d => 
            d.Categorias.Any(c => c.Id == categoria.Id))
            .ToList();
    }

    public List<Despesa> SelecionarDespesasPorPeriodo(DateTime dataInicio, DateTime dataFim)
    {
        return registros.Where(d => 
            d.DataOcorrencia.Date >= dataInicio.Date && 
            d.DataOcorrencia.Date <= dataFim.Date)
            .ToList();
    }

    public List<Despesa> SelecionarDespesasPorFormaPagamento(FormaPagamentoEnum formaPagamento)
    {
        return registros.Where(d => d.FormaPagamento == formaPagamento)
            .ToList();
    }

    public decimal CalcularTotalDespesasPorCategoria(Categoria categoria)
    {
        return registros.Where(d => 
            d.Categorias.Any(c => c.Id == categoria.Id))
            .Sum(d => d.Valor);
    }
} 