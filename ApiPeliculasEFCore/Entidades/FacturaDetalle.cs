﻿using Microsoft.EntityFrameworkCore;

namespace ApiPeliculasEFCore.Entidades
{
    public class FacturaDetalle
    {
        public int Id { get; set; }
        public int FacturaId { get; set; }
        public string Producto { get; set; }
        [Precision(18,2)]
        public decimal precio { get; set; }
        public int Cantidad{ get; set; }
        [Precision(18,2)]
        public decimal Total { get; set; }
    }
}
