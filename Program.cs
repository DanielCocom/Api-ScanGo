using api_scango.Domain.Entities;
using api_scango.Domain.Services;
using api_scango.Infrastructure.Data;
using api_scango.Infrastructure.Data.Repositories;
using api_scango.Infrastructure.Data.Repositories.administrador;
using api_scango.Services.Fetures.administrador;
using api_scango.Services.Fetures.compra;
using api_scango.Services.Fetures.establecimiento;

// using api_scango.Services.Fetures.establecimiento;
using api_scango.Services.Fetures.producto;
using api_scango.Services.Mappings;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var Configurations = builder.Configuration;

// Add services to the container.
// builder.Services.AddScoped<ProductoService>();
// builder.Services.AddTransient<ProductoRepository>();
// 
// Clientes
builder.Services.AddScoped<ClienteService>();
builder.Services.AddTransient<ClienteRepository>();

// Carrito
// builder.Services.AddScoped<CarritoService>();
// builder.Services.AddTransient<CarritoRepository>();

builder.Services.AddScoped<EstablecimientoService>();
builder.Services.AddTransient<EstablecimientoRepository>();

builder.Services.AddScoped<AdministradorService>();
builder.Services.AddTransient<AdministradorRepository>();

// builder.Services.AddScoped<CompraServices>();
// builder.Services.AddTransient<CompraRepository>();
// 
// 
builder.Services.AddControllers();
builder.Services.AddDbContext<ScanGoDbContext>(
    options => {
        options.UseSqlServer(Configurations.GetConnectionString("gemDevelopment"));
    }
);
// builder.Services.AddScoped<DBExternal>(_ => new DBExternal("workstation id=DbScanGo.mssql.somee.com;packet size=4096;user id=DanielCocom;pwd=dcd238e3;data source=DbScanGo.mssql.somee.com;persist security info=False;initial catalog=DbScanGo;MultipleActiveResultSets=True;Trust Server Certificate=true"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(ReponseMappingProfile).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
    app.UseSwagger();
    app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
