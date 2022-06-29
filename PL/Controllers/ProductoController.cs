using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class ProductoController : Controller
    {
        public ActionResult GetAll()
        {
            ML.Result result = BL.Producto.GetAll();
            ML.Producto producto = new ML.Producto();

            if (result.Correct)
            {
                producto.Productos = result.Objects;
            }


            return View(producto);
        }


        [HttpGet]
        public ActionResult Form(int? IdProducto)
        {

            ML.Producto producto = new ML.Producto();
            if (IdProducto == null)
            {
                return View(producto);
            }
            else
            {
                ML.Result result = new ML.Result();

                if (result.Correct)
                {

                }

            }
            return View(producto);
        }


        [HttpPost]
        public ActionResult Form(ML.Producto producto)
        {



            ML.Result result = new ML.Result();
            IFormFile file = Request.Form.Files["fuImage"];
            if (file != null)
            {
                byte[] ImagenBytes = ConvertToBytes(file);
                producto.Imagen = Convert.ToBase64String(ImagenBytes);
            }
            if (producto.IdProducto == 0)
            {
                result = BL.Producto.Add(producto);


                if (result.Correct)
                {
                    ViewBag.Mensaje = "El alumno se ha agregado";
                }
                else
                {
                    ViewBag.Mensaje = "El alumno NO se ha agregado";
                }
            }
            return PartialView("Modal");

        }
        public static byte[] ConvertToBytes(IFormFile imagen)
        {

            using var fileStream = imagen.OpenReadStream();

            byte[] bytes = new byte[fileStream.Length];
            fileStream.Read(bytes, 0, (int)fileStream.Length);

            return bytes;
        }
    }
}
