﻿using System.ComponentModel.DataAnnotations;

namespace ApiPeliculasEFCore.Entidades
{
    public class Factura
    {
        public int Id { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int NumeroFactura { get; set; }
        [Timestamp]
        public byte[] Version { get; set; }
    }
}
