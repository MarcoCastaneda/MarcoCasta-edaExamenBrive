
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class SucursalProducto

    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.MCastanedaBriveContext context = new DL.MCastanedaBriveContext())
                {
                    var query = context.SucursalProductos.FromSqlRaw($"SucursalProductoGetAll").ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.SucursalProducto sucursalProducto = new ML.SucursalProducto();
                            sucursalProducto.IdSucursalProducto = obj.IdSucursalProducto;

                            sucursalProducto.Sucursal = new ML.Sucursal();
                            sucursalProducto.Sucursal.IdSucursal = obj.IdSucursal.Value;
                            sucursalProducto.Sucursal.NombreSucursal = obj.NombreSucursal;

                            sucursalProducto.Producto = new ML.Producto();
                            sucursalProducto.Producto.IdProducto = obj.IdProducto.Value;
                            sucursalProducto.Producto.Nombre = obj.NombreProducto;



                            result.Objects.Add(sucursalProducto);
                        }
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


        public static ML.Result ProductosNoAsignados(int ListaSucursales)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.MCastanedaBriveContext context = new DL.MCastanedaBriveContext())
                {
                    var query = context.Productos.FromSqlRaw($"ProductosNoAsignados {ListaSucursales}").ToList();
                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.SucursalProducto sucursalProducto = new ML.SucursalProducto();


                            sucursalProducto.Producto = new ML.Producto();
                            sucursalProducto.Producto.IdProducto = obj.IdProducto;
                            sucursalProducto.Producto.Nombre = obj.NombreProducto;
                            sucursalProducto.Producto.Stock = obj.Stock.Value;

                            result.Objects.Add(sucursalProducto);
                            result.Correct = true;
                        }

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo realizar la consulta";
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
        public static ML.Result Delete(ML.SucursalProducto sucursalProducto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.MCastanedaBriveContext context = new DL.MCastanedaBriveContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"SucursalProductoDelete {sucursalProducto.IdSucursalProducto}");

                    if (query >= 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se ha podido realizar el delete";
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
        public static ML.Result GetProductosAsigando(int IdSucursal)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.MCastanedaBriveContext context = new DL.MCastanedaBriveContext())
                {
                    var query = context.SucursalProductos.FromSqlRaw($"ProductosAsignados {IdSucursal}").ToList();
                    result.Objects = new List<object>();

                    if (query != null)
                    {

                        foreach (var obj in query)
                        {
                            ML.SucursalProducto sucursalProducto = new ML.SucursalProducto();
                            sucursalProducto.IdSucursalProducto = obj.IdSucursalProducto;

                            sucursalProducto.Sucursal = new ML.Sucursal();
                            sucursalProducto.Sucursal.IdSucursal = obj.IdSucursal.Value;
                            sucursalProducto.Sucursal.NombreSucursal = obj.NombreSucursal;

                            sucursalProducto.Producto = new ML.Producto();
                            sucursalProducto.Producto.IdProducto = obj.IdProducto.Value;
                            sucursalProducto.Producto.Nombre = obj.NombreProducto;

                            result.Objects.Add(sucursalProducto);
                            result.Correct = true;
                        }
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo realizar la consulta";
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



        public static ML.Result Add(ML.SucursalProducto sucursalProducto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.MCastanedaBriveContext context = new DL.MCastanedaBriveContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"SucursalProductoAdd {sucursalProducto.Sucursal.IdSucursal}, {sucursalProducto.Producto.IdProducto}");
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se ha podido realizar el insert";
                    }
                    result.Correct = true;
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


