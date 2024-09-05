using Newtonsoft.Json;
namespace Prueba_Estado_Cuenta_API.MiddleWare
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate requestDelegate, ILogger<ExceptionMiddleware> logger)
        {
            _requestDelegate = requestDelegate;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + " " + ex.StackTrace + " " + ex.InnerException);
                string mensajeError = "";
                mensajeError = "Error interno del servidor por excepción generada. " +
                    "Para más información comunicarse con el departamentode TI encargado";

                await HandleExceptionAsync(context, mensajeError);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, string mensaje)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 500;

            return context.Response.WriteAsync(JsonConvert.SerializeObject(new ErroresException()
            {
                Status = "Error interno del servidor",
                Message = mensaje
            }));
        }
    }
}
