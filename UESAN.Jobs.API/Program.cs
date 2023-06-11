using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using UESAN.Jobs.Core.Interfaces;
using UESAN.Jobs.Core.Services;
using UESAN.Jobs.Infrastructure.Models;
using UESAN.Jobs.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var _config = builder.Configuration;
var connectionString = _config
				.GetConnectionString("DevConnection");
builder
	   .Services
	   .AddDbContext<BolsaDeTrabajoContext>
	   (options => options.UseSqlServer(connectionString));

builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<IUsuarioService, UsuarioService>();
builder.Services.AddTransient<UsuarioService, UsuarioService>();
builder.Services.AddTransient<IEmpresaRepository, EmpresaRepository>();
builder.Services.AddTransient<IEmpresaService, EmpresaService>();
builder.Services.AddTransient<IPostulanteRepository, PostulanteRepository>();
builder.Services.AddTransient<IPostulanteService, PostulanteService>();
builder.Services.AddTransient<IOfertaRepository, OfertaRepository>();
builder.Services.AddTransient<IOfertaService, OfertaService>();
builder.Services.AddTransient<IOfertaPostularRepository,OfertaPostularRepository>();
builder.Services.AddTransient<IOfertaPostularService, OfertaPostularService>();
builder.Services.AddTransient<ICompetenciasRepository, CompetenciasRepository>();
builder.Services.AddTransient<ICompetenciasService, CompetenciasService>();
builder.Services.AddTransient<ICompetenciasOfertaRepository,CompetenciasOfertaRepository>();
builder.Services.AddTransient<ICompetenciasOfertaService, CompetenciasOfertaService>();


builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
options.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
