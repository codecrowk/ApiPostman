using Microsoft.EntityFrameworkCore;
using Payfair.Data;
using Payfair.Services;
using Payfair.Interfaces;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor
builder.Services.AddControllers();

// Configurar el contexto de la base de datos con MySQL
builder.Services.AddDbContext<BaseContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("MySqlConnection"),
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.20-mysql")
    )
);

// Registrar UsuarioService e IUsuarioService para la inyección de dependencias
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

// Configurar Swagger/OpenAPI para la documentación de la API
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "My API", Version = "v1" });
});

var app = builder.Build();

// Configurar el pipeline de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    // Habilitar middleware para servir Swagger como un endpoint JSON
    app.UseSwagger();

    // Habilitar middleware para servir swagger-ui (HTML, JS, CSS, etc.),
    // especificando el endpoint JSON de Swagger
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
