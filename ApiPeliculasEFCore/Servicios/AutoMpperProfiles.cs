using ApiPeliculasEFCore.DtOs;
using ApiPeliculasEFCore.Entidades;
using AutoMapper;
using NetTopologySuite;
using NetTopologySuite.Geometries;

namespace ApiPeliculasEFCore.Servicios
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<GeneroActualizacionDTO, Genero>();

            CreateMap<Actor, ActorDTOs>();
            CreateMap<Cine, CineDTOs>()
                .ForMember(x => x.Latitud, c => c.MapFrom(prop => prop.Ubicacion.Y))
                .ForMember(x => x.Longitud, c => c.MapFrom(prop => prop.Ubicacion.X));

            CreateMap<Genero, GeneroDTOs>();

            CreateMap<Pelicula, PeliculaDTOs>().ForMember(x => x.Cines, ent => ent.MapFrom(c => c.SalaDeCine.Select(s => s.Cine)))
                .ForMember(dto => dto.Actores, ent => ent.MapFrom(x => x.PeliculaActores.Select(pa => pa.Actor)));

            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);

            CreateMap<CineCreacionDTO, Cine>()
                .ForMember(ent => ent.SalaDeCines, opciones => opciones.Ignore())
                .ForMember(ent => ent.Ubicacion, dto => dto.MapFrom(campo => geometryFactory.CreatePoint(new Coordinate(campo.Longitud, campo.Latitud))));

            CreateMap<CineOfertaCreacionDTO, CineOferta>();
            CreateMap<SalaDeCineCreacionDTO, SalaDeCine>();

            CreateMap<PeliculaCreacionDTO, Pelicula>().ForMember(x => x.Genero, dto => dto.MapFrom(x => x.Genero.Select(id => new Genero() { Id = id })))
                .ForMember(ent => ent.SalaDeCine, dto => dto.MapFrom(campo => campo.SalaDeCine.Select(id => new SalaDeCine() { Id = id })));

            CreateMap<PeliculaActorCreacionDTO, PeliculaActor>();

            CreateMap<ActorCreacionDTO, Actor>();
        }
    }
}
