// TODO: Tranformar todos os controllers em ass�ncronos e polir a l�gica de neg�cio

using dotnet_learning.Database;
using dotnet_learning.Repositories;
using dotnet_learning.Repositories.Interfaces;

// Faz uma configura��o das principais coisas que a API vai usar e depois faz o build

DotNetEnv.Env.Load();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddTransient<IClubRepository,ClubRepository>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();

app.UseHttpsRedirection();  // Redireciona requisi��es HTTP para HTTPS
app.MapControllers();       // Mapeia os controllers buscando na pasta controllers

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
