using Microsoft.EntityFrameworkCore;
using Oracle.EntityFrameworkCore;
using OficinaMecanica.API.data;
; // Assumindo que seu DbContext está na pasta Data

// ----------------------------------------------------
// 1. INICIALIZAÇÃO ÚNICA DO BUILDER
// ----------------------------------------------------
var builder = WebApplication.CreateBuilder(args);

// ----------------------------------------------------
// 2. SERVIÇOS
// ----------------------------------------------------

// Adiciona o DbContext para o Oracle (2,0 pontos)
builder.Services.AddDbContext<MecanicaDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection")));

// Adiciona os Controllers da API
builder.Services.AddControllers();

// Configurações do Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ----------------------------------------------------
// 3. CONSTRUÇÃO E CONFIGURAÇÃO DO PIPELINE
// ----------------------------------------------------
var app = builder.Build();

// Configura o HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();