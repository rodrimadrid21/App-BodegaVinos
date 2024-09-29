using BodegaVinos.Data;
using BodegaVinos.Repositories;
using BodegaVinos.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Agregar los servicios de los repositorios y los servicios
builder.Services.AddSingleton<WineRepository>();
builder.Services.AddScoped<WineService>(); // Asegúrate de que esto esté aquí

// Configurar servicios
builder.Services.AddControllers();

// Registrar el DbContext con SQL Server
builder.Services.AddDbContext<BodegaVinosDbContext>(optionsAction : options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// Configurar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
