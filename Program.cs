using BodegaVinos.Data;
using BodegaVinos.Repositories;
using BodegaVinos.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//Clave secreta para firmar el token
var jwtSecret = builder.Configuration["Jwt:SecretKey"];
var key = Encoding.UTF8.GetBytes(jwtSecret);

// Configuracion de JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

//agregar los servicios de los repositorios y los servicios
builder.Services.AddScoped<WineRepository>();
builder.Services.AddScoped<WineService>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<UserService>();

//configurar servicios
builder.Services.AddControllers();

//registrar el DbContext con slite
builder.Services.AddDbContext<BodegaVinosDbContext>(optionsAction : options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DBConnectionString")));//ver

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//configurar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}//ver

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
