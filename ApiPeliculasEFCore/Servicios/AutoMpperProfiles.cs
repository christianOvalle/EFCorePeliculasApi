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

            CreateMap<Genero, GeneroDTOs>();

            CreateMap<Pelicula, PeliculaDTOs>().ForMember(x => x.Cines, ent => ent.MapFrom(c => c.SalaDeCine.Select(s => s.Cine)))
                .ForMember(dto => dto.Actores, ent => ent.MapFrom(x => x.PeliculaActores.Select(pa => pa.Actor)));

        }
    }
}
