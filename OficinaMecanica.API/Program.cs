using Microsoft.EntityFrameworkCore;
using Oracle.EntityFrameworkCore;
using OficinaMecanica.API.data;
; // Assumindo que seu DbContext est� na pasta Data

// ----------------------------------------------------
// 1. INICIALIZA��O �NICA DO BUILDER
// ----------------------------------------------------
var builder = WebApplication.CreateBuilder(args);

// ----------------------------------------------------
// 2. SERVI�OS
// ----------------------------------------------------

// Adiciona o DbContext para o Oracle (2,0 pontos)
builder.Services.AddDbContext<MecanicaDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection")));

// Adiciona os Controllers da API
builder.Services.AddControllers();

// Configura��es do Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ----------------------------------------------------
// 3. CONSTRU��O E CONFIGURA��O DO PIPELINE
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