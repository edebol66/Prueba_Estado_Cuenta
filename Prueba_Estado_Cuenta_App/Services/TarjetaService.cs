using System.Text.Json;
using Prueba_Estado_Cuenta_App.Error;
using Prueba_Estado_Cuenta_App.Models;

namespace Prueba_Estado_Cuenta_App.Services
{
    public class TarjetaService : ITarjetaService
    {
        private readonly HttpClient _httpClient;
        RetornoError retornoErrores = new RetornoError();

        public TarjetaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<TarjetaLimite> obtenerLimiteTarjeta(int idCliente)
        {
            try
            {
                var url = $"https://localhost:7181/ConsultarLimiteNumero/{idCliente}";
                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();

                    var tarjetaLimite = JsonSerializer.Deserialize<TarjetaLimite>(jsonString, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                        PropertyNameCaseInsensitive = true
                    });

                    return tarjetaLimite!;
                }
                return new TarjetaLimite();
            }
            catch (Exception ex)
            {
                retornoErrores.retornoErroresServicio(ex);
                return new TarjetaLimite();
            }
        }
    }
}
