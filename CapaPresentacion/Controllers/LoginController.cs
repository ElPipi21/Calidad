using CapaAplicacion.Servicio;
using CapaDominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapaPresentacion.Controllers
{
    public class LoginController : Controller
    {
        private ClienteServicio clienteServicio;

        public ActionResult Logout()
        {
            Session["cliente"] = null;
            return RedirectToAction("VerificarAcceso", "Login");
        }
        // GET: Login
        [HttpGet]
        public ActionResult VerificarAcceso(String msg)
        {
            ViewBag.mensaje = msg;
            return View();
        }
        [HttpPost]
        public ActionResult VerificarAcceso(FormCollection frm, String msg)
        {
            try
            {
                String cliente = frm["txtNombre"].ToString();
                String clave = frm["txtPassword"].ToString();
                Cliente cli = clienteServicio.verificarAcceso(cliente, clave);
                if(cli != null)
                {
                    Session["cliente"] = cli;
                    return RedirectToAction("Producto", "ListarProductos");
                }
                else
                {
                    return RedirectToAction("VerificarAcceso", new { msg = "¡Cliente o password no válido!" });
                }
            }
            catch (Exception)
            {

                return View();
            }
        }
    }
}