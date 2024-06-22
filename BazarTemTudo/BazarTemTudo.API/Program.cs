using Autofac.Core;
using AutoMapper;
using BazarTemTudo.API;
using BazarTemTudo.Application.AppService;
using BazarTemTudo.Application.Interface;
using BazarTemTudo.Domain.Entities;
using BazarTemTudo.Domain.Interface;
using BazarTemTudo.Domain.Interface.Repository;
using BazarTemTudo.Domain.Interface.Service;
using BazarTemTudo.Domain.Service;
using BazarTemTudo.Infra.Filesystem.FileUpload;
using BazarTemTudo.InfraData.Context;
using BazarTemTudo.InfraData.Mapping;
using BazarTemTudo.InfraData.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseSqlite(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
    .UseSqlServer(
        builder.Configuration.GetConnectionString("SecondConnection"))
);


builder.Services.AddScoped<ICargaRepository, CargaRepository>();
builder.Services.AddScoped<ICargaAppService, CargaAppService>();
builder.Services.AddScoped<ICargaService, CargaService>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", policy =>
    {
        policy.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
             .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


builder.Services.AddAutoMapper(cfg => { 
    cfg.AddProfile<BazarTemTudoMapping>();

});



builder.Services.AddIdentity<Usuarios, IdentityRole>(options =>
{
    // Configurações do Identity
})
    .AddEntityFrameworkStores<ApplicationDBContext>()
    .AddDefaultTokenProviders();


builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings.
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;
    options.SignIn.RequireConfirmedEmail = false;

    // Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // User settings.
    options.User.AllowedUserNameCharacters =
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = false;
});      





builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.OperationFilter<FileUploadFilter>();
});

var app = builder.Build();


app.UseCors("AllowLocalhost");


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseAuthentication();
//app.UseAuthorization();

app.MapControllers();

app.Run();
