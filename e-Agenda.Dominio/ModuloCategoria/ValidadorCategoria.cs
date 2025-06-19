namespace e_Agenda.Dominio.ModuloCategoria;

public class ValidadorCategoria
{
    public List<string> Validar(Categoria categoria)
    {
        List<string> erros = new List<string>();

        if (string.IsNullOrWhiteSpace(categoria.Titulo))
        {
            erros.Add("O título é obrigatório.");
        }
        else if (categoria.Titulo.Length < 2)
        {
            erros.Add("O título deve ter pelo menos 2 caracteres.");
        }
        else if (categoria.Titulo.Length > 100)
        {
            erros.Add("O título deve ter no máximo 100 caracteres.");
        }

        return erros;
    }

    public List<string> ValidarExclusao(Categoria categoria)
    {
        List<string> erros = new List<string>();

        if (!categoria.PodeSerExcluida())
        {
            erros.Add("Não é possível excluir uma categoria que possui despesas relacionadas.");
        }

        return erros;
    }
} 