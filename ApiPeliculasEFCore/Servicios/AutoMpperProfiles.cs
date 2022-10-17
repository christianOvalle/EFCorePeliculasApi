using ApiPeliculasEFCore.DtOs;
using ApiPeliculasEFCore.Entidades;
using AutoMapper;

namespace ApiPeliculasEFCore.Servicios
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Actor, ActorDTOs>();
            CreateMap<Cine, CineDTOs>()
                .ForMember(x => x.Latitud, c => c.MapFrom(prop => prop.Ubicacion.Y))
                .ForMember(x => x.Longitud, c => c.MapFrom(prop => prop.Ubicacion.X));
        }
    }
}
