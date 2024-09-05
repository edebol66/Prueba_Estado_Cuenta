using Prueba_Estado_Cuenta_App.Error;
using Prueba_Estado_Cuenta_App.Models.ViewModels;
using System.Text.Json;

namespace Prueba_Estado_Cuenta_App.Services
{
    public class PagoService : IPagoService
    {
        private readonly HttpClient _httpClient;
        RetornoError retornoErrores = new RetornoError();

        public PagoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> realizarPago(PagoVM pago)
        {
            try
            {
                var json = JsonSerializer.Serialize(pago);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("https://localhost:7181/agregarPago", content);
                return response.IsSuccessStatusCode;
            }catch (Exception ex)
            {
                retornoErrores.retornoErroresServicio(ex);
                return false;
            }
        }
    }
}
