using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practica6Unidad2.Models;

namespace Practica6Unidad2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            RegistroProducto rp = new RegistroProducto();
            return View(rp.MostrarTodos());
        }

        public ActionResult Guardar() {
            return View();
        }

        [HttpPost]
        public ActionResult Guardar([Bind(Include ="Id,Descripcion,Tipo,Precio")] Producto prod) {
            RegistroProducto rp = new RegistroProducto();

            if (ModelState.IsValid)
            {
                rp.GrabarProducto(prod);
                return RedirectToAction("Index");
            }

            return View(prod);
        }

        public ActionResult Borrar(int cod) {
            RegistroProducto rp = new RegistroProducto();
            rp.Borrar(cod);
            return RedirectToAction("Index");
        }

        public ActionResult Modificar(int cod) {
            RegistroProducto rp = new RegistroProducto();
            Producto prod = new Producto();
            prod = rp.MostrarEspecifico(cod);
            return View(prod);
        }

        [HttpPost, ActionName("Modificar")]
        public ActionResult Modificar([Bind(Include ="Id,Descripcion,Tipo,Precio")] Producto prod){
            RegistroProducto rp = new RegistroProducto();
            if (ModelState.IsValid)
            {
                rp.Modificar(prod);
                return RedirectToAction("Index");
            }
            return View(prod);            
        }
    }
}