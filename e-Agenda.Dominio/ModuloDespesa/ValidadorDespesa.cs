namespace e_Agenda.Dominio.ModuloDespesa;

public class ValidadorDespesa
{
    public List<string> Validar(Despesa despesa)
    {
        List<string> erros = new List<string>();

        if (string.IsNullOrWhiteSpace(despesa.Descricao))
        {
            erros.Add("A descrição é obrigatória.");
        }
        else if (despesa.Descricao.Length < 2)
        {
            erros.Add("A descrição deve ter pelo menos 2 caracteres.");
        }
        else if (despesa.Descricao.Length > 100)
        {
            erros.Add("A descrição deve ter no máximo 100 caracteres.");
        }

        if (despesa.Valor <= 0)
        {
            erros.Add("O valor deve ser maior que zero.");
        }

        if (despesa.DataOcorrencia > DateTime.Now.Date)
        {
            erros.Add("A data de ocorrência não pode ser uma data futura.");
        }

        if (despesa.Categorias == null || despesa.Categorias.Count == 0)
        {
            erros.Add("A despesa deve estar associada a pelo menos uma categoria.");
        }

        return erros;
    }
} 