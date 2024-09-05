namespace Prueba_Estado_Cuenta_App.Error
{
    public class RetornoError
    {
        public void retornoErroresServicio(Exception ex)
        {
            string respuesta = "Se ha producido un error interno del servicio. Por favor, " +
                "comunicarse con el departamento de TI asignado. " + ex.Message + " | " + ex.InnerException;
            Exception exception = new Exception(respuesta);
            throw exception;
        }
    }
}
