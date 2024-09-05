using Microsoft.EntityFrameworkCore;
using Prueba_Estado_Cuenta_API.Models.Estado_Cuenta;
using Prueba_Estado_Cuenta_API.Models.DTO_Estado_Cuenta;
namespace Prueba_Estado_Cuenta_API.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly Estado_CuentaContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(Estado_CuentaContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public List<ObtenerClienteDTO> obtenerClientes()
        {
            var retornoClientes = (from c in _context.Clientes
                                   select new ObtenerClienteDTO
                                   {
                                       IdCliente = c.IdCliente,
                                       Nombre = c.Nombre + " " + c.Apellido
                                   }).ToList();
            return retornoClientes;
        }
        public void guardarDb(TEntity entidad) => _dbSet.Add(entidad);

        public void aplicarCambiosDb() => _context.SaveChanges();

        public async Task<TEntity> obtenerRegistroTabla(int id)
        {
            var entidad = await _dbSet.FindAsync(id);
            return entidad!;
        }

        public List<NumeroLimiteTarjeta> limiteNumeroTarjetaCredito(int idCliente)
        {
            var retornoDatosTarjeta = (from t in _context.Tarjeta
                                  join tt in _context.TipoTarjeta on t.IdTipoTarjeta equals tt.IdTipoTarjeta
                                  join cu in _context.Cuenta on t.IdCuenta equals cu.IdCuenta
                                  join ci in _context.Clientes on cu.IdCliente equals ci.IdCliente
                                  where ci.IdCliente == idCliente
                                  select new NumeroLimiteTarjeta
                                  {
                                      NumeroTarjeta = t.NumeroTarjeta,
                                      Limite = tt.Limite
                                  }).ToList();
            return retornoDatosTarjeta;
        }

        public List<CompraMesDTO> obtenerComprasMesActual(int idCliente)
        {
            var obtenerFechaActual = DateTime.Now;
            var inicioMes = new DateTime(obtenerFechaActual.Year, obtenerFechaActual.Month, 1);
            var finMes = inicioMes.AddMonths(1).AddDays(-1);

            var obtenerCompraMes = (from c in _context.Compras
                                    join cu in _context.Cuenta on c.IdCuenta equals cu.IdCuenta
                                    join cli in _context.Clientes on cu.IdCliente equals cli.IdCliente
                                    where c.FechaCompra >= inicioMes && c.FechaCompra <= finMes 
                                    && cli.IdCliente == idCliente
                                    select new CompraMesDTO
                                    {
                                        Monto = c.Monto,
                                        Descripcion = c.Descripcion,
                                        FechaCompra = c.FechaCompra
                                    }).ToList();

            return obtenerCompraMes;
        }

        public double obtenerMontoActualPasado(int idCliente)
        {
            var obtenerFechaActual = DateTime.Now;
            var inicioDiaMesAnterior = new DateTime(obtenerFechaActual.Year, obtenerFechaActual.Month, 1)
                .AddMonths(-1);
            var finDiaMesActual = new DateTime(obtenerFechaActual.Year, obtenerFechaActual.Month, 1)
                .AddMonths(1).AddDays(-1);

            var obtenerCompras = (from c in _context.Compras
                                  join cu in _context.Cuenta on c.IdCuenta equals cu.IdCuenta
                                  join cli in _context.Clientes on cu.IdCliente equals cli.IdCliente
                                  where c.FechaCompra >= inicioDiaMesAnterior && c.FechaCompra <= finDiaMesActual
                                  && cli.IdCliente == idCliente
                                  select c.Monto).Sum();
            return obtenerCompras;
        }

        public void realizarCompraActualizarSaldo(RequestAgregarCompra requestAgregarCompra)
        {
            _context.Database.ExecuteSqlInterpolated($@"EXEC realizarCompra 
            @idCliente={requestAgregarCompra.IdCliente},@monto={requestAgregarCompra.Monto},
            @descripcion={requestAgregarCompra.Descripcion},@fecha={requestAgregarCompra.FechaCompra}");
        }

        public void realizarPagoActualizarSaldo(RequestAgregarPagoDTO requestAgregarPagoDTO)
        {
            _context.Database.ExecuteSqlInterpolated($@"EXEC realizarPago
            @idCliente={requestAgregarPagoDTO.IdCliente},@monto={requestAgregarPagoDTO.Monto},
            @fecha={requestAgregarPagoDTO.FechaPago}");
        }

        public async Task<ConfiguracionPorcentaje> obtenerConfiguracionPorcentaje(string nombreConfig)
        {
            var obtenerConfiguracion = await _context.ConfiguracionPorcentajes
                .Where(x => x.NombreConfiguracion == nombreConfig).FirstOrDefaultAsync();
            return obtenerConfiguracion!;
        }

        public List<HistorialPagoComprasDTO> obtenerHistorialPagoCompras(int idCliente)
        {
            var obtenerFechaActual = DateTime.Now;
            var inicioMes = new DateTime(obtenerFechaActual.Year, obtenerFechaActual.Month, 1);
            var finMes = inicioMes.AddMonths(1).AddDays(-1);

            var obtenerCompraMes = (from c in _context.Compras
                                    join cu in _context.Cuenta on c.IdCuenta equals cu.IdCuenta
                                    join cli in _context.Clientes on cu.IdCliente equals cli.IdCliente
                                    where c.FechaCompra >=inicioMes && c.FechaCompra<=finMes &&
                                    cli.IdCliente == idCliente
                                    select new HistorialPagoComprasDTO
                                    {
                                        Tipo_Transaccion = "Compra",
                                        Descripcion = c.Descripcion,
                                        Monto = c.Monto,
                                        Fecha = c.FechaCompra
                                    }).ToList();
                                    
              var obtenerPagosMes =  (from p in _context.Pagos
                                     join cu in _context.Cuenta on p.IdCuenta equals cu.IdCuenta
                                     join cli in _context.Clientes on cu.IdCliente equals cli.IdCliente
                                     where p.FechaPago >= inicioMes && p.FechaPago<=finMes &&
                                     cli.IdCliente == idCliente
                                     select new HistorialPagoComprasDTO
                                     {
                                         Tipo_Transaccion = "Pago",
                                         Descripcion = " ",
                                         Monto = p.Monto,
                                         Fecha = p.FechaPago
                                     }).ToList();

            var historial = obtenerCompraMes.Union(obtenerPagosMes).OrderByDescending(t => t.Fecha).ToList();

            return historial;

        }

    }
}
