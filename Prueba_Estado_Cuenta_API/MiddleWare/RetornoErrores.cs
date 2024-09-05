namespace Prueba_Estado_Cuenta_API.MiddleWare
{
    public class RetornoErrores
    {
        public void retornoErroresServicio(Exception ex)
        {
            string respuesta = "Se ha producido un error interno del servicio. Por favor, " +
                "comunicarse con el departamento de TI asignado. " +ex.Message +" | "+ex.InnerException;
            Exception exception = new Exception(respuesta);
            throw exception;
        }

        public void retornoErrorControlador(Exception ex)
        {
            string respuesta = "Se ha producido un error en el servidor. Por favor, " +
                "intente realizar el proceso más tarde" +ex.Message + " | "+ex.StackTrace;
            Exception exception = new Exception(respuesta);
            throw exception;
        }
    }
}
