using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class SucursalProducto : Controller
    {
        public ActionResult ProductosAsignados(int IdSucursal)
        {
            ML.Result result = new ML.Result();
            ML.SucursalProducto sucursalProducto = new ML.SucursalProducto();
            result = BL.SucursalProducto.GetProductosAsigando(IdSucursal);
            ML.Result resultalumno = BL.Sucursal.GetById(IdSucursal);
            sucursalProducto.SucursalProductos = result.Objects;
            sucursalProducto.Sucursal = ((ML.Sucursal)resultalumno.Object);
            return View(sucursalProducto);
        }

        public ActionResult GetAll()
        {
            ML.Result result = new ML.Result();
            ML.SucursalProducto sucursalProducto = new ML.SucursalProducto();

            result = BL.SucursalProducto.GetAll();
            sucursalProducto.SucursalProductos = result.Objects;

            return View(sucursalProducto);
        }
        [HttpGet]
        public ActionResult ProductoNoAsignados(int IdSucursal)
        {
            ML.Result result = BL.SucursalProducto.ProductosNoAsignados(IdSucursal);
            ML.SucursalProducto sucursalProducto = new ML.SucursalProducto();

            ML.Result resultProducto = BL.Sucursal.GetById(IdSucursal);

            sucursalProducto.SucursalProductos = result.Objects;
            sucursalProducto.Sucursal = ((ML.Sucursal)resultProducto.Object);

            return View(sucursalProducto);
        }

        [HttpPost]
        public ActionResult AgregarProductos(ML.SucursalProducto sucursalProducto)
        {
            ML.Result result = new ML.Result();
            if (sucursalProducto.ListaSucursales != null)
            {
                foreach (int IdProducto in sucursalProducto.ListaSucursales)
                {
                    ML.SucursalProducto sucursalProducto1 = new ML.SucursalProducto();

                    sucursalProducto1.Sucursal = new ML.Sucursal();
                    sucursalProducto1.Sucursal.IdSucursal = sucursalProducto.Sucursal.IdSucursal;

                    sucursalProducto1.Producto = new ML.Producto();
                    sucursalProducto1.Producto.IdProducto = (IdProducto);

                    ML.Result resul = BL.SucursalProducto.Add(sucursalProducto1);
                }
                result.Correct = true;
                ViewBag.Message = "Se ha actualizado";
                ViewBag.ProductosAsignados = true;
            }
            else
            {
                result.Correct = false;
            }
            return PartialView("modal");
        }

        public ActionResult Delete(int IdSucursalProducto, int IdSucursal)
        {
            ML.SucursalProducto sucursalProducto = new ML.SucursalProducto();
            sucursalProducto.IdSucursalProducto = IdSucursalProducto;
            ML.Result result = BL.SucursalProducto.Delete(sucursalProducto);

            

            if (result.Correct)
            {
                ViewBag.message = "Se ha eliminado exitosamente el registro";
            }
            else
            {
                ViewBag.message = "ocurrió un error al eliminar el registro " + result.ErrorMessage;

            }
            return PartialView("modal");
        }
    }
}

