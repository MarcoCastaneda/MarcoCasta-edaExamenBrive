using System;
using System.Collections.Generic;

namespace DL
{
    public partial class Sucursal
    {
        public Sucursal()
        {
            SucursalProductos = new HashSet<SucursalProducto>();
        }

        public int IdSucursal { get; set; }
        public string? NombreSucursal { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }

        public virtual ICollection<SucursalProducto> SucursalProductos { get; set; }
    }
}
