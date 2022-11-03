﻿using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;

namespace ApiPeliculasEFCore.Entidades
{
    public class Cine 
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        //[Precision(precision:9,scale:2)]
        public Point Ubicacion { get; set; }
        public CineOferta CineOferta { get; set; }
        public HashSet<SalaDeCine> SalaDeCines { get; set; }
        public CineDetalle CineDetalle { get; set; }
        public Direccion Direccion { get; set; }
    }
}
