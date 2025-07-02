using e_Agenda.Dominio.ModuloContato;
using e_Agenda.Dominio.ModuloTarefa;
using e_Agenda.Infraestrura.Arquivos.Compartilhado;
using e_Agenda.Infraestrutura.ModuloTarefa;
using e_Agenda.WebApp.ActionFilters;
using eAgenda.Infraestrutura.ModuloContato;

namespace e_Agenda.WebApp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews(options =>
        {
            options.Filters.Add<ValidarModeloAttribute>();
        });

        builder.Services.AddScoped<ContextoDados>((_) => new ContextoDados(true));
        builder.Services.AddScoped<IRepositorioTarefa, RepositorioTarefa>();
        builder.Services.AddScoped<IRepositorioContato, RepositorioContato>();

        var app = builder.Build();

        app.UseAntiforgery();
        app.UseStaticFiles();
        app.UseRouting();
        app.MapDefaultControllerRoute();

        app.Run();
    }
}