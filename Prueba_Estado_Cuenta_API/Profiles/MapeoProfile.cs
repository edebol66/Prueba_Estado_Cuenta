using AutoMapper;
using Prueba_Estado_Cuenta_API.Models.Estado_Cuenta;
using Prueba_Estado_Cuenta_API.Models.DTO_Estado_Cuenta;
namespace Prueba_Estado_Cuenta_API.Profiles
{
    public class MapeoProfile : Profile
    {
        public MapeoProfile()
        {
            CreateMap<(Tarjetum, TipoTarjetum), ResponseNumeroLimiteTarjeta>()
                .ForMember(dest => dest.NumeroTarjeta, opt => opt.MapFrom(prop => prop.Item1.NumeroTarjeta))
                .ForMember(dest => dest.Limite, opt => opt.MapFrom(prop => prop.Item2.Limite)).ReverseMap();

            CreateMap<(Tarjetum, TipoTarjetum,Cliente), NumeroLimiteTarjeta>()
                .ForMember(dest => dest.NumeroTarjeta, opt => opt.MapFrom(prop => prop.Item1.NumeroTarjeta))
                .ForMember(dest => dest.Limite, opt => opt.MapFrom(prop => prop.Item2.Limite)).ReverseMap();

            CreateMap<Compra, RequestAgregarCompra>().ReverseMap();

            CreateMap<Compra, HistorialPagoComprasDTO>().ReverseMap();
            CreateMap<Pago, HistorialPagoComprasDTO>().ReverseMap();
        }
    }
}
