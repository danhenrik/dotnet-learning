// TODO: Tranformar todos os controllers em ass�ncronos e polir a l�gica de neg�cio

using dotnetlearning.Database;

// Faz uma configura��o das principais coisas que a API vai usar e depois faz o build

DotNetEnv.Env.Load();

// API Setup
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
// =========================================

// Swagger setup
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// =========================================

// DB Setup
builder.Services.AddDbContext<AppDbContext>();
// =========================================

// API Setup
var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();

app.UseHttpsRedirection();  // Redireciona requisi��es HTTP para HTTPS
app.MapControllers();       // Mapeia os controllers buscando na pasta controllers
// =========================================

// Swagger setup
app.UseSwagger();
app.UseSwaggerUI();
// =========================================

// API startup
app.Run();
// =========================================