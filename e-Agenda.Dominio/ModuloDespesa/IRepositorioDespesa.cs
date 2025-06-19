using e_Agenda.Dominio.Compartilhado;
using e_Agenda.Dominio.ModuloCategoria;

namespace e_Agenda.Dominio.ModuloDespesa;

public interface IRepositorioDespesa : IRepositorioBase<Despesa>
{
    List<Despesa> SelecionarDespesasPorCategoria(Categoria categoria);
    List<Despesa> SelecionarDespesasPorPeriodo(DateTime dataInicio, DateTime dataFim);
    List<Despesa> SelecionarDespesasPorFormaPagamento(FormaPagamentoEnum formaPagamento);
    decimal CalcularTotalDespesasPorCategoria(Categoria categoria);
} 