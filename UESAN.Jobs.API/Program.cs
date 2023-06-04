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
