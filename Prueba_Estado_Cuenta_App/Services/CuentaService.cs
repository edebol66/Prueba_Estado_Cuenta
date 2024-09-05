using Prueba_Estado_Cuenta_App.Error;

namespace Prueba_Estado_Cuenta_App.Services
{
    public class CuentaService : ICuentaService
    {
        private readonly HttpClient _httpClient;
        RetornoError retornoErrores = new RetornoError();

        public CuentaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<double> obtenerSaldoActual(int idCliente)
        {
            try
            {
                var url = $"https://localhost:7181/obtenerSaldoActual/{idCliente}";
                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();

                    return double.Parse(jsonString);
                }
                return 0;
            }
            catch (Exception ex)
            {
                retornoErrores.retornoErroresServicio(ex);
                return 0;
            }
        }

        public async Task<string> obtenerSaldoDisponible(int idCliente)
        {
            try
            {
                var url = $"https://localhost:7181/obtenerSaldoDisponible/{idCliente}";
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
                retornoErrores.retornoErroresServicio(ex);
                return null!;
            }
        }

        public async Task<string> obtenerMontoInteresBonficable(int idCliente)
        {
            try
            {
                var url = $"https://localhost:7181/obtenerInteresBonificable/{idCliente}";
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
                retornoErrores.retornoErroresServicio(ex);
                return null!;
            }
        }

        public async Task<string> obtenerCuotaMinima(int idCliente)
        {
            try
            {
                var url = $"https://localhost:7181/obtenerCuotaMinima/{idCliente}";
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
                retornoErrores.retornoErroresServicio(ex);
                return null!;
            }
        }

        public async Task<string> obtenerContadoInteres(int idCliente)
        {
            try
            {
                var url = $"https://localhost:7181/obtenerTotalContadoIntereses/{idCliente}";
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
                retornoErrores.retornoErroresServicio(ex);
                return null!;
            }
        }

        public async Task<string> obtenerTotalPagar(int idCliente)
        {
            try
            {
                var url = $"https://localhost:7181/obtenerTotalPagarContado/{idCliente}";
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
                retornoErrores.retornoErroresServicio(ex);
                return null!;
            }
        }
    }
}
