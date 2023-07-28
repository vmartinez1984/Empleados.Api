using AutoMapper;
using Empleados.Api.Dtos;
using Empleados.Api.Models;
using System.Globalization;

namespace Empleados.Api.Helpers
{
    public class EmpleadosMapper: Profile
    {
        public EmpleadosMapper()
        {
            CreateMap<Departamento, DepartamentoDto>().ReverseMap();

            CreateMap<Empleado, EmpleadoDto>()
            .ForMember(
                destino => destino.DepartamentoNombre,
                opt => opt.MapFrom(origen => origen.Departamento.Nombre)
            )
            .ForMember(destino =>
                destino.FechaDeContrato,
                opt=> opt.MapFrom(origen=>origen.FechaDeContrato.ToString("dd/MM/yyyy"))
            );

            CreateMap<EmpleadoDto, Empleado>()
                .ForMember(destino => destino.Departamento, opt => opt.Ignore())
                .ForMember(
                    destino => destino.FechaDeContrato, 
                    opt => opt.MapFrom(origen=> DateTime.ParseExact(origen.FechaDeContrato, "dd/MM/yyyy",CultureInfo.InvariantCulture))
                );
        }
    }
}
