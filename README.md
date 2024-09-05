# Estado de cuentas (API y FrontEnd) - Documentación técnica.

Este es un proyecto para gestionar el estado de cuentas de los clientes, teniendo las funcionalidades para manejar cuentas bancarias, clientes, tarjeta, compras y pagos. Las tecnologías implementadas dentro de la API como también en el lado del Front son .NET con Entity Framework y SQL Server. Cabe recalcar que esta es una solución con dos proyectos uno dedicado al FrontEnd y el otro una API Rest para ser consumida.

TECNOLOGÍAS UTILIZDAS
- API
    * .NET 6
    * ASP.NET Core
    * Entity Framework
    * SQL Server(Base de datos)
    * Arquitectura REST

- FrontEnd
    * ASP.NET MVC
    * Bootstrap
 

INSTALACIÓN

  1- Descargar o clonar repositorio
  
    git clone https://github.com/edebol66/Prueba_Estado_Cuenta.git
    cd Prueba_Estado_Cuenta
  
  2- Correr el Script que se encuentra en el proyecto dentro de la carpeta Script SQL llamado: scriptEstadoCuenta.sql (Nota: Antes de correr el script colocar esta sentencia
   CREATE TABLE Estado_Cuenta, luego de haber realizado esto, continuar con el Script que se ha compartido)
  
  3- Inicializar la aplicación para poder hacer uso de ella.

USO
- API
  La API expone varios endpoint que interactuan con la base de datos; los cuales son:
    * Cliente
      - GET /obtenerNombreCliente/{idCliente} (Obtiene el nombre del cliente)
      - GET /obtenerClientes (Obtiene todos los nomrbes de los clientes con su respectivo identificador)

    * Cuenta
      - GET /obtenerSaldoActual/{idCliente} (Obtiene el saldo actual de la tarjeta)
      - GET /obtenerSaldoDisponible/{idCliente} (Obtiene el saldo disponible de la tarjeta)
      - GET /obtenerInteresBonificable/{idCliente} (Obtiene el interes bonificable de la tarjeta)
      - GET /obtenerCuotaMinima/{idCliente} (Obtiene la cuota mínima de la tarjeta)
      - GET /obtenerTotalPagarContado/{idCliente} (Obtiene la cuota total a pagar de contado de la tarjeta)
      - GET /obtenerTotalContadoIntereses/{idCliente} (Obtiene la cuota total a pagar de contado con intereses de la tarjeta)
     
    * Compra
      - GET /obtenerCompraMesActual/{idCliente} (Obtiene las compras realizadas en el mes actual)
      - GET /obtenerMontoMesAntAct/{idCliente} (Obtiene el monto de las compras del mes actual y el mes anterior)
      - GET /obtenerHistorial/{idCliente} (Obtiene el historial de compras y pagos realizados en los últimos 2 meses)
      - POST /agregarCompra (Realiza el proceso para agregar una compra a la tarjeta)

    * Pago
      - POST /agregarPago (Realiza el proceso para agregar una pago a la tarjeta)

    * Tarjeta
      - GET /ConsultarLimiteNumero/{idCliente} (Obtiene el límite y el número de la tarjeta de crédito)

  - FRONT END
     La aplicación MVC, expone algunas vistas para su interacción, las cuales son:
     * Vista clientes: Esta es la vista principal que aparece al iniciar la aplicación. Permite visualizar un listado de clientes y cada uno de ellos tiene la posibilida de redirigir hacia otras vistas por medio
       de botonoes. Las vistas a las que se puede redireccionar son: Estado Cuenta, Realizar Compra, Realizar Pago y Ver Historial.

     * Vista Estado Cuenta: En esta vista se puede visualizar la información específica del cliente en aspecto de tarjeta, transacción, saldos, total de compras, entre otros.
   
     * Vista Realizar compra: Permite realizar una compra adicionando los datos requeridos que se presentan en la pantalla.
   
     * Vista Realizar pago: Permite realizar un pago adicionando los datos requeridos que se presentan en la pantalla.
   
     * Vista Historial : Permite visualizar en una tabla los datos de los movimientos realizados en los últimos 2 meses, tanto de compras como de pagos.


