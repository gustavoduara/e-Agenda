using e_Agenda.Dominio.ModuloContato;
using e_Agenda.WebApp.Extensions;
using e_Agenda.WebApp.Models;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace e_Agenda.WebApp.Models
{
    public abstract class FormularioContatoViewModel
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Cargo { get; set; }
        public string Empresa { get; set; }
    }

    public class CadastrarContatoViewModel : FormularioContatoViewModel
    {
        public CadastrarContatoViewModel() { }

        public CadastrarContatoViewModel(string nome, string email, string telefone, string cargo, string empresa) : this()
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Cargo = cargo;
            Empresa = empresa;
        }
    }


    public class EditarContatoViewModel : FormularioContatoViewModel
    {

        public Guid Id { get; set; }
        public EditarContatoViewModel() { }

        public EditarContatoViewModel(Guid id, string nome, string email, string telefone, string cargo, string empresa) : this()
        {
            Id = id;
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Cargo = cargo;
            Empresa = empresa;
        }
    }


    public class ExcluirContatoViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public ExcluirContatoViewModel() { }
        public ExcluirContatoViewModel(Guid id, string nome) : this()
        {
            Id = id;
            Nome = nome;
        }
    }


    public class VisualizarContatosViewModel
    {
        public List<DetalhesContatoViewModel> Registros { get; }
        public VisualizarContatosViewModel(List<Contato> produtos)
        {
            Registros = [];

            foreach (var produto in produtos)
            {
                var detalhesVM = produto.ParaDetalhesVM();

                Registros.Add(detalhesVM);
            }
        }
    }


    public class  DetalhesContatoViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Cargo { get; set; }
        public string Empresa { get; set; }
        public DetalhesContatoViewModel(Guid id, string nome, string email, string telefone, string cargo, string empresa)
        {
            Id = id;
            Nome = nome;
        }
    }

}
