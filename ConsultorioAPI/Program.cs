using ConsultorioAPI.DContext;
using ConsultorioAPI.Service.Consulta;
using ConsultorioAPI.Service.Paciente;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPacienteService, PacienteService>();
builder.Services.AddScoped<IConsultaService, ConsultaService>();
builder.Services.AddDbContext<ConDbContext>(options => 
{ 
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoConsulta"));
});

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
