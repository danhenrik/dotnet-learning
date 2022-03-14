// TODO: Tranformar todos os controllers em assíncronos e polir a lógica de negócio

using dotnetlearning.Database;
using dotnetlearning.Repositories;
using dotnetlearning.Repositories.Interfaces;

// Faz uma configuração das principais coisas que a API vai usar e depois faz o build

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

app.UseHttpsRedirection();  // Redireciona requisições HTTP para HTTPS
app.MapControllers();       // Mapeia os controllers buscando na pasta controllers

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
