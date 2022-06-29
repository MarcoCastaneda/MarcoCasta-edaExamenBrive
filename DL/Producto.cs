using System;
using System.Collections.Generic;

namespace DL
{
    public partial class Producto
    {
        public Producto()
        {
            SucursalProductos = new HashSet<SucursalProducto>();
        }

        public int IdProducto { get; set; }
        public string? NombreProducto { get; set; }
        public string? Imagen { get; set; }
        public decimal PrecioUnitario { get; set; }
        public string Codigo { get; set; }
        public int? Stock { get; set; }

        public virtual ICollection<SucursalProducto> SucursalProductos { get; set; }
    }
}
