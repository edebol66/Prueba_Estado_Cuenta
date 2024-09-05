using Prueba_Estado_Cuenta_App.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient<IClienteService, ClienteService>();
builder.Services.AddHttpClient<ITarjetaService, TarjetaService>();
builder.Services.AddHttpClient<ICuentaService, CuentaService>();
builder.Services.AddHttpClient<ICompraService, CompraService>();
builder.Services.AddHttpClient<IPagoService, PagoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Cliente}/{action=Index}/{id?}");

app.Run();
