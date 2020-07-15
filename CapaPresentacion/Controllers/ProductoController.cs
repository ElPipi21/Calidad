using CapaAplicacion.Servicio;
using CapaDominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapaPresentacion.Controllers
{
    public class ProductoController : Controller
    {
        private ProductoServicio productoServicio = new ProductoServicio();

        // GET: Producto
        public ActionResult ListarProductos()
        {
            List<Producto> listarProductos = productoServicio.listarProductos();
            return View(listarProductos);
        }
    }
}