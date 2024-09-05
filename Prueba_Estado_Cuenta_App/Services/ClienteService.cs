using System.Text.Json;
using Prueba_Estado_Cuenta_App.Error;
using Prueba_Estado_Cuenta_App.Models;

namespace Prueba_Estado_Cuenta_App.Services
{
    public class ClienteService : IClienteService
    {
        private readonly HttpClient _httpClient;
        RetornoError retornoError = new RetornoError();
        public ClienteService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Cliente>> obtenerNombres()
        {
            try
            {
                var url = $"https://localhost:7181/obtenerClientes";
                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();

                    var cliente = JsonSerializer.Deserialize<List<Cliente>>(jsonString, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                        PropertyNameCaseInsensitive = true
                    });

                    var viewModel = cliente?.Select(c => new Cliente
                    {
                        IdCliente = c.IdCliente,
                        Nombre = c.Nombre
                    }).ToList() ?? new List<Cliente>();
                    return cliente!;
                }
                return new List<Cliente>();
            }
            catch (Exception ex)
            {
                retornoError.retornoErroresServicio(ex);
                return new List<Cliente>();
            }
        }

        public async Task<string> obtenerNombreCliente(int idCliente)
        {
            try
            {
                var url = $"https://localhost:7181/obtenerNombreCliente/{idCliente}";
                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();

                    return jsonString.ToString()!;
                }
                return null!;
            }
            catch (Exception ex)
            {
                retornoError.retornoErroresServicio(ex);
                return null!;
            }
        }
    }
}
