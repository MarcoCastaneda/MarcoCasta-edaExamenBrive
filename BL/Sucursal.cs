using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Sucursal
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.MCastanedaBriveContext context = new DL.MCastanedaBriveContext())
                {
                    var query = context.Sucursals.FromSqlRaw($"SucursalGetAll").ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Sucursal sucursal = new ML.Sucursal();



                            sucursal.IdSucursal = obj.IdSucursal;
                            sucursal.NombreSucursal = obj.NombreSucursal;
                            sucursal.Direccion = obj.Direccion;
                            sucursal.Telefono = obj.Telefono;




                            result.Objects.Add(sucursal);
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
        public static ML.Result Add(ML.Sucursal sucursal)
        {

            ML.Result result = new ML.Result();

            try
            {
                using (DL.MCastanedaBriveContext context = new DL.MCastanedaBriveContext())
                // using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    var query = context.Database.ExecuteSqlRaw($"SucursalAdd'{sucursal.NombreSucursal}','{sucursal.Direccion}','{sucursal.Telefono}'");
                    // string query = "UsuarioAdd";
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
        public static ML.Result GetById(int IdSucursal)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.MCastanedaBriveContext context = new DL.MCastanedaBriveContext())
                {
                    var obj = context.Sucursals.FromSqlRaw($"SucursalGetById {IdSucursal}").AsEnumerable().FirstOrDefault();

                    result.Objects = new List<object>();

                    if (obj != null)
                    {
                        ML.Sucursal sucursal = new ML.Sucursal();

                        sucursal.IdSucursal = obj.IdSucursal;
                        sucursal.NombreSucursal = obj.NombreSucursal;
                        sucursal.Direccion = obj.Direccion;
                        sucursal.Telefono = obj.Telefono;

                        result.Object = sucursal;

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio un error al realizar la consulta";
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
        public static ML.Result Delete(ML.Sucursal sucursal)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.MCastanedaBriveContext context = new DL.MCastanedaBriveContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"SucursalDelete {sucursal.IdSucursal}");

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







    }
}
