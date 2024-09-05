using Prueba_Estado_Cuenta_App.Models.ModelsGeneral;
using Prueba_Estado_Cuenta_App.Models.ViewModels;
using System.Text.Json;
using System.Globalization;
using Prueba_Estado_Cuenta_App.Error;

namespace Prueba_Estado_Cuenta_App.Services
{
    public class CompraService : ICompraService
    {
        private readonly HttpClient _httpClient;
        RetornoError retornoError = new RetornoError();

        public CompraService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Compra>> obtenerCompraMesActual(int idCliente)
        {
            try
            {
                var url = $"https://localhost:7181/obtenerCompraMesActual/{idCliente}";
                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();

                    var compra = JsonSerializer.Deserialize<List<Compra>>(jsonString, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                        PropertyNameCaseInsensitive = true
                    });

                    var viewModel = compra?.Select(c => new Compra
                    {
                        Descripcion = c.Descripcion,
                        FechaCompra = c.FechaCompra,
                        Monto = c.Monto
                    }).ToList() ?? new List<Compra>();

                    return compra!;
                }
                return new List<Compra>();
            }
            catch (Exception ex)
            {
                retornoError.retornoErroresServicio(ex);
                return new List<Compra>();
            }
        }

        public async Task<string> obtenerMontoTotalCompras(int idCliente)
        {
            try
            {
                var url = $"https://localhost:7181/obtenerMontoMesAntAct/{idCliente}";
                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();

                    return jsonString.ToString();
                }
                return null!;
            }
            catch (Exception ex)
            {
                retornoError.retornoErroresServicio(ex);
                return null!;
            }
        }

        public string obtenerInicialesMes()
        {
            try
            {
                DateTime fechaActual = DateTime.Now;
                DateTime fechaMesAnterior = fechaActual.AddMonths(-1);

                var inicialesMesActual = fechaActual.ToString("MMM", CultureInfo.InvariantCulture).ToUpper();
                var inicialesMesAnterior = fechaMesAnterior.ToString("MMM", CultureInfo.InvariantCulture).ToUpper();

                return inicialesMesActual + "-" + inicialesMesAnterior;
            }catch (Exception ex)
            {
                retornoError.retornoErroresServicio(ex);
                return null!;
            }
            
        }

        public async Task<bool> realizarCompra(CompraVM compra)
        {
            try
            {
                var json = JsonSerializer.Serialize(compra);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("https://localhost:7181/agregarCompra", content);
                return response.IsSuccessStatusCode;
            }catch(Exception ex)
            {
                retornoError.retornoErroresServicio(ex);
                return false;
            }
        }

        public async Task<List<HistorialPagoComprasVM>> obtenerHistorialPagoCompras(int idCliente)
        {
            try
            {
                var url = $"https://localhost:7181/obtenerHistorial/{idCliente}";
                var response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();

                    var compra = JsonSerializer.Deserialize<List<HistorialPagoComprasVM>>(jsonString, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                        PropertyNameCaseInsensitive = true
                    });

                    var viewModel = compra?.Select(c => new HistorialPagoComprasVM
                    {
                        Tipo_Transaccion = c.Tipo_Transaccion,
                        Fecha = c.Fecha,
                        Descripcion = c.Descripcion,
                        Monto = c.Monto
                    }).ToList() ?? new List<HistorialPagoComprasVM>();

                    return compra!;
                }
                return new List<HistorialPagoComprasVM>();

            }
            catch(Exception ex)
            {
                retornoError.retornoErroresServicio(ex);
                return new List<HistorialPagoComprasVM>();
            }
        }
    }
}
