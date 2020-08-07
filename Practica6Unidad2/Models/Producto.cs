using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practica6Unidad2.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Descripcion{ get; set; }
        public string Tipo { get; set; }
        public double Precio { get; set; }

    }
}