using Microsoft.AspNetCore.Mvc.ModelBinding;
namespace Prueba_Estado_Cuenta_API.MiddleWare
{
    public class ErrorHelper
    {
        protected ErrorHelper() { }

        public static ErrorHelper Intance()
        {
            return new ErrorHelper();
        }

        public static List<ModelErrors> getModelStateError(ModelStateDictionary model)
        {
            return model.Select(x => new ModelErrors()
            {
                campo = x.Key,
                Mensaje = (x.Value != null) ? x.Value.Errors.Select(y => y.ErrorMessage).ToList() : null,
            }).ToList();
        }

        public static ModelErrors GetModelStateErrors(string model)
        {
            return new ModelErrors()
            {
                campo = "",
                Mensaje = new List<string>
                {
                    model
                }
            };
        }

        public class ModelErrors
        {
            public string? campo { get; set; }
            public List<string>? Mensaje { get; set; }
        }
    }
}
