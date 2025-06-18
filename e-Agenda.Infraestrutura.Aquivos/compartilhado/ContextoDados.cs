
using e_Agenda.Dominio.ModuloContato;
using System.Text.Json.Serialization;
using System.Text.Json;
using e_Agenda.Dominio.ModuloTarefas;

namespace e_Agenda.Infraestrura.Arquivos.Compartilhado;


public class ContextoDados
{
    private string pastaArmazenamento = "C:\\temp";
    private string arquivoArmazenamento = "dados-e-agenda.json";

    public List<Contato> Contatos { get; set; }
    public List<Tarefas> Tarefas { get; set; }

    public ContextoDados()
    {
        Contatos = new List<Contato>();
        Tarefas = new List<Tarefas>();
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
        Tarefas = contextoArmazenado.Tarefas;
    }
}
