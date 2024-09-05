using Microsoft.EntityFrameworkCore;
using Prueba_Estado_Cuenta_API.Profiles;
using Prueba_Estado_Cuenta_API.Models.Estado_Cuenta;
using Prueba_Estado_Cuenta_API.Services;
using Prueba_Estado_Cuenta_API.Repository;
using Prueba_Estado_Cuenta_API.MiddleWare;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MapeoProfile));

var conexionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<Estado_CuentaContext>(
    options => options.UseSqlServer(conexionString));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddScoped<ITarjetaService, TarjetaServices>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<ICuentaService, CuentaService>();
builder.Services.AddScoped<ICompraService, CompraService>();
builder.Services.AddScoped<IPagoService, PagoService>();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();
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
