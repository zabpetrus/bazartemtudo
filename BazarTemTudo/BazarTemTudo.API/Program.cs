using AutoMapper;
using BazarTemTudo.Application.AppService;
using BazarTemTudo.Application.Interface;
using BazarTemTudo.Application.Mapping;
using BazarTemTudo.Domain.Interface;
using BazarTemTudo.Domain.Interface.Repository;
using BazarTemTudo.Domain.Service;
using BazarTemTudo.InfraData.Context;
using BazarTemTudo.InfraData.Mapping;
using BazarTemTudo.InfraData.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddDbContext<SQLiteContext>(options =>
    options.UseSqlite(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<SQLiteContext>();

builder.Services.AddAuthorization();

builder.Services.AddScoped<IClientesAppService, ClienteAppService>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IClientesRepository, ClientesRepository>();

//builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddAutoMapper(cfg => { cfg.AddProfile<ClienteMapping>(); });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapIdentityApi<IdentityUser>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
