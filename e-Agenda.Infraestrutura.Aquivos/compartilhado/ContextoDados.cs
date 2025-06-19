using System.Text.Json.Serialization;
using System.Text.Json;
using e_Agenda.Dominio.ModuloContato;
using e_Agenda.Dominio.ModuloCategoria;
using e_Agenda.Dominio.ModuloDespesa;

namespace e_Agenda.Infraestrura.Arquivos.Compartilhado;


public class ContextoDados
{
    private string pastaArmazenamento = "C:\\temp";
    private string arquivoArmazenamento = "dados-e-agenda.json";

    public List<Contato> Contatos { get; set; }
    public List<Categoria> Categorias { get; set; }
    public List<Despesa> Despesas { get; set; }

    public ContextoDados()
    {
        Contatos = new List<Contato>();
        Categorias = new List<Categoria>();
        Despesas = new List<Despesa>();
    }

    public ContextoDados(bool carregarDados) : this()
    {
        if (carregarDados)
            Carregar();
    }

    public void Salvar()
    {
        string caminhoCompleto = Path.Combine(pastaArmazenamento, arquivoArmazenamento);

        JsonSerializerOptions jsonOptions = new JsonSerializerOptions();
        jsonOptions.WriteIndented = true;
        jsonOptions.ReferenceHandler = ReferenceHandler.Preserve;

        string json = JsonSerializer.Serialize(this, jsonOptions);

        if (!Directory.Exists(pastaArmazenamento))
            Directory.CreateDirectory(pastaArmazenamento);

        File.WriteAllText(caminhoCompleto, json);
    }

    public void Carregar()
    {
        string caminhoCompleto = Path.Combine(pastaArmazenamento, arquivoArmazenamento);

        if (!File.Exists(caminhoCompleto)) return;

        string json = File.ReadAllText(caminhoCompleto);

        if (string.IsNullOrWhiteSpace(json)) return;

        JsonSerializerOptions jsonOptions = new JsonSerializerOptions();
        jsonOptions.ReferenceHandler = ReferenceHandler.Preserve;

        ContextoDados contextoArmazenado = JsonSerializer.Deserialize<ContextoDados>(
            json, 
            jsonOptions
        )!;

        if (contextoArmazenado == null) return;

        Contatos = contextoArmazenado.Contatos;
        Categorias = contextoArmazenado.Categorias;
        Despesas = contextoArmazenado.Despesas;

        // Re-establish bidirectional relationships after loading
        RestaurarRelacionamentos();
    }

    private void RestaurarRelacionamentos()
    {
        // Clear all relationships first
        foreach (var categoria in Categorias)
        {
            categoria.Despesas.Clear();
        }

        // Rebuild relationships from despesas to categorias
        foreach (var despesa in Despesas)
        {
            foreach (var categoriaId in despesa.Categorias.Select(c => c.Id).ToList())
            {
                // Find the actual categoria instance from the repository
                var categoriaReal = Categorias.FirstOrDefault(c => c.Id == categoriaId);
                if (categoriaReal != null)
                {
                    // Replace the categoria in despesa with the real instance
                    var categoriaIndex = despesa.Categorias.FindIndex(c => c.Id == categoriaId);
                    if (categoriaIndex >= 0)
                    {
                        despesa.Categorias[categoriaIndex] = categoriaReal;
                    }

                    // Add despesa to categoria if not already there
                    if (!categoriaReal.Despesas.Contains(despesa))
                    {
                        categoriaReal.Despesas.Add(despesa);
                    }
                }
            }
        }
    }
}
