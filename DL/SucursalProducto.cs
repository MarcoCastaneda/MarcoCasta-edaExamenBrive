using System;
using System.Collections.Generic;

namespace DL
{
    public partial class SucursalProducto
    {
        public int IdSucursalProducto { get; set; }
        public int? IdSucursal { get; set; } 
        public string NombreSucursal { get; set; }
        public int? IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public int? Stock { get; set; }
        public decimal PrecioUnitario { get; set; }
        public string Imagen { get; set; }

        public virtual Producto? IdProductoNavigation { get; set; }
        public virtual Sucursal? IdSucursalNavigation { get; set; }
    }
}
