// See https://aka.ms/new-console-template for more information
using BazarTemTudo.TesteConsole;
using BazarTemTudo.TesteConsole.Context;
using BazarTemTudo.TesteConsole.Repository;
using BazarTemTudo.TesteConsole.Uploader;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


Console.WriteLine("Hello, World!");

// Configurar o serviço de injeção de dependência
var serviceProvider = new ServiceCollection()
    .AddDbContext<TestContext>(options =>
        options.UseSqlServer("Server=DESKTOP-NSQ6C33\\ATLAS;Database=BazarDB;Trusted_Connection=True;TrustServerCertificate=true"))
    .AddScoped<CargaRepository>()
    .AddScoped<LoadCarga>()
    .BuildServiceProvider();

// Resgatar a instância de LoadCarga e chamar o método
var loadCarga = serviceProvider.GetService<LoadCarga>();
loadCarga.LoadTxtFileContent();