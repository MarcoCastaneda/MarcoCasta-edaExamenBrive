using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class SucursalController : Controller
    {
        public ActionResult GetAll()
        {
            ML.Result result = BL.Sucursal.GetAll();
            ML.Sucursal sucursal = new ML.Sucursal();

            if (result.Correct)
            {
                sucursal.SUcursales = result.Objects;
            }


            return View(sucursal);
        }

        [HttpGet]
        public ActionResult Form(int? IdSucursal)
        {

            ML.Sucursal sucursal = new ML.Sucursal();
            if (IdSucursal == null)
            {
                return View(sucursal);
            }
            else
            {
                ML.Result result = new ML.Result();

                if (result.Correct)
                {

                }

            }
            return View(sucursal);
        }


        [HttpPost]
        public ActionResult Form(ML.Sucursal sucursal)
        {

            ML.Result result = new ML.Result();
            if (sucursal.IdSucursal == 0)
            {
                result = BL.Sucursal.Add(sucursal);


                if (result.Correct)
                {
                    ViewBag.Mensaje = "El alumno se ha agregado";
                }
                else
                {
                    ViewBag.Mensaje = "El alumno NO se ha agregado";
                }
            }
            //else
            //{
            //    result = BL.Alumno.Update(alumno);
            //    if (resultAlumno.Correct)
            //    {
            //        ViewBag.Mensaje = "El alumno se ha actualizado";
            //    }
            //    else
            //    {

            //        ViewBag.Mensaje = "El alumno NO se actualizo";
            //    }
            //}
            return PartialView("modal");
        }
        public ActionResult Delete(int Idsucursal)
        {
            ML.Sucursal sucursal = new ML.Sucursal();
            sucursal.IdSucursal = Idsucursal;
            ML.Result result = BL.Sucursal.Delete(sucursal);



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
