using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BL
{
    public class Producto
    {

        public static ML.Result Add(ML.Producto producto)
        {

            ML.Result result = new ML.Result();

            try
            {
                using (DL.MCastanedaBriveContext context = new DL.MCastanedaBriveContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"ProductoAdd'{producto.Nombre}',{producto.Stock},{producto.PrecioUnitario},'{producto.Imagen}','{producto.Codigo}'");
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }

            catch (Exception ex)
            {


                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }




        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.MCastanedaBriveContext context = new DL.MCastanedaBriveContext())
                {
                    var query = context.Productos.FromSqlRaw($"productoGetAll").ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Producto producto = new ML.Producto();

                            producto = new ML.Producto();

                            producto.IdProducto = obj.IdProducto;
                            producto.Nombre = obj.NombreProducto;
                            producto.PrecioUnitario = obj.PrecioUnitario;
                            producto.Imagen = obj.Imagen;
                            producto.Codigo = obj.Codigo;

                            producto.Stock = obj.Stock.Value;




                            result.Objects.Add(producto);
                        }
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }


    }
}
